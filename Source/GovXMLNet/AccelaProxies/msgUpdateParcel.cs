﻿// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="UpdateParcel">
	  <xsd:complexContent>
		<xsd:extension base="OperationRequest">
		  <xsd:sequence>
			<xsd:element ref="Parcel"/>
		  </xsd:sequence>
		</xsd:extension>
	  </xsd:complexContent>
	</xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class msgUpdateParcel : clsOperationRequest
    {
        // Members
        public clsParcel Parcel { get; set; }

        // Constructors
        public msgUpdateParcel()
        {
        }
    }
}
