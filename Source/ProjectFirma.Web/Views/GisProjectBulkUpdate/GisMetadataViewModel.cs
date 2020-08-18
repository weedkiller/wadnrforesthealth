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
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.GisProjectBulkUpdate
{
    public class GisMetadataViewModel : FormViewModel, IValidatableObject
    {

        [Required]
        [DisplayName("Project Identifier Column")]
        public int ProjectIdentifierMetadataAttributeID { get; set; }

        [Required]
        [DisplayName("Project Name Column")]
        public int ProjectNameMetadataAttributeID { get; set; }

        [DisplayName("Treatment Type Column")]
        public int? TreatmentTypeMetadataAttributeID { get; set; }

        [Required]
        [DisplayName("Completion Date Column")]
        public int CompletionDateMetadataAttributeID { get; set; }

        [DisplayName("Start Date Column")]
        public int? StartDateMetadataAttributeID { get; set; }

        [DisplayName("Project Stage Column")]
        public int? ProjectStageMetadataAttributeID { get; set; }

        [Required]
        [DisplayName("Footprint Acres Column")]
        public int? FootprintAcresMetadataAttributeID { get; set; }

        [DisplayName("Treatment Detailed Activity Type Column")]
        public int? TreatmentDetailedActivityTypeMetadataAttributeID { get; set; }

        [DisplayName("Treated Acres Column")]
        public int? TreatedAcresMetadataAttributeID { get; set; }

        [DisplayName("Pruning Acres Column")]
        public int? PruningAcresMetadataAttributeID { get; set; }

        [DisplayName("Thinning Acres Column")]
        public int? ThinningAcresMetadataAttributeID { get; set; }

        [DisplayName("Chipping Acres Column")]
        public int? ChippingAcresMetadataAttributeID { get; set; }

        [DisplayName("Mastication Acres Column")]
        public int? MasticationAcresMetadataAttributeID { get; set; }

        [DisplayName("Grazing Acres Column")]
        public int? GrazingAcresMetadataAttributeID { get; set; }

        [DisplayName("Lop and Scatter Acres Column")]
        public int? LopScatAcresMetadataAttributeID { get; set; }

        [DisplayName("Biomass Removal Acres Column")]
        public int? BiomassRemovalAcresMetadataAttributeID { get; set; }

        [DisplayName("Hand Pile Acres Column")]
        public int? HandPileAcresMetadataAttributeID { get; set; }

        [DisplayName("Hand Pile Burn Acres Column")]
        public int? HandPileBurnAcresMetadataAttributeID { get; set; }

        [DisplayName("Machine Pile Burn Acres Column")]
        public int? MachinePileBurnAcresMetadataAttributeID { get; set; }

        [DisplayName("Broadcast Burn Acres Column")]
        public int? BroadcastBurnAcresMetadataAttributeID { get; set; }

        [DisplayName("Other Acres Column")]
        public int? OtherAcresMetadataAttributeID { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public GisMetadataViewModel() { }


        public GisMetadataViewModel(GisUploadAttempt gisUploadAttempt, List<Models.GisMetadataAttribute> gisMetadataAttributes)
        {
            var organization = gisUploadAttempt.GisUploadSourceOrganization;
            var defaults = organization.GisDefaultMappings;
            ProjectIdentifierMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.ProjectIdentifier) ?? 0;
            ProjectNameMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.ProjectName) ?? 0;
            TreatmentTypeMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.TreatmentType);
            CompletionDateMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.CompletionDate) ?? 0;
            StartDateMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.PlannedDate);
            ProjectStageMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.ProjectStage);
            FootprintAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.FootprintAcres);
            TreatedAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.TreatedAcres);
            TreatmentDetailedActivityTypeMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.TreatmentDetailedActivityType);
            PruningAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostSharePruningAcres);
            ThinningAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareThinningAcres);
            ChippingAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareChippingAcres);
            MasticationAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareMasticationAcres);
            GrazingAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareGrazingAcres);
            LopScatAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareLopAndScatterAcres);
            BiomassRemovalAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareBiomassRemovalAcres);
            HandPileAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareHandPileAcres);
            HandPileBurnAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareHandPileBurnAcres);
            MachinePileBurnAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareMachinePileBurnAcres);
            BroadcastBurnAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareBroadcastBurnAcres);
            OtherAcresMetadataAttributeID = GetPossibleDefaultMetadataAttributeID(gisMetadataAttributes, defaults, Models.FieldDefinition.GrantAllocationAwardLandownerCostShareOtherTreatmentAcres);
        }

        private static int? GetPossibleDefaultMetadataAttributeID(List<GisMetadataAttribute> gisMetadataAttributes, ICollection<GisDefaultMapping> defaults, Models.FieldDefinition fieldDefinition)
        {
            int? defaultMetadataAttributeID = null;
            var projectIdentifierDefault =
                defaults.SingleOrDefault(x => x.FieldDefinition == fieldDefinition);
            if (projectIdentifierDefault != null)
            {
                var projectIdentifierGisMetadataAttribute = gisMetadataAttributes
                    .SingleOrDefault(x => string.Equals(x.GisMetadataAttributeName,
                        projectIdentifierDefault.GisDefaultMappingColumnName));
                if (projectIdentifierGisMetadataAttribute != null)
                {
                    defaultMetadataAttributeID = projectIdentifierGisMetadataAttribute.GisMetadataAttributeID;
                }
            }

            return defaultMetadataAttributeID;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var somethingBadWithTheFile = false;

            if (somethingBadWithTheFile)
            {
                yield return new SitkaValidationResult<UploadGisFileViewModel, HttpPostedFileBase>("There is something wrong with the file", m => m.FileResourceData);
            }

        }
    }
}
