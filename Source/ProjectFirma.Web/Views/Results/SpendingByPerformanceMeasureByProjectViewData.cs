﻿using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByPerformanceMeasureByProjectViewData : FirmaViewData
    {        
        public readonly Models.PerformanceMeasure SelectedPerformanceMeasure;
        public readonly List<Models.PerformanceMeasure> PerformanceMeasures;
        public readonly string SpendingByPerformanceMeasureByProjectUrl;

        public readonly PerformanceMeasureChartViewData PerformanceMeasureChartViewData;
        
        public readonly SpendingByPerformanceMeasureByProjectGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public SpendingByPerformanceMeasureByProjectViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            List<Models.PerformanceMeasure> performanceMeasures,
            Models.PerformanceMeasure selectedPerformanceMeasure,
            PerformanceMeasureChartViewData performanceMeasureChartViewData) : base(currentPerson, firmaPage)
        {
            PageTitle = "Spending by Project for Selected Performance Measure";

            PerformanceMeasures = performanceMeasures;
            SelectedPerformanceMeasure = selectedPerformanceMeasure;
            PerformanceMeasureChartViewData = performanceMeasureChartViewData;

            SpendingByPerformanceMeasureByProjectUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByPerformanceMeasureByProject(UrlTemplate.Parameter1Int));

            GridSpec = new SpendingByPerformanceMeasureByProjectGridSpec(SelectedPerformanceMeasure)
            {
                ObjectNameSingular = string.Format("record by PM {0}: {1}", SelectedPerformanceMeasure.PerformanceMeasureID, SelectedPerformanceMeasure.DisplayNameNoNumber),
                ObjectNamePlural = string.Format("records by PM {0}: {1}", SelectedPerformanceMeasure.PerformanceMeasureID, SelectedPerformanceMeasure.DisplayNameNoNumber),
                SaveFiltersInCookie = true
            };

            GridName = "projectFundingSourceExpendituresBySectorGrid";
            GridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByPerformanceMeasureByProjectGridJsonData(selectedPerformanceMeasure.PerformanceMeasureID));
        }
    }
}