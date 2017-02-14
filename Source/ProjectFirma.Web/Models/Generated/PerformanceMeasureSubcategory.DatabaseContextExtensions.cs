//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureSubcategory]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureSubcategory GetPerformanceMeasureSubcategory(this IQueryable<PerformanceMeasureSubcategory> performanceMeasureSubcategories, int performanceMeasureSubcategoryID)
        {
            var performanceMeasureSubcategory = performanceMeasureSubcategories.SingleOrDefault(x => x.PerformanceMeasureSubcategoryID == performanceMeasureSubcategoryID);
            Check.RequireNotNullThrowNotFound(performanceMeasureSubcategory, "PerformanceMeasureSubcategory", performanceMeasureSubcategoryID);
            return performanceMeasureSubcategory;
        }

        public static void DeletePerformanceMeasureSubcategory(this List<int> performanceMeasureSubcategoryIDList)
        {
            if(performanceMeasureSubcategoryIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategories.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureSubcategories.Where(x => performanceMeasureSubcategoryIDList.Contains(x.PerformanceMeasureSubcategoryID)));
            }
        }

        public static void DeletePerformanceMeasureSubcategory(this ICollection<PerformanceMeasureSubcategory> performanceMeasureSubcategoriesToDelete)
        {
            if(performanceMeasureSubcategoriesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategories.RemoveRange(performanceMeasureSubcategoriesToDelete);
            }
        }

        public static void DeletePerformanceMeasureSubcategory(this int performanceMeasureSubcategoryID)
        {
            DeletePerformanceMeasureSubcategory(new List<int> { performanceMeasureSubcategoryID });
        }

        public static void DeletePerformanceMeasureSubcategory(this PerformanceMeasureSubcategory performanceMeasureSubcategoryToDelete)
        {
            DeletePerformanceMeasureSubcategory(new List<PerformanceMeasureSubcategory> { performanceMeasureSubcategoryToDelete });
        }
    }
}