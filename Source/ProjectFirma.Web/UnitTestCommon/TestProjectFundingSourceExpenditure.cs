﻿/*-----------------------------------------------------------------------
<copyright file="TestProjectFundingSourceExpenditure.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectFundingSourceExpenditure
        {
            public static ProjectFundingSourceExpenditure Create()
            {
                var project = TestProject.Create();
                //var fundingSource = TestFundingSource.Create();
                var grantAllocation = TestGrantAllocation.Create();
                return Create(project, grantAllocation);
            }

            public static ProjectFundingSourceExpenditure Create(Project project, GrantAllocation grantAllocation)
            {
                var projectFundingSourceExpenditure = ProjectFundingSourceExpenditure.CreateNewBlank(project, grantAllocation);
                return projectFundingSourceExpenditure;
            }

            public static ProjectFundingSourceExpenditure Create(Project project, GrantAllocation grantAllocation, int calendarYear)
            {
                var projectFundingSourceExpenditure = Create(project, grantAllocation);
                projectFundingSourceExpenditure.CalendarYear = calendarYear;
                return projectFundingSourceExpenditure;
            }

            public static ProjectFundingSourceExpenditure Create(Project project, FundingSource fundingSource, GrantAllocation grantAllocation, int calendarYear, decimal expenditureAmount)
            {
                var projectFundingSourceExpenditure = Create(project, grantAllocation, calendarYear);
                projectFundingSourceExpenditure.ExpenditureAmount = expenditureAmount;
                return projectFundingSourceExpenditure;
            }
        }
    }
}
