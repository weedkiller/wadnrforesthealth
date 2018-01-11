//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Project]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[Project]")]
    public partial class Project : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Project()
        {
            this.NotificationProjects = new List<NotificationProject>();
            this.PerformanceMeasureActuals = new List<PerformanceMeasureActual>();
            this.PerformanceMeasureExpecteds = new List<PerformanceMeasureExpected>();
            this.ProjectAssessmentQuestions = new List<ProjectAssessmentQuestion>();
            this.ProjectBudgets = new List<ProjectBudget>();
            this.ProjectClassifications = new List<ProjectClassification>();
            this.ProjectExemptReportingYears = new List<ProjectExemptReportingYear>();
            this.ProjectExternalLinks = new List<ProjectExternalLink>();
            this.ProjectFundingSourceExpenditures = new List<ProjectFundingSourceExpenditure>();
            this.ProjectFundingSourceRequests = new List<ProjectFundingSourceRequest>();
            this.ProjectImages = new List<ProjectImage>();
            this.ProjectLocations = new List<ProjectLocation>();
            this.ProjectLocationStagings = new List<ProjectLocationStaging>();
            this.ProjectNotes = new List<ProjectNote>();
            this.ProjectOrganizations = new List<ProjectOrganization>();
            this.ProjectTags = new List<ProjectTag>();
            this.ProjectUpdateBatches = new List<ProjectUpdateBatch>();
            this.ProjectWatersheds = new List<ProjectWatershed>();
            this.SnapshotProjects = new List<SnapshotProject>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Project(int projectID, int taxonomyTierOneID, int projectStageID, string projectName, string projectDescription, int? implementationStartYear, int? completionYear, decimal? estimatedTotalCost, DbGeometry projectLocationPoint, string performanceMeasureActualYearsExemptionExplanation, bool isFeatured, string projectLocationNotes, int? planningDesignStartYear, int projectLocationSimpleTypeID, decimal? estimatedAnnualOperatingCost, int fundingTypeID, int? primaryContactPersonID, string projectWatershedNotes, int projectApprovalStatusID, int? proposingPersonID, DateTime? proposingDate, string performanceMeasureNotes, DateTime? submissionDate, DateTime? approvalDate, int? reviewedByPersonID) : this()
        {
            this.ProjectID = projectID;
            this.TaxonomyTierOneID = taxonomyTierOneID;
            this.ProjectStageID = projectStageID;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.ImplementationStartYear = implementationStartYear;
            this.CompletionYear = completionYear;
            this.EstimatedTotalCost = estimatedTotalCost;
            this.ProjectLocationPoint = projectLocationPoint;
            this.PerformanceMeasureActualYearsExemptionExplanation = performanceMeasureActualYearsExemptionExplanation;
            this.IsFeatured = isFeatured;
            this.ProjectLocationNotes = projectLocationNotes;
            this.PlanningDesignStartYear = planningDesignStartYear;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.EstimatedAnnualOperatingCost = estimatedAnnualOperatingCost;
            this.FundingTypeID = fundingTypeID;
            this.PrimaryContactPersonID = primaryContactPersonID;
            this.ProjectWatershedNotes = projectWatershedNotes;
            this.ProjectApprovalStatusID = projectApprovalStatusID;
            this.ProposingPersonID = proposingPersonID;
            this.ProposingDate = proposingDate;
            this.PerformanceMeasureNotes = performanceMeasureNotes;
            this.SubmissionDate = submissionDate;
            this.ApprovalDate = approvalDate;
            this.ReviewedByPersonID = reviewedByPersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Project(int taxonomyTierOneID, int projectStageID, string projectName, string projectDescription, bool isFeatured, int projectLocationSimpleTypeID, int fundingTypeID, int projectApprovalStatusID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyTierOneID = taxonomyTierOneID;
            this.ProjectStageID = projectStageID;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.IsFeatured = isFeatured;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleTypeID;
            this.FundingTypeID = fundingTypeID;
            this.ProjectApprovalStatusID = projectApprovalStatusID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Project(TaxonomyTierOne taxonomyTierOne, ProjectStage projectStage, string projectName, string projectDescription, bool isFeatured, ProjectLocationSimpleType projectLocationSimpleType, FundingType fundingType, ProjectApprovalStatus projectApprovalStatus) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyTierOneID = taxonomyTierOne.TaxonomyTierOneID;
            this.TaxonomyTierOne = taxonomyTierOne;
            taxonomyTierOne.Projects.Add(this);
            this.ProjectStageID = projectStage.ProjectStageID;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.IsFeatured = isFeatured;
            this.ProjectLocationSimpleTypeID = projectLocationSimpleType.ProjectLocationSimpleTypeID;
            this.FundingTypeID = fundingType.FundingTypeID;
            this.ProjectApprovalStatusID = projectApprovalStatus.ProjectApprovalStatusID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Project CreateNewBlank(TaxonomyTierOne taxonomyTierOne, ProjectStage projectStage, ProjectLocationSimpleType projectLocationSimpleType, FundingType fundingType, ProjectApprovalStatus projectApprovalStatus)
        {
            return new Project(taxonomyTierOne, projectStage, default(string), default(string), default(bool), projectLocationSimpleType, fundingType, projectApprovalStatus);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return NotificationProjects.Any() || PerformanceMeasureActuals.Any() || PerformanceMeasureExpecteds.Any() || ProjectAssessmentQuestions.Any() || ProjectBudgets.Any() || ProjectClassifications.Any() || ProjectExemptReportingYears.Any() || ProjectExternalLinks.Any() || ProjectFundingSourceExpenditures.Any() || ProjectFundingSourceRequests.Any() || ProjectImages.Any() || ProjectLocations.Any() || ProjectLocationStagings.Any() || ProjectNotes.Any() || ProjectOrganizations.Any() || ProjectTags.Any() || ProjectUpdateBatches.Any() || ProjectWatersheds.Any() || SnapshotProjects.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Project).Name, typeof(NotificationProject).Name, typeof(PerformanceMeasureActual).Name, typeof(PerformanceMeasureExpected).Name, typeof(ProjectAssessmentQuestion).Name, typeof(ProjectBudget).Name, typeof(ProjectClassification).Name, typeof(ProjectExemptReportingYear).Name, typeof(ProjectExternalLink).Name, typeof(ProjectFundingSourceExpenditure).Name, typeof(ProjectFundingSourceRequest).Name, typeof(ProjectImage).Name, typeof(ProjectLocation).Name, typeof(ProjectLocationStaging).Name, typeof(ProjectNote).Name, typeof(ProjectOrganization).Name, typeof(ProjectTag).Name, typeof(ProjectUpdateBatch).Name, typeof(ProjectWatershed).Name, typeof(SnapshotProject).Name};

        [Key]
        public int ProjectID { get; set; }
        public int TenantID { get; private set; }
        public int TaxonomyTierOneID { get; set; }
        public int ProjectStageID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int? ImplementationStartYear { get; set; }
        public int? CompletionYear { get; set; }
        public decimal? EstimatedTotalCost { get; set; }
        public DbGeometry ProjectLocationPoint { get; set; }
        public string PerformanceMeasureActualYearsExemptionExplanation { get; set; }
        public bool IsFeatured { get; set; }
        public string ProjectLocationNotes { get; set; }
        public int? PlanningDesignStartYear { get; set; }
        public int ProjectLocationSimpleTypeID { get; set; }
        public decimal? EstimatedAnnualOperatingCost { get; set; }
        public int FundingTypeID { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public string ProjectWatershedNotes { get; set; }
        public int ProjectApprovalStatusID { get; set; }
        public int? ProposingPersonID { get; set; }
        public DateTime? ProposingDate { get; set; }
        public string PerformanceMeasureNotes { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? ReviewedByPersonID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectID; } set { ProjectID = value; } }

        public virtual ICollection<NotificationProject> NotificationProjects { get; set; }
        public virtual ICollection<PerformanceMeasureActual> PerformanceMeasureActuals { get; set; }
        public virtual ICollection<PerformanceMeasureExpected> PerformanceMeasureExpecteds { get; set; }
        public virtual ICollection<ProjectAssessmentQuestion> ProjectAssessmentQuestions { get; set; }
        public virtual ICollection<ProjectBudget> ProjectBudgets { get; set; }
        public virtual ICollection<ProjectClassification> ProjectClassifications { get; set; }
        public virtual ICollection<ProjectExemptReportingYear> ProjectExemptReportingYears { get; set; }
        public virtual ICollection<ProjectExternalLink> ProjectExternalLinks { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual ICollection<ProjectFundingSourceRequest> ProjectFundingSourceRequests { get; set; }
        public virtual ICollection<ProjectImage> ProjectImages { get; set; }
        public virtual ICollection<ProjectLocation> ProjectLocations { get; set; }
        public virtual ICollection<ProjectLocationStaging> ProjectLocationStagings { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotes { get; set; }
        public virtual ICollection<ProjectOrganization> ProjectOrganizations { get; set; }
        public virtual ICollection<ProjectTag> ProjectTags { get; set; }
        public virtual ICollection<ProjectUpdateBatch> ProjectUpdateBatches { get; set; }
        public virtual ICollection<ProjectWatershed> ProjectWatersheds { get; set; }
        public virtual ICollection<SnapshotProject> SnapshotProjects { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual TaxonomyTierOne TaxonomyTierOne { get; set; }
        public ProjectStage ProjectStage { get { return ProjectStage.AllLookupDictionary[ProjectStageID]; } }
        public ProjectLocationSimpleType ProjectLocationSimpleType { get { return ProjectLocationSimpleType.AllLookupDictionary[ProjectLocationSimpleTypeID]; } }
        public FundingType FundingType { get { return FundingType.AllLookupDictionary[FundingTypeID]; } }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual Person ProposingPerson { get; set; }
        public virtual Person ReviewedByPerson { get; set; }
        public ProjectApprovalStatus ProjectApprovalStatus { get { return ProjectApprovalStatus.AllLookupDictionary[ProjectApprovalStatusID]; } }

        public static class FieldLengths
        {
            public const int ProjectName = 140;
            public const int ProjectDescription = 4000;
            public const int PerformanceMeasureActualYearsExemptionExplanation = 4000;
            public const int ProjectLocationNotes = 4000;
            public const int ProjectWatershedNotes = 4000;
            public const int PerformanceMeasureNotes = 500;
        }
    }
}