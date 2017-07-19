﻿/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency">
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

using System.Collections.Generic;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.OrganizationAndRelationshipType
{
    public class RelationshipTypeGridSpec : GridSpec<Models.RelationshipType>
    {
        public RelationshipTypeGridSpec(bool hasManagePermissions, List<OrganizationType> allOrganizationTypes)
        {
            var basicsColumnGroupCount = 1;
           

            if (hasManagePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, x.CanDelete()), 30);
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<OrganizationAndRelationshipTypeController>.BuildUrlFromExpression(t => t.EditRelationshipType(a)),
                        $"Edit Relationship Type '{a.RelationshipTypeName}'")),
                    30);
                basicsColumnGroupCount += 2;
            }

            Add("Relationship Type Name", a => a.RelationshipTypeName, 240);
            foreach (var organizationType in allOrganizationTypes)
            {
                Add(organizationType.OrganizationTypeName, a => a.IsAssociatedWithOrganiztionType(organizationType).ToCheckboxImageOrEmpty(), 100);
            }

            GroupingHeader =
                BuildGroupingHeader(new ColumnHeaderGroupingList
                {
                    {"", basicsColumnGroupCount},
                    {"Applicable to Organizations with the following types:", allOrganizationTypes.Count}                    
                });

        }
    }
}