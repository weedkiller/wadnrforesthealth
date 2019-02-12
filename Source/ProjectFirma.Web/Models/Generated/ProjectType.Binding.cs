//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectType]
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
    // Table [dbo].[ProjectType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ProjectType]")]
    public partial class ProjectType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectType()
        {
            this.Projects = new HashSet<Project>();
            this.ProjectTypePerformanceMeasures = new HashSet<ProjectTypePerformanceMeasure>();
            this.ProjectTypeProjectCustomAttributeTypes = new HashSet<ProjectTypeProjectCustomAttributeType>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectType(int projectTypeID, int taxonomyBranchID, string projectTypeName, string projectTypeDescription, string projectTypeCode, string themeColor, int? projectTypeSortOrder) : this()
        {
            this.ProjectTypeID = projectTypeID;
            this.TaxonomyBranchID = taxonomyBranchID;
            this.ProjectTypeName = projectTypeName;
            this.ProjectTypeDescription = projectTypeDescription;
            this.ProjectTypeCode = projectTypeCode;
            this.ThemeColor = themeColor;
            this.ProjectTypeSortOrder = projectTypeSortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectType(int taxonomyBranchID, string projectTypeName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyBranchID = taxonomyBranchID;
            this.ProjectTypeName = projectTypeName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectType(TaxonomyBranch taxonomyBranch, string projectTypeName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyBranchID = taxonomyBranch.TaxonomyBranchID;
            this.TaxonomyBranch = taxonomyBranch;
            taxonomyBranch.ProjectTypes.Add(this);
            this.ProjectTypeName = projectTypeName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectType CreateNewBlank(TaxonomyBranch taxonomyBranch)
        {
            return new ProjectType(taxonomyBranch, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Projects.Any() || ProjectTypePerformanceMeasures.Any() || ProjectTypeProjectCustomAttributeTypes.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectType).Name, typeof(Project).Name, typeof(ProjectTypePerformanceMeasure).Name, typeof(ProjectTypeProjectCustomAttributeType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ProjectTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in Projects.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectTypePerformanceMeasures.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectTypeProjectCustomAttributeTypes.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectTypeID { get; set; }
        public int TaxonomyBranchID { get; set; }
        public string ProjectTypeName { get; set; }
        public string ProjectTypeDescription { get; set; }
        [NotMapped]
        public HtmlString ProjectTypeDescriptionHtmlString
        { 
            get { return ProjectTypeDescription == null ? null : new HtmlString(ProjectTypeDescription); }
            set { ProjectTypeDescription = value?.ToString(); }
        }
        public string ProjectTypeCode { get; set; }
        public string ThemeColor { get; set; }
        public int? ProjectTypeSortOrder { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectTypeID; } set { ProjectTypeID = value; } }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ProjectTypePerformanceMeasure> ProjectTypePerformanceMeasures { get; set; }
        public virtual ICollection<ProjectTypeProjectCustomAttributeType> ProjectTypeProjectCustomAttributeTypes { get; set; }
        public virtual TaxonomyBranch TaxonomyBranch { get; set; }

        public static class FieldLengths
        {
            public const int ProjectTypeName = 100;
            public const int ProjectTypeCode = 10;
            public const int ThemeColor = 7;
        }
    }
}