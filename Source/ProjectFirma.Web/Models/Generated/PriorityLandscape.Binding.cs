//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PriorityLandscape]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    // Table [dbo].[PriorityLandscape] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[PriorityLandscape]")]
    public partial class PriorityLandscape : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PriorityLandscape()
        {
            this.ProjectPriorityLandscapes = new HashSet<ProjectPriorityLandscape>();
            this.ProjectPriorityLandscapeUpdates = new HashSet<ProjectPriorityLandscapeUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PriorityLandscape(int priorityLandscapeID, string priorityLandscapeName, DbGeometry priorityLandscapeLocation) : this()
        {
            this.PriorityLandscapeID = priorityLandscapeID;
            this.PriorityLandscapeName = priorityLandscapeName;
            this.PriorityLandscapeLocation = priorityLandscapeLocation;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PriorityLandscape(string priorityLandscapeName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PriorityLandscapeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PriorityLandscapeName = priorityLandscapeName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PriorityLandscape CreateNewBlank()
        {
            return new PriorityLandscape(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectPriorityLandscapes.Any() || ProjectPriorityLandscapeUpdates.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(ProjectPriorityLandscapes.Any())
            {
                dependentObjects.Add(typeof(ProjectPriorityLandscape).Name);
            }

            if(ProjectPriorityLandscapeUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectPriorityLandscapeUpdate).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PriorityLandscape).Name, typeof(ProjectPriorityLandscape).Name, typeof(ProjectPriorityLandscapeUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.PriorityLandscapes.Remove(this);
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

            foreach(var x in ProjectPriorityLandscapes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectPriorityLandscapeUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PriorityLandscapeID { get; set; }
        public string PriorityLandscapeName { get; set; }
        public DbGeometry PriorityLandscapeLocation { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PriorityLandscapeID; } set { PriorityLandscapeID = value; } }

        public virtual ICollection<ProjectPriorityLandscape> ProjectPriorityLandscapes { get; set; }
        public virtual ICollection<ProjectPriorityLandscapeUpdate> ProjectPriorityLandscapeUpdates { get; set; }

        public static class FieldLengths
        {
            public const int PriorityLandscapeName = 100;
        }
    }
}