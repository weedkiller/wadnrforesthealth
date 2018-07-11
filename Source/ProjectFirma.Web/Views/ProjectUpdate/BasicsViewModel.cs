﻿/*-----------------------------------------------------------------------
<copyright file="BasicsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using FluentValidation.Attributes;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    [Validator(typeof(BasicsViewModelValidator))]
    public class BasicsViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectDescription)]
        [StringLength(Models.Project.MaxLengthForProjectDescription)]
        public string ProjectDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectStage)]
        public int ProjectStageID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PlanningDesignStartYear)]
        public int? PlanningDesignStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ImplementationStartYear)]
        public int? ImplementationStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CompletionYear)]
        public int? CompletionYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedTotalCost)]
        public MoneyWholeNumber? EstimatedTotalCost { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedAnnualOperatingCost)]
        public MoneyWholeNumber? EstimatedAnnualOperatingCost { get; set; }

        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.BasicsComment)]
        public string Comments { get; set; }

        public ProjectCustomAttributes ProjectCustomAttributes { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public BasicsViewModel()
        {
        }

        public BasicsViewModel(Models.ProjectUpdate projectUpdate, string comments)
        {
            ProjectDescription = projectUpdate.ProjectDescription;
            ProjectStageID = projectUpdate.ProjectStageID;
            PlanningDesignStartYear = projectUpdate.PlanningDesignStartYear;
            ImplementationStartYear = projectUpdate.ImplementationStartYear;
            CompletionYear = projectUpdate.CompletionYear;
            EstimatedTotalCost = projectUpdate.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = projectUpdate.EstimatedAnnualOperatingCost;
            Comments = comments;
            ProjectCustomAttributes = new ProjectCustomAttributes(projectUpdate);
        }

        public void UpdateModel(Models.ProjectUpdate projectUpdate, Person currentPerson)
        {
            projectUpdate.ProjectDescription = ProjectDescription;
            projectUpdate.ProjectStageID = ProjectStageID;
            projectUpdate.PlanningDesignStartYear = PlanningDesignStartYear;
            projectUpdate.ImplementationStartYear = ImplementationStartYear;
            projectUpdate.CompletionYear = CompletionYear;
            projectUpdate.EstimatedTotalCost = EstimatedTotalCost;
            projectUpdate.EstimatedAnnualOperatingCost = EstimatedAnnualOperatingCost;
            ProjectCustomAttributes?.UpdateModel(projectUpdate, currentPerson);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ImplementationStartYear < PlanningDesignStartYear)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>(
                    FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear,
                    m => m.ImplementationStartYear);
            }

            if (CompletionYear < ImplementationStartYear)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>(
                    FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear,
                    m => m.CompletionYear);
            }

            var isCompletedOrPostImplementation = ProjectStageID == ProjectStage.Completed.ProjectStageID || ProjectStageID == ProjectStage.PostImplementation.ProjectStageID;
            if (isCompletedOrPostImplementation && CompletionYear > DateTime.Now.Year)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>(
                    "Since project is in Completed or Post-Implementation stage, the Completion Year needs to be less than or equal to the current year",
                    m => m.CompletionYear);
            }
        }
    }
}
