﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class ConfigureAccomplishmentsDashboardViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [DisplayName("Accomplishments Button Text")]
        public HtmlString AccomplishmentsButtonTextHtmlString { get; set; }

        [Required]
        [DisplayName("Expenditures Button Text")]
        public HtmlString ExpendituresButtonTextHtmlString { get; set; }

        [Required]
        [DisplayName("Organizations Button Text")]
        public HtmlString OrganizationsButtonTextHtmlString { get; set; }

        [Required]
        [DisplayName("Funding report should include?")]
        public int? FundingDisplayTypeID { get; set; }

        [Required]
        [DisplayName("Include Reporting Organization in Accomplishments Dashboard?")]
        public bool? IncludeReportingOrganizationType { get; set; }

        public ConfigureAccomplishmentsDashboardViewModel()
        {
        }

        public ConfigureAccomplishmentsDashboardViewModel(TenantAttribute tenantAttribute)
        {
            AccomplishmentsButtonTextHtmlString =
                tenantAttribute.AccomplishmentsDashboardAccomplishmentsButtonTextHtmlString;
            ExpendituresButtonTextHtmlString =
                tenantAttribute.AccomplishmentsDashboardExpendituresButtonTextHtmlString;
            OrganizationsButtonTextHtmlString =
                tenantAttribute.AccomplishmentsDashboardOrganizationsButtonTextHtmlString;
            FundingDisplayTypeID =
                tenantAttribute.AccomplishmentsDashboardFundingDisplayTypeID;
            IncludeReportingOrganizationType = tenantAttribute.AccomplishmentsDashboardIncludeReportingOrganizationType;
        }

        public void UpdateModel()
        {
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            tenantAttribute.AccomplishmentsDashboardAccomplishmentsButtonTextHtmlString =
                AccomplishmentsButtonTextHtmlString;
            tenantAttribute.AccomplishmentsDashboardExpendituresButtonTextHtmlString =
                ExpendituresButtonTextHtmlString;
            tenantAttribute.AccomplishmentsDashboardOrganizationsButtonTextHtmlString =
                OrganizationsButtonTextHtmlString;
            tenantAttribute.AccomplishmentsDashboardFundingDisplayTypeID =
                FundingDisplayTypeID ??
                ModelObjectHelpers.NotYetAssignedID; // Should never be null due to Required validation
            tenantAttribute.AccomplishmentsDashboardIncludeReportingOrganizationType =
                IncludeReportingOrganizationType ?? false; // Should never be null due to Required validation
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (AccomplishmentsDashboardFundingDisplayType.All.All(x =>
                x.AccomplishmentsDashboardFundingDisplayTypeID != FundingDisplayTypeID)) 
            {
                yield return new SitkaValidationResult<ConfigureAccomplishmentsDashboardViewModel, int?>(
                    "The value supplied for \"Funding report should include?\" is invalid.",
                    m => m.FundingDisplayTypeID);
            }
        }
    }
}
