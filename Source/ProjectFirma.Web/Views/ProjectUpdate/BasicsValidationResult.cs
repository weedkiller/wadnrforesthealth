﻿/*-----------------------------------------------------------------------
<copyright file="BasicsValidationResult.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BasicsValidationResult
    {
        public static readonly string PlannedDateIsRequired = $"{Models.FieldDefinition.PlannedDate.GetFieldDefinitionLabel()} is a required field.";
        public static readonly string ImplementationStartYearIsRequired = $"{Models.FieldDefinition.ApprovalStartDate.GetFieldDefinitionLabel()} is a required field.";
        public static readonly string CompletionDateIsRequired = $"For projects in the Completed or Post-Implementation stage, {Models.FieldDefinition.CompletionDate.GetFieldDefinitionLabel()} is a required field.";
        public static readonly string ProjectDescriptionIsRequired = $"{Models.FieldDefinition.ProjectDescription.GetFieldDefinitionLabel()} is required.";
        public static readonly string CompletionDateShouldBeLessThanCurrentYear = $"Since the {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} is in Completed or Post-Implementation stage, the {Models.FieldDefinition.CompletionDate.GetFieldDefinitionLabel()} needs to be less than or equal to this year";
        public static readonly string PlannedDateShouldBeLessThanCurrentYear = $"Since the {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} is in the Planning / Design stage, the {Models.FieldDefinition.PlannedDate.GetFieldDefinitionLabel()} needs to be less than or equal to this year";
        public static readonly string ImplementationStartYearShouldBeLessThanCurrentYear = $"Since the {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} is in Implementation stage, the {Models.FieldDefinition.ApprovalStartDate.GetFieldDefinitionLabel()} needs to be less than or equal to this year";

        private readonly List<string> _warningMessages;

        public BasicsValidationResult(Models.ProjectUpdate projectUpdate)
        {
            _warningMessages = new List<string>();

            if (projectUpdate.PlannedDate == null)
            {
                _warningMessages.Add(PlannedDateIsRequired);
            }
            if (projectUpdate.GetImplementationStartYear() == null && projectUpdate.ProjectStage != ProjectStage.Cancelled && projectUpdate.ProjectStage != ProjectStage.Deferred )
            {
                _warningMessages.Add(ImplementationStartYearIsRequired);
            }
                        
            if ((projectUpdate.ProjectStage == ProjectStage.Completed || projectUpdate.ProjectStage == ProjectStage.PostImplementation) && projectUpdate.GetCompletionYear() == null)
            {
                _warningMessages.Add(CompletionDateIsRequired);
            }

            if (GeneralUtility.IsNullOrEmptyOrOnlyWhitespace(projectUpdate.ProjectDescription))
            {
                _warningMessages.Add(ProjectDescriptionIsRequired);
            }
            
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
            if ((projectUpdate.ProjectStage == ProjectStage.Completed || projectUpdate.ProjectStage == ProjectStage.PostImplementation) && projectUpdate.GetCompletionYear() > currentYear)
            {
                _warningMessages.Add(CompletionDateShouldBeLessThanCurrentYear);
            }
            if (projectUpdate.ProjectStage == ProjectStage.Planned && projectUpdate.PlannedDate?.Year > currentYear)
            {
                _warningMessages.Add(PlannedDateShouldBeLessThanCurrentYear);
            }
            if (projectUpdate.ProjectStage == ProjectStage.Implementation && projectUpdate.GetImplementationStartYear() > currentYear)
            {
                _warningMessages.Add(ImplementationStartYearShouldBeLessThanCurrentYear);
            }

            if (projectUpdate.GetImplementationStartYear() < projectUpdate.PlannedDate?.Year)
            {
                _warningMessages.Add(FirmaValidationMessages.ImplementationStartYearGreaterThanPlannedDate);
            }
            if (projectUpdate.GetCompletionYear() < projectUpdate.GetImplementationStartYear())
            {
                _warningMessages.Add(FirmaValidationMessages.CompletionDateGreaterThanEqualToImplementationStartYear);
            }
            if (projectUpdate.GetCompletionYear() < projectUpdate.PlannedDate?.Year)
            {
                _warningMessages.Add(FirmaValidationMessages.CompletionDateGreaterThanEqualToPlannedDate);
            }
        }

        public List<string> GetWarningMessages()
        {     
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}
