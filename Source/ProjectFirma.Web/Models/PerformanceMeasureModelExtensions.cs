using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this PerformanceMeasure performanceMeasure)
        {
            return UrlTemplate.MakeHrefString(performanceMeasure.GetSummaryUrl(), performanceMeasure.PerformanceMeasureDisplayName);
        }

        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetSummaryUrl(this PerformanceMeasure performanceMeasure)
        {
            return SummaryUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        public static readonly UrlTemplate<int> InfoSheetUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.InfoSheet(UrlTemplate.Parameter1Int)));
        public static string GetInfoSheetUrl(this PerformanceMeasure performanceMeasure)
        {
            return InfoSheetUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        public static HtmlString GetDisplayNameAsInfoSheetUrl(this PerformanceMeasure performanceMeasure)
        {
            string infoSheetUrl = string.Empty;
            if (performanceMeasure != null)
            {
                infoSheetUrl = performanceMeasure.GetInfoSheetUrl();
            }
            return UrlTemplate.MakeHrefString(infoSheetUrl, performanceMeasure.PerformanceMeasureDisplayName);
        }

        private static readonly UrlTemplate<int> DefinitionAndGuidanceUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.DefinitionAndGuidance(UrlTemplate.Parameter1Int)));
        public static string GetDefinitionAndGuidanceUrl(this PerformanceMeasure performanceMeasure)
        {
            return DefinitionAndGuidanceUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        public static string GetEditReportedValuesUrl(this PerformanceMeasure performanceMeasure)
        {
            if (performanceMeasure != null)
            {
                return null;
            }
            throw new NotImplementedException("PerformanceMeasure {0} is not reported in the Project Tracker!  No way to edit reported values!");
        }

        public static bool IsPerformanceMeasureDisplayNameUnique(IEnumerable<PerformanceMeasure> performanceMeasures, string performanceMeasureDisplayName, int currentPerformanceMeasureID)
        {
            var performanceMeasure =
                performanceMeasures.SingleOrDefault(
                    x => x.PerformanceMeasureID != currentPerformanceMeasureID && string.Equals(x.PerformanceMeasureDisplayName, performanceMeasureDisplayName, StringComparison.InvariantCultureIgnoreCase));
            return performanceMeasure == null;
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.DeletePerformanceMeasure(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this PerformanceMeasure performanceMeasure)
        {
            return DeleteUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }
    }
}