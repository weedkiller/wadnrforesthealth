﻿/*-----------------------------------------------------------------------
<copyright file="SpendingByPerformanceMeasureByProjectGridSpec.cs" company="Tahoe Regional Planning Agency">
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
using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using Microsoft.Ajax.Utilities;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByPerformanceMeasureByProjectGridSpec : GridSpec<PerformanceMeasureSubcategoriesTotalReportedValue>
    {
        public SpendingByPerformanceMeasureByProjectGridSpec(Models.PerformanceMeasure performanceMeasure)
        {
            Add(Models.FieldDefinition.Project.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.ProjectUrl, a.ProjectName), 350, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            foreach (var performanceMeasureSubcategory in performanceMeasure.PerformanceMeasureSubcategories.OrderBy(x => x.PerformanceMeasureSubcategoryDisplayName))
            {
                Add(performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName,
                    a =>
                    {
                        var performanceMeasureActualSubcategoryOption =
                            a.PerformanceMeasureActualSubcategoryOptions.SingleOrDefault(x => x.PerformanceMeasureSubcategoryID == performanceMeasureSubcategory.PerformanceMeasureSubcategoryID);
                        if (performanceMeasureActualSubcategoryOption != null)
                        {
                            return performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                        }
                        return string.Empty;
                    },
                    120,
                    DhtmlxGridColumnFilterType.SelectFilterStrict);
            }

            var reportedValueColumnName = string.Format("{0} ({1})",
                Models.FieldDefinition.ReportedValue.ToGridHeaderString(),
                performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName);

            Add(reportedValueColumnName, a => a.TotalReportedValue, 150, DhtmlxGridColumnFormatType.Decimal, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.ReportedExpenditure.ToGridHeaderString(), x => x.CalculateWeightedTotalExpenditure(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);

            var reportedValueUnitCostColumnName = string.Format("Estimated Cost Per {0} ", performanceMeasure.MeasurementUnitType.SingularDisplayName);
            Add(reportedValueUnitCostColumnName, a => a.CalculateWeightedTotalExpenditurePerPerformanceMeasure(), 100, DhtmlxGridColumnFormatType.Currency);

            Add(string.Format("Other Reported {0}", MultiTenantHelpers.GetPerformanceMeasureNamePluralized()),
                a =>
                {
                    var reportedPerformanceMeasures = a.Project.GetReportedPerformanceMeasures().Where(x => a.PerformanceMeasureID != x.PerformanceMeasure.PerformanceMeasureID).ToList();
                    var htmlStrings = reportedPerformanceMeasures.DistinctBy(x => x.PerformanceMeasureID).Select(x => UrlTemplate.MakeHrefString(x.PerformanceMeasure.GetSummaryUrl(), x.PerformanceMeasure.PerformanceMeasureID.ToString())).ToList();
                    return new HtmlString(string.Join(", ", htmlStrings));
                },
             200,
             DhtmlxGridColumnFilterType.Html);

            Add(Models.FieldDefinition.Region.ToGridHeaderString(), a => a.Project.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            //Add("State", a => a.Project.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            //Add("Jurisdiction", a => a.Project.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            //Add("Watershed", a => a.Project.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
        }
    }
}
