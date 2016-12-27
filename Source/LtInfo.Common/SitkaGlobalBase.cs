using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.LoggingFilters;
using LtInfo.Common.Mvc;
using log4net.Config;
using LtInfo.Common.Views;

namespace LtInfo.Common
{
    public class ViewEngineLocations
    {
        public List<String> ViewLocations;
        public List<String> PartialViewLocations;
        public List<String> AreaViewLocations;
        public List<String> AreaPartialViewLocations;
    }

    public abstract class SitkaGlobalBase : SitkaHttpApplication
    {
        public const string CustomErrorMessageDivID = "customErrorMessageDiv";
        public const string CustomErrorMessageReplaceToken = "CUSTOM ERROR HERE";
        public const string CustomThrowErrorMessageForTesting = "This is a custom message that the user should be able to see!";
        public const string CustomNotAuthorizedErrorMessageForTesting = "This is a custom not authorized that the user should be able to see!";
        public const string CustomNotFoundMessageReplaceToken = "CUSTOM NOT FOUND HERE";
        public const string TestValidatedRequestFormField = "JunkField";

        public abstract string ErrorUrl { get; }
        public abstract string NotFoundUrl { get; }
        public abstract string ErrorHtml { get; }
        public abstract string NotFoundHtml { get; }

        public bool UseAreasInRoutes { get; set; }

        /// <summary>
        /// Pattern applied to <see cref="HttpRequest.Path"/> to set http headers to allow caching for static content. Adjust regex to match all that is considered cacheable content that is cacheable. Note <see cref="HttpRequest.Path"/> doesn't include the query string.
        /// </summary>
        private static readonly Regex CacheableContentRequestPathRegex = new Regex(@"^.*(asset\.axd)|(\.css)|(\.eot)|(\.gif)|(\.ico)|(\.jpg)|(\.js)|(\.pdf)|(\.png)|(\.svg)|(\.swf)|(\.ttf)|(\.woff)|(\.woff2)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        protected void ApplicationBeginRequest()
        {
            UnsupportedHttpMethodHandler.BeginRequestRespondToUnsupportedHttpMethodsWith405MethodNotAllowed(Request, Response);
            RedirectToCanonicalHostnameIfNeeded();
            Response.TrySkipIisCustomErrors = true;
        }

        /// <summary>
        /// If the URL doesn't match <see cref="SitkaWebConfiguration.CanonicalHostName"/> do a redirect. Otherwise do nothing. This is especially important for sites using SSL to get certificate to match up
        /// </summary>
        private void RedirectToCanonicalHostnameIfNeeded()
        {
            if (String.IsNullOrWhiteSpace(Request.Url.Host))
            {
                return;
            }

            var canonicalHostName = SitkaWebConfiguration.GetCanonicalHost(Request.Url.Host, true) ?? SitkaWebConfiguration.CanonicalHostName;

            // Check for hostname match (deliberately case-insensitive, DNS is case-insensitive and so is SSL Cert for common name) against the canonical host name as specified in the configuration
            if (!String.Equals(Request.Url.Host, canonicalHostName, StringComparison.InvariantCultureIgnoreCase))
            {

                var builder = new UriBuilder(Request.Url) { Host = canonicalHostName };
                var newUri = builder.Uri;

                // Signal this as a permanent redirect 301 HTTP status not 302 since we'd want to update bad URLs
                Response.RedirectPermanent(newUri.AbsoluteUri);
            }
        }

        /// <summary>
        /// List of <see cref="HttpStatusCode"/> settings that should be logged in case one slips by the <see cref="ApplicationError"/> trap
        /// </summary>
        private static readonly HashSet<HttpStatusCode> HttpStatusCodesThatShouldBeLogged = new HashSet<HttpStatusCode>
                                                                                             {
                                                                                                 HttpStatusCode.BadRequest,
                                                                                                 HttpStatusCode.Unauthorized,
                                                                                                 HttpStatusCode.PaymentRequired,
                                                                                                 HttpStatusCode.Forbidden,
                                                                                                 HttpStatusCode.MethodNotAllowed,
                                                                                                 HttpStatusCode.NotAcceptable,
                                                                                                 HttpStatusCode.ProxyAuthenticationRequired,
                                                                                                 HttpStatusCode.RequestTimeout,
                                                                                                 HttpStatusCode.Conflict,
                                                                                                 HttpStatusCode.Gone,
                                                                                                 HttpStatusCode.LengthRequired,
                                                                                                 HttpStatusCode.PreconditionFailed,
                                                                                                 HttpStatusCode.RequestEntityTooLarge,
                                                                                                 HttpStatusCode.RequestUriTooLong,
                                                                                                 HttpStatusCode.UnsupportedMediaType,
                                                                                                 HttpStatusCode.RequestedRangeNotSatisfiable,
                                                                                                 HttpStatusCode.ExpectationFailed,
                                                                                                 HttpStatusCode.InternalServerError,
                                                                                                 HttpStatusCode.NotImplemented,
                                                                                                 HttpStatusCode.BadGateway,
                                                                                                 HttpStatusCode.ServiceUnavailable,
                                                                                                 HttpStatusCode.GatewayTimeout,
                                                                                                 HttpStatusCode.HttpVersionNotSupported
                                                                                             };

        /// <summary>
        /// Add appropriate HTTP caching headers to get browser to round trip to server when using browser back button
        /// ASP.NET pages get the headers.
        /// * Static file types (.css, .gif, .ico, .jpg., .js, etc.) get whatever is configured in the <param name="cacheTimeForStaticContent" />
        /// * Dynamic file types get non caching headers as below:
        /// 
        /// Cache-Control: private, proxy-revalidate
        /// Pragma: no-cache
        /// Expires: Mon, 01 Jan 1990 00:00:00 GMT
        /// </summary>
        protected static void AddCachingHeaders(HttpResponse response, HttpRequest request, TimeSpan cacheTimeForStaticContent)
        {
            AddCachingHeaders(response, request, cacheTimeForStaticContent, false);
        }

        /// <summary>
        /// Overload providing caller the ability to override the caching regardless of the request path
        /// </summary>
        protected static void AddCachingHeaders(HttpResponse response, HttpRequest request, TimeSpan cacheTimeForStaticContent, bool overrideCache)
        {
            // If it's a request that matches content we'd like to allow for caching...
            if (!overrideCache && CacheableContentRequestPathRegex.IsMatch(request.Path))
            {
                // Set up caching headers
                // ----------------------

                // Expires: [some time from now]
                response.Cache.SetExpires(DateTime.Now.Add(cacheTimeForStaticContent));

                // Cache-Control: public
                response.Cache.SetCacheability(HttpCacheability.Public);

                // Cache-Control: proxy-revalidate
                response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                return;
            }

            // Otherwise set up non-caching headers
            // ------------------------------------

            // Code below is trying to setup http headers like these (included here to capture search attempts for these headers):
            //
            // Cache-Control: private, proxy-revalidate
            // Pragma: no-cache
            // Expires: Mon, 01 Jan 1990 00:00:00 GMT

            // Cache-Control: private
            response.Cache.SetCacheability(HttpCacheability.Private);

            // Cache-Control: proxy-revalidate
            response.Cache.SetRevalidation(HttpCacheRevalidation.ProxyCaches);

            // Pragma: no-cache
            // for our HTTP 1.0 friends
            response.AppendHeader("Pragma", "no-cache");

            // Expires: Mon, 01 Jan 1990 00:00:00 GMT
            response.Cache.SetExpires(DateTime.Parse("01 Jan 1990 00:00:00 GMT"));
        }

        protected void ApplicationStart(string appName, Version applicationVersion, DateTime dateCompiled, ReadOnlyCollection<MethodInfo> allControllerActionMethods)
        {
            ApplicationStart(appName, applicationVersion, dateCompiled, allControllerActionMethods, new List<string>(), null, new Dictionary<string, string>());
        }

        protected void ApplicationStart(string appName, Version applicationVersion, DateTime dateCompiled, ReadOnlyCollection<MethodInfo> allControllerActionMethods, List<string> sharedPartialViewLocations, List<SitkaRouteTableEntry> defaultRoutes, Dictionary<string, string> areasDictionary)
        {
            var viewLocations = new ViewEngineLocations { PartialViewLocations = sharedPartialViewLocations };
            ApplicationStart(appName, applicationVersion, dateCompiled, allControllerActionMethods, viewLocations, defaultRoutes, areasDictionary);
        }

        protected void ApplicationStart(string appName, Version applicationVersion, DateTime dateCompiled, ReadOnlyCollection<MethodInfo> allControllerActionMethods, ViewEngineLocations viewLocations, List<SitkaRouteTableEntry> defaultRoutes, Dictionary<string, string> areasDictionary)
        {
            // read the log4net configuration from the web.config file
            XmlConfigurator.Configure();

            Logger.InfoFormat("Application Start{0}{1} version: {2}{0}Compiled: {3:MM/dd/yyyy HH:mm:ss}{0}"
                               , Environment.NewLine
                               , appName
                               , applicationVersion
                               , dateCompiled
                );

            RouteTableBuilder.Build(allControllerActionMethods, defaultRoutes, areasDictionary);
            SetupCustomViewLocationsForTemplates(viewLocations, areasDictionary);
            ModelBinders.Binders.DefaultBinder = new SitkaDefaultModelBinder();
        }

        protected virtual void SetupCustomViewLocationsForTemplates(ViewEngineLocations viewEngineLocations, Dictionary<string, string> areasDictionary)
        {
            ViewEngines.Engines.Clear();

            if (viewEngineLocations != null)
            {
                var appSpecificEngine = new RazorViewEngine();

                if (viewEngineLocations.AreaViewLocations != null && viewEngineLocations.AreaViewLocations.Count > 0)
                {
                    appSpecificEngine.AreaViewLocationFormats = viewEngineLocations.AreaViewLocations.ToArray();
                }

                if (viewEngineLocations.AreaPartialViewLocations != null && viewEngineLocations.AreaPartialViewLocations.Count > 0)
                {
                    appSpecificEngine.AreaPartialViewLocationFormats = viewEngineLocations.AreaPartialViewLocations.ToArray();
                }

                if (viewEngineLocations.ViewLocations != null && viewEngineLocations.ViewLocations.Count > 0)
                {
                    appSpecificEngine.ViewLocationFormats = viewEngineLocations.ViewLocations.ToArray();
                }

                if (viewEngineLocations.PartialViewLocations != null && viewEngineLocations.PartialViewLocations.Count > 0)
                {
                    appSpecificEngine.PartialViewLocationFormats = viewEngineLocations.PartialViewLocations.ToArray();
                }

                // add the application specific formats first based on the policy that more specific matches should be found before general matches
                ViewEngines.Engines.Add(appSpecificEngine);
            }

            var extraPartialViewLoactions = new List<string> { "~/Views/{1}/{0}.cshtml", "~/Views/Shared/{0}.cshtml", "~/Views/SitkaCommon/{0}.cshtml" };
            if (areasDictionary.Any())
            {
                extraPartialViewLoactions.AddRange(areasDictionary.Keys.SelectMany(x => new List<string> {string.Format("~/Areas/{0}/Views/{{1}}/{{0}}.cshtml", x), string.Format("~/Areas/{0}/Views/Shared/{{0}}.cshtml", x)}));
            }

            var globalLocations = new RazorViewEngine
            {// In addition to the usual Root and "Shared" location, we add a "SitkaCommon" directory. This is where we put views coming from Sitka Common.
                PartialViewLocationFormats = extraPartialViewLoactions.ToArray()
            };

            ViewEngines.Engines.Add(globalLocations);
        }

        private ReadOnlyCollection<ISitkaLoggingFilter> _loggingFilters;
        private IEnumerable<ISitkaLoggingFilter> LoggingFilters
        {
            get { return _loggingFilters ?? (_loggingFilters = new ReadOnlyCollection<ISitkaLoggingFilter>(GetLoggingFilters())); }
        }

        private bool IsRequestExemptedFromLogging(SitkaRequestInfo requestInfo)
        {
            return LoggingFilters.Any(sitkaLoggingFilter => sitkaLoggingFilter.ShouldRequestBeFiltered(requestInfo));
        }

        protected virtual List<ISitkaLoggingFilter> GetLoggingFilters()
        {
            var filters = new List<ISitkaLoggingFilter> { new TrendMicroFilter(), new NotReferred404LoggingFilter(), new NagiosLoggingFilter(), new RequireSslLoggingFilter(), new UnsupportedHttpMethodHandler(), new RemoteHostClosedTheConnectionLoggingFilter() };
            return filters;
        }

        protected void ApplicationError()
        {
            string errorPageHtml;
            var httpStatusCode = (int)HttpStatusCode.InternalServerError;
            var lastStoredError = Server.GetLastError();
            var requestInfo = new SitkaRequestInfo(lastStoredError, HttpContext.Current);

            try
            {
                if (!IsRequestExemptedFromLogging(requestInfo))
                {
                    SitkaLogger.Instance.LogDetailedErrorMessage(requestInfo);
                }

                if (lastStoredError is HttpException)
                {
                    httpStatusCode = ((HttpException)lastStoredError).GetHttpCode();
                }

                if (lastStoredError is SitkaDisplayErrorExceptionWithHttpCode)
                {
                    httpStatusCode = (int)((SitkaDisplayErrorExceptionWithHttpCode)lastStoredError).HttpStatusCode;
                }

                if (httpStatusCode == (int)HttpStatusCode.NotFound || SitkaHttpRequestStorage.NotFoundStoredError != null)
                {
                    return; // we know that applicationend will spit out the not found error page to the client.
                }

                errorPageHtml = GetErrorPageHtml(Request.IsLocal, Request.Cookies.ToCookieCollection(Request.Url.Host), lastStoredError);
            }
            catch (Exception ex)
            {
                // Catch and log anything that goes wrong in this error handler, we don't let it escape so that it doesn't start the error handling over again
                SitkaLogger.Instance.LogDetailedErrorMessage(new Exception("Secondary exception occurred while trying to display error message.", ex));
                errorPageHtml = WrapExceptionDetailsInHtml(String.Format("Secondary exception occurred while trying to display error message, original error message lost.\r\nSecondary Exception Details:\r\n{0}", ex));
            }

            SendErrorResponseToBrowser(errorPageHtml, httpStatusCode);
            Server.ClearError();
        }

        public static string GetMissingPageHtml(CookieCollection cookies, string notFoundHtml)
        {
            // DO NOT pass the "ASP.NET_SessionId" cookie. It forces this request to block on obtaining write access to the user session, which our parent request currently holds. 
            var allCookiesExceptSessionCookie = CookieHelper.GetAllCookiesExceptSessionCookie(cookies);
            return HttpHelper.GetUrl(Instance.NotFoundUrl, allCookiesExceptSessionCookie).Replace(CustomNotFoundMessageReplaceToken, notFoundHtml);
        }

        private void SendErrorResponseToBrowser(string innerError, int httpStatusCode)
        {
            Response.Clear();
            if (Response.StatusCode != httpStatusCode)
            {
                Response.StatusCode = httpStatusCode;
            }
            Response.Write(innerError);
        }

        public string GetErrorPageHtml(bool isLocal, CookieCollection cookies, Exception getLastError)
        {
            try
            {
                var errorMessage = Instance.ErrorHtml;
                if (getLastError != null)
                {
                    var sitkaException = GetSitkaDisplayableExceptionIfAny(getLastError);
                    if (sitkaException != null)
                    {
                        errorMessage = sitkaException.Message;
                        if (SitkaHttpRequestStorage.ShouldHandleCustomErrors)
                        {
                            errorMessage = errorMessage.Replace("\n", "<br/>");
                        }
                    }
                    else if (isLocal)
                    {
                        errorMessage = string.Format("{0}\r\n{1}", errorMessage, WrapExceptionDetailsInHtml(getLastError.ToString()));
                    }
                }

                if (SitkaHttpRequestStorage.ShouldHandleCustomErrors && !IsThisHttpRequestForTheErrorTemplatePage())
                {
                    // DO NOT pass the "ASP.NET_SessionId" cookie. It forces this request to block on obtaining write access to the user session, which our parent request currently holds. 
                    var allCookiesExceptSessionCookie = CookieHelper.GetAllCookiesExceptSessionCookie(cookies);
                    var errorPage = HttpHelper.GetUrl(Instance.ErrorUrl, allCookiesExceptSessionCookie);
                    return errorPage.Replace(CustomErrorMessageReplaceToken, errorMessage);
                }

                return errorMessage;
            }
            catch (Exception ex)
            {
                // Catch and log anything that goes wrong in this error handler, we don't let it escape so that it doesn't start the error handling over again
                SitkaLogger.Instance.LogDetailedErrorMessage(ex);
                return WrapExceptionDetailsInHtml(String.Format("Secondary exception occurred while trying to display error message, original error message lost.\r\nSecondary Exception Details:\r\n{0}", ex));
            }
        }

        private bool IsThisHttpRequestForTheErrorTemplatePage()
        {
            // Sometimes we get urls like: /Error/Error.aspx?500;http://example.com/Home.mvc/Error
            // That means the error template page got a secondary error, so we don't want to continue trying to load the error template page
            var errorUri = new UriBuilder(Instance.ErrorUrl);
            var errorPath = errorUri.Path;
            if (Request.Url.PathAndQuery.Contains(errorPath, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            var errorUrlAbsolutePath = GeneralUtility.UrlToAbsolutePath(Instance.ErrorUrl);
            var potentialErrorUrlPaths = new List<string> { errorUrlAbsolutePath };
            var requestAbsolutePath = Request.Url.AbsolutePath;
            return potentialErrorUrlPaths.Contains(requestAbsolutePath, StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Wraps text into an html &lt;pre&gt; tag, including CSS formatting for good wrapping and does the Html Encoding also
        /// </summary>
        private static string WrapExceptionDetailsInHtml(string text)
        {
            return String.Format("<pre class=\"stackTrace\" style=\"white-space:pre-wrap;background-color:lightYellow;color:darkRed;padding:10px\">\r\n{0}\r\n</pre>", text.HtmlEncode());
        }

        private static SitkaDisplayErrorException GetSitkaDisplayableExceptionIfAny(Exception lastError)
        {
            if (lastError is SitkaDisplayErrorException)
            {
                return (SitkaDisplayErrorException)lastError;
            }

            if (lastError.InnerException == null)
            {
                return null;
            }

            return GetSitkaDisplayableExceptionIfAny(lastError.InnerException);
        }

        public static SitkaGlobalBase Instance
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return (SitkaGlobalBase)HttpContext.Current.ApplicationInstance;
                }

                throw new NullReferenceException("Cannot call SitkaGlobalBase.Instance when not under an Http Context!");
            }
        }

        public static ActionResult RequestValidationTestUrlImpl(HttpRequestBase request)
        {
            return new ContentResult { Content = request.Form[TestValidatedRequestFormField].HtmlEncode() };
        }

        /// <summary>
        /// HttpRequests that have the SOAPAction HTTP Header Field are web service calls.
        /// From the SOAP standard, <see cref="http://www.w3.org/TR/2000/NOTE-SOAP-20000508/#_Toc478383528" />, "An HTTP client MUST use this header field when issuing a SOAP HTTP Request."
        /// </summary>
        private static bool IsWebServiceHttpRequest(HttpRequest request)
        {
            return request.Headers.AllKeys.Any(x => String.Equals(x, "SOAPAction"));
        }

        protected void ApplicationEndRequest()
        {
            var responseStatusCode = (HttpStatusCode)Response.StatusCode;
            var lastError = Server.GetLastError();

            // Decide about logging the error or not
            // -------------------------------------
            if (HttpStatusCodesThatShouldBeLogged.Contains(responseStatusCode) && SitkaHttpRequestStorage.ShouldLogErrorFromApplicationEnd)
            {
                var requestInfo = new SitkaRequestInfo(lastError, HttpContext.Current);
                if (!IsRequestExemptedFromLogging(requestInfo))
                {
                    if (lastError == null && IsWebServiceHttpRequest(Request))
                    {
                        lastError = SitkaHttpRequestStorage.WcfStoredError;
                    }
                    SitkaLogger.Instance.LogDetailedErrorMessage(string.Format("Http Server is returning response status code \"{0}\" and error was not logged via the Application_Error method", Response.Status), lastError, Context);
                    if (lastError != null && lastError.InnerException != null)
                    {
                        SitkaLogger.Instance.LogDetailedErrorMessage(string.Format("Http Server is returning response status code \"{0}\" - Inner exception", Response.Status), lastError.InnerException, Context);
                    }
                }
            }

            // Send the NotFound page as needed
            // --------------------------------
            if (responseStatusCode == HttpStatusCode.NotFound || SitkaHttpRequestStorage.NotFoundStoredError != null)
            {
                var html = Instance.NotFoundHtml;
                if (SitkaHttpRequestStorage.NotFoundStoredError != null)
                {
                    html += string.Format("<p>{0}</p>", SitkaHttpRequestStorage.NotFoundStoredError.Message);
                    SitkaHttpRequestStorage.NotFoundStoredError = null;
                }
                var errorHtml = GetMissingPageHtml(Request.Cookies.ToCookieCollection(Request.Url.Host), html);
                SendErrorResponseToBrowser(errorHtml, (int)HttpStatusCode.NotFound);
            }

            // Release any resources needed only for this one http request, particularly any EntityFramework contexts or other IDisposable items
            SitkaHttpRequestStorage.DisposeItemsAndClearStore();
        }

        /// <summary>
        /// If your page is going to set a weird error status and you don't want it to log automatically, call this function
        /// </summary>
        public static void CancelErrorLoggingFromApplicationEnd()
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                SitkaHttpRequestStorage.ShouldLogErrorFromApplicationEnd = false;
            }
        }

        /// <summary>
        /// If your page is going to set a weird error status and you don't want it to log automatically, call this function
        /// </summary>
        public static void CancelCustomErrorHandling()
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                SitkaHttpRequestStorage.ShouldHandleCustomErrors = false;
            }
        }

        public string GetErrorContentWithoutThrowing(string message)
        {
            var errorException = new SitkaDisplayErrorException(message);
            var errorHtml = GetErrorPageHtml(Request.IsLocal, Request.Cookies.ToCookieCollection(Request.Url.Host), errorException);
            return errorHtml;
        }
    }
}