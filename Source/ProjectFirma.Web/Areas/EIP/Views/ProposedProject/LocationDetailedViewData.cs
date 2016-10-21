﻿using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class LocationDetailedViewData : ProposedProjectViewData
    {
        public readonly ProjectLocationDetailViewData ProjectLocationDetailViewData;

        public LocationDetailedViewData(Person currentPerson,
            Models.ProposedProject proposedProject,
            ProposalSectionsStatus proposalSectionsStatus,
            ProjectLocationDetailViewData projectLocationDetailViewData)
            : base(currentPerson, proposedProject, ProposedProjectSectionEnum.LocationDetailed, proposalSectionsStatus)
        {
            ProjectLocationDetailViewData = projectLocationDetailViewData;
        }
    }
}