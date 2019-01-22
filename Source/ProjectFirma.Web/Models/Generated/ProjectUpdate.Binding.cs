//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdate]
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
    // Table [dbo].[ProjectUpdate] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ProjectUpdate]")]
    public partial class ProjectUpdate : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdate(int projectUpdateID, int projectUpdateBatchID, int projectStageID, string projectDescription, DateTime? approvalStartDate, DateTime? completionDate, decimal? estimatedTotalCost, DbGeometry projectLocationPoint, string projectLocationNotes, DateTime? plannedDate, int projectLocationSimpleTypeID, int? primaryContactPersonID, int? focusAreaID) : this()
        {
            this.ProjectUpdateID = projectUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectStageID = projectStageID;
            this.ProjectDescription = projectDescription;
            this.ApprovalStartDate = approvalStartDate;
            this.CompletionDate = completionDate;
            this.EstimatedTotalCost = estimatedTotalCost;
            this.ProjectLocationPoint = projectLocationPoint;
            this.ProjectLocationNotes = projectLocationNotes;
            this.PlannedDate = plannedDate;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.PrimaryContactPersonID = primaryContactPersonID;
            this.FocusAreaID = focusAreaID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdate(int projectUpdateBatchID, int projectStageID, string projectDescription, int projectLocationSimpleTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectStageID = projectStageID;
            this.ProjectDescription = projectDescription;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectUpdate(ProjectUpdateBatch projectUpdateBatch, ProjectStage projectStage, string projectDescription, ProjectLocationSimpleType projectLocationSimpleType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            this.ProjectStageID = projectStage.ProjectStageID;
            this.ProjectDescription = projectDescription;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleType.ProjectLocationSimpleTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, ProjectStage projectStage, ProjectLocationSimpleType projectLocationSimpleType)
        {
            return new ProjectUpdate(projectUpdateBatch, projectStage, default(string), projectLocationSimpleType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectUpdate).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.ProjectUpdates.Remove(this);
        }

        [Key]
        public int ProjectUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int ProjectStageID { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime? ApprovalStartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public decimal? EstimatedTotalCost { get; set; }
        public DbGeometry ProjectLocationPoint { get; set; }
        public string ProjectLocationNotes { get; set; }
        public DateTime? PlannedDate { get; set; }
        public int ProjectLocationSimpleTypeID { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public int? FocusAreaID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectUpdateID; } set { ProjectUpdateID = value; } }

        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public ProjectStage ProjectStage { get { return ProjectStage.AllLookupDictionary[ProjectStageID]; } }
        public ProjectLocationSimpleType ProjectLocationSimpleType { get { return ProjectLocationSimpleType.AllLookupDictionary[ProjectLocationSimpleTypeID]; } }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual FocusArea FocusArea { get; set; }

        public static class FieldLengths
        {
            public const int ProjectDescription = 4000;
            public const int ProjectLocationNotes = 4000;
        }
    }
}