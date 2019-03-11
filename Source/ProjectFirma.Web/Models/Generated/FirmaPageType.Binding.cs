//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class FirmaPageType : IHavePrimaryKey
    {
        public static readonly FirmaPageTypeHomePage HomePage = FirmaPageTypeHomePage.Instance;
        public static readonly FirmaPageTypeDemoScript DemoScript = FirmaPageTypeDemoScript.Instance;
        public static readonly FirmaPageTypeInternalSetupNotes InternalSetupNotes = FirmaPageTypeInternalSetupNotes.Instance;
        public static readonly FirmaPageTypeFullProjectList FullProjectList = FirmaPageTypeFullProjectList.Instance;
        public static readonly FirmaPageTypePerformanceMeasuresList PerformanceMeasuresList = FirmaPageTypePerformanceMeasuresList.Instance;
        public static readonly FirmaPageTypeProjectTypeList ProjectTypeList = FirmaPageTypeProjectTypeList.Instance;
        public static readonly FirmaPageTypeTaxonomyBranchList TaxonomyBranchList = FirmaPageTypeTaxonomyBranchList.Instance;
        public static readonly FirmaPageTypeTaxonomyTrunkList TaxonomyTrunkList = FirmaPageTypeTaxonomyTrunkList.Instance;
        public static readonly FirmaPageTypeFundingSourcesList FundingSourcesList = FirmaPageTypeFundingSourcesList.Instance;
        public static readonly FirmaPageTypeOrganizationsList OrganizationsList = FirmaPageTypeOrganizationsList.Instance;
        public static readonly FirmaPageTypeMyProjects MyProjects = FirmaPageTypeMyProjects.Instance;
        public static readonly FirmaPageTypeProjectMap ProjectMap = FirmaPageTypeProjectMap.Instance;
        public static readonly FirmaPageTypeHomeMapInfo HomeMapInfo = FirmaPageTypeHomeMapInfo.Instance;
        public static readonly FirmaPageTypeHomeAdditionalInfo HomeAdditionalInfo = FirmaPageTypeHomeAdditionalInfo.Instance;
        public static readonly FirmaPageTypeFeaturedProjectList FeaturedProjectList = FirmaPageTypeFeaturedProjectList.Instance;
        public static readonly FirmaPageTypeFullProjectListSimple FullProjectListSimple = FirmaPageTypeFullProjectListSimple.Instance;
        public static readonly FirmaPageTypeTaxonomy Taxonomy = FirmaPageTypeTaxonomy.Instance;
        public static readonly FirmaPageTypeTagList TagList = FirmaPageTypeTagList.Instance;
        public static readonly FirmaPageTypeProposals Proposals = FirmaPageTypeProposals.Instance;
        public static readonly FirmaPageTypeManageUpdateNotifications ManageUpdateNotifications = FirmaPageTypeManageUpdateNotifications.Instance;
        public static readonly FirmaPageTypeProposeProjectInstructions ProposeProjectInstructions = FirmaPageTypeProposeProjectInstructions.Instance;
        public static readonly FirmaPageTypeProjectStewardOrganizationList ProjectStewardOrganizationList = FirmaPageTypeProjectStewardOrganizationList.Instance;
        public static readonly FirmaPageTypeEnterHistoricProjectInstructions EnterHistoricProjectInstructions = FirmaPageTypeEnterHistoricProjectInstructions.Instance;
        public static readonly FirmaPageTypePendingProjects PendingProjects = FirmaPageTypePendingProjects.Instance;
        public static readonly FirmaPageTypeTraining Training = FirmaPageTypeTraining.Instance;
        public static readonly FirmaPageTypeCustomFooter CustomFooter = FirmaPageTypeCustomFooter.Instance;
        public static readonly FirmaPageTypeManageProjectCustomAttributeTypeInstructions ManageProjectCustomAttributeTypeInstructions = FirmaPageTypeManageProjectCustomAttributeTypeInstructions.Instance;
        public static readonly FirmaPageTypeManageProjectCustomAttributeTypesList ManageProjectCustomAttributeTypesList = FirmaPageTypeManageProjectCustomAttributeTypesList.Instance;
        public static readonly FirmaPageTypeFactSheetCustomText FactSheetCustomText = FirmaPageTypeFactSheetCustomText.Instance;
        public static readonly FirmaPageTypeFocusAreasList FocusAreasList = FirmaPageTypeFocusAreasList.Instance;
        public static readonly FirmaPageTypeFullGrantList FullGrantList = FirmaPageTypeFullGrantList.Instance;
        public static readonly FirmaPageTypeFullGrantAllocationList FullGrantAllocationList = FirmaPageTypeFullGrantAllocationList.Instance;
        public static readonly FirmaPageTypeRegionsList RegionsList = FirmaPageTypeRegionsList.Instance;
        public static readonly FirmaPageTypePriorityAreasList PriorityAreasList = FirmaPageTypePriorityAreasList.Instance;
        public static readonly FirmaPageTypeFullAgreementList FullAgreementList = FirmaPageTypeFullAgreementList.Instance;
        public static readonly FirmaPageTypeFullInvoiceList FullInvoiceList = FirmaPageTypeFullInvoiceList.Instance;

        public static readonly List<FirmaPageType> All;
        public static readonly ReadOnlyDictionary<int, FirmaPageType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FirmaPageType()
        {
            All = new List<FirmaPageType> { HomePage, DemoScript, InternalSetupNotes, FullProjectList, PerformanceMeasuresList, ProjectTypeList, TaxonomyBranchList, TaxonomyTrunkList, FundingSourcesList, OrganizationsList, MyProjects, ProjectMap, HomeMapInfo, HomeAdditionalInfo, FeaturedProjectList, FullProjectListSimple, Taxonomy, TagList, Proposals, ManageUpdateNotifications, ProposeProjectInstructions, ProjectStewardOrganizationList, EnterHistoricProjectInstructions, PendingProjects, Training, CustomFooter, ManageProjectCustomAttributeTypeInstructions, ManageProjectCustomAttributeTypesList, FactSheetCustomText, FocusAreasList, FullGrantList, FullGrantAllocationList, RegionsList, PriorityAreasList, FullAgreementList, FullInvoiceList };
            AllLookupDictionary = new ReadOnlyDictionary<int, FirmaPageType>(All.ToDictionary(x => x.FirmaPageTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FirmaPageType(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID)
        {
            FirmaPageTypeID = firmaPageTypeID;
            FirmaPageTypeName = firmaPageTypeName;
            FirmaPageTypeDisplayName = firmaPageTypeDisplayName;
            FirmaPageRenderTypeID = firmaPageRenderTypeID;
        }
        public FirmaPageRenderType FirmaPageRenderType { get { return FirmaPageRenderType.AllLookupDictionary[FirmaPageRenderTypeID]; } }
        [Key]
        public int FirmaPageTypeID { get; private set; }
        public string FirmaPageTypeName { get; private set; }
        public string FirmaPageTypeDisplayName { get; private set; }
        public int FirmaPageRenderTypeID { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return FirmaPageTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FirmaPageType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FirmaPageTypeID == FirmaPageTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FirmaPageType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FirmaPageTypeID;
        }

        public static bool operator ==(FirmaPageType left, FirmaPageType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FirmaPageType left, FirmaPageType right)
        {
            return !Equals(left, right);
        }

        public FirmaPageTypeEnum ToEnum { get { return (FirmaPageTypeEnum)GetHashCode(); } }

        public static FirmaPageType ToType(int enumValue)
        {
            return ToType((FirmaPageTypeEnum)enumValue);
        }

        public static FirmaPageType ToType(FirmaPageTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case FirmaPageTypeEnum.CustomFooter:
                    return CustomFooter;
                case FirmaPageTypeEnum.DemoScript:
                    return DemoScript;
                case FirmaPageTypeEnum.EnterHistoricProjectInstructions:
                    return EnterHistoricProjectInstructions;
                case FirmaPageTypeEnum.FactSheetCustomText:
                    return FactSheetCustomText;
                case FirmaPageTypeEnum.FeaturedProjectList:
                    return FeaturedProjectList;
                case FirmaPageTypeEnum.FocusAreasList:
                    return FocusAreasList;
                case FirmaPageTypeEnum.FullAgreementList:
                    return FullAgreementList;
                case FirmaPageTypeEnum.FullGrantAllocationList:
                    return FullGrantAllocationList;
                case FirmaPageTypeEnum.FullGrantList:
                    return FullGrantList;
                case FirmaPageTypeEnum.FullInvoiceList:
                    return FullInvoiceList;
                case FirmaPageTypeEnum.FullProjectList:
                    return FullProjectList;
                case FirmaPageTypeEnum.FullProjectListSimple:
                    return FullProjectListSimple;
                case FirmaPageTypeEnum.FundingSourcesList:
                    return FundingSourcesList;
                case FirmaPageTypeEnum.HomeAdditionalInfo:
                    return HomeAdditionalInfo;
                case FirmaPageTypeEnum.HomeMapInfo:
                    return HomeMapInfo;
                case FirmaPageTypeEnum.HomePage:
                    return HomePage;
                case FirmaPageTypeEnum.InternalSetupNotes:
                    return InternalSetupNotes;
                case FirmaPageTypeEnum.ManageProjectCustomAttributeTypeInstructions:
                    return ManageProjectCustomAttributeTypeInstructions;
                case FirmaPageTypeEnum.ManageProjectCustomAttributeTypesList:
                    return ManageProjectCustomAttributeTypesList;
                case FirmaPageTypeEnum.ManageUpdateNotifications:
                    return ManageUpdateNotifications;
                case FirmaPageTypeEnum.MyProjects:
                    return MyProjects;
                case FirmaPageTypeEnum.OrganizationsList:
                    return OrganizationsList;
                case FirmaPageTypeEnum.PendingProjects:
                    return PendingProjects;
                case FirmaPageTypeEnum.PerformanceMeasuresList:
                    return PerformanceMeasuresList;
                case FirmaPageTypeEnum.PriorityAreasList:
                    return PriorityAreasList;
                case FirmaPageTypeEnum.ProjectMap:
                    return ProjectMap;
                case FirmaPageTypeEnum.ProjectStewardOrganizationList:
                    return ProjectStewardOrganizationList;
                case FirmaPageTypeEnum.ProjectTypeList:
                    return ProjectTypeList;
                case FirmaPageTypeEnum.Proposals:
                    return Proposals;
                case FirmaPageTypeEnum.ProposeProjectInstructions:
                    return ProposeProjectInstructions;
                case FirmaPageTypeEnum.RegionsList:
                    return RegionsList;
                case FirmaPageTypeEnum.TagList:
                    return TagList;
                case FirmaPageTypeEnum.Taxonomy:
                    return Taxonomy;
                case FirmaPageTypeEnum.TaxonomyBranchList:
                    return TaxonomyBranchList;
                case FirmaPageTypeEnum.TaxonomyTrunkList:
                    return TaxonomyTrunkList;
                case FirmaPageTypeEnum.Training:
                    return Training;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FirmaPageTypeEnum
    {
        HomePage = 1,
        DemoScript = 4,
        InternalSetupNotes = 5,
        FullProjectList = 6,
        PerformanceMeasuresList = 9,
        ProjectTypeList = 11,
        TaxonomyBranchList = 13,
        TaxonomyTrunkList = 14,
        FundingSourcesList = 15,
        OrganizationsList = 16,
        MyProjects = 18,
        ProjectMap = 22,
        HomeMapInfo = 24,
        HomeAdditionalInfo = 25,
        FeaturedProjectList = 26,
        FullProjectListSimple = 33,
        Taxonomy = 34,
        TagList = 36,
        Proposals = 38,
        ManageUpdateNotifications = 41,
        ProposeProjectInstructions = 45,
        ProjectStewardOrganizationList = 46,
        EnterHistoricProjectInstructions = 47,
        PendingProjects = 48,
        Training = 49,
        CustomFooter = 51,
        ManageProjectCustomAttributeTypeInstructions = 52,
        ManageProjectCustomAttributeTypesList = 53,
        FactSheetCustomText = 54,
        FocusAreasList = 55,
        FullGrantList = 56,
        FullGrantAllocationList = 57,
        RegionsList = 58,
        PriorityAreasList = 59,
        FullAgreementList = 60,
        FullInvoiceList = 61
    }

    public partial class FirmaPageTypeHomePage : FirmaPageType
    {
        private FirmaPageTypeHomePage(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeHomePage Instance = new FirmaPageTypeHomePage(1, @"HomePage", @"Home Page", 2);
    }

    public partial class FirmaPageTypeDemoScript : FirmaPageType
    {
        private FirmaPageTypeDemoScript(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeDemoScript Instance = new FirmaPageTypeDemoScript(4, @"DemoScript", @"Demo Script", 2);
    }

    public partial class FirmaPageTypeInternalSetupNotes : FirmaPageType
    {
        private FirmaPageTypeInternalSetupNotes(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeInternalSetupNotes Instance = new FirmaPageTypeInternalSetupNotes(5, @"InternalSetupNotes", @"Internal Setup Notes", 2);
    }

    public partial class FirmaPageTypeFullProjectList : FirmaPageType
    {
        private FirmaPageTypeFullProjectList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFullProjectList Instance = new FirmaPageTypeFullProjectList(6, @"FullProjectList", @"Full Project List", 1);
    }

    public partial class FirmaPageTypePerformanceMeasuresList : FirmaPageType
    {
        private FirmaPageTypePerformanceMeasuresList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypePerformanceMeasuresList Instance = new FirmaPageTypePerformanceMeasuresList(9, @"PerformanceMeasuresList", @"Performance Measures List", 1);
    }

    public partial class FirmaPageTypeProjectTypeList : FirmaPageType
    {
        private FirmaPageTypeProjectTypeList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProjectTypeList Instance = new FirmaPageTypeProjectTypeList(11, @"ProjectTypeList", @"Project Type List", 1);
    }

    public partial class FirmaPageTypeTaxonomyBranchList : FirmaPageType
    {
        private FirmaPageTypeTaxonomyBranchList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTaxonomyBranchList Instance = new FirmaPageTypeTaxonomyBranchList(13, @"TaxonomyBranchList", @"Taxonomy Branch List", 1);
    }

    public partial class FirmaPageTypeTaxonomyTrunkList : FirmaPageType
    {
        private FirmaPageTypeTaxonomyTrunkList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTaxonomyTrunkList Instance = new FirmaPageTypeTaxonomyTrunkList(14, @"TaxonomyTrunkList", @"Taxonomy Trunk List", 1);
    }

    public partial class FirmaPageTypeFundingSourcesList : FirmaPageType
    {
        private FirmaPageTypeFundingSourcesList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFundingSourcesList Instance = new FirmaPageTypeFundingSourcesList(15, @"FundingSourcesList", @"Funding Sources List", 1);
    }

    public partial class FirmaPageTypeOrganizationsList : FirmaPageType
    {
        private FirmaPageTypeOrganizationsList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeOrganizationsList Instance = new FirmaPageTypeOrganizationsList(16, @"OrganizationsList", @"Organizations List", 1);
    }

    public partial class FirmaPageTypeMyProjects : FirmaPageType
    {
        private FirmaPageTypeMyProjects(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeMyProjects Instance = new FirmaPageTypeMyProjects(18, @"MyProjects", @"My Projects", 1);
    }

    public partial class FirmaPageTypeProjectMap : FirmaPageType
    {
        private FirmaPageTypeProjectMap(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProjectMap Instance = new FirmaPageTypeProjectMap(22, @"ProjectMap", @"Project Map", 1);
    }

    public partial class FirmaPageTypeHomeMapInfo : FirmaPageType
    {
        private FirmaPageTypeHomeMapInfo(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeHomeMapInfo Instance = new FirmaPageTypeHomeMapInfo(24, @"HomeMapInfo", @"Home Page Map Info", 2);
    }

    public partial class FirmaPageTypeHomeAdditionalInfo : FirmaPageType
    {
        private FirmaPageTypeHomeAdditionalInfo(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeHomeAdditionalInfo Instance = new FirmaPageTypeHomeAdditionalInfo(25, @"HomeAdditionalInfo", @"Home Page Additional Info", 2);
    }

    public partial class FirmaPageTypeFeaturedProjectList : FirmaPageType
    {
        private FirmaPageTypeFeaturedProjectList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFeaturedProjectList Instance = new FirmaPageTypeFeaturedProjectList(26, @"FeaturedProjectList", @"Featured Project List", 1);
    }

    public partial class FirmaPageTypeFullProjectListSimple : FirmaPageType
    {
        private FirmaPageTypeFullProjectListSimple(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFullProjectListSimple Instance = new FirmaPageTypeFullProjectListSimple(33, @"FullProjectListSimple", @"Full Project List (Simple)", 1);
    }

    public partial class FirmaPageTypeTaxonomy : FirmaPageType
    {
        private FirmaPageTypeTaxonomy(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTaxonomy Instance = new FirmaPageTypeTaxonomy(34, @"Taxonomy", @"Taxonomy", 1);
    }

    public partial class FirmaPageTypeTagList : FirmaPageType
    {
        private FirmaPageTypeTagList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTagList Instance = new FirmaPageTypeTagList(36, @"TagList", @"Tag List", 1);
    }

    public partial class FirmaPageTypeProposals : FirmaPageType
    {
        private FirmaPageTypeProposals(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProposals Instance = new FirmaPageTypeProposals(38, @"Proposals", @"Proposals", 1);
    }

    public partial class FirmaPageTypeManageUpdateNotifications : FirmaPageType
    {
        private FirmaPageTypeManageUpdateNotifications(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeManageUpdateNotifications Instance = new FirmaPageTypeManageUpdateNotifications(41, @"ManageUpdateNotifications", @"Manage Project Update Notifications", 1);
    }

    public partial class FirmaPageTypeProposeProjectInstructions : FirmaPageType
    {
        private FirmaPageTypeProposeProjectInstructions(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProposeProjectInstructions Instance = new FirmaPageTypeProposeProjectInstructions(45, @"ProposeProjectInstructions", @"Propose Project Instructions", 2);
    }

    public partial class FirmaPageTypeProjectStewardOrganizationList : FirmaPageType
    {
        private FirmaPageTypeProjectStewardOrganizationList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeProjectStewardOrganizationList Instance = new FirmaPageTypeProjectStewardOrganizationList(46, @"ProjectStewardOrganizationList", @"ProjectStewardOrganizationList", 1);
    }

    public partial class FirmaPageTypeEnterHistoricProjectInstructions : FirmaPageType
    {
        private FirmaPageTypeEnterHistoricProjectInstructions(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeEnterHistoricProjectInstructions Instance = new FirmaPageTypeEnterHistoricProjectInstructions(47, @"EnterHistoricProjectInstructions", @"Enter Historic Project Instructions", 2);
    }

    public partial class FirmaPageTypePendingProjects : FirmaPageType
    {
        private FirmaPageTypePendingProjects(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypePendingProjects Instance = new FirmaPageTypePendingProjects(48, @"PendingProjects", @"Pending Projects", 1);
    }

    public partial class FirmaPageTypeTraining : FirmaPageType
    {
        private FirmaPageTypeTraining(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeTraining Instance = new FirmaPageTypeTraining(49, @"Training", @"Training", 2);
    }

    public partial class FirmaPageTypeCustomFooter : FirmaPageType
    {
        private FirmaPageTypeCustomFooter(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeCustomFooter Instance = new FirmaPageTypeCustomFooter(51, @"CustomFooter", @"Custom Footer", 1);
    }

    public partial class FirmaPageTypeManageProjectCustomAttributeTypeInstructions : FirmaPageType
    {
        private FirmaPageTypeManageProjectCustomAttributeTypeInstructions(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeManageProjectCustomAttributeTypeInstructions Instance = new FirmaPageTypeManageProjectCustomAttributeTypeInstructions(52, @"ManageProjectCustomAttributeTypeInstructions", @"Manage Project Custom Attribute Type Instructions", 2);
    }

    public partial class FirmaPageTypeManageProjectCustomAttributeTypesList : FirmaPageType
    {
        private FirmaPageTypeManageProjectCustomAttributeTypesList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeManageProjectCustomAttributeTypesList Instance = new FirmaPageTypeManageProjectCustomAttributeTypesList(53, @"ManageProjectCustomAttributeTypesList", @"Manage Project Custom Attribute Types List", 2);
    }

    public partial class FirmaPageTypeFactSheetCustomText : FirmaPageType
    {
        private FirmaPageTypeFactSheetCustomText(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFactSheetCustomText Instance = new FirmaPageTypeFactSheetCustomText(54, @"FactSheetCustomText", @"Fact Sheet Custom Text", 2);
    }

    public partial class FirmaPageTypeFocusAreasList : FirmaPageType
    {
        private FirmaPageTypeFocusAreasList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFocusAreasList Instance = new FirmaPageTypeFocusAreasList(55, @"FocusAreasList", @"Focus Areas List", 1);
    }

    public partial class FirmaPageTypeFullGrantList : FirmaPageType
    {
        private FirmaPageTypeFullGrantList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFullGrantList Instance = new FirmaPageTypeFullGrantList(56, @"FullGrantList", @"Full Grant List", 1);
    }

    public partial class FirmaPageTypeFullGrantAllocationList : FirmaPageType
    {
        private FirmaPageTypeFullGrantAllocationList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFullGrantAllocationList Instance = new FirmaPageTypeFullGrantAllocationList(57, @"FullGrantAllocationList", @"Full Grant Allocation List", 1);
    }

    public partial class FirmaPageTypeRegionsList : FirmaPageType
    {
        private FirmaPageTypeRegionsList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeRegionsList Instance = new FirmaPageTypeRegionsList(58, @"RegionsList", @"Regions List", 1);
    }

    public partial class FirmaPageTypePriorityAreasList : FirmaPageType
    {
        private FirmaPageTypePriorityAreasList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypePriorityAreasList Instance = new FirmaPageTypePriorityAreasList(59, @"PriorityAreasList", @"Priority Areas List", 1);
    }

    public partial class FirmaPageTypeFullAgreementList : FirmaPageType
    {
        private FirmaPageTypeFullAgreementList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFullAgreementList Instance = new FirmaPageTypeFullAgreementList(60, @"FullAgreementList", @"Full Agreement List", 1);
    }

    public partial class FirmaPageTypeFullInvoiceList : FirmaPageType
    {
        private FirmaPageTypeFullInvoiceList(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : base(firmaPageTypeID, firmaPageTypeName, firmaPageTypeDisplayName, firmaPageRenderTypeID) {}
        public static readonly FirmaPageTypeFullInvoiceList Instance = new FirmaPageTypeFullInvoiceList(61, @"FullInvoiceList", @"Full Invoice List", 1);
    }
}