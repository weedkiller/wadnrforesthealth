﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.FileResourceControls;

namespace ProjectFirma.Web.Views.PriorityLandscape
{
    public class DetailViewData : FirmaViewData
    {
        public Models.PriorityLandscape PriorityLandscape { get; }
        public bool UserHasPriorityLandscapeManagePermissions { get; }
        public string IndexUrl { get; }
        public ProjectIndexGridSpec BasicProjectInfoGridSpec { get; }
        public string BasicProjectInfoGridName { get; }
    public string BasicProjectInfoGridDataUrl { get; }
        public MapInitJson MapInitJson { get; }
        public ViewGoogleChartViewData ViewGoogleChartViewData { get; }
        public List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas { get; }
        public FileDetailsViewData PriorityLandscapeFileDetailsViewData { get; set; }

        public DetailViewData(Person currentPerson, Models.PriorityLandscape priorityLandscape, MapInitJson mapInitJson, ViewGoogleChartViewData viewGoogleChartViewData, List<Models.PerformanceMeasure> performanceMeasures) : base(currentPerson)
        {
            PriorityLandscape = priorityLandscape;
            MapInitJson = mapInitJson;
            ViewGoogleChartViewData = viewGoogleChartViewData;
            PageTitle = priorityLandscape.PriorityLandscapeName;
            EntityName = "PriorityLandscape";
            UserHasPriorityLandscapeManagePermissions = new PriorityLandscapeManageFeature().HasPermissionByPerson(currentPerson);
            IndexUrl = SitkaRoute<PriorityLandscapeController>.BuildUrlFromExpression(x => x.Index());

            BasicProjectInfoGridName = "priorityLandscapeProjectListGrid";
            BasicProjectInfoGridSpec = new ProjectIndexGridSpec(CurrentPerson, false, false)
            {
                ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} in this {Models.FieldDefinition.PriorityLandscape.GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} in this {Models.FieldDefinition.PriorityLandscape.GetFieldDefinitionLabel()}",
                SaveFiltersInCookie = true
            };
          
            BasicProjectInfoGridDataUrl = SitkaRoute<PriorityLandscapeController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(priorityLandscape));

            PerformanceMeasureChartViewDatas = performanceMeasures.Select(x=>priorityLandscape.GetPerformanceMeasureChartViewData(x, CurrentPerson)).ToList();

            PriorityLandscapeFileDetailsViewData = new FileDetailsViewData(
                EntityDocument.CreateFromEntityDocument(new List<IEntityDocument>(priorityLandscape.PriorityLandscapeFileResources)),
                SitkaRoute<PriorityLandscapeController>.BuildUrlFromExpression(x => x.NewPriorityLandscapeFiles(priorityLandscape.PrimaryKey)),
                UserHasPriorityLandscapeManagePermissions,
                Models.FieldDefinition.PriorityLandscape
            );
        }

        
    }
}
