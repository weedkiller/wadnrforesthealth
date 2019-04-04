﻿/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditure.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectFundingSourceExpenditure : IAuditableEntity, IFundingSourceExpenditure
    {
        public decimal? MonetaryAmount
        {
            get { return ExpenditureAmount; }
        }

        public string ExpenditureAmountDisplay
        {
            get { return ExpenditureAmount.ToStringCurrency(); }
        }

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var fundingSource = HttpRequestStorage.DatabaseEntities.FundingSources.Find(FundingSourceID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var fundingSourceName = fundingSource != null ? fundingSource.AuditDescriptionString : ViewUtilities.NotFoundString;
                var expenditureAmount = ExpenditureAmountDisplay;
                return $"Project: {projectName}, Funding Source: {fundingSourceName}, Year: {CalendarYear},  Expenditure: {expenditureAmount}";
            }
        }

        int IFundingSourceExpenditure.FundingSourceID => throw new NotImplementedException("Stop using FundingSourceID");

        public static IEnumerable<CalendarYearReportedValue> ToCalendarYearReportedValues(IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            var yearRange = FirmaDateUtilities.GetRangeOfYearsForReporting();
            return yearRange.OrderBy(cy => cy).Select(cy =>
            {
                var pmavForThisCalendaYear = projectFundingSourceExpenditures.Where(x => x.CalendarYear == cy).ToList();
                return new CalendarYearReportedValue(cy, pmavForThisCalendaYear.Any() ? (double?) pmavForThisCalendaYear.Sum(y => y.ExpenditureAmount) : null);
            });
        }
    }
}
