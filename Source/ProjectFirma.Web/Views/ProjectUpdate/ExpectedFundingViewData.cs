﻿/*-----------------------------------------------------------------------
<copyright file="ExpendituresViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectFunding;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpectedFundingViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public ProjectFundingDetailViewData ProjectFundingDetailViewData { get; set; }

        public readonly string RequestGrantAllocationUrl;
        public readonly ViewDataForAngularClass ViewDataForAngular;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        
        public ExpectedFundingViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ViewDataForAngularClass viewDataForAngularClass, ProjectFundingDetailViewData projectFundingDetailViewData, UpdateStatus updateStatus, ExpectedFundingValidationResult expectedFundingValidationResult)
            : base(currentPerson, projectUpdateBatch, updateStatus, expectedFundingValidationResult.GetWarningMessages(), ProjectUpdateSection.ExpectedFunding.ProjectUpdateSectionDisplayName)
        {
            ViewDataForAngular = viewDataForAngularClass;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpectedFunding(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpectedFunding(projectUpdateBatch.Project));
            RequestGrantAllocationUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingGrantAllocation());
            ProjectFundingDetailViewData = projectFundingDetailViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.ExpectedFundingComment, projectUpdateBatch.IsReturned);
            ValidationWarnings = expectedFundingValidationResult.GetWarningMessages();
        }

        public class ViewDataForAngularClass
        {
            public readonly List<GrantAllocationSimple> AllGrantAllocationSimples;
            // Actually a ProjectUpdateBatchID
            public readonly int ProjectID;
            public readonly decimal EstimatedTotalCost;
            public readonly decimal EstimatedIndirectCost;
            public readonly decimal EstimatedPersonnelAndBenefitsCost;
            public readonly decimal EstimatedSuppliesCost;
            public readonly decimal EstimatedTravelCost;

            public ViewDataForAngularClass(ProjectUpdateBatch projectUpdateBatch,
                List<GrantAllocationSimple> allGrantAllocationSimples,
                decimal estimatedTotalCost, decimal estimatedIndirectCost, decimal estimatedPersonnelAndBenefitsCost, decimal estimatedSuppliesCost, decimal estimatedTravelCost)
            {
                AllGrantAllocationSimples = allGrantAllocationSimples;
                ProjectID = projectUpdateBatch.ProjectUpdateBatchID;
                EstimatedTotalCost = estimatedTotalCost;
                EstimatedIndirectCost = estimatedIndirectCost;
                EstimatedPersonnelAndBenefitsCost = estimatedPersonnelAndBenefitsCost;
                EstimatedSuppliesCost = estimatedSuppliesCost;
                EstimatedTravelCost = estimatedTravelCost;

            }
        }
    }
}
