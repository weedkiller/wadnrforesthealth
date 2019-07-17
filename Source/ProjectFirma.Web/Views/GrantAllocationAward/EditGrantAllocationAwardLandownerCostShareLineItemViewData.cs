﻿/*-----------------------------------------------------------------------
<copyright file="EditGrantAllocationAwardLandownerCostShareLineItemViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Globalization;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.GrantAllocationAward
{
    public class EditGrantAllocationAwardLandownerCostShareLineItemViewData : FirmaUserControlViewData
    {
        public IEnumerable<SelectListItem> StatusList { get; }
        public IEnumerable<SelectListItem> ProjectList { get; }
        public IEnumerable<SelectListItem> GrantAllocationAwardList { get; }

        public EditGrantAllocationAwardLandownerCostShareLineItemViewData(IEnumerable<LandownerCostShareLineItemStatus> statusList, IEnumerable<Models.Project> projectList, IEnumerable<Models.GrantAllocationAward> grantAllocationAwards)
        {
            StatusList = statusList.ToSelectList(x => x.LandownerCostShareLineItemStatusID.ToString(CultureInfo.InvariantCulture), y => y.LandownerCostShareLineItemStatusDisplayName);
            ProjectList = projectList.ToSelectListWithEmptyFirstRow(x => x.ProjectID.ToString(CultureInfo.InvariantCulture), y => y.DisplayName);
            GrantAllocationAwardList = grantAllocationAwards.ToSelectListWithEmptyFirstRow(x => x.GrantAllocationAwardID.ToString(CultureInfo.InvariantCulture), y => y.GrantAllocationAwardName);
        }
    }

}