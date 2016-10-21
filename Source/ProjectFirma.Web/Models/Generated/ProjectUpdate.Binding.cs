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
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ProjectUpdate]")]
    public partial class ProjectUpdate : IHavePrimaryKey
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
        public ProjectUpdate(int projectUpdateID, int projectUpdateBatchID, int projectStageID, string projectDescription, int? implementationStartYear, int? completionYear, decimal? estimatedTotalCost, decimal? securedFunding, DbGeometry projectLocationPoint, int? projectLocationAreaID, string projectLocationNotes, int? planningDesignStartYear, int projectLocationSimpleTypeID, decimal? estimatedAnnualOperatingCost) : this()
        {
            this.ProjectUpdateID = projectUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectStageID = projectStageID;
            this.ProjectDescription = projectDescription;
            this.ImplementationStartYear = implementationStartYear;
            this.CompletionYear = completionYear;
            this.EstimatedTotalCost = estimatedTotalCost;
            this.SecuredFunding = securedFunding;
            this.ProjectLocationPoint = projectLocationPoint;
            this.ProjectLocationAreaID = projectLocationAreaID;
            this.ProjectLocationNotes = projectLocationNotes;
            this.PlanningDesignStartYear = planningDesignStartYear;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.EstimatedAnnualOperatingCost = estimatedAnnualOperatingCost;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdate(int projectUpdateBatchID, int projectStageID, string projectDescription, int projectLocationSimpleTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
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

        [Key]
        public int ProjectUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int ProjectStageID { get; set; }
        public string ProjectDescription { get; set; }
        public int? ImplementationStartYear { get; set; }
        public int? CompletionYear { get; set; }
        public decimal? EstimatedTotalCost { get; set; }
        public decimal? SecuredFunding { get; set; }
        public DbGeometry ProjectLocationPoint { get; set; }
        public int? ProjectLocationAreaID { get; set; }
        public string ProjectLocationNotes { get; set; }
        public int? PlanningDesignStartYear { get; set; }
        public int ProjectLocationSimpleTypeID { get; set; }
        public decimal? EstimatedAnnualOperatingCost { get; set; }
        public int PrimaryKey { get { return ProjectUpdateID; } set { ProjectUpdateID = value; } }

        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public ProjectStage ProjectStage { get { return ProjectStage.AllLookupDictionary[ProjectStageID]; } }
        public virtual ProjectLocationArea ProjectLocationArea { get; set; }
        public ProjectLocationSimpleType ProjectLocationSimpleType { get { return ProjectLocationSimpleType.AllLookupDictionary[ProjectLocationSimpleTypeID]; } }

        public static class FieldLengths
        {
            public const int ProjectDescription = 4000;
            public const int ProjectLocationNotes = 4000;
        }
    }
}