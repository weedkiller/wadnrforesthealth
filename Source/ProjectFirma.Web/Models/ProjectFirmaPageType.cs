using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectFirmaPageType
    {
        public abstract string GetViewUrl();
    }

    public partial class ProjectFirmaPageTypeEIPTrackerNarrative
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.HomeController>.BuildUrlFromExpression(x => x.ViewPageContent(ToEnum));
        }
    }

    public partial class ProjectFirmaPageTypeEIPHomeAdditionalInfo
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.HomeController>.BuildUrlFromExpression(x => x.ViewPageContent(ToEnum));
        }
    }

    public partial class ProjectFirmaPageTypeEIPOverview
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.AboutController>.BuildUrlFromExpression(x => x.EIPOverview());
        }
    }

    public partial class ProjectFirmaPageTypeHistoryOfTheEIP
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.AboutController>.BuildUrlFromExpression(x => x.HistoryOfTheEIP());
        }
    }

    public partial class ProjectFirmaPageTypeEIPPartners
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.AboutController>.BuildUrlFromExpression(x => x.EIPPartners());
        }
    }

    public partial class ProjectFirmaPageTypeEIPFaq
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.AboutController>.BuildUrlFromExpression(x => x.Faq());
        }
    }

    public partial class ProjectFirmaPageTypeThisTool
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.AboutController>.BuildUrlFromExpression(x => x.ThisTool());
        }
    }

    public partial class ProjectFirmaPageTypeDemoScript
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.AboutController>.BuildUrlFromExpression(x => x.DemoScript());
        }
    }

    public partial class ProjectFirmaPageTypeAnnualApprovalProcess
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.AboutController>.BuildUrlFromExpression(x => x.AnnualApprovalProcess());
        }
    }

    public partial class ProjectFirmaPageTypeFullProjectList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeFiveYearProjectList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.FiveYearList());
        }
    }

    public partial class ProjectFirmaPageTypeCompletedProjectList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.CompletedList());
        }
    }

    public partial class ProjectFirmaPageTypeTerminatedProjectList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.TerminatedList());
        }
    }

    public partial class ProjectFirmaPageTypeEIPPerformanceMeasuresList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<EIPPerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeThresholdsHome
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.Threshold.Controllers.HomeController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeActionPrioritiesList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ActionPriorityController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeLocalAndRegionalPlansList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeFocusAreasList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<FocusAreaController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeFundingSourcesList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeOrganizationsList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeProgramsList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProgramController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeWatershedsList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<WatershedController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeMyProjects
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate());
        }
    }

    public partial class ProjectFirmaPageTypeMyOrganizationsProjects
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.MyOrganizationsProjects());
        }
    }

    public partial class ProjectFirmaPageTypePagesWithIntroTextList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectFirmaPageController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeInvestmentByFundingSector
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.ResultsController>.BuildUrlFromExpression(x => x.InvestmentByFundingSector(null));
        }
    }

    public partial class ProjectFirmaPageTypeSpendingBySectorByFocusAreaByProgram
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.ResultsController>.BuildUrlFromExpression(x => x.SpendingBySectorByFocusAreaByProgram(null));
        }
    }

    public partial class ProjectFirmaPageTypeSpendingByEIPPerformanceMeasureByProject
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.ResultsController>.BuildUrlFromExpression(x => x.SpendingByEIPPerformanceMeasureByProject(null));
        }
    }

    public partial class ProjectFirmaPageTypeEIPProjectMap
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.ResultsController>.BuildUrlFromExpression(x => x.EipProjectMap());
        }
    }

    public partial class ProjectFirmaPageTypeEIPResultsByProgram
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.ResultsController>.BuildUrlFromExpression(x => x.EipResultsByProgram(null));
        }
    }

    public partial class ProjectFirmaPageTypeEIPTaxonomy
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(x => x.EipTaxonomy());
        }
    }

    public partial class ProjectFirmaPageTypeTransportationTaxonomy
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(x => x.TransportationTaxonomy());
        }
    }


    
    public partial class ProjectFirmaPageTypeFeaturedProjectList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.FeaturedList());
        }
    }

    public partial class ProjectFirmaPageTypeManageUpdateNotifications
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Manage());
        }
    }

    public partial class ProjectFirmaPageTypeProjectUpdateStatus
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ProjectUpdateStatus());
        }
    }

    public partial class ProjectFirmaPageTypeTransportationStrategiesList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<TransportationStrategyController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeTransportationObjectivesList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<TransportationObjectiveController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeTransportationProjectList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.TransportationList());
        }
    }

    public partial class ProjectFirmaPageTypeTransportationCostParameterSet
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<TransportationCostParameterSetController>.BuildUrlFromExpression(x => x.Summary());
        }
    }

    public partial class ProjectFirmaPageTypeFullProjectListSimple
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.FullProjectListSimple());
        }
    }

    public partial class ProjectFirmaPageTypeTagList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<TagController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeProposedProjects
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeSIDHome
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.Sustainability.Controllers.HomeController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeSIDAboutContent
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.Sustainability.Controllers.HomeController>.BuildUrlFromExpression(x => x.About());
        }
    }

    public partial class ProjectFirmaPageTypeSIDAboutIntro
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.Sustainability.Controllers.HomeController>.BuildUrlFromExpression(x => x.About());
        }
    }

    public partial class ProjectFirmaPageTypeSIDAboutFAQ
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.Sustainability.Controllers.HomeController>.BuildUrlFromExpression(x => x.About());
        }
    }

    public partial class ProjectFirmaPageTypeLTInfoDataCenter
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Controllers.HomeController>.BuildUrlFromExpression(x => x.DataCenter());
        }
    }

    public partial class ProjectFirmaPageTypeLTInfoAbout
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Controllers.HomeController>.BuildUrlFromExpression(x => x.About());
        }
    }

    public partial class ProjectFirmaPageTypeThresholdsTaxonomy
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<Areas.Threshold.Controllers.ThresholdCategoryController>.BuildUrlFromExpression(x => x.Index());
        }
    }

    public partial class ProjectFirmaPageTypeMonitoringProgramsList
    {
        public override string GetViewUrl()
        {
            return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(x => x.Index());
        }
    }
}