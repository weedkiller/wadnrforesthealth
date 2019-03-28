﻿/*-----------------------------------------------------------------------
<copyright file="ProjectBasicsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.GrantAllocationControls
{
    public class GrantAllocationBasicsViewData
    {
        public Models.GrantAllocation GrantAllocation { get; }
        public bool UserHasGrantAllocationManagePermissions { get; }
        public string OrganizationDisplayName { get; }
        public string GrantManagerDisplayName { get; }
        //public GrantAllocationTaxonomyViewData GrantAllocationTaxonomyViewData { get; }

        public GrantAllocationBasicsViewData(Models.GrantAllocation grantAllocation, bool userHasGrantAllocationManagePermissions, TaxonomyLevel taxonomyLevel)
        {
            GrantAllocation = grantAllocation;
            UserHasGrantAllocationManagePermissions = userHasGrantAllocationManagePermissions;
            OrganizationDisplayName = grantAllocation.Organization != null ? grantAllocation.Organization.DisplayName : string.Empty;
            GrantManagerDisplayName = grantAllocation.GrantManager != null
                ? grantAllocation.GrantManager.FullNameFirstLastAndOrgShortName
                : string.Empty;
            //GrantAllocationTaxonomyViewData = new GrantAllocationTaxonomyViewData(grantAllocation, taxonomyLevel);
        }        
    }
}
