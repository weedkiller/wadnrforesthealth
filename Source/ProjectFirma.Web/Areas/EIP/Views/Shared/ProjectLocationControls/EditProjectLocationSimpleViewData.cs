﻿using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.Map;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls
{
    public class EditProjectLocationSimpleViewData : EIPViewData
    {
        public readonly IEnumerable<SelectListItem> ProjectLocationSelectListItems;
        public readonly MapInitJson MapInitJson;
        public readonly string MapFormID;
        public readonly string MapPostUrl;
        public readonly string ProjectLocationInformationContainer;
        public readonly string ProjectLocationAreaGeoJsonUrl;

        public EditProjectLocationSimpleViewData(Person currentPerson, MapInitJson mapInitJson, IEnumerable<SelectListItem> projectLocationSelectListItems, string mapPostUrl, string mapFormID)
            : base(currentPerson)
        {
            MapInitJson = mapInitJson;
            ProjectLocationSelectListItems = projectLocationSelectListItems;
            MapPostUrl = mapPostUrl;
            MapFormID = mapFormID;
            ProjectLocationInformationContainer = string.Format("{0}LocationInformationContainer", mapInitJson.MapDivID);
            ProjectLocationAreaGeoJsonUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.GetProjectLocationAreaGeoJson(null));
        }
    }
}