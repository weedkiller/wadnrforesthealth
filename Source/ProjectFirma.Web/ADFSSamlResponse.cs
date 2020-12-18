using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Security.Cryptography.Xml;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjectFirma.Web
{
    // ReSharper disable once InconsistentNaming
    public class AdfsSamlResponse
    {
        private string _originalDecodedResponse;
        private const string BaseAttributeStatementXPath = "/samlp:Response/saml:EncryptedAssertion/saml:Assertion/saml:AttributeStatement";
        private XmlDocument _xmlDoc;
        private XmlNamespaceManager _xmlNameSpaceManager; //we need this one to run our XPath queries on the SAML XML

        public void LoadXmlFromBase64(string base64AdfsSamlResponse)
        {
            var utf8Encoding = new System.Text.UTF8Encoding();
            var xmlStringAdfsSamlResponse = utf8Encoding.GetString(Convert.FromBase64String(base64AdfsSamlResponse));
            LoadFromString(xmlStringAdfsSamlResponse);
        }

        public void LoadFromString(string xmlStringAdfsSamlResponse)
        {
            _originalDecodedResponse = xmlStringAdfsSamlResponse;
            _xmlDoc = new XmlDocument {PreserveWhitespace = true, XmlResolver = null};
            _xmlDoc.LoadXml(xmlStringAdfsSamlResponse);
            _xmlNameSpaceManager = GetNamespaceManager(_xmlDoc); //lets construct a "manager" for XPath queries
        }

        public void Decrypt()
        {
            /* first step: make sure encrypted xml contains all these items.
             * EncryptedKey                (present in many documents)
             *   EncryptionMethod          (present in many documents)
             *     KeyInfo                 (absent in some documents)
             *       X509Data                 ditto
             *         X509Certificate        ditto with x.509 cert in Base4
             *  
             * because that's the way dotnet EncryptedXML figures out
             * under the covers which key to use to decode the document,
             * bless its pointed little head.  */

            /* handle the decrypt */
            var encryptedXml = new EncryptedXml(_xmlDoc);
            encryptedXml.DecryptDocument();
        }

        /// <summary>
        /// decrypt a document with the specified key
        /// </summary>
        /// <param name="docin">encrypted document</param>
        /// <param name="key">the key pair</param>
        /// <returns>the decrypted document</returns>
        public static XmlDocument DecryptDocument(XmlDocument docin, X509Certificate2 key, StringBuilder log = null)
        {
            /* first step: make sure encrypted xml contains all these items.
             * EncryptedKey                (present in many documents)
             *   EncryptionMethod          (present in many documents)
             *     KeyInfo                 (absent in some documents)
             *       X509Data                 ditto
             *         X509Certificate        ditto with x.509 cert in Base4
             *  
             * because that's the way dotnet EncryptedXML figures out
             * under the covers which key to use to decode the document,
             * bless its pointed little head.  */

            var encryptedKey = GetFirstNodeByTagName(docin, @"EncryptedKey");
            if (null == encryptedKey)
            {
                /* not an encrypted document, give it right back. */
                return docin;
            }
            /* leave the input document unchanged, manipulate a copy */
            var doc = (XmlDocument)docin.Clone();

            encryptedKey = GetFirstNodeByTagName(doc, @"EncryptedKey");
            if (null == encryptedKey)
            {
                if (null != log)
                    log.Append("No encryption key in document").AppendLine();
                return docin;
            }

            var encryptionMethod = GetFirstNodeByTagName(doc, @"EncryptionMethod");
            if (null == encryptionMethod)
            {
                if (null != log)
                    log.Append("No key encryption method in document").AppendLine();
                return docin;
            }

            /*create required stanza of XML based on our public key */
            const string keynamespace = SignedXml.XmlDsigNamespaceUrl;
            XmlNode ki = doc.CreateElement(null, @"KeyInfo", keynamespace);
            XmlNode xd = doc.CreateElement(null, @"X509Data", keynamespace);
            XmlNode xc = doc.CreateElement(null, @"X509Certificate", keynamespace);
            xc.InnerText = Convert.ToBase64String(key.Export(X509ContentType.Cert));

            /* insert it into the received document */
            xd.AppendChild(xc);
            ki.AppendChild(xd);
            encryptedKey.InsertAfter(ki, encryptionMethod);
            if (null != log) log.Append("Adding KeyInfo data to encrypted document").AppendLine();

            /* handle the decrypt */
            try
            {
                var exml = new EncryptedXml(doc);
                exml.DecryptDocument();
            }
            catch (CryptographicException cre)
            {
                if (null != log) log.Append(cre.Message).AppendLine();
            }
            return doc;
        }

        private static XmlNode GetFirstNodeByTagName(XmlDocument docin, string localName)
        {
            var nodeList = docin.GetElementsByTagName(localName);
            var item = nodeList.Count > 0 ? nodeList[0] : null;
            return item;
        }


        public string GetFirstName()
        {
            var node = _xmlDoc.SelectSingleNode($"{BaseAttributeStatementXPath}/saml:Attribute[@Name=\'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/firstname\']/saml:AttributeValue", _xmlNameSpaceManager);
            return node?.InnerText;
        }

        public string GetLastName()
        {
            var node = _xmlDoc.SelectSingleNode($"{BaseAttributeStatementXPath}/saml:Attribute[@Name='http://schemas.xmlsoap.org/ws/2005/05/identity/claims/lastname']/saml:AttributeValue", _xmlNameSpaceManager);
            return node?.InnerText;
        }

        public string GetEmail()
        {
            var node = _xmlDoc.SelectSingleNode($"{BaseAttributeStatementXPath}/saml:Attribute[@Name='http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress']/saml:AttributeValue", _xmlNameSpaceManager);
            return node?.InnerText;
        }

        public List<string> GetRoleGroups()
        {
            var nodes = _xmlDoc.SelectNodes($"{BaseAttributeStatementXPath}/saml:Attribute[@Name='http://schemas.xmlsoap.org/claims/Group']/saml:AttributeValue", _xmlNameSpaceManager);
            if (nodes != null && nodes.Count > 0)
            {
                return nodes.Cast<XmlNode>().Select(x => x.InnerText).ToList();
            }
            return new List<string>();
        }

        //returns namespace manager, we need one b/c MS says so... Otherwise XPath doesn't work in an XML doc with namespaces
        //see https://stackoverflow.com/questions/7178111/why-is-xmlnamespacemanager-necessary
        private static XmlNamespaceManager GetNamespaceManager(XmlDocument xmlDocument)
        {
            var manager = new XmlNamespaceManager(xmlDocument.NameTable);
            manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
            manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");
            return manager;
        }

        public string GetSamlAsPrettyPrintXml()
        {
            try
            {
                var stringWriter = new StringWriter();
                var xmlTextWriter = new XmlTextWriter(stringWriter);
                xmlTextWriter.Formatting = Formatting.Indented;
                _xmlDoc.WriteTo(xmlTextWriter);

                return stringWriter.ToString();
            }
            catch (Exception e)
            {
                // At least show something if we have problems here
                return $"Problem pretty printing XML: {e.Message}. Original ADFS Response: {_originalDecodedResponse}";
            }
        }

    }
}
