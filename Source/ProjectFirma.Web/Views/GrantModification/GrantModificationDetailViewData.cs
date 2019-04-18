﻿/*-----------------------------------------------------------------------
<copyright file="GrantModificationDetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Views.Shared.TextControls;

namespace ProjectFirma.Web.Views.GrantModification
{
    public class GrantModificationDetailViewData : FirmaViewData
    {
        public Models.GrantModification GrantModification { get; }
        public string EditGrantModificationBasicsUrl { get; }
        public EntityNotesViewData InternalGrantModificationNotesViewData { get; }
        public bool ShowDownload { get; }
        public bool UserHasEditGrantModificationPermissions { get; }
        public string ParentGrantUrl { get; }
        public string BackToParentGrantUrlText { get; }

        public GrantModificationDetailViewData(Person currentPerson, Models.GrantModification grantModification, EntityNotesViewData internalGrantModificationNotesViewData) : base(currentPerson)
        {
            GrantModification = grantModification;
            PageTitle = grantModification.GrantModificationName;
            BreadCrumbTitle = $"{Models.FieldDefinition.GrantModification.GetFieldDefinitionLabel()} Detail";
            InternalGrantModificationNotesViewData = internalGrantModificationNotesViewData;
            ParentGrantUrl = SitkaRoute<GrantController>.BuildUrlFromExpression(gc => gc.GrantDetail(grantModification.GrantID));
            BackToParentGrantUrlText = $"Back to {Models.FieldDefinition.Grant.GetFieldDefinitionLabel()}: {grantModification.Grant.GrantName}";
            EditGrantModificationBasicsUrl = SitkaRoute<GrantModificationController>.BuildUrlFromExpression(gmc => gmc.EditGrantModification(grantModification.PrimaryKey));
            UserHasEditGrantModificationPermissions = new GrantModificationEditAsAdminFeature().HasPermissionByPerson(currentPerson);
            // Used for creating file download link, if file available
            ShowDownload = grantModification.GrantModificationFileResource != null;
        }
    }
}
