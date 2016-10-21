﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class BasicsViewData : ProposedProjectViewData
    {
        public IEnumerable<SelectListItem> ActionPriorities;
        public IEnumerable<SelectListItem> Organizations;
        public IEnumerable<SelectListItem> FundingTypes;
        public IEnumerable<Models.TransportationObjective> TransportationObjectives;
        public IEnumerable<SelectListItem> StartYearRange;
        public IEnumerable<SelectListItem> CompletionYearRange;

        public BasicsViewData(Person currentPerson, IEnumerable<Organization> organizations, IEnumerable<FundingType> fundingTypes, IEnumerable<Models.TransportationObjective> transportationObjectives, IEnumerable<Models.ActionPriority> actionPriorities)
            : base(currentPerson, ProposedProjectSectionEnum.Basics)
        {
            AssignParameters(actionPriorities, organizations, fundingTypes, transportationObjectives);
        }

        public BasicsViewData(Person currentPerson,
            Models.ProposedProject proposedProject,
            ProposalSectionsStatus proposalSectionsStatus,
            IEnumerable<Organization> organizations,
            IEnumerable<FundingType> fundingTypes, IEnumerable<Models.TransportationObjective> transportationObjectives, IEnumerable<Models.ActionPriority> actionPriorities)
            : base(currentPerson, proposedProject, ProposedProjectSectionEnum.Basics, proposalSectionsStatus)
        {
            AssignParameters(actionPriorities, organizations, fundingTypes, transportationObjectives);
        }

        private void AssignParameters(IEnumerable<Models.ActionPriority> actionPriorities, IEnumerable<Organization> organizations, IEnumerable<FundingType> fundingTypes, IEnumerable<Models.TransportationObjective> transportationObjectives)
        {
            ActionPriorities = actionPriorities.ToList().OrderBy(ap => ap.DisplayName).ToList().ToGroupedSelectList();
            Organizations = organizations.ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), y => y.DisplayName);

            TransportationObjectives = transportationObjectives;
            
            FundingTypes = fundingTypes.ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            StartYearRange =
                ProjectFirmaDateUtilities.GetRangeOfYears(ProjectFirmaDateUtilities.MinimumYearForReporting, DateTime.Now.Year + ProjectFirmaDateUtilities.YearsBeyondPresentForMaximumYearForUserInput)
                    .ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            CompletionYearRange = ProjectFirmaDateUtilities.FutureYearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
        }
    }
}