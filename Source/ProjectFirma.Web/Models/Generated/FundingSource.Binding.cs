//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSource]
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
    [Table("[dbo].[FundingSource]")]
    public partial class FundingSource : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FundingSource()
        {
            this.ProjectBudgets = new HashSet<ProjectBudget>();
            this.ProjectBudgetUpdates = new HashSet<ProjectBudgetUpdate>();
            this.ProjectFundingSourceExpenditures = new HashSet<ProjectFundingSourceExpenditure>();
            this.ProjectFundingSourceExpenditureUpdates = new HashSet<ProjectFundingSourceExpenditureUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSource(int fundingSourceID, int organizationID, string fundingSourceName, bool isActive, string fundingSourceDescription) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.FundingSourceID = fundingSourceID;
            this.OrganizationID = organizationID;
            this.FundingSourceName = fundingSourceName;
            this.IsActive = isActive;
            this.FundingSourceDescription = fundingSourceDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSource(int organizationID, string fundingSourceName, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.OrganizationID = organizationID;
            this.FundingSourceName = fundingSourceName;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FundingSource(Organization organization, string fundingSourceName, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.Tenant = HttpRequestStorage.Tenant;
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.FundingSources.Add(this);
            this.FundingSourceName = fundingSourceName;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FundingSource CreateNewBlank(Organization organization)
        {
            return new FundingSource(organization, default(string), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectBudgets.Any() || ProjectBudgetUpdates.Any() || ProjectFundingSourceExpenditures.Any() || ProjectFundingSourceExpenditureUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FundingSource).Name, typeof(ProjectBudget).Name, typeof(ProjectBudgetUpdate).Name, typeof(ProjectFundingSourceExpenditure).Name, typeof(ProjectFundingSourceExpenditureUpdate).Name};

        [Key]
        public int FundingSourceID { get; set; }
        public int OrganizationID { get; set; }
        public string FundingSourceName { get; set; }
        public bool IsActive { get; set; }
        public string FundingSourceDescription { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return FundingSourceID; } set { FundingSourceID = value; } }

        public virtual ICollection<ProjectBudget> ProjectBudgets { get; set; }
        public virtual ICollection<ProjectBudgetUpdate> ProjectBudgetUpdates { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditureUpdate> ProjectFundingSourceExpenditureUpdates { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {
            public const int FundingSourceName = 200;
            public const int FundingSourceDescription = 500;
        }
    }
}