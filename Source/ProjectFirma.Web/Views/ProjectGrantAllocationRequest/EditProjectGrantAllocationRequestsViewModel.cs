﻿/*-----------------------------------------------------------------------
<copyright file="EditprojectGrantAllocationRequestsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectGrantAllocationRequest
{
    public class EditProjectGrantAllocationRequestsViewModel : FormViewModel, IValidatableObject
    {
        
        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedTotalCost)]
        [JsonIgnore]
        [ValidateMoneyInRangeForSqlServer]
        public Money? ProjectEstimatedTotalCost { get; set; }

        [Required]
        public bool? ForProject { get; set; }

        public List<ProjectGrantAllocationRequestSimple> ProjectGrantAllocationRequests { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingSource)]
        public List<int> FundingSourceIDs { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingSourceNote)]
        [StringLength(Models.Project.FieldLengths.ProjectFundingSourceNotes)]
        public string ProjectFundingSourceNotes { get; set; }

        //TODO: Get TotalAmount in here, pass to Angular Controller in EditProjectGrantAllocationRequests.cshtml

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectGrantAllocationRequestsViewModel()
        {
        }

        public EditProjectGrantAllocationRequestsViewModel(List<Models.ProjectGrantAllocationRequest> projectGrantAllocationRequests, 
                                                           bool forProject, 
                                                           Money? projectEstimatedTotalCost,
                                                           string projectFundingSourceNotes,
                                                           List<ProjectFundingSource> projectFundingSources)
        {
            ProjectGrantAllocationRequests = projectGrantAllocationRequests
                .Select(x => new ProjectGrantAllocationRequestSimple(x)).ToList();
            ProjectEstimatedTotalCost = projectEstimatedTotalCost;
            ForProject = forProject;
            ProjectFundingSourceNotes = projectFundingSourceNotes;
            FundingSourceIDs = projectFundingSources.Select(x => x.FundingSourceID).ToList();
        }

        public void UpdateModel(List<Models.ProjectGrantAllocationRequest> currentProjectGrantAllocationRequests,
                                IList<Models.ProjectGrantAllocationRequest> allProjectGrantAllocationRequests, 
                                Models.Project project,
                                List<ProjectFundingSource> currentProjectFundingSources,
                                IList<ProjectFundingSource> allProjectFundingSources)
        {
            var projectGrantAllocationRequestsModified = new List<Models.ProjectGrantAllocationRequest>();
            if (ProjectGrantAllocationRequests != null)
            {
                // Completely rebuild the list
                projectGrantAllocationRequestsModified = ProjectGrantAllocationRequests.Select(x => x.ToProjectGrantAllocationRequest()).ToList();
            }

            if (ForProject ?? false) // never null
            {
                if (project == null)
                {
                    throw new InvalidOperationException(
                        $"Project is required to update {Models.FieldDefinition.GrantAllocation.GetFieldDefinitionLabel()} Requests for a Project");
                }

                //Update the ProjectFundingSources
                var projectFundingSourcesUpdated = new List<Models.ProjectFundingSource>();
                if (FundingSourceIDs.Any())
                {
                    // Completely rebuild the list
                    projectFundingSourcesUpdated = FundingSourceIDs.Select(x => new ProjectFundingSource(project.ProjectID, x)).ToList();
                }

                currentProjectFundingSources.Merge(projectFundingSourcesUpdated,
                    allProjectFundingSources,
                    (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID);

                //Update Project fields
                project.ProjectFundingSourceNotes = ProjectFundingSourceNotes;
                project.EstimatedTotalCost = ProjectEstimatedTotalCost;
            }

            currentProjectGrantAllocationRequests.Merge(projectGrantAllocationRequestsModified,
                allProjectGrantAllocationRequests,
                (x, y) => x.ProjectID == y.ProjectID && x.GrantAllocationID == y.GrantAllocationID,
                (x, y) =>
                {
                    x.TotalAmount = y.TotalAmount;
                });
            
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProjectGrantAllocationRequests == null)
            {
                yield break;
            }

            if (ProjectGrantAllocationRequests.GroupBy(x => x.GrantAllocationID).Any(x => x.Count() > 1))
            {
                yield return new ValidationResult("Each grant allocation can only be used once.");
            }

            //foreach (var projectGrantAllocationRequest in ProjectGrantAllocationRequests)
            //{
            //    if (projectGrantAllocationRequest.AreBothValuesZero())
            //    {
            //        var grantAllocation = HttpRequestStorage.DatabaseEntities.GrantAllocations.Single(x => x.GrantAllocationID == projectGrantAllocationRequest.GrantAllocationID);
            //        yield return new ValidationResult(
            //            $"Secured Funding and Unsecured Funding cannot both be zero for Grant Allocation: {grantAllocation.GrantAllocationName}. If the amount of secured or unsecured funding is unknown, you can leave the amounts blank.");
            //    }
            //}
        }
    }
}