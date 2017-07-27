﻿/*-----------------------------------------------------------------------
<copyright file="ProjectViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public abstract class ProjectViewData : FirmaViewData
    {
        public readonly Models.Project Project;
        public readonly ProjectUpdateState LatestUpdateState;

        protected ProjectViewData(Person currentPerson, Models.Project project) : this(currentPerson, project, false)
        {
        }        

        protected ProjectViewData(Person currentPerson, Models.Project project, bool useFluidContainer) : base(currentPerson, null)
        {
            Project = project;
            HtmlPageTitle = project.ProjectName;
            EntityName = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()}";
            LatestUpdateState = project.GetLatestUpdateState();
        }        
    }
}
