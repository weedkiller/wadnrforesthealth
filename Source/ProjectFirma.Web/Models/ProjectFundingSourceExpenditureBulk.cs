using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public class ProjectFundingSourceExpenditureBulk
    {
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public List<CalendarYearMonetaryAmount> CalendarYearExpenditures { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectFundingSourceExpenditureBulk()
        {
        }

        public ProjectFundingSourceExpenditureBulk(ProjectFundingSourceExpenditure projectFundingSourceExpenditure,
            List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectFundingSourceExpenditure.ProjectID;
            FundingSourceID = projectFundingSourceExpenditure.FundingSourceID;
            CalendarYearExpenditures = new List<CalendarYearMonetaryAmount>();
            Add(projectFundingSourceExpenditures);
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectFundingSourceExpenditures.Select(x => x.CalendarYear).ToList();
            CalendarYearExpenditures.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearMonetaryAmount(x, null)));
        }

        private ProjectFundingSourceExpenditureBulk(ProjectFundingSourceExpenditureUpdate projectFundingSourceExpenditureUpdate,
            List<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectFundingSourceExpenditureUpdate.ProjectUpdateBatch.ProjectID;
            FundingSourceID = projectFundingSourceExpenditureUpdate.FundingSourceID;
            CalendarYearExpenditures = new List<CalendarYearMonetaryAmount>();
            Add(projectFundingSourceExpenditureUpdates);
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectFundingSourceExpenditureUpdates.Select(x => x.CalendarYear).ToList();
            CalendarYearExpenditures.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearMonetaryAmount(x, null)));
        }

        public static List<ProjectFundingSourceExpenditureBulk> MakeFromList(List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, List<int> calendarYearsToPopulate)
        {
            var groupedByProjectFundingSource = projectFundingSourceExpenditures.GroupBy(x => new {x.ProjectID, x.FundingSourceID});
            return groupedByProjectFundingSource.Select(grouping => new ProjectFundingSourceExpenditureBulk(grouping.First(), grouping.ToList(), calendarYearsToPopulate)).ToList();
        }

        public static List<ProjectFundingSourceExpenditureBulk> MakeFromList(List<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, List<int> calendarYearsToPopulate)
        {
            var groupedByProjectFundingSource = projectFundingSourceExpenditureUpdates.GroupBy(x => new {x.ProjectUpdateBatchID, x.FundingSourceID});
            return groupedByProjectFundingSource.Select(grouping => new ProjectFundingSourceExpenditureBulk(grouping.First(), grouping.ToList(), calendarYearsToPopulate)).ToList();
        }

        public void Add(List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            projectFundingSourceExpenditures.ForEach(Add);
        }

        public void Add(List<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates)
        {
            projectFundingSourceExpenditureUpdates.ForEach(Add);
        }

        public void Add(ProjectFundingSourceExpenditure projectFundingSourceExpenditure)
        {
            Check.Require(projectFundingSourceExpenditure.ProjectID == ProjectID && projectFundingSourceExpenditure.FundingSourceID == FundingSourceID,
                "Row doesn't align with collection mismatch ProjectID and FundingSourceID");
            CalendarYearExpenditures.Add(new CalendarYearMonetaryAmount(projectFundingSourceExpenditure.CalendarYear, projectFundingSourceExpenditure.ExpenditureAmount));
        }

        public void Add(ProjectFundingSourceExpenditureUpdate projectFundingSourceExpenditureUpdate)
        {
            Check.Require(projectFundingSourceExpenditureUpdate.ProjectUpdateBatch.ProjectID == ProjectID && projectFundingSourceExpenditureUpdate.FundingSourceID == FundingSourceID,
                "Row doesn't align with collection mismatch ProjectID and FundingSourceID");
            CalendarYearExpenditures.Add(new CalendarYearMonetaryAmount(projectFundingSourceExpenditureUpdate.CalendarYear, projectFundingSourceExpenditureUpdate.ExpenditureAmount));
        }

        public List<ProjectFundingSourceExpenditure> ToProjectFundingSourceExpenditures()
        {
            // ReSharper disable PossibleInvalidOperationException
            return
                CalendarYearExpenditures.Where(x => x.MonetaryAmount.HasValue)
                    .Select(x => new ProjectFundingSourceExpenditure(ProjectID, FundingSourceID, x.CalendarYear, x.MonetaryAmount.Value))
                    .ToList();
            // ReSharper restore PossibleInvalidOperationException
        }

        public List<ProjectFundingSourceExpenditureUpdate> ToProjectFundingSourceExpenditureUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            // ReSharper disable PossibleInvalidOperationException
            return
                CalendarYearExpenditures.Where(x => x.MonetaryAmount.HasValue)
                    .Select(x => new ProjectFundingSourceExpenditureUpdate(projectUpdateBatch.ProjectUpdateBatchID, FundingSourceID, x.CalendarYear, x.MonetaryAmount.Value))
                    .ToList();
            // ReSharper restore PossibleInvalidOperationException
        }
    }
}