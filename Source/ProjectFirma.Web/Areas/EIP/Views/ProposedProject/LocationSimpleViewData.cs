﻿using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class LocationSimpleViewData : ProposedProjectViewData
    {
        public readonly EditProjectLocationSimpleViewData EditProjectLocationSimpleViewData;

        public LocationSimpleViewData(Person currentPerson,
            Models.ProposedProject proposedProject,
            ProposalSectionsStatus proposalSectionsStatus,
            EditProjectLocationSimpleViewData editProjectLocationSimpleViewData) : base(currentPerson, proposedProject, ProposedProjectSectionEnum.LocationSimple, proposalSectionsStatus)
        {
            EditProjectLocationSimpleViewData = editProjectLocationSimpleViewData;
        }
    }
}