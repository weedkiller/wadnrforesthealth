
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class DatabaseEntities : DbContext, LtInfo.Common.EntityModelBinding.ILtInfoEntityTypeLoader
    {
        public DatabaseEntities()
            : base("name=DatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public virtual DbSet<AgreementGrantAllocation> AgreementGrantAllocations { get; set; }
        public virtual DbSet<AgreementPerson> AgreementPeople { get; set; }
        public virtual DbSet<Agreement> Agreements { get; set; }
        public virtual DbSet<AgreementStatus> AgreementStatuses { get; set; }
        public virtual DbSet<AgreementType> AgreementTypes { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }
        public virtual DbSet<ClassificationPerformanceMeasure> ClassificationPerformanceMeasures { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }
        public virtual DbSet<ClassificationSystem> ClassificationSystems { get; set; }
        public virtual DbSet<CostType> CostTypes { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<CustomPageImage> CustomPageImages { get; set; }
        public virtual DbSet<CustomPage> CustomPages { get; set; }
        public virtual DbSet<FederalFundCode> FederalFundCodes { get; set; }
        public virtual DbSet<FieldDefinitionDataImage> FieldDefinitionDataImages { get; set; }
        public virtual DbSet<FieldDefinitionData> FieldDefinitionDatas { get; set; }
        public virtual DbSet<FileResource> FileResources { get; set; }
        public virtual DbSet<FirmaHomePageImage> FirmaHomePageImages { get; set; }
        public virtual DbSet<FirmaPageImage> FirmaPageImages { get; set; }
        public virtual DbSet<FirmaPage> FirmaPages { get; set; }
        public virtual DbSet<FocusAreaLocationStaging> FocusAreaLocationStagings { get; set; }
        public virtual DbSet<FocusArea> FocusAreas { get; set; }
        public virtual DbSet<FundingSource> FundingSources { get; set; }
        public virtual DbSet<GrantAllocationNote> GrantAllocationNotes { get; set; }
        public virtual DbSet<GrantAllocationProgramManager> GrantAllocationProgramManagers { get; set; }
        public virtual DbSet<GrantAllocationProjectCode> GrantAllocationProjectCodes { get; set; }
        public virtual DbSet<GrantAllocation> GrantAllocations { get; set; }
        public virtual DbSet<GrantNoteInternal> GrantNoteInternals { get; set; }
        public virtual DbSet<GrantNote> GrantNotes { get; set; }
        public virtual DbSet<Grant> Grants { get; set; }
        public virtual DbSet<GrantStatus> GrantStatuses { get; set; }
        public virtual DbSet<GrantType> GrantTypes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<NotificationProject> NotificationProjects { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<OrganizationBoundaryStaging> OrganizationBoundaryStagings { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationTypeRelationshipType> OrganizationTypeRelationshipTypes { get; set; }
        public virtual DbSet<OrganizationType> OrganizationTypes { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PerformanceMeasureActual> PerformanceMeasureActuals { get; set; }
        public virtual DbSet<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual DbSet<PerformanceMeasureActualSubcategoryOptionUpdate> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual DbSet<PerformanceMeasureActualUpdate> PerformanceMeasureActualUpdates { get; set; }
        public virtual DbSet<PerformanceMeasureExpected> PerformanceMeasureExpecteds { get; set; }
        public virtual DbSet<PerformanceMeasureExpectedSubcategoryOption> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual DbSet<PerformanceMeasureNote> PerformanceMeasureNotes { get; set; }
        public virtual DbSet<PerformanceMeasure> PerformanceMeasures { get; set; }
        public virtual DbSet<PerformanceMeasureSubcategory> PerformanceMeasureSubcategories { get; set; }
        public virtual DbSet<PerformanceMeasureSubcategoryOption> PerformanceMeasureSubcategoryOptions { get; set; }
        public virtual DbSet<PersonEnvironmentCredential> PersonEnvironmentCredentials { get; set; }
        public virtual DbSet<PersonStewardOrganization> PersonStewardOrganizations { get; set; }
        public virtual DbSet<PersonStewardRegion> PersonStewardRegions { get; set; }
        public virtual DbSet<PersonStewardTaxonomyBranch> PersonStewardTaxonomyBranches { get; set; }
        public virtual DbSet<PriorityArea> PriorityAreas { get; set; }
        public virtual DbSet<ProgramIndex> ProgramIndices { get; set; }
        public virtual DbSet<ProjectClassification> ProjectClassifications { get; set; }
        public virtual DbSet<ProjectCode> ProjectCodes { get; set; }
        public virtual DbSet<ProjectCustomAttribute> ProjectCustomAttributes { get; set; }
        public virtual DbSet<ProjectCustomAttributeType> ProjectCustomAttributeTypes { get; set; }
        public virtual DbSet<ProjectCustomAttributeUpdate> ProjectCustomAttributeUpdates { get; set; }
        public virtual DbSet<ProjectCustomAttributeUpdateValue> ProjectCustomAttributeUpdateValues { get; set; }
        public virtual DbSet<ProjectCustomAttributeValue> ProjectCustomAttributeValues { get; set; }
        public virtual DbSet<ProjectDocument> ProjectDocuments { get; set; }
        public virtual DbSet<ProjectDocumentUpdate> ProjectDocumentUpdates { get; set; }
        public virtual DbSet<ProjectExemptReportingYear> ProjectExemptReportingYears { get; set; }
        public virtual DbSet<ProjectExemptReportingYearUpdate> ProjectExemptReportingYearUpdates { get; set; }
        public virtual DbSet<ProjectExternalLink> ProjectExternalLinks { get; set; }
        public virtual DbSet<ProjectExternalLinkUpdate> ProjectExternalLinkUpdates { get; set; }
        public virtual DbSet<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual DbSet<ProjectFundingSourceExpenditureUpdate> ProjectFundingSourceExpenditureUpdates { get; set; }
        public virtual DbSet<ProjectFundingSourceRequest> ProjectFundingSourceRequests { get; set; }
        public virtual DbSet<ProjectFundingSourceRequestUpdate> ProjectFundingSourceRequestUpdates { get; set; }
        public virtual DbSet<ProjectImage> ProjectImages { get; set; }
        public virtual DbSet<ProjectImageUpdate> ProjectImageUpdates { get; set; }
        public virtual DbSet<ProjectInternalNote> ProjectInternalNotes { get; set; }
        public virtual DbSet<ProjectLocation> ProjectLocations { get; set; }
        public virtual DbSet<ProjectLocationStaging> ProjectLocationStagings { get; set; }
        public virtual DbSet<ProjectLocationStagingUpdate> ProjectLocationStagingUpdates { get; set; }
        public virtual DbSet<ProjectLocationUpdate> ProjectLocationUpdates { get; set; }
        public virtual DbSet<ProjectNote> ProjectNotes { get; set; }
        public virtual DbSet<ProjectNoteUpdate> ProjectNoteUpdates { get; set; }
        public virtual DbSet<ProjectOrganization> ProjectOrganizations { get; set; }
        public virtual DbSet<ProjectOrganizationUpdate> ProjectOrganizationUpdates { get; set; }
        public virtual DbSet<ProjectPerson> ProjectPeople { get; set; }
        public virtual DbSet<ProjectPersonUpdate> ProjectPersonUpdates { get; set; }
        public virtual DbSet<ProjectPriorityArea> ProjectPriorityAreas { get; set; }
        public virtual DbSet<ProjectPriorityAreaUpdate> ProjectPriorityAreaUpdates { get; set; }
        public virtual DbSet<ProjectRegion> ProjectRegions { get; set; }
        public virtual DbSet<ProjectRegionUpdate> ProjectRegionUpdates { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectTag> ProjectTags { get; set; }
        public virtual DbSet<ProjectTypePerformanceMeasure> ProjectTypePerformanceMeasures { get; set; }
        public virtual DbSet<ProjectTypeProjectCustomAttributeType> ProjectTypeProjectCustomAttributeTypes { get; set; }
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
        public virtual DbSet<ProjectUpdateBatch> ProjectUpdateBatches { get; set; }
        public virtual DbSet<ProjectUpdateConfiguration> ProjectUpdateConfigurations { get; set; }
        public virtual DbSet<ProjectUpdateHistory> ProjectUpdateHistories { get; set; }
        public virtual DbSet<ProjectUpdate> ProjectUpdates { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<SupportRequestLog> SupportRequestLogs { get; set; }
        public virtual DbSet<SystemAttribute> SystemAttributes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TaxonomyBranch> TaxonomyBranches { get; set; }
        public virtual DbSet<TaxonomyTrunk> TaxonomyTrunks { get; set; }
        public virtual DbSet<tmpAgreementContact> tmpAgreementContacts { get; set; }
        public virtual DbSet<tmpAgreementContactsImportTemplate> tmpAgreementContactsImportTemplates { get; set; }
        public virtual DbSet<TrainingVideo> TrainingVideos { get; set; }
        public virtual DbSet<TreatmentActivity> TreatmentActivities { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        public object LoadType(Type type, int primaryKey)
        {
            switch (type.Name)
            {
                case "ActivityType":
                    var activityType = ActivityType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(activityType, "ActivityType", primaryKey);
                    return activityType;

                case "AgreementGrantAllocation":
                    return AgreementGrantAllocations.GetAgreementGrantAllocation(primaryKey);

                case "AgreementPerson":
                    return AgreementPeople.GetAgreementPerson(primaryKey);

                case "AgreementPersonRole":
                    var agreementPersonRole = AgreementPersonRole.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(agreementPersonRole, "AgreementPersonRole", primaryKey);
                    return agreementPersonRole;

                case "Agreement":
                    return Agreements.GetAgreement(primaryKey);

                case "AgreementStatus":
                    return AgreementStatuses.GetAgreementStatus(primaryKey);

                case "AgreementType":
                    return AgreementTypes.GetAgreementType(primaryKey);

                case "AuditLogEventType":
                    var auditLogEventType = AuditLogEventType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(auditLogEventType, "AuditLogEventType", primaryKey);
                    return auditLogEventType;

                case "AuditLog":
                    return AuditLogs.GetAuditLog(primaryKey);

                case "Authenticator":
                    var authenticator = Authenticator.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(authenticator, "Authenticator", primaryKey);
                    return authenticator;

                case "ClassificationPerformanceMeasure":
                    return ClassificationPerformanceMeasures.GetClassificationPerformanceMeasure(primaryKey);

                case "Classification":
                    return Classifications.GetClassification(primaryKey);

                case "ClassificationSystem":
                    return ClassificationSystems.GetClassificationSystem(primaryKey);

                case "CostType":
                    return CostTypes.GetCostType(primaryKey);

                case "County":
                    return Counties.GetCounty(primaryKey);

                case "CustomPageDisplayType":
                    var customPageDisplayType = CustomPageDisplayType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(customPageDisplayType, "CustomPageDisplayType", primaryKey);
                    return customPageDisplayType;

                case "CustomPageImage":
                    return CustomPageImages.GetCustomPageImage(primaryKey);

                case "CustomPage":
                    return CustomPages.GetCustomPage(primaryKey);

                case "DeploymentEnvironment":
                    var deploymentEnvironment = DeploymentEnvironment.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(deploymentEnvironment, "DeploymentEnvironment", primaryKey);
                    return deploymentEnvironment;

                case "FederalFundCode":
                    return FederalFundCodes.GetFederalFundCode(primaryKey);

                case "FieldDefinitionDataImage":
                    return FieldDefinitionDataImages.GetFieldDefinitionDataImage(primaryKey);

                case "FieldDefinitionData":
                    return FieldDefinitionDatas.GetFieldDefinitionData(primaryKey);

                case "FieldDefinition":
                    var fieldDefinition = FieldDefinition.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(fieldDefinition, "FieldDefinition", primaryKey);
                    return fieldDefinition;

                case "FileResourceMimeType":
                    var fileResourceMimeType = FileResourceMimeType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(fileResourceMimeType, "FileResourceMimeType", primaryKey);
                    return fileResourceMimeType;

                case "FileResource":
                    return FileResources.GetFileResource(primaryKey);

                case "FirmaHomePageImage":
                    return FirmaHomePageImages.GetFirmaHomePageImage(primaryKey);

                case "FirmaPageImage":
                    return FirmaPageImages.GetFirmaPageImage(primaryKey);

                case "FirmaPageRenderType":
                    var firmaPageRenderType = FirmaPageRenderType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(firmaPageRenderType, "FirmaPageRenderType", primaryKey);
                    return firmaPageRenderType;

                case "FirmaPage":
                    return FirmaPages.GetFirmaPage(primaryKey);

                case "FirmaPageType":
                    var firmaPageType = FirmaPageType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(firmaPageType, "FirmaPageType", primaryKey);
                    return firmaPageType;

                case "FocusAreaLocationStaging":
                    return FocusAreaLocationStagings.GetFocusAreaLocationStaging(primaryKey);

                case "FocusArea":
                    return FocusAreas.GetFocusArea(primaryKey);

                case "FocusAreaStatus":
                    var focusAreaStatus = FocusAreaStatus.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(focusAreaStatus, "FocusAreaStatus", primaryKey);
                    return focusAreaStatus;

                case "FundingSource":
                    return FundingSources.GetFundingSource(primaryKey);

                case "GoogleChartType":
                    var googleChartType = GoogleChartType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(googleChartType, "GoogleChartType", primaryKey);
                    return googleChartType;

                case "GrantAllocationNote":
                    return GrantAllocationNotes.GetGrantAllocationNote(primaryKey);

                case "GrantAllocationProgramManager":
                    return GrantAllocationProgramManagers.GetGrantAllocationProgramManager(primaryKey);

                case "GrantAllocationProjectCode":
                    return GrantAllocationProjectCodes.GetGrantAllocationProjectCode(primaryKey);

                case "GrantAllocation":
                    return GrantAllocations.GetGrantAllocation(primaryKey);

                case "GrantNoteInternal":
                    return GrantNoteInternals.GetGrantNoteInternal(primaryKey);

                case "GrantNote":
                    return GrantNotes.GetGrantNote(primaryKey);

                case "Grant":
                    return Grants.GetGrant(primaryKey);

                case "GrantStatus":
                    return GrantStatuses.GetGrantStatus(primaryKey);

                case "GrantType":
                    return GrantTypes.GetGrantType(primaryKey);

                case "Invoice":
                    return Invoices.GetInvoice(primaryKey);

                case "MeasurementUnitType":
                    var measurementUnitType = MeasurementUnitType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(measurementUnitType, "MeasurementUnitType", primaryKey);
                    return measurementUnitType;

                case "NotificationProject":
                    return NotificationProjects.GetNotificationProject(primaryKey);

                case "Notification":
                    return Notifications.GetNotification(primaryKey);

                case "NotificationType":
                    var notificationType = NotificationType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(notificationType, "NotificationType", primaryKey);
                    return notificationType;

                case "OrganizationBoundaryStaging":
                    return OrganizationBoundaryStagings.GetOrganizationBoundaryStaging(primaryKey);

                case "Organization":
                    return Organizations.GetOrganization(primaryKey);

                case "OrganizationTypeRelationshipType":
                    return OrganizationTypeRelationshipTypes.GetOrganizationTypeRelationshipType(primaryKey);

                case "OrganizationType":
                    return OrganizationTypes.GetOrganizationType(primaryKey);

                case "Person":
                    return People.GetPerson(primaryKey);

                case "PerformanceMeasureActual":
                    return PerformanceMeasureActuals.GetPerformanceMeasureActual(primaryKey);

                case "PerformanceMeasureActualSubcategoryOption":
                    return PerformanceMeasureActualSubcategoryOptions.GetPerformanceMeasureActualSubcategoryOption(primaryKey);

                case "PerformanceMeasureActualSubcategoryOptionUpdate":
                    return PerformanceMeasureActualSubcategoryOptionUpdates.GetPerformanceMeasureActualSubcategoryOptionUpdate(primaryKey);

                case "PerformanceMeasureActualUpdate":
                    return PerformanceMeasureActualUpdates.GetPerformanceMeasureActualUpdate(primaryKey);

                case "PerformanceMeasureDataSourceType":
                    var performanceMeasureDataSourceType = PerformanceMeasureDataSourceType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(performanceMeasureDataSourceType, "PerformanceMeasureDataSourceType", primaryKey);
                    return performanceMeasureDataSourceType;

                case "PerformanceMeasureExpected":
                    return PerformanceMeasureExpecteds.GetPerformanceMeasureExpected(primaryKey);

                case "PerformanceMeasureExpectedSubcategoryOption":
                    return PerformanceMeasureExpectedSubcategoryOptions.GetPerformanceMeasureExpectedSubcategoryOption(primaryKey);

                case "PerformanceMeasureNote":
                    return PerformanceMeasureNotes.GetPerformanceMeasureNote(primaryKey);

                case "PerformanceMeasure":
                    return PerformanceMeasures.GetPerformanceMeasure(primaryKey);

                case "PerformanceMeasureSubcategory":
                    return PerformanceMeasureSubcategories.GetPerformanceMeasureSubcategory(primaryKey);

                case "PerformanceMeasureSubcategoryOption":
                    return PerformanceMeasureSubcategoryOptions.GetPerformanceMeasureSubcategoryOption(primaryKey);

                case "PerformanceMeasureTargetValueType":
                    var performanceMeasureTargetValueType = PerformanceMeasureTargetValueType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(performanceMeasureTargetValueType, "PerformanceMeasureTargetValueType", primaryKey);
                    return performanceMeasureTargetValueType;

                case "PerformanceMeasureType":
                    var performanceMeasureType = PerformanceMeasureType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(performanceMeasureType, "PerformanceMeasureType", primaryKey);
                    return performanceMeasureType;

                case "PersonEnvironmentCredential":
                    return PersonEnvironmentCredentials.GetPersonEnvironmentCredential(primaryKey);

                case "PersonStewardOrganization":
                    return PersonStewardOrganizations.GetPersonStewardOrganization(primaryKey);

                case "PersonStewardRegion":
                    return PersonStewardRegions.GetPersonStewardRegion(primaryKey);

                case "PersonStewardTaxonomyBranch":
                    return PersonStewardTaxonomyBranches.GetPersonStewardTaxonomyBranch(primaryKey);

                case "PriorityArea":
                    return PriorityAreas.GetPriorityArea(primaryKey);

                case "ProgramIndex":
                    return ProgramIndices.GetProgramIndex(primaryKey);

                case "ProjectApprovalStatus":
                    var projectApprovalStatus = ProjectApprovalStatus.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectApprovalStatus, "ProjectApprovalStatus", primaryKey);
                    return projectApprovalStatus;

                case "ProjectClassification":
                    return ProjectClassifications.GetProjectClassification(primaryKey);

                case "ProjectCode":
                    return ProjectCodes.GetProjectCode(primaryKey);

                case "ProjectColorByType":
                    var projectColorByType = ProjectColorByType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectColorByType, "ProjectColorByType", primaryKey);
                    return projectColorByType;

                case "ProjectCostType":
                    var projectCostType = ProjectCostType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectCostType, "ProjectCostType", primaryKey);
                    return projectCostType;

                case "ProjectCreateSection":
                    var projectCreateSection = ProjectCreateSection.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectCreateSection, "ProjectCreateSection", primaryKey);
                    return projectCreateSection;

                case "ProjectCustomAttributeDataType":
                    var projectCustomAttributeDataType = ProjectCustomAttributeDataType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectCustomAttributeDataType, "ProjectCustomAttributeDataType", primaryKey);
                    return projectCustomAttributeDataType;

                case "ProjectCustomAttribute":
                    return ProjectCustomAttributes.GetProjectCustomAttribute(primaryKey);

                case "ProjectCustomAttributeType":
                    return ProjectCustomAttributeTypes.GetProjectCustomAttributeType(primaryKey);

                case "ProjectCustomAttributeUpdate":
                    return ProjectCustomAttributeUpdates.GetProjectCustomAttributeUpdate(primaryKey);

                case "ProjectCustomAttributeUpdateValue":
                    return ProjectCustomAttributeUpdateValues.GetProjectCustomAttributeUpdateValue(primaryKey);

                case "ProjectCustomAttributeValue":
                    return ProjectCustomAttributeValues.GetProjectCustomAttributeValue(primaryKey);

                case "ProjectDocument":
                    return ProjectDocuments.GetProjectDocument(primaryKey);

                case "ProjectDocumentUpdate":
                    return ProjectDocumentUpdates.GetProjectDocumentUpdate(primaryKey);

                case "ProjectExemptReportingType":
                    var projectExemptReportingType = ProjectExemptReportingType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectExemptReportingType, "ProjectExemptReportingType", primaryKey);
                    return projectExemptReportingType;

                case "ProjectExemptReportingYear":
                    return ProjectExemptReportingYears.GetProjectExemptReportingYear(primaryKey);

                case "ProjectExemptReportingYearUpdate":
                    return ProjectExemptReportingYearUpdates.GetProjectExemptReportingYearUpdate(primaryKey);

                case "ProjectExternalLink":
                    return ProjectExternalLinks.GetProjectExternalLink(primaryKey);

                case "ProjectExternalLinkUpdate":
                    return ProjectExternalLinkUpdates.GetProjectExternalLinkUpdate(primaryKey);

                case "ProjectFundingSourceExpenditure":
                    return ProjectFundingSourceExpenditures.GetProjectFundingSourceExpenditure(primaryKey);

                case "ProjectFundingSourceExpenditureUpdate":
                    return ProjectFundingSourceExpenditureUpdates.GetProjectFundingSourceExpenditureUpdate(primaryKey);

                case "ProjectFundingSourceRequest":
                    return ProjectFundingSourceRequests.GetProjectFundingSourceRequest(primaryKey);

                case "ProjectFundingSourceRequestUpdate":
                    return ProjectFundingSourceRequestUpdates.GetProjectFundingSourceRequestUpdate(primaryKey);

                case "ProjectImage":
                    return ProjectImages.GetProjectImage(primaryKey);

                case "ProjectImageTiming":
                    var projectImageTiming = ProjectImageTiming.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectImageTiming, "ProjectImageTiming", primaryKey);
                    return projectImageTiming;

                case "ProjectImageUpdate":
                    return ProjectImageUpdates.GetProjectImageUpdate(primaryKey);

                case "ProjectInternalNote":
                    return ProjectInternalNotes.GetProjectInternalNote(primaryKey);

                case "ProjectLocationFilterType":
                    var projectLocationFilterType = ProjectLocationFilterType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectLocationFilterType, "ProjectLocationFilterType", primaryKey);
                    return projectLocationFilterType;

                case "ProjectLocation":
                    return ProjectLocations.GetProjectLocation(primaryKey);

                case "ProjectLocationSimpleType":
                    var projectLocationSimpleType = ProjectLocationSimpleType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectLocationSimpleType, "ProjectLocationSimpleType", primaryKey);
                    return projectLocationSimpleType;

                case "ProjectLocationStaging":
                    return ProjectLocationStagings.GetProjectLocationStaging(primaryKey);

                case "ProjectLocationStagingUpdate":
                    return ProjectLocationStagingUpdates.GetProjectLocationStagingUpdate(primaryKey);

                case "ProjectLocationType":
                    var projectLocationType = ProjectLocationType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectLocationType, "ProjectLocationType", primaryKey);
                    return projectLocationType;

                case "ProjectLocationUpdate":
                    return ProjectLocationUpdates.GetProjectLocationUpdate(primaryKey);

                case "ProjectNote":
                    return ProjectNotes.GetProjectNote(primaryKey);

                case "ProjectNoteUpdate":
                    return ProjectNoteUpdates.GetProjectNoteUpdate(primaryKey);

                case "ProjectOrganization":
                    return ProjectOrganizations.GetProjectOrganization(primaryKey);

                case "ProjectOrganizationUpdate":
                    return ProjectOrganizationUpdates.GetProjectOrganizationUpdate(primaryKey);

                case "ProjectPerson":
                    return ProjectPeople.GetProjectPerson(primaryKey);

                case "ProjectPersonRelationshipType":
                    var projectPersonRelationshipType = ProjectPersonRelationshipType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectPersonRelationshipType, "ProjectPersonRelationshipType", primaryKey);
                    return projectPersonRelationshipType;

                case "ProjectPersonUpdate":
                    return ProjectPersonUpdates.GetProjectPersonUpdate(primaryKey);

                case "ProjectPriorityArea":
                    return ProjectPriorityAreas.GetProjectPriorityArea(primaryKey);

                case "ProjectPriorityAreaUpdate":
                    return ProjectPriorityAreaUpdates.GetProjectPriorityAreaUpdate(primaryKey);

                case "ProjectRegion":
                    return ProjectRegions.GetProjectRegion(primaryKey);

                case "ProjectRegionUpdate":
                    return ProjectRegionUpdates.GetProjectRegionUpdate(primaryKey);

                case "Project":
                    return Projects.GetProject(primaryKey);

                case "ProjectStage":
                    var projectStage = ProjectStage.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectStage, "ProjectStage", primaryKey);
                    return projectStage;

                case "ProjectStewardshipAreaType":
                    var projectStewardshipAreaType = ProjectStewardshipAreaType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectStewardshipAreaType, "ProjectStewardshipAreaType", primaryKey);
                    return projectStewardshipAreaType;

                case "ProjectTag":
                    return ProjectTags.GetProjectTag(primaryKey);

                case "ProjectTypePerformanceMeasure":
                    return ProjectTypePerformanceMeasures.GetProjectTypePerformanceMeasure(primaryKey);

                case "ProjectTypeProjectCustomAttributeType":
                    return ProjectTypeProjectCustomAttributeTypes.GetProjectTypeProjectCustomAttributeType(primaryKey);

                case "ProjectType":
                    return ProjectTypes.GetProjectType(primaryKey);

                case "ProjectUpdateBatch":
                    return ProjectUpdateBatches.GetProjectUpdateBatch(primaryKey);

                case "ProjectUpdateConfiguration":
                    return ProjectUpdateConfigurations.GetProjectUpdateConfiguration(primaryKey);

                case "ProjectUpdateHistory":
                    return ProjectUpdateHistories.GetProjectUpdateHistory(primaryKey);

                case "ProjectUpdate":
                    return ProjectUpdates.GetProjectUpdate(primaryKey);

                case "ProjectUpdateSection":
                    var projectUpdateSection = ProjectUpdateSection.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectUpdateSection, "ProjectUpdateSection", primaryKey);
                    return projectUpdateSection;

                case "ProjectUpdateState":
                    var projectUpdateState = ProjectUpdateState.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectUpdateState, "ProjectUpdateState", primaryKey);
                    return projectUpdateState;

                case "ProjectWorkflowSectionGrouping":
                    var projectWorkflowSectionGrouping = ProjectWorkflowSectionGrouping.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectWorkflowSectionGrouping, "ProjectWorkflowSectionGrouping", primaryKey);
                    return projectWorkflowSectionGrouping;

                case "Region":
                    return Regions.GetRegion(primaryKey);

                case "RelationshipType":
                    return RelationshipTypes.GetRelationshipType(primaryKey);

                case "Role":
                    var role = Role.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(role, "Role", primaryKey);
                    return role;

                case "StateProvince":
                    return StateProvinces.GetStateProvince(primaryKey);

                case "SupportRequestLog":
                    return SupportRequestLogs.GetSupportRequestLog(primaryKey);

                case "SupportRequestType":
                    var supportRequestType = SupportRequestType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(supportRequestType, "SupportRequestType", primaryKey);
                    return supportRequestType;

                case "SystemAttribute":
                    return SystemAttributes.GetSystemAttribute(primaryKey);

                case "Tag":
                    return Tags.GetTag(primaryKey);

                case "TaxonomyBranch":
                    return TaxonomyBranches.GetTaxonomyBranch(primaryKey);

                case "TaxonomyLevel":
                    var taxonomyLevel = TaxonomyLevel.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(taxonomyLevel, "TaxonomyLevel", primaryKey);
                    return taxonomyLevel;

                case "TaxonomyTrunk":
                    return TaxonomyTrunks.GetTaxonomyTrunk(primaryKey);

                case "tmpAgreementContact":
                    return tmpAgreementContacts.GettmpAgreementContact(primaryKey);

                case "tmpAgreementContactsImportTemplate":
                    return tmpAgreementContactsImportTemplates.GettmpAgreementContactsImportTemplate(primaryKey);

                case "TrainingVideo":
                    return TrainingVideos.GetTrainingVideo(primaryKey);

                case "TreatmentActivity":
                    return TreatmentActivities.GetTreatmentActivity(primaryKey);

                case "TreatmentActivityStatus":
                    var treatmentActivityStatus = TreatmentActivityStatus.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(treatmentActivityStatus, "TreatmentActivityStatus", primaryKey);
                    return treatmentActivityStatus;

                case "TreatmentType":
                    var treatmentType = TreatmentType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(treatmentType, "TreatmentType", primaryKey);
                    return treatmentType;

                case "Vendor":
                    return Vendors.GetVendor(primaryKey);
                default:
                    throw new NotImplementedException(string.Format("No loader for type \"{0}\"", type.FullName));
            }
        }
    }
}