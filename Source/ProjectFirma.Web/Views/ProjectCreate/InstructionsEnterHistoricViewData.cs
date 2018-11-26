﻿/*-----------------------------------------------------------------------
<copyright file="InstructionsEnterHistoricViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class InstructionsEnterHistoricViewData : ProjectCreateViewData
    {

        public readonly bool IsNewProjectCreate;

        public readonly ViewPageContentViewData InstructionsViewPageContentViewData;
        public InstructionsEnterHistoricViewData(Person currentPerson, Models.FirmaPage firmaPage, bool isNewProjectCreate) : base(currentPerson, "Instructions", SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsEnterHistoric(null)))
        {
            PageTitle = $"Add {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}";
            InstructionsViewPageContentViewData = new ViewPageContentViewData(firmaPage, new FirmaPageManageFeature().HasPermission(currentPerson, firmaPage).HasPermission);
            IsNewProjectCreate = isNewProjectCreate;
        }

        public InstructionsEnterHistoricViewData(Person currentPerson, Models.Project project, ProposalSectionsStatus proposalSectionsStatus, Models.FirmaPage firmaPage, bool isNewProjectCreate) : base(currentPerson, project, "Instructions", proposalSectionsStatus)
        {
            InstructionsViewPageContentViewData = new ViewPageContentViewData(firmaPage, new FirmaPageManageFeature().HasPermission(currentPerson, firmaPage).HasPermission);
            IsNewProjectCreate = isNewProjectCreate;
        }
    }
}
