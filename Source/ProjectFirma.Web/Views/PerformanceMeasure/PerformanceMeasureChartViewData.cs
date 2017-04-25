﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureChartViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public enum ChartViewMode
    {
        Small,
        Large,
        InfoSheet,
        ManagementMode,
        NoPopup

    }

    public class PerformanceMeasureChartViewData : FirmaUserControlViewData
    {
        private const int DefaultWidth = 500;
        private const int DefaultHeight = 350;
        public readonly Models.PerformanceMeasure PerformanceMeasure;
        public readonly int ChartWidth;
        public readonly int ChartHeight;
        public readonly bool HyperlinkPerformanceMeasureName;
        public readonly ChartViewMode ChartViewMode;
        public readonly Dictionary<string, GoogleChartJson> GoogleChartJsonDictionary;

        public readonly bool HasChartData;

        public PerformanceMeasureChartViewData(Models.PerformanceMeasure performanceMeasure, int width, int height, bool hyperlinkPerformanceMeasureName, ChartViewMode chartViewMode, List<int> projectIDs)
        {
            ChartWidth = width;
            ChartHeight = height;

            PerformanceMeasure = performanceMeasure;
            HyperlinkPerformanceMeasureName = hyperlinkPerformanceMeasureName;
            ChartViewMode = chartViewMode;

            GoogleChartJsonDictionary = performanceMeasure.GetGoogleChartJsonDictionary(projectIDs);
            foreach (var googleChartJson in GoogleChartJsonDictionary.Values)
            {
                googleChartJson.GoogleChartConfiguration.SetSize(ChartHeight, ChartWidth);
            }

            HasChartData = GoogleChartJsonDictionary.Values.Any(x => x.GoogleChartDataTable.GoogleChartRowCs.Any());
        }

        public PerformanceMeasureChartViewData(Models.PerformanceMeasure performanceMeasure, bool hyperlinkPerformanceMeasureName, ChartViewMode chartViewMode, List<int> projectIDs)
            : this(performanceMeasure, DefaultWidth, DefaultHeight, hyperlinkPerformanceMeasureName, chartViewMode, projectIDs)
        {
        }
    }
}
