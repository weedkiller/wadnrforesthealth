//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TreatmentActivity]
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
        public static TreatmentActivity GetTreatmentActivity(this IQueryable<TreatmentActivity> treatmentActivities, int treatmentActivityID)
        {
            var treatmentActivity = treatmentActivities.SingleOrDefault(x => x.TreatmentActivityID == treatmentActivityID);
            Check.RequireNotNullThrowNotFound(treatmentActivity, "TreatmentActivity", treatmentActivityID);
            return treatmentActivity;
        }

        public static void DeleteTreatmentActivity(this IQueryable<TreatmentActivity> treatmentActivities, List<int> treatmentActivityIDList)
        {
            if(treatmentActivityIDList.Any())
            {
                treatmentActivities.Where(x => treatmentActivityIDList.Contains(x.TreatmentActivityID)).Delete();
            }
        }

        public static void DeleteTreatmentActivity(this IQueryable<TreatmentActivity> treatmentActivities, ICollection<TreatmentActivity> treatmentActivitiesToDelete)
        {
            if(treatmentActivitiesToDelete.Any())
            {
                var treatmentActivityIDList = treatmentActivitiesToDelete.Select(x => x.TreatmentActivityID).ToList();
                treatmentActivities.Where(x => treatmentActivityIDList.Contains(x.TreatmentActivityID)).Delete();
            }
        }

        public static void DeleteTreatmentActivity(this IQueryable<TreatmentActivity> treatmentActivities, int treatmentActivityID)
        {
            DeleteTreatmentActivity(treatmentActivities, new List<int> { treatmentActivityID });
        }

        public static void DeleteTreatmentActivity(this IQueryable<TreatmentActivity> treatmentActivities, TreatmentActivity treatmentActivityToDelete)
        {
            DeleteTreatmentActivity(treatmentActivities, new List<TreatmentActivity> { treatmentActivityToDelete });
        }
    }
}