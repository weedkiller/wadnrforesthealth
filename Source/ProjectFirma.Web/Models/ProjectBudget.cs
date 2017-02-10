using System;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectBudget : IAuditableEntity, IProjectBudgetAmount
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.AllProjects.Find(ProjectID);
                var fundingSource = HttpRequestStorage.DatabaseEntities.AllFundingSources.Find(FundingSourceID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var fundingSourceName = fundingSource != null ? fundingSource.AuditDescriptionString : ViewUtilities.NotFoundString;
                return String.Format("Project: {0}, Funding Source: {1}, CostType: {2}, Year: {3},  Budget: {4}",
                    projectName,
                    fundingSourceName,
                    ProjectCostType.ProjectCostTypeDisplayName,
                    CalendarYear,
                    BudgetedAmount.ToStringCurrency());
            }
        }

        public decimal? MonetaryAmount
        {
            get { return BudgetedAmount; }
        }
    }
}