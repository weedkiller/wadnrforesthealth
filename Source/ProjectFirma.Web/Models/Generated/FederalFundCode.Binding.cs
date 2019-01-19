//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FederalFundCode]
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
    // Table [dbo].[FederalFundCode] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[FederalFundCode]")]
    public partial class FederalFundCode : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FederalFundCode()
        {
            this.GrantAllocations = new HashSet<GrantAllocation>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FederalFundCode(int federalFundCodeID, string federalFundCodeAbbrev) : this()
        {
            this.FederalFundCodeID = federalFundCodeID;
            this.FederalFundCodeAbbrev = federalFundCodeAbbrev;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FederalFundCode CreateNewBlank()
        {
            return new FederalFundCode();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return GrantAllocations.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FederalFundCode).Name, typeof(GrantAllocation).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            dbContext.FederalFundCodes.Remove(this);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in GrantAllocations.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int FederalFundCodeID { get; set; }
        public string FederalFundCodeAbbrev { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FederalFundCodeID; } set { FederalFundCodeID = value; } }

        public virtual ICollection<GrantAllocation> GrantAllocations { get; set; }

        public static class FieldLengths
        {
            public const int FederalFundCodeAbbrev = 10;
        }
    }
}