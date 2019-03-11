﻿/*-----------------------------------------------------------------------
<copyright file="EditViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditViewData : FirmaUserControlViewData
    {
        public IEnumerable<SelectListItem> OrganizationTypes { get; }
        public IEnumerable<SelectListItem> People { get; }
        public bool IsInKeystone { get; }
        public string RequestOrganizationChangeUrl { get; }
        public bool IsSitkaAdmin { get; }
        public string VendorFindUrlTemplate { get; }

        public EditViewData(IEnumerable<SelectListItem> organizationTypes, IEnumerable<SelectListItem> people, bool isInKeystone, bool isSitkaAdmin)
        {
            OrganizationTypes = organizationTypes;
            People = people;
            IsInKeystone = isInKeystone;
            RequestOrganizationChangeUrl =
                SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.RequestOrganizationNameChange());
            IsSitkaAdmin = isSitkaAdmin;
            VendorFindUrlTemplate =
                SitkaRoute<VendorController>.BuildUrlFromExpression(x => x.FindVendor(string.Empty));

        }
    }
}
