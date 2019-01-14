//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TreatmentType]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[TreatmentType]")]
    public partial class TreatmentType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TreatmentType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TreatmentType(int treatmentTypeID, string treatmentTypeName, string treatmentTypeDisplayName) : this()
        {
            this.TreatmentTypeID = treatmentTypeID;
            this.TreatmentTypeName = treatmentTypeName;
            this.TreatmentTypeDisplayName = treatmentTypeDisplayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TreatmentType(string treatmentTypeName, string treatmentTypeDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TreatmentTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TreatmentTypeName = treatmentTypeName;
            this.TreatmentTypeDisplayName = treatmentTypeDisplayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TreatmentType CreateNewBlank()
        {
            return new TreatmentType(default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TreatmentType).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.TreatmentTypes.Remove(this);
        }

        [Key]
        public int TreatmentTypeID { get; set; }
        public string TreatmentTypeName { get; set; }
        public string TreatmentTypeDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TreatmentTypeID; } set { TreatmentTypeID = value; } }



        public static class FieldLengths
        {
            public const int TreatmentTypeName = 50;
            public const int TreatmentTypeDisplayName = 50;
        }
    }
}