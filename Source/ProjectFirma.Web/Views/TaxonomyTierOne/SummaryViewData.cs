﻿using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    public class SummaryViewData : FirmaViewData
    {
        public readonly Models.TaxonomyTierOne TaxonomyTierOne;
        public readonly bool UserHasTaxonomyTierOneManagePermissions;
        public readonly string EditTaxonomyTierOneUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string FiveYearListProjectGridName;
        public readonly string FiveYearListProjectGridDataUrl;
        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;
        public readonly string EditDescriptionUrl;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string ProjectMapFilteredUrl;

        public SummaryViewData(Person currentPerson,
            Models.TaxonomyTierOne taxonomyTierOne,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData) : base(currentPerson)
        {
            TaxonomyTierOne = taxonomyTierOne;
            PageTitle = taxonomyTierOne.DisplayName;
            EntityName = MultiTenantHelpers.GetTaxonomyTierOneDisplayName();

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            UserHasTaxonomyTierOneManagePermissions = new TaxonomyTierOneManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTaxonomyTierOneUrl = SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(c => c.Edit(taxonomyTierOne));

            FiveYearListProjectGridName = "taxonomyTierOneProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = string.Format("Project with this {0}", MultiTenantHelpers.GetTaxonomyTierOneDisplayName()),
                ObjectNamePlural = string.Format("Projects with this {0}", MultiTenantHelpers.GetTaxonomyTierOneDisplayName()),
                SaveFiltersInCookie = true
            };

            FiveYearListProjectGridDataUrl = SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(taxonomyTierOne));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyTierOne);
            EditDescriptionUrl = SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(tc => tc.EditDescription(taxonomyTierOne));
        }
    }
}