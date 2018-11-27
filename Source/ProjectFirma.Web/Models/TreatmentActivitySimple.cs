﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class TreatmentActivitySimple
    {
        public int? TreatmentActivityID { get; set; }

        [Required(ErrorMessage="Project is required.")]
        public int? ProjectID { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DisplayName("Start Date")]
        public DateTime? TreatmentActivityStartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? TreatmentActivityEndDate { get; set; }

        [Required(ErrorMessage = "Acres Treated is required.")]
        public decimal? TreatmentActivityAcresTreated { get; set; }

        public string TreatmentActivityNotes { get; set; }

        [Required(ErrorMessage = "Treatment Type is required.")]
        public int? TreatmentActivityTypeID { get; set; }
        
        // Needed by ModelBinder
        public TreatmentActivitySimple()
        {

        }

        public TreatmentActivitySimple(TreatmentActivity y)
        {
            TreatmentActivityID = y.TreatmentActivityID;
            TreatmentActivityEndDate = y.TreatmentActivityEndDate;
            TreatmentActivityNotes = y.TreatmentActivityNotes;
            TreatmentActivityStartDate = y.TreatmentActivityStartDate;
            TreatmentActivityTypeID = y.TreatmentActivityTypeID;
            TreatmentActivityAcresTreated = y.TreatmentActivityAcresTreated;
            ProjectID = y.ProjectID;
        }

        public TreatmentActivity ToTreatmentActivity()
        {
            // None of the nullables will ever default, thanks to RequiredAttribute
            return new TreatmentActivity(TreatmentActivityID.GetValueOrDefault(), ProjectID.GetValueOrDefault(), TreatmentActivityTypeID.GetValueOrDefault(), TreatmentActivityAcresTreated.GetValueOrDefault(), TreatmentActivityStartDate.GetValueOrDefault(),TreatmentActivityEndDate, TreatmentActivityNotes);
        }
    }
}
