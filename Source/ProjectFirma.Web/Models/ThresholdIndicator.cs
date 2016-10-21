﻿using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public partial class ThresholdIndicator : IAuditableEntity, IIndicatorWithOnlyOneSubcategoryAndNotReportedInEIP
    {
        public string AuditDescriptionString
        {
            get { return Indicator.IndicatorDisplayName; }
            
        }

        public IndicatorSubcategory IndicatorSubcategory
        {
            get
            {
                Check.Require(IndicatorSubcategories.Count == 1, string.Format("Indicator {0} is a non-EIP Indicator!  Non-EIP Indicators can only have 1 subcategory but this indicator has  {1}!", Indicator.IndicatorDisplayName, IndicatorSubcategories.Count));
                return IndicatorSubcategories.Single();
            }
        }

        public List<IIndicatorReportingPeriod> GetIndicatorReportingPeriods()
        {
            return new List<IIndicatorReportingPeriod>(ThresholdIndicatorReportingPeriods);
        }

        public List<IIndicatorReported> GetIndicatorReportedValues()
        {
            return new List<IIndicatorReported>(ThresholdIndicatorReporteds);
        }

        public string GetChartPopupUrl()
        {
            return ThresholdIndicatorModelExtensions.GetChartPopupUrl(this);
        }

        public bool IsManagementOrPolicyStatement
        {
            get { return ThresholdStandardType == ThresholdStandardType.Management || ThresholdStandardType == ThresholdStandardType.PolicyStatement; }
        }

        public string FullDisplayName
        {
            get { return string.Format("{0} - {1} - {2}", ThresholdReportingCategory.ThresholdCategory.DisplayName, ThresholdReportingCategory.DisplayName, Indicator.IndicatorDisplayName); }
        }
    }
}