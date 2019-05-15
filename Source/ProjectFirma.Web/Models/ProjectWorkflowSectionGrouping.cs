﻿using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.ProjectUpdate;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectWorkflowSectionGrouping
    {
        public abstract List<ProjectSectionSimple> GetProjectCreateSections(Project project, bool ignoreStatus);

        protected List<ProjectSectionSimple> GetProjectCreateSectionsImpl(Project project,
            List<ProjectCreateSection> projectCreateSections, bool ignoreStatus)
        {
            return projectCreateSections.Select(x => new ProjectSectionSimple(x, x.GetSectionUrl(project), !ignoreStatus && x.IsComplete(project), false, project != null && x.HasCompletionStatus)).OrderBy(x => x.SortOrder).ToList();
        }

        public abstract List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus, bool ignoreStatus);

        protected List<ProjectSectionSimple> GetProjectUpdateSectionsImpl(ProjectUpdateBatch projectUpdateBatch,
            List<ProjectUpdateSection> projectUpdateSections, UpdateStatus updateStatus, bool ignoreStatus)
        {
            return projectUpdateSections.Select(x => new ProjectSectionSimple(x, x.GetSectionUrl(projectUpdateBatch.Project), !ignoreStatus && x.IsComplete(projectUpdateBatch), updateStatus != null && x.SectionIsUpdated(updateStatus))).OrderBy(x => x.SortOrder).ToList();
        }
    }

    public partial class ProjectWorkflowSectionGroupingOverview
    {
        public override List<ProjectSectionSimple> GetProjectCreateSections(Project project, bool ignoreStatus)
        {
            return GetProjectCreateSectionsImpl(project, ProjectCreateSections, ignoreStatus);
        }

        public override List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus, bool ignoreStatus)
        {
            return GetProjectUpdateSectionsImpl(projectUpdateBatch, ProjectUpdateSections, updateStatus, ignoreStatus);
        }
    }

    public partial class ProjectWorkflowSectionGroupingLocation
    {
        public override List<ProjectSectionSimple> GetProjectCreateSections(Project project, bool ignoreStatus)
        {
            return GetProjectCreateSectionsImpl(project, ProjectCreateSections, ignoreStatus);
        }

        public override List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus, bool ignoreStatus)
        {
            return GetProjectUpdateSectionsImpl(projectUpdateBatch, ProjectUpdateSections, updateStatus, ignoreStatus);
        }
    }

    public partial class ProjectWorkflowSectionGroupingPerformanceMeasures
    {
        public override List<ProjectSectionSimple> GetProjectCreateSections(Project project, bool ignoreStatus)
        {
            // TODO Neutered Per WA DNR #1446. May decide to bring it back later
            //if (project != null && project.AreReportedPerformanceMeasuresRelevant())
            //{
            //    return GetProjectCreateSectionsImpl(project, ProjectCreateSections, ignoreStatus);
            //}

            return new List<ProjectSectionSimple>();
        }

        public override List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus, bool ignoreStatus)
        {
            // TODO Neutered Per WA DNR #1446. May decide to bring it back later
            //if (projectUpdateBatch.AreAccomplishmentsRelevant())
            //{
            //    return GetProjectUpdateSectionsImpl(projectUpdateBatch, ProjectUpdateSections, updateStatus, ignoreStatus);
            //}

            return new List<ProjectSectionSimple>();
        }
    }

    public partial class ProjectWorkflowSectionGroupingExpenditures
    {
        public override List<ProjectSectionSimple> GetProjectCreateSections(Project project, bool ignoreStatus)
        {
            // 5/15/2019 TK - WADNR may need this in phase 2. Removed this from the except because entry is removed from DB ", ProjectCreateSection.ReportedExpenditures"
            var projectCreateSections = ProjectCreateSections.Except(new List<ProjectCreateSection> { ProjectCreateSection.ExpectedFunding }).ToList();
            if (project != null && project.IsExpectedFundingRelevant())
            {
                projectCreateSections.Add(ProjectCreateSection.ExpectedFunding);
            }

            //if (project != null && project.AreReportedExpendituresRelevant())
            //{
            //    projectCreateSections.Add(ProjectCreateSection.ReportedExpenditures);
            //}
            return GetProjectCreateSectionsImpl(project, projectCreateSections, ignoreStatus);
        }

        public override List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            UpdateStatus updateStatus, bool ignoreStatus)
        {
            var projectUpdateSections = ProjectUpdateSections.Except(new List<ProjectUpdateSection> { ProjectUpdateSection.ExpectedFunding }).ToList();
            if (projectUpdateBatch.Project.IsExpectedFundingRelevant())
            {
                projectUpdateSections.Add(ProjectUpdateSection.ExpectedFunding);
            }

            return GetProjectUpdateSectionsImpl(projectUpdateBatch, projectUpdateSections, updateStatus, ignoreStatus);
        }
    }

    public partial class ProjectWorkflowSectionGroupingAdditionalData
    {
        public override List<ProjectSectionSimple> GetProjectCreateSections(Project project, 
                                                                            bool ignoreStatus)
        {
            return GetProjectCreateSectionsImpl(project, ProjectCreateSections, ignoreStatus);
        }

        public override List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
                                                                            UpdateStatus updateStatus, 
                                                                            bool ignoreStatus)
        {
            return GetProjectUpdateSectionsImpl(projectUpdateBatch, ProjectUpdateSections, updateStatus, ignoreStatus);
        }
    }
}