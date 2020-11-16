﻿/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirma.Web.Views.GrantAllocationAwardLandownerCostShareLineItem
{
    public class IndexViewData : FirmaViewData
    {
        public readonly LandownerCostShareIndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = "DNR Cost Share Treatments";
            GridSpec = new LandownerCostShareIndexGridSpec(currentPerson)
            {
                ObjectNameSingular = Models.FieldDefinition.GrantAllocationAwardLandownerCostShareLineItem.GetFieldDefinitionLabel(),
                ObjectNamePlural = Models.FieldDefinition.GrantAllocationAwardLandownerCostShareLineItem.GetFieldDefinitionLabelPluralized(),
                SaveFiltersInCookie = true
            };

            GridName = "landownerCostShareLineItemGrid";
            GridDataUrl = SitkaRoute<GrantAllocationAwardLandownerCostShareLineItemController>.BuildUrlFromExpression(tac => tac.IndexGridJsonData());
        }
    }
}
