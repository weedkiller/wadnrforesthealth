﻿/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {
            PageTitle = MultiTenantHelpers.GetTaxonomyTierOneDisplayNamePluralized();

            var hasTaxonomyTierOneManagePermissions = new TaxonomyTierOneManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasTaxonomyTierOneManagePermissions)
            {
                ObjectNameSingular = MultiTenantHelpers.GetTaxonomyTierOneDisplayName(),
                ObjectNamePlural = MultiTenantHelpers.GetTaxonomyTierOneDisplayNamePluralized(),
                SaveFiltersInCookie = true
            };

            if (hasTaxonomyTierOneManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(t => t.New()), string.Format("Create a new {0}", MultiTenantHelpers.GetTaxonomyTierOneDisplayName()));
            }

            GridName = "taxonomyTierOnesGrid";
            GridDataUrl = SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}
