//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPageImage]
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
    // Table [dbo].[CustomPageImage] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[CustomPageImage]")]
    public partial class CustomPageImage : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CustomPageImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CustomPageImage(int customPageImageID, int customPageID, int fileResourceID) : this()
        {
            this.CustomPageImageID = customPageImageID;
            this.CustomPageID = customPageID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CustomPageImage(int customPageID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CustomPageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CustomPageID = customPageID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CustomPageImage(CustomPage customPage, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CustomPageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CustomPageID = customPage.CustomPageID;
            this.CustomPage = customPage;
            customPage.CustomPageImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.CustomPageImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CustomPageImage CreateNewBlank(CustomPage customPage, FileResource fileResource)
        {
            return new CustomPageImage(customPage, fileResource);
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CustomPageImage).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.CustomPageImages.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int CustomPageImageID { get; set; }
        public int CustomPageID { get; set; }
        public int FileResourceID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CustomPageImageID; } set { CustomPageImageID = value; } }

        public virtual CustomPage CustomPage { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}