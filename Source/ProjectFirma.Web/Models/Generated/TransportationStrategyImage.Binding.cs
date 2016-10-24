//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationStrategyImage]
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
    [Table("[dbo].[TransportationStrategyImage]")]
    public partial class TransportationStrategyImage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransportationStrategyImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationStrategyImage(int transportationStrategyImageID, int transportationStrategyID, int fileResourceID) : this()
        {
            this.TransportationStrategyImageID = transportationStrategyImageID;
            this.TransportationStrategyID = transportationStrategyID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationStrategyImage(int transportationStrategyID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransportationStrategyImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TransportationStrategyID = transportationStrategyID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TransportationStrategyImage(TransportationStrategy transportationStrategy, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TransportationStrategyImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TransportationStrategyID = transportationStrategy.TransportationStrategyID;
            this.TransportationStrategy = transportationStrategy;
            transportationStrategy.TransportationStrategyImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.TransportationStrategyImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransportationStrategyImage CreateNewBlank(TransportationStrategy transportationStrategy, FileResource fileResource)
        {
            return new TransportationStrategyImage(transportationStrategy, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransportationStrategyImage).Name};

        [Key]
        public int TransportationStrategyImageID { get; set; }
        public int TransportationStrategyID { get; set; }
        public int FileResourceID { get; set; }
        public int PrimaryKey { get { return TransportationStrategyImageID; } set { TransportationStrategyImageID = value; } }

        public virtual TransportationStrategy TransportationStrategy { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}