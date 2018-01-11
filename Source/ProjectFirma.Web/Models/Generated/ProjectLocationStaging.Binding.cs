//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationStaging]
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
    [Table("[dbo].[ProjectLocationStaging]")]
    public partial class ProjectLocationStaging : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectLocationStaging()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationStaging(int projectLocationStagingID, int projectID, int personID, string featureClassName, string geoJson, string selectedProperty, bool shouldImport) : this()
        {
            this.ProjectLocationStagingID = projectLocationStagingID;
            this.ProjectID = projectID;
            this.PersonID = personID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
            this.SelectedProperty = selectedProperty;
            this.ShouldImport = shouldImport;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationStaging(int projectID, int personID, string featureClassName, string geoJson, bool shouldImport) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationStagingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.PersonID = personID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
            this.ShouldImport = shouldImport;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectLocationStaging(Project project, Person person, string featureClassName, string geoJson, bool shouldImport) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationStagingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectLocationStagings.Add(this);
            this.PersonID = person.PersonID;
            this.Person = person;
            person.ProjectLocationStagings.Add(this);
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
            this.ShouldImport = shouldImport;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectLocationStaging CreateNewBlank(Project project, Person person)
        {
            return new ProjectLocationStaging(project, person, default(string), default(string), default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectLocationStaging).Name};

        [Key]
        public int ProjectLocationStagingID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public int PersonID { get; set; }
        public string FeatureClassName { get; set; }
        public string GeoJson { get; set; }
        public string SelectedProperty { get; set; }
        public bool ShouldImport { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectLocationStagingID; } set { ProjectLocationStagingID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Person Person { get; set; }

        public static class FieldLengths
        {
            public const int FeatureClassName = 255;
            public const int SelectedProperty = 255;
        }
    }
}