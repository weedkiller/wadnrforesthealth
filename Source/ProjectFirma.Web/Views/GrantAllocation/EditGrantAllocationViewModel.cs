﻿/*-----------------------------------------------------------------------
<copyright file="EditProjectViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using ApprovalUtilities.Utilities;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.GrantAllocation
{
    public class EditGrantAllocationViewModel : FormViewModel, IValidatableObject
    {
        public int GrantAllocationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectName)]
        [Required]
        public string ProjectName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.Organization)]
        [Required]
        public int OrganizationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.GrantStatus)]
        [Required]
        public int GrantStatusID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.GrantType)]
        public int? GrantTypeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.GrantNumber)]
        public int GrantID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProgramIndex)]
        public int? ProgramIndexID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CFDA)]
        public string CFDANumber { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectCode)]
        public List<int> ProjectCodeIDs { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.FederalFundCode)]
        public int? FederalFundCodeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.Region)]
        public int? RegionID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.AllocationAmount)]
        public Money? AllocationAmount { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.GrantStartDate)]
        public DateTime? StartDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.GrantEndDate)]
        public DateTime? EndDate { get; set; }
      
 /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditGrantAllocationViewModel()
        {
        }

        public EditGrantAllocationViewModel(Models.GrantAllocation grantAllocation)
        {
            ProjectName = grantAllocation.ProjectName;
            OrganizationID = grantAllocation.Grant.OrganizationID;
            GrantStatusID = grantAllocation.Grant.GrantStatusID;
            GrantTypeID = grantAllocation.Grant.GrantTypeID;
            GrantID = grantAllocation.Grant.GrantID;
            ProgramIndexID = grantAllocation.ProgramIndex.ProgramIndexID;
            CFDANumber = grantAllocation.Grant.CFDANumber;
            ProjectCodeIDs = grantAllocation.ProjectCodes.Select(pc => pc.ProjectCodeID).ToList();
            FederalFundCodeID = grantAllocation.FederalFundCode.FederalFundCodeID;
            RegionID = grantAllocation.RegionIDDisplay;
            AllocationAmount = grantAllocation.AllocationAmount;
            StartDate = grantAllocation.StartDate;
            EndDate = grantAllocation.EndDate;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProjectName == "")
            {
                yield return new SitkaValidationResult<EditGrantAllocationViewModel, string>(
                    FirmaValidationMessages.OrganizationNameUnique, m => m.ProjectName);
            }
        }

        public void UpdateModel(Models.GrantAllocation grantAllocation, Person currentPerson)
        {
            grantAllocation.ProjectName = ProjectName;
            grantAllocation.OrganizationID = OrganizationID;
            grantAllocation.Grant.GrantStatusID = GrantStatusID;
            grantAllocation.Grant.GrantTypeID = GrantTypeID;
            grantAllocation.GrantID = GrantID;
            //grantAllocation.ProgramIndex.ProgramIndexAbbrev = ProgramIndex != null ? ProgramIndex : String.Empty;
            grantAllocation.ProgramIndexID = ProgramIndexID;
            grantAllocation.Grant.CFDANumber = CFDANumber;
            grantAllocation.ProjectCodes = grantAllocation.ConvertIntsToProjectCodes(ProjectCodeIDs);
            grantAllocation.FederalFundCodeID = FederalFundCodeID;
            grantAllocation.RegionID = RegionID;
            grantAllocation.AllocationAmount = AllocationAmount;
            grantAllocation.StartDate = StartDate;
            grantAllocation.EndDate = EndDate;
        }
    }
}