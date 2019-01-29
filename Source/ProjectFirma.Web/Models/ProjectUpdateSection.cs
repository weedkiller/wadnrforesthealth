﻿using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.ProjectUpdate;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectUpdateSection
    {
        public abstract bool IsComplete(ProjectUpdateBatch projectUpdateBatch);
        public abstract string GetSectionUrl(Project project);
        public abstract bool SectionIsUpdated(UpdateStatus updateStatus);
        public virtual string GetProjectUpdateSectionDisplayName()
        {
            return ProjectUpdateSectionDisplayName;
        }
    }

    public partial class ProjectUpdateSectionBasics
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.AreProjectBasicsValid;
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Basics(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsBasicsUpdated;
        }
    }

    public partial class ProjectUpdateSectionProjectAttributes
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.AreProjectAttributesValid;
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ProjectAttributes(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsProjectAttributesUpdated;
        }
    }

    public partial class ProjectUpdateSectionLocationSimple
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.IsProjectLocationSimpleValid();
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationSimple(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsLocationSimpleUpdated;
        }
    }

    public partial class ProjectUpdateSectionLocationDetailed
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return true;
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationDetailed(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsLocationDetailUpdated;
        }
    }

    public partial class ProjectUpdateSectionRegions
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.IsProjectRegionValid();
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Regions(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsRegionsUpdated;
        }
    }

    public partial class ProjectUpdateSectionPriorityAreas
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.IsProjectPriorityAreaValid();
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.PriorityAreas(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsPriorityAreasUpdated;
        }
    }

    

    public partial class ProjectUpdateSectionPerformanceMeasures
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            // TODO Neutered Per WA DNR #1446. May decide to bring it back later
            //return projectUpdateBatch.ArePerformanceMeasuresValid();
            return true;
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.PerformanceMeasures(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsPerformanceMeasuresUpdated;
        }
    }

    public partial class ProjectUpdateSectionExpenditures
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.AreExpendituresValid();
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Expenditures(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsExpendituresUpdated;
        }
    }

    public partial class ProjectUpdateSectionPhotos
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return true;
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Photos(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsPhotosUpdated;
        }
    }

    public partial class ProjectUpdateSectionExternalLinks
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return true;
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExternalLinks(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsExternalLinksUpdated;
        }
    }

    public partial class ProjectUpdateSectionNotesAndDocuments
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return true;
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DocumentsAndNotes(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsNotesUpdated;
        }
    }

    public partial class ProjectUpdateSectionOrganizations
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.AreOrganizationsValid();
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Organizations(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsOrganizationsUpdated;
        }
    }

    public partial class ProjectUpdateSectionContacts
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.AreContactsValid();
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Contacts(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsContactsUpdated;
        }
    }

    public partial class ProjectUpdateSectionExpectedFunding
    {
        public override bool IsComplete(ProjectUpdateBatch projectUpdateBatch)
        {
            return true;
        }

        public override string GetSectionUrl(Project project)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            return ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID) ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpectedFunding(project)) : null;
        }

        public override bool SectionIsUpdated(UpdateStatus updateStatus)
        {
            return updateStatus.IsExpectedFundingUpdated;
        }
    }
}