﻿/*-----------------------------------------------------------------------
<copyright file="ExpendituresViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpectedFundingViewModel : FormViewModel, IValidatableObject
    {       
        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpendituresComment)]
        public string Comments { get; set; }

        public List<ProjectFundingSourceRequestSimple> ProjectFundingSourceRequests { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpectedFundingViewModel()
        {
        }

        public ExpectedFundingViewModel(List<ProjectFundingSourceRequestUpdate> projectFundingSourceRequestUpdates,
            string comments)
        {
            ProjectFundingSourceRequests = projectFundingSourceRequestUpdates.Select(x => new ProjectFundingSourceRequestSimple(x)).ToList();
            Comments = comments;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch,
            List<ProjectFundingSourceRequestUpdate> currentProjectFundingSourceRequestUpdates,
            IList<ProjectFundingSourceRequestUpdate> allProjectFundingSourceRequestUpdates)
        {
            var projectFundingSourceRequestUpdatesUpdated = new List<ProjectFundingSourceRequestUpdate>();
            if (ProjectFundingSourceRequests != null)
            {
                // Completely rebuild the list
                projectFundingSourceRequestUpdatesUpdated = ProjectFundingSourceRequests.Where(x => x.UnsecuredAmount.HasValue || x.SecuredAmount.HasValue).Select(x => x.ToProjectFundingSourceRequestUpdate()).ToList();
            }

            currentProjectFundingSourceRequestUpdates.Merge(projectFundingSourceRequestUpdatesUpdated,
                allProjectFundingSourceRequestUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.FundingSourceID == y.FundingSourceID,
                (x, y) =>
                {
                    x.SecuredAmount = y.SecuredAmount;
                    x.UnsecuredAmount = y.UnsecuredAmount;
                });
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (ProjectFundingSourceRequests != null)
            {
                if (ProjectFundingSourceRequests.GroupBy(x => x.FundingSourceID).Any(x => x.Count() > 1))
                {
                    validationResults.Add(new ValidationResult("Each funding source can only be used once."));
                }

                if (ProjectFundingSourceRequests.Any(x => x.AreBothValuesZeroOrEmpty()))
                {
                    validationResults.Add(new ValidationResult(FirmaValidationMessages.ExpectedFundingValuesCannotBothBeZeroOrEmpty));
                }
            }

            return validationResults;
        }
    }
}