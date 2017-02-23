﻿/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Sitka Technology Group">
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
using System.Web;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Organization
{
    public class IndexGridSpec : GridSpec<Models.Organization>
    {
        public IndexGridSpec(Person currentPerson, bool hasDeletePermissions)
        {
            var userViewFeature = new UserViewFeature();
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects()), 30);
            }
            Add(Models.FieldDefinition.Organization.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.OrganizationName), 400, DhtmlxGridColumnFilterType.Html);
            Add("Abbreviation", a => a.OrganizationAbbreviation, 100);
            Add(Models.FieldDefinition.Sector.ToGridHeaderString(), a => a.Sector.SectorDisplayName, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.PrimaryContact.ToGridHeaderString(), a => userViewFeature.HasPermissionByPerson(currentPerson) ? a.PrimaryContactPersonAsUrl : new HtmlString(a.PrimaryContactPersonAsString), 120);
            Add("# of Projects", a => a.GetAllProjectOrganizations().Count, 90);
            Add("# of Funding Sources", a => a.FundingSources.Count, 150);
            Add("# of Users", a => a.People.Count, 90);
            Add("Is Active", a => a.IsActive.ToYesNo(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}
