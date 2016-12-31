﻿using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class DetailViewData : ProposedProjectViewData
    {
        public readonly string EditProposedProjectUrl;
        public readonly string EditMapUrl;
        public readonly string ApproveProjectUrl;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly string ProposedProjectsUrl;
        public readonly string EditClassificationsUrl;

        public readonly string ActiveProjectsListUrl;

        public readonly string MapFormID;
        public readonly string EditPerformanceMeasureExpectedsUrl;
        public readonly PerformanceMeasureExpectedSummaryViewData PerformanceMeasureExpectedSummaryViewData;

        public readonly AuditLogsGridSpec AuditLogsGridSpec;
        public readonly string AuditLogsGridName;
        public readonly string AuditLogsGridDataUrl;
        public readonly EntityNotesViewData EntityNotesViewData;

        public readonly ImageGalleryViewData ImageGalleryViewData;

        public AssessmentTreeViewData AssessmentTreeViewData;

        public DetailViewData(Person currentPerson, Models.ProposedProject proposedProject, ProjectLocationSummaryViewData projectLocationSummaryViewData, PerformanceMeasureExpectedSummaryViewData performanceMeasureExpectedSummaryViewData, ImageGalleryViewData imageGalleryViewData, EntityNotesViewData entityNotesViewData, string mapFormID, AssessmentTreeViewData assessmentTreeViewData) : base(currentPerson, proposedProject, ProposedProjectSectionEnum.Basics, new ProposalSectionsStatus(proposedProject))
        {
            PageTitle = proposedProject.DisplayName;
            BreadCrumbTitle = "Proposed Project Detail";
            MapFormID = mapFormID;

            ActiveProjectsListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.ActiveProjectsList());
            EditProposedProjectUrl = proposedProject.GetEditUrl();
            EditMapUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationSimple(proposedProject));
            ApproveProjectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Approve(proposedProject));
            EditPerformanceMeasureExpectedsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditExpectedPerformanceMeasureValues(proposedProject));
            ProposedProjectsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Index());
            EditClassificationsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(c => c.EditClassifications(proposedProject));

            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            PerformanceMeasureExpectedSummaryViewData = performanceMeasureExpectedSummaryViewData;
            ImageGalleryViewData = imageGalleryViewData;
            EntityNotesViewData = entityNotesViewData;

            AuditLogsGridSpec = new AuditLogsGridSpec() {ObjectNameSingular = "Change", ObjectNamePlural = "Changes", SaveFiltersInCookie = true};
            AuditLogsGridName = "proposedProjectAuditLogsGrid";
            AuditLogsGridDataUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(tc => tc.AuditLogsGridJsonData(proposedProject));

            AssessmentTreeViewData = assessmentTreeViewData;
        }
    }
}