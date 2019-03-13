﻿/*-----------------------------------------------------------------------
<copyright file="ProposalSectionsStatus.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.ProjectPriorityArea;
using ProjectFirma.Web.Views.ProjectRegion;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ProposalSectionsStatus
    {
        public bool IsBasicsSectionComplete { get; set; }
        public bool IsCustomAttributesSectionComplete { get; set; }
        public bool IsPerformanceMeasureSectionComplete { get; set; }
        public bool IsProjectLocationSimpleSectionComplete { get; set; }
        public bool IsProjectLocationDetailedSectionComplete { get; set; }
        public bool IsClassificationsComplete { get; set; }
        public bool IsNotesSectionComplete { get; set; }

        public static bool AreAllSectionsValidForProject(Models.Project project)
        {
            return Models.Project.GetApplicableProposalWizardSections(project, false).All(x => x.IsComplete);
        }
        public bool IsExpectedFundingSectionComplete { get; set; }
        public bool IsProjectOrganizationsSectionComplete { get; set; }
        public bool IsProjectContactsSectionComplete { get; set; }
        public bool IsRegionSectionComplete { get; set; }
        public bool IsPriorityAreaSectionComplete { get; set; }

        public ProposalSectionsStatus(Models.Project project)
        {
            var basicsResults = new BasicsViewModel(project).GetValidationResults();
            IsBasicsSectionComplete = !basicsResults.Any();

            var customAttributeResults = new CustomAttributesViewModel(project).GetValidationResults();
            IsCustomAttributesSectionComplete = !customAttributeResults.Any();

            var locationSimpleValidationResults = new LocationSimpleViewModel(project).GetValidationResults();
            IsProjectLocationSimpleSectionComplete = !locationSimpleValidationResults.Any();

            IsProjectLocationDetailedSectionComplete = IsBasicsSectionComplete;

            var regionIDs = project.ProjectRegions
                .Select(x => x.RegionID).ToList();
            var editProjectRegionsValidationResults = new EditProjectRegionsViewModel(regionIDs,
                    project.NoRegionsExplanation).GetValidationResults();

            IsRegionSectionComplete = !editProjectRegionsValidationResults.Any();

            var priorityAreaIDs = project.ProjectPriorityAreas
                .Select(x => x.PriorityAreaID).ToList();
            var editProjectPriorityAreasValidationResults = new EditProjectPriorityAreasViewModel(priorityAreaIDs,
                    project.NoPriorityAreasExplanation).GetValidationResults();

            IsPriorityAreaSectionComplete = !editProjectPriorityAreasValidationResults.Any();

            var performanceMeasureValidationResults =
                new ExpectedPerformanceMeasureValuesViewModel(project).GetValidationResults();
            IsPerformanceMeasureSectionComplete = !performanceMeasureValidationResults.Any();

            var efValidationResults = new ExpectedFundingViewModel(project.ProjectFundingSourceRequests.ToList(),
                    project.EstimatedTotalCost, project.EstimatedIndirectCost, project.EstimatedPersonnelAndBenefitsCost, project.EstimatedSuppliesCost, project.EstimatedTravelCost)
                .GetValidationResults();
            IsExpectedFundingSectionComplete = !efValidationResults.Any();

            var proposalClassificationSimples = ProjectCreateController.GetProjectClassificationSimples(project);
            var classificationValidationResults =
                new EditProposalClassificationsViewModel(proposalClassificationSimples).GetValidationResults();
            IsClassificationsComplete = !classificationValidationResults.Any();

            IsNotesSectionComplete = IsBasicsSectionComplete; //there is no validation required on Notes
        }

        public ProposalSectionsStatus()
        {
            IsBasicsSectionComplete = false;
            IsPerformanceMeasureSectionComplete = false;
            IsClassificationsComplete = false;
            IsProjectLocationSimpleSectionComplete = false;
            IsProjectLocationDetailedSectionComplete = false;
            IsRegionSectionComplete = false;
            IsPriorityAreaSectionComplete = false;
            IsNotesSectionComplete = false;
        }
    }
}
