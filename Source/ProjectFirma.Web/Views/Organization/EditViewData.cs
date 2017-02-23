﻿/*-----------------------------------------------------------------------
<copyright file="EditViewData.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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

namespace ProjectFirma.Web.Views.Organization
{
    public class EditViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> Sectors;
        public readonly IEnumerable<SelectListItem> People;
        public readonly bool IsInKeystone;
        public readonly string RequestOrganizationChangeUrl;

        public EditViewData(IEnumerable<SelectListItem> sectors, IEnumerable<SelectListItem> people, bool isInKeystone, string requestOrganizationChangeUrl)
        {
            Sectors = sectors;
            People = people;
            IsInKeystone = isInKeystone;
            RequestOrganizationChangeUrl = requestOrganizationChangeUrl;
        }
    }
}
