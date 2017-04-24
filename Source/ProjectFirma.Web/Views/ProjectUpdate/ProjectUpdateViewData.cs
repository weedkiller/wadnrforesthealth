﻿/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public enum ProjectUpdateSectionEnum
    {
        Instructions,
        Basics,
        PerformanceMeasures,
        Expenditures,
        Photos,
        LocationSimple,
        LocationDetailed,
        Notes,
        History,
        Budgets,
        ExternalLinks
    }

    public class ProjectUpdateViewData : FirmaViewData
    {
        public readonly ProjectUpdateSectionEnum SelectedProjectUpdateSection;
        public readonly ProjectUpdateBatch ProjectUpdateBatch;
        public readonly Models.Project Project;
        public readonly string ProjectUpdateMyProjectsUrl;
        public readonly string ProjectUpdateInstructionsUrl;
        public readonly string ProjectUpdateBasicsUrl;
        public readonly string ProjectUpdatePerformanceMeasuresUrl;
        public readonly string ProjectUpdateExpendituresUrl;
        public readonly string ProjectUpdateBudgetsUrl;
        public readonly string ProjectUpdatePhotosUrl;
        public readonly string ProjectUpdateLocationSimpleUrl;
        public readonly string ProjectUpdateLocationDetailedUrl;
        public readonly string ProjectUpdateNotesUrl;
        public readonly string ProjectUpdateExternalLinksUrl;
        public readonly string ProjectUpdateHistoryUrl;
        public readonly string DeleteProjectUpdateUrl;
        public readonly string SubmitUrl;
        public readonly string ApproveUrl;
        public readonly string ReturnUrl;

        public readonly bool IsEditable;
        public readonly bool IsReadyToApprove;
        public readonly bool ShowApproveAndReturnButton;
        public readonly bool AreProjectBasicsValid;
        public readonly UpdateStatus UpdateStatus;
        public readonly bool HasUpdateStarted;

        public ProjectUpdateViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateSectionEnum selectedProjectUpdateSection, UpdateStatus updateStatus) : base(currentPerson, null)
        {
            SelectedProjectUpdateSection = selectedProjectUpdateSection;
            ProjectUpdateBatch = projectUpdateBatch;
            Project = ProjectUpdateBatch.Project;
            HtmlPageTitle += " - Project Updates";
            EntityName = string.Format("Project Update for Reporting Year: {0}", FirmaDateUtilities.CalculateCurrentYearToUseForReporting());
            PageTitle = Project.DisplayName;
            ProjectUpdateMyProjectsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate());
            ProjectUpdateInstructionsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Instructions(Project));
            ProjectUpdateBasicsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Basics(Project));
            ProjectUpdatePerformanceMeasuresUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.PerformanceMeasures(Project));
            ProjectUpdateExpendituresUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Expenditures(Project));
            ProjectUpdateBudgetsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Budgets(Project));
            ProjectUpdatePhotosUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Photos(Project));
            ProjectUpdateLocationSimpleUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationSimple(Project));
            ProjectUpdateLocationDetailedUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationDetailed(Project));
            ProjectUpdateExternalLinksUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExternalLinks(Project));
            ProjectUpdateNotesUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Notes(Project));
            ProjectUpdateHistoryUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.History(Project));
            DeleteProjectUpdateUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DeleteProjectUpdate(Project));
            SubmitUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Submit(Project));
            ApproveUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Approve(Project));
            ReturnUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Return(Project));
            var isApprover = new ProjectUpdateAdminFeature().HasPermissionByPerson(CurrentPerson);
            ShowApproveAndReturnButton = projectUpdateBatch.IsSubmitted && isApprover;
            IsEditable = projectUpdateBatch.InEditableState || ShowApproveAndReturnButton;
            IsReadyToApprove = projectUpdateBatch.IsReadyToApprove;
            AreProjectBasicsValid = projectUpdateBatch.AreProjectBasicsValid;

            //Neuter UpdateStatus for non-approver users until we go live with "Show Changes" for all users.
            UpdateStatus = CurrentPerson.IsApprover() ? updateStatus : new UpdateStatus(false, false, false, false, false, false, false, false, false);
            HasUpdateStarted = ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID);
        }
    }
}
