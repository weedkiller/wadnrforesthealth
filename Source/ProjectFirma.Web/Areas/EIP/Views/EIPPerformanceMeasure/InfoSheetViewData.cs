﻿using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.EIPPerformanceMeasure
{
    public class InfoSheetViewData : EIPViewData
    {
        public readonly Models.EIPPerformanceMeasure EIPPerformanceMeasure;
        public readonly bool HasReportedValues;
        public readonly List<KeyValuePair<Models.Program, bool>> EIPPerformanceMeasurePrograms;
        public readonly IndicatorChartViewData IndicatorChartViewData;
        public readonly string IndexUrl;
        
        public InfoSheetViewData(Person currentPerson, Models.EIPPerformanceMeasure eipPerformanceMeasure, IndicatorChartViewData indicatorChartViewData)
            : base(currentPerson)
        {
            EIPPerformanceMeasure = eipPerformanceMeasure;
            HtmlPageTitle = string.Format("PM {0}", eipPerformanceMeasure.EIPPerformanceMeasureID);
            EntityName = "Performance Measure";
            BreadCrumbTitle = "Info Sheet";

            HasReportedValues = eipPerformanceMeasure.EIPPerformanceMeasureActuals.Any();
            EIPPerformanceMeasurePrograms = eipPerformanceMeasure.GetPrograms().OrderBy(x => x.Key.DisplayName).ToList();
            IndicatorChartViewData = indicatorChartViewData;

            IndexUrl = SitkaRoute<EIPPerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
        }
    }
}