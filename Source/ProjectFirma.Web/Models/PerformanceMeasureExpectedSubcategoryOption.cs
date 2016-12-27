﻿using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureExpectedSubcategoryOption : IAuditableEntity, IPerformanceMeasureValueSubcategoryOption
    {
        public string AuditDescriptionString
        {
            get
            {
                var performanceMeasureSubcategoryOption = HttpRequestStorage.DatabaseEntities.PerformanceMeasureSubcategoryOptions.Find(PerformanceMeasureSubcategoryOptionID);
                var performanceMeasureSubcategory = HttpRequestStorage.DatabaseEntities.PerformanceMeasureSubcategories.Find(PerformanceMeasureSubcategoryID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Find(PerformanceMeasureID);
                var performanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOption != null ? performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : ViewUtilities.NotFoundString;
                var performanceMeasureSubcategoryName = performanceMeasureSubcategory != null ? performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.DisplayName : ViewUtilities.NotFoundString;
                return string.Format("Performance Measure: {0}, Subcategory: {1}, Subcategory Option: {2}", performanceMeasureName, performanceMeasureSubcategoryName, performanceMeasureSubcategoryOptionName);
            }
        }
    }
}