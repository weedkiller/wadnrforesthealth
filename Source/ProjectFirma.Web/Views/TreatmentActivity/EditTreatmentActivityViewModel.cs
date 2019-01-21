﻿/*-----------------------------------------------------------------------
<copyright file="EditTreatmentActivitysViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Views.TreatmentActivity
{
    public class EditTreatmentActivityViewModel : FormViewModel, IValidatableObject
    {
 
        public int ProjectID { get; set; }
        public int TreatmentActivityID { get; set; }
        [Required]
        [DisplayName("Contact")]
        public int? TreatmentActivityContactID { get; set; }
        
        [DisplayName("Start Date")]
        public DateTime? TreatmentActivityStartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime? TreatmentActivityEndDate { get; set; }
        [DisplayName("Program Index")]
        public string TreatmentActivityProgramIndex { get; set; }
        [DisplayName("Project Code")]
        public string TreatmentActivityProjectCode { get; set; }
        [Required]
        [DisplayName("Status")]
        public int TreatmentActivityStatusID { get; set; }
        [DisplayName("Notes")]
        public string TreatmentActivityNotes { get; set; }
        [DisplayName("Total Footprint")]
        public decimal TreatmentActivityFootprintAcres { get; set; }
        [DisplayName("Chipping")]
        public decimal TreatmentActivityChippingAcres { get; set; }
        [DisplayName("Pruning")]
        public decimal TreatmentActivityPruningAcres { get; set; }
        [DisplayName("Thinning")]
        public decimal TreatmentActivityThinningAcres { get; set; }
        [DisplayName("Mastication")]
        public decimal TreatmentActivityMasticationAcres { get; set; }
        [DisplayName("Grazing")]
        public decimal TreatmentActivityGrazingAcres { get; set; }
        [DisplayName("Lop and Scatter")]
        public decimal TreatmentActivityLopAndScatterAcres { get; set; }
        [DisplayName("Biomass Removal")]
        public decimal TreatmentActivityBiomassRemovalAcres { get; set; }
        [DisplayName("Hand Pile")]
        public decimal TreatmentActivityHandPileAcres { get; set; }
        [DisplayName("Broadcast Burn")]
        public decimal TreatmentActivityBroadcastBurnAcres { get; set; }
        [DisplayName("Hand Pile Burn")]
        public decimal TreatmentActivityHandPileBurnAcres { get; set; }
        [DisplayName("Machine Pile Burn")]
        public decimal TreatmentActivityMachinePileBurnAcres { get; set; }
        [DisplayName("Other Treatment")]
        public decimal TreatmentActivityOtherTreatmentAcres { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditTreatmentActivityViewModel()
        {
        }

        public EditTreatmentActivityViewModel(Models.TreatmentActivity treatmentActivity)
        {
            TreatmentActivityID = treatmentActivity.TreatmentActivityID;
            TreatmentActivityContactID = treatmentActivity.TreatmentActivityContactID;
            TreatmentActivityStartDate = treatmentActivity.TreatmentActivityStartDate;
            TreatmentActivityEndDate = treatmentActivity.TreatmentActivityEndDate;
            TreatmentActivityProgramIndex = treatmentActivity.TreatmentActivityProgramIndex;
            TreatmentActivityProjectCode = treatmentActivity.TreatmentActivityProjectCode;
            TreatmentActivityStatusID = treatmentActivity.TreatmentActivityStatusID;
            TreatmentActivityNotes = treatmentActivity.TreatmentActivityNotes;
            TreatmentActivityFootprintAcres = treatmentActivity.TreatmentActivityFootprintAcres;
            TreatmentActivityChippingAcres = treatmentActivity.TreatmentActivityChippingAcres;
            TreatmentActivityPruningAcres = treatmentActivity.TreatmentActivityPruningAcres;
            TreatmentActivityThinningAcres = treatmentActivity.TreatmentActivityThinningAcres;
            TreatmentActivityMasticationAcres = treatmentActivity.TreatmentActivityMasticationAcres;
            TreatmentActivityGrazingAcres = treatmentActivity.TreatmentActivityGrazingAcres;
            TreatmentActivityLopAndScatterAcres = treatmentActivity.TreatmentActivityLopAndScatterAcres;
            TreatmentActivityBiomassRemovalAcres = treatmentActivity.TreatmentActivityBiomassRemovalAcres;
            TreatmentActivityHandPileAcres = treatmentActivity.TreatmentActivityHandPileAcres;
            TreatmentActivityBroadcastBurnAcres = treatmentActivity.TreatmentActivityBroadcastBurnAcres;
            TreatmentActivityHandPileBurnAcres = treatmentActivity.TreatmentActivityHandPileBurnAcres;
            TreatmentActivityMachinePileBurnAcres = treatmentActivity.TreatmentActivityMachinePileBurnAcres;
            TreatmentActivityOtherTreatmentAcres = treatmentActivity.TreatmentActivityOtherTreatmentAcres;

        }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TreatmentActivityEndDate != null && TreatmentActivityEndDate.Value < TreatmentActivityStartDate)
            {
                yield return new ValidationResult("End Date cannot be before Start Date");
            }
        }

        public void UpdateModel(Models.TreatmentActivity treatmentActivity, Models.Project project)
        {
            treatmentActivity.ProjectID = project.ProjectID;
            treatmentActivity.TreatmentActivityID = TreatmentActivityID;
            treatmentActivity.TreatmentActivityContactID = TreatmentActivityContactID;
            treatmentActivity.TreatmentActivityStartDate = TreatmentActivityStartDate;
            treatmentActivity.TreatmentActivityEndDate = TreatmentActivityEndDate;
            treatmentActivity.TreatmentActivityProgramIndex = TreatmentActivityProgramIndex;
            treatmentActivity.TreatmentActivityProjectCode = TreatmentActivityProjectCode;
            treatmentActivity.TreatmentActivityStatusID = TreatmentActivityStatusID;
            treatmentActivity.TreatmentActivityNotes = TreatmentActivityNotes;
            treatmentActivity.TreatmentActivityFootprintAcres = TreatmentActivityFootprintAcres;
            treatmentActivity.TreatmentActivityChippingAcres = TreatmentActivityChippingAcres;
            treatmentActivity.TreatmentActivityPruningAcres = TreatmentActivityPruningAcres;
            treatmentActivity.TreatmentActivityThinningAcres = TreatmentActivityThinningAcres;
            treatmentActivity.TreatmentActivityMasticationAcres = TreatmentActivityMasticationAcres;
            treatmentActivity.TreatmentActivityGrazingAcres = TreatmentActivityGrazingAcres;
            treatmentActivity.TreatmentActivityLopAndScatterAcres = TreatmentActivityLopAndScatterAcres;
            treatmentActivity.TreatmentActivityBiomassRemovalAcres = TreatmentActivityBiomassRemovalAcres;
            treatmentActivity.TreatmentActivityHandPileAcres = TreatmentActivityHandPileAcres;
            treatmentActivity.TreatmentActivityBroadcastBurnAcres = TreatmentActivityBroadcastBurnAcres;
            treatmentActivity.TreatmentActivityHandPileBurnAcres = TreatmentActivityHandPileBurnAcres;
            treatmentActivity.TreatmentActivityMachinePileBurnAcres = TreatmentActivityMachinePileBurnAcres;
            treatmentActivity.TreatmentActivityOtherTreatmentAcres = TreatmentActivityOtherTreatmentAcres;

            //HttpRequestStorage.DatabaseEntities.SaveChanges();
        }
    }
}