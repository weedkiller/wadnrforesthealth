﻿using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.Map;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Areas.EIP.Views.Results
{
    public class EipProjectMapViewData : EIPViewData
    {
        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;

        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly Dictionary<ProjectLocationFilterType, IEnumerable<SelectListItem>> ProjectLocationFilterTypesAndValues;
        public readonly string ProjectLocationsUrl;
        public readonly string FilteredProjectsWithLocationAreasUrl;

        public EipProjectMapViewData(Person currentPerson,
            ProjectFirmaPage projectFirmaPage,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData,
            Dictionary<ProjectLocationFilterType, IEnumerable<SelectListItem>> projectLocationFilterTypesAndValues,
            string projectLocationsUrl,
            string filteredProjectsWithLocationAreasUrl) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "EIP Project Map";
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationFilterTypesAndValues = projectLocationFilterTypesAndValues;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsUrl = projectLocationsUrl;
            FilteredProjectsWithLocationAreasUrl = filteredProjectsWithLocationAreasUrl;
        }
    }
}