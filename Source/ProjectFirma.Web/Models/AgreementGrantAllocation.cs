﻿using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public partial class AgreementGrantAllocation : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get { return this.GrantAllocation != null ? this.GrantAllocation.ProjectName : "NullGrantAllocation"; }
        }

        public AgreementGrantAllocation(Agreement agreement, GrantAllocation grantAllocation) : this(agreement, grantAllocation, grantAllocation.Grant)
        {
            // Invariant
            EnsureGrantIDsAlign();
        }

        /// <summary>
        /// Invariant
        /// </summary>
        public void EnsureGrantIDsAlign()
        {
            Check.Ensure(GrantAllocation.Grant.GrantID == Agreement.GrantID, $"GrantIDs must align. Agreement GrantID: {Agreement.GrantID} GrantAllocation GrantID: {GrantAllocation.Grant.GrantID}");
        }

        public static List<AgreementGrantAllocation> OrderAgreementGrantAllocationsByYearPrefixedGrantNumbersThenEverythingElse(List<AgreementGrantAllocation> agreementGrantAllocations)
        {
            var interiorGrantAllocations = agreementGrantAllocations.Select(aga => aga.GrantAllocation).ToList();
            var interiorGrantAllocationInProperOrder = GrantAllocation.OrderGrantAllocationsByYearPrefixedGrantNumbersThenEverythingElse(interiorGrantAllocations);

            List<AgreementGrantAllocation> outgoingAgreementGrantAllocations = new List<AgreementGrantAllocation>();
            foreach (var grantAllocation in interiorGrantAllocationInProperOrder)
            {
                var currentSubset = agreementGrantAllocations.Where(aga => aga.GrantAllocationID == grantAllocation.GrantAllocationID).ToList();
                outgoingAgreementGrantAllocations.AddRange(currentSubset);
            }

            return outgoingAgreementGrantAllocations;
        }
    }
}