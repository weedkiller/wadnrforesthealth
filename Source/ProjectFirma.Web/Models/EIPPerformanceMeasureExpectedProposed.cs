﻿using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class EIPPerformanceMeasureExpectedProposed : IAuditableEntity, IEIPPerformanceMeasureValue
    {
        public string ExpectedValueDisplay
        {
            get { return GetExpectedValueDisplay(ExpectedValue, EIPPerformanceMeasure); }
        }

        private static string GetExpectedValueDisplay(double? expectedValue, EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return eipPerformanceMeasure.Indicator.MeasurementUnitType.DisplayValue(expectedValue);
        }

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.ProposedProjects.Find(ProposedProjectID);
                var eipPerformanceMeasure = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasures.Find(EIPPerformanceMeasureID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var eipPerformanceMeasureName = eipPerformanceMeasure != null ? eipPerformanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                var expectedValue = GetExpectedValueDisplay(ExpectedValue, eipPerformanceMeasure);
                return String.Format("Proposed Project: {0}, Performance Measure: {1}, Expected Value: {2}", projectName, eipPerformanceMeasureName, expectedValue);
            }
        }

        public string IndicatorSubcategoriesAsString
        {
            get
            {
                return EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Any()
                    ? String.Join(", ",
                        EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.OrderBy(x => x.IndicatorSubcategory.IndicatorSubcategoryDisplayName)
                            .Select(x => String.Format("[{0}: {1}]", x.IndicatorSubcategory.IndicatorSubcategoryDisplayName, x.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName)))
                    : ViewUtilities.NoneString;
            }
        }

        public List<IEIPPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions
        {
            get { return new List<IEIPPerformanceMeasureValueSubcategoryOption>(EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.ToList()); }
        }
        public double? ReportedValue
        {
            get { return ExpectedValue; }
        }
    }
}