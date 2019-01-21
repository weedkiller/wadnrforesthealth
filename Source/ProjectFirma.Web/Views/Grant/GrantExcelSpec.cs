﻿/*-----------------------------------------------------------------------
<copyright file="GrantExcelSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.ExcelWorkbookUtilities;

namespace ProjectFirma.Web.Views.Grant
{
    public class GrantAllocationExcelSpec : ExcelWorksheetSpec<Models.GrantAllocation>
    {
        public GrantAllocationExcelSpec()
        {
            // TODO: We likely need FieldDefinition labels here. 
            AddColumn("Grant Number", x => x.Grant.GrantNumber);
            AddColumn("Start Date", x => x.StartDate);
            AddColumn("End Date", x => x.EndDate);
            AddColumn("Allocation Amount", x => x.AllocationAmount);
        }
    }

    public class GrantExcelSpec : ExcelWorksheetSpec<Models.Grant>
    {
        public GrantExcelSpec()
        {
            // TODO: We likely need FieldDefinition labels here. 
            AddColumn("Grant Number", x => x.GrantNumber);
            AddColumn("Start Date", x => x.StartDate);
            AddColumn("End Date", x => x.EndDate);
            AddColumn("Awarded Funds", x => x.AwardedFunds);
        }
    }
}