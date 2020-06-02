//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCreateSection]
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
    public abstract partial class ProjectCreateSection : IHavePrimaryKey
    {
        public static readonly ProjectCreateSectionBasics Basics = ProjectCreateSectionBasics.Instance;
        public static readonly ProjectCreateSectionLocationSimple LocationSimple = ProjectCreateSectionLocationSimple.Instance;
        public static readonly ProjectCreateSectionLocationDetailed LocationDetailed = ProjectCreateSectionLocationDetailed.Instance;
        public static readonly ProjectCreateSectionExpectedPerformanceMeasures ExpectedPerformanceMeasures = ProjectCreateSectionExpectedPerformanceMeasures.Instance;
        public static readonly ProjectCreateSectionReportedPerformanceMeasures ReportedPerformanceMeasures = ProjectCreateSectionReportedPerformanceMeasures.Instance;
        public static readonly ProjectCreateSectionExpectedFunding ExpectedFunding = ProjectCreateSectionExpectedFunding.Instance;
        public static readonly ProjectCreateSectionClassifications Classifications = ProjectCreateSectionClassifications.Instance;
        public static readonly ProjectCreateSectionPhotos Photos = ProjectCreateSectionPhotos.Instance;
        public static readonly ProjectCreateSectionNotesAndDocuments NotesAndDocuments = ProjectCreateSectionNotesAndDocuments.Instance;
        public static readonly ProjectCreateSectionOrganizations Organizations = ProjectCreateSectionOrganizations.Instance;
        public static readonly ProjectCreateSectionContacts Contacts = ProjectCreateSectionContacts.Instance;
        public static readonly ProjectCreateSectionDNRUplandRegions DNRUplandRegions = ProjectCreateSectionDNRUplandRegions.Instance;
        public static readonly ProjectCreateSectionPriorityAreas PriorityAreas = ProjectCreateSectionPriorityAreas.Instance;
        public static readonly ProjectCreateSectionProjectAttributes ProjectAttributes = ProjectCreateSectionProjectAttributes.Instance;

        public static readonly List<ProjectCreateSection> All;
        public static readonly ReadOnlyDictionary<int, ProjectCreateSection> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectCreateSection()
        {
            All = new List<ProjectCreateSection> { Basics, LocationSimple, LocationDetailed, ExpectedPerformanceMeasures, ReportedPerformanceMeasures, ExpectedFunding, Classifications, Photos, NotesAndDocuments, Organizations, Contacts, DNRUplandRegions, PriorityAreas, ProjectAttributes };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectCreateSection>(All.ToDictionary(x => x.ProjectCreateSectionID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectCreateSection(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID)
        {
            ProjectCreateSectionID = projectCreateSectionID;
            ProjectCreateSectionName = projectCreateSectionName;
            ProjectCreateSectionDisplayName = projectCreateSectionDisplayName;
            SortOrder = sortOrder;
            HasCompletionStatus = hasCompletionStatus;
            ProjectWorkflowSectionGroupingID = projectWorkflowSectionGroupingID;
        }
        public ProjectWorkflowSectionGrouping ProjectWorkflowSectionGrouping { get { return ProjectWorkflowSectionGrouping.AllLookupDictionary[ProjectWorkflowSectionGroupingID]; } }
        [Key]
        public int ProjectCreateSectionID { get; private set; }
        public string ProjectCreateSectionName { get; private set; }
        public string ProjectCreateSectionDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        public bool HasCompletionStatus { get; private set; }
        public int ProjectWorkflowSectionGroupingID { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCreateSectionID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectCreateSection other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectCreateSectionID == ProjectCreateSectionID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectCreateSection);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectCreateSectionID;
        }

        public static bool operator ==(ProjectCreateSection left, ProjectCreateSection right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectCreateSection left, ProjectCreateSection right)
        {
            return !Equals(left, right);
        }

        public ProjectCreateSectionEnum ToEnum { get { return (ProjectCreateSectionEnum)GetHashCode(); } }

        public static ProjectCreateSection ToType(int enumValue)
        {
            return ToType((ProjectCreateSectionEnum)enumValue);
        }

        public static ProjectCreateSection ToType(ProjectCreateSectionEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectCreateSectionEnum.Basics:
                    return Basics;
                case ProjectCreateSectionEnum.Classifications:
                    return Classifications;
                case ProjectCreateSectionEnum.Contacts:
                    return Contacts;
                case ProjectCreateSectionEnum.DNRUplandRegions:
                    return DNRUplandRegions;
                case ProjectCreateSectionEnum.ExpectedFunding:
                    return ExpectedFunding;
                case ProjectCreateSectionEnum.ExpectedPerformanceMeasures:
                    return ExpectedPerformanceMeasures;
                case ProjectCreateSectionEnum.LocationDetailed:
                    return LocationDetailed;
                case ProjectCreateSectionEnum.LocationSimple:
                    return LocationSimple;
                case ProjectCreateSectionEnum.NotesAndDocuments:
                    return NotesAndDocuments;
                case ProjectCreateSectionEnum.Organizations:
                    return Organizations;
                case ProjectCreateSectionEnum.Photos:
                    return Photos;
                case ProjectCreateSectionEnum.PriorityAreas:
                    return PriorityAreas;
                case ProjectCreateSectionEnum.ProjectAttributes:
                    return ProjectAttributes;
                case ProjectCreateSectionEnum.ReportedPerformanceMeasures:
                    return ReportedPerformanceMeasures;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectCreateSectionEnum
    {
        Basics = 2,
        LocationSimple = 3,
        LocationDetailed = 4,
        ExpectedPerformanceMeasures = 6,
        ReportedPerformanceMeasures = 7,
        ExpectedFunding = 8,
        Classifications = 11,
        Photos = 13,
        NotesAndDocuments = 14,
        Organizations = 15,
        Contacts = 16,
        DNRUplandRegions = 17,
        PriorityAreas = 18,
        ProjectAttributes = 19
    }

    public partial class ProjectCreateSectionBasics : ProjectCreateSection
    {
        private ProjectCreateSectionBasics(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionBasics Instance = new ProjectCreateSectionBasics(2, @"Basics", @"Basics", 20, true, 1);
    }

    public partial class ProjectCreateSectionLocationSimple : ProjectCreateSection
    {
        private ProjectCreateSectionLocationSimple(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionLocationSimple Instance = new ProjectCreateSectionLocationSimple(3, @"LocationSimple", @"Location - Simple", 30, true, 2);
    }

    public partial class ProjectCreateSectionLocationDetailed : ProjectCreateSection
    {
        private ProjectCreateSectionLocationDetailed(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionLocationDetailed Instance = new ProjectCreateSectionLocationDetailed(4, @"LocationDetailed", @"Location - Detailed", 40, false, 2);
    }

    public partial class ProjectCreateSectionExpectedPerformanceMeasures : ProjectCreateSection
    {
        private ProjectCreateSectionExpectedPerformanceMeasures(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionExpectedPerformanceMeasures Instance = new ProjectCreateSectionExpectedPerformanceMeasures(6, @"ExpectedPerformanceMeasures", @"Expected Performance Measures", 60, true, 3);
    }

    public partial class ProjectCreateSectionReportedPerformanceMeasures : ProjectCreateSection
    {
        private ProjectCreateSectionReportedPerformanceMeasures(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionReportedPerformanceMeasures Instance = new ProjectCreateSectionReportedPerformanceMeasures(7, @"ReportedPerformanceMeasures", @"Reported Performance Measures", 70, true, 3);
    }

    public partial class ProjectCreateSectionExpectedFunding : ProjectCreateSection
    {
        private ProjectCreateSectionExpectedFunding(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionExpectedFunding Instance = new ProjectCreateSectionExpectedFunding(8, @"ExpectedFunding", @"Expected Funding", 80, false, 4);
    }

    public partial class ProjectCreateSectionClassifications : ProjectCreateSection
    {
        private ProjectCreateSectionClassifications(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionClassifications Instance = new ProjectCreateSectionClassifications(11, @"Classifications", @"Classifications", 110, true, 5);
    }

    public partial class ProjectCreateSectionPhotos : ProjectCreateSection
    {
        private ProjectCreateSectionPhotos(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionPhotos Instance = new ProjectCreateSectionPhotos(13, @"Photos", @"Photos", 130, false, 5);
    }

    public partial class ProjectCreateSectionNotesAndDocuments : ProjectCreateSection
    {
        private ProjectCreateSectionNotesAndDocuments(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionNotesAndDocuments Instance = new ProjectCreateSectionNotesAndDocuments(14, @"NotesAndDocuments", @"Documents and Notes", 140, false, 5);
    }

    public partial class ProjectCreateSectionOrganizations : ProjectCreateSection
    {
        private ProjectCreateSectionOrganizations(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionOrganizations Instance = new ProjectCreateSectionOrganizations(15, @"Organizations", @"Organizations", 25, true, 1);
    }

    public partial class ProjectCreateSectionContacts : ProjectCreateSection
    {
        private ProjectCreateSectionContacts(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionContacts Instance = new ProjectCreateSectionContacts(16, @"Contacts", @"Contacts", 26, true, 1);
    }

    public partial class ProjectCreateSectionDNRUplandRegions : ProjectCreateSection
    {
        private ProjectCreateSectionDNRUplandRegions(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionDNRUplandRegions Instance = new ProjectCreateSectionDNRUplandRegions(17, @"DNRUplandRegions", @"DNR Upland Regions", 50, true, 2);
    }

    public partial class ProjectCreateSectionPriorityAreas : ProjectCreateSection
    {
        private ProjectCreateSectionPriorityAreas(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionPriorityAreas Instance = new ProjectCreateSectionPriorityAreas(18, @"PriorityAreas", @"Priority Areas", 45, true, 2);
    }

    public partial class ProjectCreateSectionProjectAttributes : ProjectCreateSection
    {
        private ProjectCreateSectionProjectAttributes(int projectCreateSectionID, string projectCreateSectionName, string projectCreateSectionDisplayName, int sortOrder, bool hasCompletionStatus, int projectWorkflowSectionGroupingID) : base(projectCreateSectionID, projectCreateSectionName, projectCreateSectionDisplayName, sortOrder, hasCompletionStatus, projectWorkflowSectionGroupingID) {}
        public static readonly ProjectCreateSectionProjectAttributes Instance = new ProjectCreateSectionProjectAttributes(19, @"ProjectAttributes", @"Project Attributes", 22, true, 1);
    }
}