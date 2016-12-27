using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public class ProjectBudgetBulk
    {
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public int ProjectCostTypeID { get; set; }
        public List<CalendarYearMonetaryAmount> CalendarYearBudgets { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectBudgetBulk()
        {
        }

        public ProjectBudgetBulk(int projectID,
            int fundingSourceID,
            int projectCostTypeID,
            List<IProjectBudgetAmount> projectBudgets,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            ProjectCostTypeID = projectCostTypeID;
            CalendarYearBudgets = new List<CalendarYearMonetaryAmount>();
            var projectBudgetsForThisProjectFundingSourceCostType =
                projectBudgets.Where(x => x.ProjectID == projectID && x.FundingSourceID == fundingSourceID && x.ProjectCostTypeID == projectCostTypeID)
                    .ToList();
            Add(projectBudgetsForThisProjectFundingSourceCostType);
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = projectBudgetsForThisProjectFundingSourceCostType.Select(x => x.CalendarYear).ToList();
            CalendarYearBudgets.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearMonetaryAmount(x, null)));
        }

        public static List<ProjectBudgetBulk> MakeFromList(List<IProjectBudgetAmount> projectBudgets, List<int> calendarYearsToPopulate)
        {
            var distinctProjects = projectBudgets.Select(x => x.ProjectID).Distinct().ToList();
            var distinctFundingSources = projectBudgets.Select(x => x.FundingSourceID).Distinct().ToList();
            var allPossibleProjectFundingSourceCostTypes = new List<Tuple<int, int, int>>();
            foreach (var projectID in distinctProjects)
            {
                foreach (var fundingSourceID in distinctFundingSources)
                {
                    allPossibleProjectFundingSourceCostTypes.AddRange(
                        ProjectCostType.All.Select(
                            projectCostType => new Tuple<int, int, int>(projectID, fundingSourceID, projectCostType.ProjectCostTypeID)));
                }
            }
            var projectBudgetBulks =
                allPossibleProjectFundingSourceCostTypes.Select(
                    grouping => new ProjectBudgetBulk(grouping.Item1, grouping.Item2, grouping.Item3, projectBudgets, calendarYearsToPopulate)).ToList();
            return projectBudgetBulks;
        }

        public void Add(List<IProjectBudgetAmount> projectBudgets)
        {
            projectBudgets.ForEach(Add);
        }

        public void Add(IProjectBudgetAmount projectBudget)
        {
            Check.Require(
                projectBudget.ProjectID == ProjectID && projectBudget.FundingSourceID == FundingSourceID &&
                projectBudget.ProjectCostTypeID == ProjectCostTypeID,
                "Row doesn't align with collection mismatch ProjectID and FundingSourceID and CostTypeID");
            CalendarYearBudgets.Add(new CalendarYearMonetaryAmount(projectBudget.CalendarYear, projectBudget.MonetaryAmount));
        }

        public List<ProjectBudget> ToProjectBudgets()
        {
            // ReSharper disable PossibleInvalidOperationException
            return
                CalendarYearBudgets.Where(x => x.MonetaryAmount.HasValue)
                    .Select(x => new ProjectBudget(ProjectID, FundingSourceID, ProjectCostTypeID, x.CalendarYear, x.MonetaryAmount.Value))
                    .ToList();
            // ReSharper restore PossibleInvalidOperationException
        }

        public List<ProjectBudgetUpdate> ToProjectBudgetUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            // ReSharper disable PossibleInvalidOperationException
            return
                CalendarYearBudgets.Where(x => x.MonetaryAmount.HasValue)
                    .Select(
                        x =>
                            new ProjectBudgetUpdate(projectUpdateBatch.ProjectUpdateBatchID, FundingSourceID, ProjectCostTypeID, x.CalendarYear)
                            {
                                BudgetedAmount = x.MonetaryAmount
                            })
                    .ToList();
            // ReSharper restore PossibleInvalidOperationException
        }
    }
}