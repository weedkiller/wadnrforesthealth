//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationStagingUpdate]
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
    [Table("[dbo].[ProjectLocationStagingUpdate]")]
    public partial class ProjectLocationStagingUpdate : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectLocationStagingUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationStagingUpdate(int projectLocationStagingUpdateID, int projectUpdateBatchID, int personID, string featureClassName, string geoJson, string selectedProperty, bool shouldImport) : this()
        {
            this.ProjectLocationStagingUpdateID = projectLocationStagingUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.PersonID = personID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
            this.SelectedProperty = selectedProperty;
            this.ShouldImport = shouldImport;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationStagingUpdate(int projectUpdateBatchID, int personID, string featureClassName, string geoJson, bool shouldImport) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectLocationStagingUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.PersonID = personID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
            this.ShouldImport = shouldImport;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectLocationStagingUpdate(ProjectUpdateBatch projectUpdateBatch, int personID, string featureClassName, string geoJson, bool shouldImport) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationStagingUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectLocationStagingUpdates.Add(this);
            this.PersonID = personID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
            this.ShouldImport = shouldImport;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectLocationStagingUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch)
        {
            return new ProjectLocationStagingUpdate(projectUpdateBatch, default(int), default(string), default(string), default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectLocationStagingUpdate).Name};

        [Key]
        public int ProjectLocationStagingUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int PersonID { get; set; }
        public string FeatureClassName { get; set; }
        public string GeoJson { get; set; }
        public string SelectedProperty { get; set; }
        public bool ShouldImport { get; set; }
        public int PrimaryKey { get { return ProjectLocationStagingUpdateID; } set { ProjectLocationStagingUpdateID = value; } }

        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }

        public static class FieldLengths
        {
            public const int FeatureClassName = 255;
            public const int SelectedProperty = 255;
        }
    }
}