//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceExpenditureUpdate]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceExpenditureUpdate GetProjectFundingSourceExpenditureUpdate(this IQueryable<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, int projectFundingSourceExpenditureUpdateID)
        {
            var projectFundingSourceExpenditureUpdate = projectFundingSourceExpenditureUpdates.SingleOrDefault(x => x.ProjectFundingSourceExpenditureUpdateID == projectFundingSourceExpenditureUpdateID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceExpenditureUpdate, "ProjectFundingSourceExpenditureUpdate", projectFundingSourceExpenditureUpdateID);
            return projectFundingSourceExpenditureUpdate;
        }

        // Delete using an IDList (WADNR style)
        public static void DeleteProjectFundingSourceExpenditureUpdate(this IQueryable<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, List<int> projectFundingSourceExpenditureUpdateIDList)
        {
            if(projectFundingSourceExpenditureUpdateIDList.Any())
            {
                var projectFundingSourceExpenditureUpdatesInSourceCollectionToDelete = projectFundingSourceExpenditureUpdates.Where(x => projectFundingSourceExpenditureUpdateIDList.Contains(x.ProjectFundingSourceExpenditureUpdateID));
                foreach (var projectFundingSourceExpenditureUpdateToDelete in projectFundingSourceExpenditureUpdatesInSourceCollectionToDelete.ToList())
                {
                    projectFundingSourceExpenditureUpdateToDelete.Delete(HttpRequestStorage.DatabaseEntities);
                }
            }
        }

        // Delete using an object list (WADNR style)
        public static void DeleteProjectFundingSourceExpenditureUpdate(this IQueryable<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, ICollection<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdatesToDelete)
        {
            if(projectFundingSourceExpenditureUpdatesToDelete.Any())
            {
                var projectFundingSourceExpenditureUpdateIDList = projectFundingSourceExpenditureUpdatesToDelete.Select(x => x.ProjectFundingSourceExpenditureUpdateID).ToList();
                var projectFundingSourceExpenditureUpdatesToDeleteFromSourceList = projectFundingSourceExpenditureUpdates.Where(x => projectFundingSourceExpenditureUpdateIDList.Contains(x.ProjectFundingSourceExpenditureUpdateID)).ToList();

                foreach (var projectFundingSourceExpenditureUpdateToDelete in projectFundingSourceExpenditureUpdatesToDeleteFromSourceList)
                {
                    projectFundingSourceExpenditureUpdateToDelete.Delete(HttpRequestStorage.DatabaseEntities);
                }
            }
        }

        public static void DeleteProjectFundingSourceExpenditureUpdate(this IQueryable<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, int projectFundingSourceExpenditureUpdateID)
        {
            DeleteProjectFundingSourceExpenditureUpdate(projectFundingSourceExpenditureUpdates, new List<int> { projectFundingSourceExpenditureUpdateID });
        }

        public static void DeleteProjectFundingSourceExpenditureUpdate(this IQueryable<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, ProjectFundingSourceExpenditureUpdate projectFundingSourceExpenditureUpdateToDelete)
        {
            DeleteProjectFundingSourceExpenditureUpdate(projectFundingSourceExpenditureUpdates, new List<ProjectFundingSourceExpenditureUpdate> { projectFundingSourceExpenditureUpdateToDelete });
        }
    }
}