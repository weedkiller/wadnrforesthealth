﻿/*-----------------------------------------------------------------------
<copyright file="ProjectCreateController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.ProjectCreate;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirma.Web.Views.Shared.ProjectDocument;
using ProjectFirma.Web.Views.Shared.ProjectOrganization;
using ProjectFirma.Web.Views.Shared.ProjectWatershedControls;
using ProjectFirma.Web.Views.Shared.SortOrder;
using Basics = ProjectFirma.Web.Views.ProjectCreate.Basics;
using BasicsViewData = ProjectFirma.Web.Views.ProjectCreate.BasicsViewData;
using BasicsViewModel = ProjectFirma.Web.Views.ProjectCreate.BasicsViewModel;
using ExpectedFunding = ProjectFirma.Web.Views.ProjectCreate.ExpectedFunding;
using ExpectedFundingViewData = ProjectFirma.Web.Views.ProjectCreate.ExpectedFundingViewData;
using ExpectedFundingViewModel = ProjectFirma.Web.Views.ProjectCreate.ExpectedFundingViewModel;
using Expenditures = ProjectFirma.Web.Views.ProjectCreate.Expenditures;
using ExpendituresViewData = ProjectFirma.Web.Views.ProjectCreate.ExpendituresViewData;
using ExpendituresViewModel = ProjectFirma.Web.Views.ProjectCreate.ExpendituresViewModel;
using LocationDetailed = ProjectFirma.Web.Views.ProjectCreate.LocationDetailed;
using LocationDetailedViewData = ProjectFirma.Web.Views.ProjectCreate.LocationDetailedViewData;
using LocationDetailedViewModel = ProjectFirma.Web.Views.ProjectCreate.LocationDetailedViewModel;
using LocationSimple = ProjectFirma.Web.Views.ProjectCreate.LocationSimple;
using LocationSimpleViewData = ProjectFirma.Web.Views.ProjectCreate.LocationSimpleViewData;
using LocationSimpleViewModel = ProjectFirma.Web.Views.ProjectCreate.LocationSimpleViewModel;
using Organizations = ProjectFirma.Web.Views.ProjectCreate.Organizations;
using OrganizationsViewData = ProjectFirma.Web.Views.ProjectCreate.OrganizationsViewData;
using OrganizationsViewModel = ProjectFirma.Web.Views.ProjectCreate.OrganizationsViewModel;
using PerformanceMeasures = ProjectFirma.Web.Views.ProjectCreate.PerformanceMeasures;
using PerformanceMeasuresViewData = ProjectFirma.Web.Views.ProjectCreate.PerformanceMeasuresViewData;
using PerformanceMeasuresViewModel = ProjectFirma.Web.Views.ProjectCreate.PerformanceMeasuresViewModel;
using Photos = ProjectFirma.Web.Views.ProjectCreate.Photos;
using WatershedViewData = ProjectFirma.Web.Views.ProjectCreate.WatershedViewData;
using WatershedViewModel = ProjectFirma.Web.Views.ProjectCreate.WatershedViewModel;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectCreateController : FirmaBaseController
    {
        [HttpGet]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public PartialViewResult ProjectTypeSelection()
        {
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            var viewData = new ProjectTypeSelectionViewData(tenantAttribute);
            var viewModel = new ProjectTypeSelectionViewModel();
            return RazorPartialView<ProjectTypeSelection, ProjectTypeSelectionViewData, ProjectTypeSelectionViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ProjectTypeSelection(ProjectTypeSelectionViewModel viewModel)
        {
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            var viewData = new ProjectTypeSelectionViewData(tenantAttribute);

            if (!ModelState.IsValid)
            {
                return RazorPartialView<ProjectTypeSelection, ProjectTypeSelectionViewData, ProjectTypeSelectionViewModel>(viewData, viewModel);
            }

            switch (viewModel.CreateType)
            {
                case ProjectTypeSelectionViewModel.ProjectCreateType.Proposal:
                    return new ModalDialogFormJsonResult(
                        SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null)));
                case ProjectTypeSelectionViewModel.ProjectCreateType.Existing:
                    return new ModalDialogFormJsonResult(
                        SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsEnterHistoric(null)));
                case ProjectTypeSelectionViewModel.ProjectCreateType.ImportExternal:
                    try
                    {
                        new ProjectExternalImportDataRestClient().ImportProjects();
                        SetMessageForDisplay("Projects were successfully imported.");
                    }
                    catch (ProjectExternalImportDataException)
                    {
                        SetErrorForDisplay("There was a problem importing projects from the provided external data source.");
                    }

                    return new ModalDialogFormJsonResult(
                        SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Index()));
                default:
                    throw new ArgumentException();
            }
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ActionResult InstructionsProposal(int? projectID)
        {
            var firmaPageType = FirmaPageType.ToType(FirmaPageTypeEnum.ProposeProjectInstructions);
            var firmaPage = FirmaPage.GetFirmaPageByPageType(firmaPageType);

            if (projectID.HasValue)
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.GetProject(projectID.Value);

                var proposalSectionsStatus = new ProposalSectionsStatus(project);
                var viewData = new InstructionsProposalViewData(CurrentPerson, project, proposalSectionsStatus, firmaPage, false);

                return RazorView<InstructionsProposal, InstructionsProposalViewData>(viewData);
            }
            else
            {
                var viewData = new InstructionsProposalViewData(CurrentPerson, firmaPage, true);
                return RazorView<InstructionsProposal, InstructionsProposalViewData>(viewData);
            }
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ActionResult InstructionsEnterHistoric(int? projectID)
        {
            var firmaPageType = FirmaPageType.ToType(FirmaPageTypeEnum.EnterHistoricProjectInstructions);
            var firmaPage = FirmaPage.GetFirmaPageByPageType(firmaPageType);

            if (projectID.HasValue)
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.GetProject(projectID.Value);

                var proposalSectionsStatus = new ProposalSectionsStatus(project);
                var viewData = new InstructionsEnterHistoricViewData(CurrentPerson, project, proposalSectionsStatus, firmaPage, false);

                return RazorView<InstructionsEnterHistoric, InstructionsEnterHistoricViewData>(viewData);
            }
            else
            {
                var viewData = new InstructionsEnterHistoricViewData(CurrentPerson, firmaPage, true);
                return RazorView<InstructionsEnterHistoric, InstructionsEnterHistoricViewData>(viewData);
            }
        }

        [HttpGet]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ActionResult CreateAndEditBasics(bool newProjectIsProposal)
        {
            var basicsViewModel = new BasicsViewModel();
            if (newProjectIsProposal)
            {
                basicsViewModel.ProjectStageID = ProjectStage.Proposal.ProjectStageID;
            }
            
            return ViewCreateAndEditBasics(basicsViewModel, !newProjectIsProposal);
        }

        private ViewResult ViewCreateAndEditBasics(BasicsViewModel viewModel, bool newProjectIsHistoric)
        {
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs;
            var instructionsPageUrl = newProjectIsHistoric
                ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsEnterHistoric(null))
                : SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null));
            var viewData = new BasicsViewData(CurrentPerson, FundingType.All, taxonomyLeafs, newProjectIsHistoric, instructionsPageUrl);

            return RazorView<Basics, BasicsViewData, BasicsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditBasics(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new BasicsViewModel(project);
            return ViewEditBasics(project, viewModel);
        }

        private ViewResult ViewEditBasics(Project project, BasicsViewModel viewModel)
        {            
            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            proposalSectionsStatus.IsBasicsSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsBasicsSectionComplete;
            
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs;
            var viewData = new BasicsViewData(CurrentPerson, project, proposalSectionsStatus, taxonomyLeafs, FundingType.All);

            return RazorView<Basics, BasicsViewData, BasicsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult CreateAndEditBasics(bool newProjectIsProposal, BasicsViewModel viewModel)
        {
            var project = new Project(viewModel.TaxonomyLeafID,
                viewModel.ProjectStageID,
                viewModel.ProjectName,
                viewModel.ProjectDescription,
                false,
                ProjectLocationSimpleType.None.ProjectLocationSimpleTypeID,
                viewModel.FundingTypeID,
                ProjectApprovalStatus.Draft.ProjectApprovalStatusID)
            {
                ProposingPerson = CurrentPerson,
                ProposingDate = DateTime.Now
            };

            return SaveProjectAndCreateAuditEntry(project, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBasics(ProjectPrimaryKey projectPrimaryKey, BasicsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            return SaveProjectAndCreateAuditEntry(project, viewModel);
        }

        private ActionResult SaveProjectAndCreateAuditEntry(Project project, BasicsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                SetErrorForDisplay($"Could not save {FieldDefinition.Project.GetFieldDefinitionLabel()}: Please fix validation errors to proceed.");

                bool showProjectStageDropDown = viewModel.ProjectStageID != ProjectStage.Proposal.ProjectStageID;

                return ModelObjectHelpers.IsRealPrimaryKeyValue(project.PrimaryKey) ? ViewEditBasics(project, viewModel) : ViewCreateAndEditBasics(viewModel, showProjectStageDropDown);
            }

            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(project.PrimaryKey))
            {
                HttpRequestStorage.DatabaseEntities.AllProjects.Add(project);
            }

            viewModel.UpdateModel(project, CurrentPerson);

            if (project.ProjectStage == ProjectStage.Proposal)
            {
                DeletePerformanceMeasureActuals(project);
                DeleteProjectExemptReportingYears(project);
                DeleteProjectFundingSourceExpenditures(project);
            }

            if (project.ProjectStage == ProjectStage.PlanningDesign)
            {
                DeletePerformanceMeasureActuals(project);
                DeleteProjectExemptReportingYears(project);
            }

            HttpRequestStorage.DatabaseEntities.SaveChanges();

            var auditLog = new AuditLog(CurrentPerson,
                DateTime.Now,
                AuditLogEventType.Added,
                "Project",
                project.ProjectID,
                "ProjectID",
                project.ProjectID.ToString())
            {
                ProjectID = project.ProjectID,
                AuditDescription = $"Project: created {project.DisplayName}"
            };
            HttpRequestStorage.DatabaseEntities.AllAuditLogs.Add(auditLog);
            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} succesfully saved.");

            return GoToNextSection(viewModel, project, ProjectCreateSection.Basics);
        }

        [HttpGet]
        [PerformanceMeasureExpectedProposedFeature]
        public ViewResult EditExpectedPerformanceMeasureValues(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ExpectedPerformanceMeasureValuesViewModel(project);
            return ViewEditExpectedPerformanceMeasureValues(project, viewModel);
        }

        private ViewResult ViewEditExpectedPerformanceMeasureValues(Project project, ExpectedPerformanceMeasureValuesViewModel viewModel)
        {
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().SortByOrderThenName().ToList();
            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            proposalSectionsStatus.IsPerformanceMeasureSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsPerformanceMeasureSectionComplete;

            var editPerformanceMeasureExpectedsViewData = new EditPerformanceMeasureExpectedViewData(
                new List<ProjectSimple> {new ProjectSimple(project)}, performanceMeasures, project.ProjectID, false);
            var viewData = new ExpectedPerformanceMeasureValuesViewData(CurrentPerson, project, proposalSectionsStatus, editPerformanceMeasureExpectedsViewData);
            return RazorView<ExpectedPerformanceMeasureValues, ExpectedPerformanceMeasureValuesViewData, ExpectedPerformanceMeasureValuesViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureExpectedProposedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditExpectedPerformanceMeasureValues(ProjectPrimaryKey projectPrimaryKey, ExpectedPerformanceMeasureValuesViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewEditExpectedPerformanceMeasureValues(project, viewModel);
            }
            var performanceMeasureExpecteds = project.PerformanceMeasureExpecteds.ToList();

            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpecteds.Load();
            var allPerformanceMeasureExpecteds = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpecteds.Local;

            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpectedSubcategoryOptions.Load();
            var allPerformanceMeasureExpectedSubcategoryOptions = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedSubcategoryOptions.Local;

            viewModel.UpdateModel(performanceMeasureExpecteds, allPerformanceMeasureExpecteds, allPerformanceMeasureExpectedSubcategoryOptions, project);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()} succesfully saved.");
            return GoToNextSection(viewModel, project,ProjectCreateSection.ExpectedPerformanceMeasures);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ActionResult PerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            if (project == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectCreateController>(x => x.InstructionsProposal(project.ProjectID)));
            }
            var performanceMeasureActualSimples =
                project.PerformanceMeasureActuals.OrderBy(pam => pam.PerformanceMeasure.PerformanceMeasureSortOrder).ThenBy(x=>x.PerformanceMeasure.DisplayName)
                    .ThenByDescending(x => x.CalendarYear)
                    .Select(x => new PerformanceMeasureActualSimple(x))
                    .ToList();
            var projectExemptReportingYears = project.ProjectExemptReportingYears
                .Select(x => new ProjectExemptReportingYearSimple(x)).ToList();
            var currentExemptedYears = projectExemptReportingYears.Select(x => x.CalendarYear).ToList();
            var possibleYearsToExempt = project.GetProjectUpdateImplementationStartToCompletionYearRange();
            projectExemptReportingYears.AddRange(
                possibleYearsToExempt.Where(x => !currentExemptedYears.Contains(x))
                    .Select((x, index) => new ProjectExemptReportingYearSimple(-(index + 1), project.ProjectID, x)));

            var viewModel = new PerformanceMeasuresViewModel(performanceMeasureActualSimples,
                project.PerformanceMeasureActualYearsExemptionExplanation,
                projectExemptReportingYears.OrderBy(x => x.CalendarYear).ToList()){ProjectID = projectPrimaryKey.PrimaryKeyValue};
            return ViewPerformanceMeasures(project, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult PerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, PerformanceMeasuresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (project == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectCreateController>(x => x.InstructionsProposal(project.ProjectID)));
            }
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewPerformanceMeasures(project, viewModel);
            }
            var performanceMeasureActuals = project.PerformanceMeasureActuals.ToList();
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Load();
            var allPerformanceMeasureActuals = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActuals.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptions.Load();
            var performanceMeasureActualSubcategoryOptions = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptions.Local;
            viewModel.UpdateModel(performanceMeasureActuals, allPerformanceMeasureActuals, performanceMeasureActualSubcategoryOptions, project);

            return GoToNextSection(viewModel, project, ProjectCreateSection.ReportedPerformanceMeasures);
        }

        private ViewResult ViewPerformanceMeasures(Project project, PerformanceMeasuresViewModel viewModel)
        {
            var performanceMeasures =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().SortByOrderThenName().ToList();
            var showExemptYears = project.ProjectExemptReportingYears.Any() ||
                                  ModelState.Values.SelectMany(x => x.Errors)
                                      .Any(
                                          x =>
                                              x.ErrorMessage == FirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears ||
                                              x.ErrorMessage == FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears);

            var performanceMeasureSubcategories = performanceMeasures.SelectMany(x => x.PerformanceMeasureSubcategories).Distinct(new HavePrimaryKeyComparer<PerformanceMeasureSubcategory>()).ToList();
            var performanceMeasureSimples = performanceMeasures.Select(x => new PerformanceMeasureSimple(x)).ToList();
            var performanceMeasureSubcategorySimples = performanceMeasureSubcategories.Select(y => new PerformanceMeasureSubcategorySimple(y)).ToList();

            var performanceMeasureSubcategoryOptionSimples = performanceMeasureSubcategories.SelectMany(y => y.PerformanceMeasureSubcategoryOptions.Select(z => new PerformanceMeasureSubcategoryOptionSimple(z))).ToList();

            var calendarYears = FirmaDateUtilities.ReportingYearsForUserInput().OrderByDescending(x => x).ToList();
            //todo
            //var performanceMeasuresValidationResult = project.ValidatePerformanceMeasures();

            var viewDataForAngularEditor = new PerformanceMeasuresViewData.ViewDataForAngularEditor(project.ProjectID,
                performanceMeasureSimples,
                performanceMeasureSubcategorySimples,
                performanceMeasureSubcategoryOptionSimples,
                calendarYears,
                showExemptYears);
            var updateStatus = new ProposalSectionsStatus(project);
            var viewData =
                new PerformanceMeasuresViewData(CurrentPerson, project, viewDataForAngularEditor, updateStatus);
            return RazorView<PerformanceMeasures, PerformanceMeasuresViewData, PerformanceMeasuresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult ExpectedFunding(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ExpectedFundingViewModel(project.ProjectFundingSourceRequests.ToList());
            return ViewExpectedFunding(project, viewModel);
        }

        private ViewResult ViewExpectedFunding(Project project, ExpectedFundingViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var estimatedTotalCost = project.EstimatedTotalCost ?? 0;
            var viewDataForAngularEditor = new ExpectedFundingViewData.ViewDataForAngularClass(project, allFundingSources, estimatedTotalCost);

            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            proposalSectionsStatus.IsExpectedFundingSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsPerformanceMeasureSectionComplete;

            var viewData = new ExpectedFundingViewData(CurrentPerson, project, proposalSectionsStatus, viewDataForAngularEditor);
            return RazorView<ExpectedFunding, ExpectedFundingViewData, ExpectedFundingViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExpectedFunding(ProjectPrimaryKey projectPrimaryKey, ExpectedFundingViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewExpectedFunding(project, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceRequests.Load();
            var projectFundingSourceRequests = project.ProjectFundingSourceRequests.ToList();
            var allProjectFundingSourceExpectedFunding = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceRequests.Local;
            viewModel.UpdateModel(project, projectFundingSourceRequests, allProjectFundingSourceExpectedFunding);
            SetMessageForDisplay("Proposed Project Performance Measures successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.ExpectedFunding);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ActionResult Expenditures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            
            if (project == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectCreateController>(x => x.InstructionsProposal(projectPrimaryKey.PrimaryKeyValue)));
            }
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRange = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var viewModel = new ExpendituresViewModel(projectFundingSourceExpenditures,
                calendarYearRange) {ProjectID = project.ProjectID};
            return ViewExpenditures(project, calendarYearRange, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Expenditures(ProjectPrimaryKey projectPrimaryKey, ExpendituresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            
            if (project == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectCreateController>(x => x.InstructionsProposal(projectPrimaryKey.PrimaryKeyValue)));
            }

            viewModel.ProjectID = project.ProjectID;

            var projectFundingSourceExpenditureUpdates = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRange = projectFundingSourceExpenditureUpdates.CalculateCalendarYearRangeForExpenditures(project);
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewExpenditures(project, calendarYearRange, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditureUpdates.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditures.Local;
            viewModel.UpdateModel(project, projectFundingSourceExpenditureUpdates, allProjectFundingSourceExpenditures);

            return GoToNextSection(viewModel, project, ProjectCreateSection.ReportedExpenditures);
        }

        private ViewResult ViewExpenditures(Project project, List<int> calendarYearRange, ExpendituresViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();

            // todo: fix this pattern
            // var expendituresValidationResult = project.ValidateExpenditures();

            var viewDataForAngularEditor = new ExpendituresViewData.ViewDataForAngularClass(project,
                allFundingSources,
                calendarYearRange);
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var fromFundingSourcesAndCalendarYears = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(
                new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures),
                calendarYearRange);
            var projectExpendituresSummaryViewData = new ProjectExpendituresDetailViewData(fromFundingSourcesAndCalendarYears, calendarYearRange);

            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            var viewData = new ExpendituresViewData(CurrentPerson, project, viewDataForAngularEditor, projectExpendituresSummaryViewData, proposalSectionsStatus);
            return RazorView<Expenditures, ExpendituresViewData, ExpendituresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditClassifications(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectClassificationSimples = GetProjectClassificationSimples(project);
            var viewModel = new EditProposalClassificationsViewModel(projectClassificationSimples);
            return ViewEditClassifications(project, viewModel);
        }

        public static List<ProjectClassificationSimple> GetProjectClassificationSimples(Project project)
        {
            var selectedProjectClassifications = project.ProjectClassifications;

            var projectClassificationSimples =
                HttpRequestStorage.DatabaseEntities.ClassificationSystems.OrderBy(x => x.ClassificationSystemName).SelectMany(x => x.Classifications).OrderBy(x => x.DisplayName).Select(x => new ProjectClassificationSimple
                {
                    ClassificationID = x.ClassificationID,
                    ClassificationSystemID = x.ClassificationSystemID,
                    ProjectID = project.ProjectID
                }).ToList();
 
            foreach (var selectedClassification in selectedProjectClassifications)
            {
                var selectedSimple = projectClassificationSimples.Single(x => x.ClassificationID == selectedClassification.ClassificationID);
                selectedSimple.Selected = true;
                selectedSimple.ProjectClassificationNotes = selectedClassification.ProjectClassificationNotes;
            }

            return projectClassificationSimples;
        }

        private ViewResult ViewEditClassifications(Project project, EditProposalClassificationsViewModel viewModel)
        {
            var allClassificationSystems = HttpRequestStorage.DatabaseEntities.ClassificationSystems.ToList().Where(x => x.HasClassifications).OrderBy(p => p.ClassificationSystemName).ToList();
            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            proposalSectionsStatus.IsClassificationsComplete = ModelState.IsValid && proposalSectionsStatus.IsClassificationsComplete;

            var viewData = new EditProposalClassificationsViewData(CurrentPerson, project, allClassificationSystems, ProjectCreateSection.Classifications, proposalSectionsStatus);
            return RazorView<EditProposalClassifications, EditProposalClassificationsViewData, EditProposalClassificationsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditClassifications(ProjectPrimaryKey projectPrimaryKey, EditProposalClassificationsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewEditClassifications(project, viewModel);
            }
            var currentProjectClassifications = viewModel.ProjectClassificationSimples;
            HttpRequestStorage.DatabaseEntities.ProjectClassifications.Load();
            viewModel.UpdateModel(project, currentProjectClassifications);

            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} {FieldDefinition.Classification.GetFieldDefinitionLabelPluralized()} succesfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.Classifications);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditAssessment(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;            
            var projectAssessmentQuestionSimples = GetProjectAssessmentQuestionSimples(project);
            var viewModel = new EditAssessmentViewModel(projectAssessmentQuestionSimples);
            return ViewEditAssessment(project, viewModel);
        }

        public static List<ProjectAssessmentQuestionSimple> GetProjectAssessmentQuestionSimples(Project project)
        {           
            var allQuestionsAsSimples =
                HttpRequestStorage.DatabaseEntities.AssessmentQuestions.Where(x => !x.ArchiveDate.HasValue).ToList().Select(x => new ProjectAssessmentQuestionSimple(x, project)).ToList();

            var answeredQuestions = project.ProjectAssessmentQuestions.ToList();

            foreach (var question in allQuestionsAsSimples)
            {
                var matchedQuestionOrNull = answeredQuestions.SingleOrDefault(answeredQuestion => answeredQuestion.AssessmentQuestionID == question.AssessmentQuestionID);                
                question.Answer = matchedQuestionOrNull?.Answer;
            }
            return allQuestionsAsSimples;
        }


        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [ProjectCreateFeature]
        public ActionResult EditAssessment(ProjectPrimaryKey projectPrimaryKey, EditAssessmentViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewEditAssessment(project, viewModel);
            }

            viewModel.UpdateModel(project);
            SetMessageForDisplay("Assessment succesfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.Assessment);
        }

        private ViewResult ViewEditAssessment(Project project, EditAssessmentViewModel viewModel)
        {
            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            proposalSectionsStatus.IsAssessmentComplete = ModelState.IsValid && proposalSectionsStatus.IsAssessmentComplete;
            var assessmentGoals = HttpRequestStorage.DatabaseEntities.AssessmentGoals.ToList();
            var viewData = new EditAssessmentViewData(CurrentPerson, project, assessmentGoals, ProjectCreateSection.Assessment, proposalSectionsStatus);
            return RazorView<EditAssessment, EditAssessmentViewData, EditAssessmentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditLocationSimple(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new LocationSimpleViewModel(project);
            return ViewEditLocationSimple(project, viewModel);
        }

        private ViewResult ViewEditLocationSimple(Project project, LocationSimpleViewModel viewModel)
        {
            var layerGeoJsons = MapInitJson.GetAllWatershedMapLayers(LayerInitialVisibility.Hide);
            var mapInitJson = new MapInitJson($"project_{project.ProjectID}_EditMap", 10, layerGeoJsons, BoundingBox.MakeNewDefaultBoundingBox(), false) {AllowFullScreen = false, DisablePopups = true };
            
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            var mapPostUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.EditLocationSimple(project, null));
            var mapFormID = GenerateEditProjectLocationSimpleFormID(project);

            var editProjectLocationViewData = new ProjectLocationSimpleViewData(CurrentPerson, mapInitJson, tenantAttribute, null, mapPostUrl, mapFormID);

            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            proposalSectionsStatus.IsProjectLocationSimpleSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsProjectLocationSimpleSectionComplete;
            var viewData = new LocationSimpleViewData(CurrentPerson, project, proposalSectionsStatus, editProjectLocationViewData);

            return RazorView<LocationSimple, LocationSimpleViewData, LocationSimpleViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditLocationSimple(ProjectPrimaryKey projectPrimaryKey, LocationSimpleViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewEditLocationSimple(project, viewModel);
            }

            viewModel.UpdateModel(project);
            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} Location succesfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.LocationSimple);
        }


        private static string GenerateEditProjectLocationSimpleFormID(Project project)
        {
            return $"editMapForProject{project.ProjectID}";
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditLocationDetailed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new LocationDetailedViewModel();
            return ViewEditLocationDetailed(project, viewModel);
        }

        private ViewResult ViewEditLocationDetailed(Project project, LocationDetailedViewModel viewModel)
        {
            var mapDivID = $"project_{project.EntityID}_EditDetailedMap";
            var detailedLocationGeoJsonFeatureCollection = project.DetailedLocationToGeoJsonFeatureCollection();
            var editableLayerGeoJson = new LayerGeoJson($"Proposed {FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()}- Detail", detailedLocationGeoJsonFeatureCollection, "red", 1, LayerInitialVisibility.Show);

            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(project);
            var layers = MapInitJson.GetAllWatershedMapLayers(LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleMapLayer(project));
            var mapInitJson = new MapInitJson(mapDivID, 10, layers, boundingBox) { AllowFullScreen = false, DisablePopups = true};

            var mapFormID = GenerateEditProjectLocationFormID(project.ProjectID);
            var uploadGisFileUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.ImportGdbFile(project.EntityID));
            var saveFeatureCollectionUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditLocationDetailed(project, null));

            var hasSimpleLocationPoint = project.ProjectLocationPoint != null;

            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            var projectLocationDetailViewData = new ProjectLocationDetailViewData(project.ProjectID, mapInitJson, editableLayerGeoJson, uploadGisFileUrl, mapFormID, saveFeatureCollectionUrl, ProjectLocation.FieldLengths.Annotation, hasSimpleLocationPoint);
            var viewData = new LocationDetailedViewData(CurrentPerson, project, proposalSectionsStatus, projectLocationDetailViewData);
            return RazorView<LocationDetailed, LocationDetailedViewData, LocationDetailedViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditLocationDetailed(ProjectPrimaryKey projectPrimaryKey, LocationDetailedViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditLocationDetailed(project, viewModel);
            }
            SaveDetailedLocations(viewModel, project);
            return GoToNextSection(viewModel, project, ProjectCreateSection.LocationDetailed);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult ImportGdbFile(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ImportGdbFileViewModel();
            return ViewImportGdbFile(viewModel, project.ProjectID);
        }

        private PartialViewResult ViewImportGdbFile(ImportGdbFileViewModel viewModel, int projectID)
        {
            var mapFormID = GenerateEditProjectLocationFormID(projectID);
            var newGisUploadUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ImportGdbFile(projectID, null));
            var approveGisUploadUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ApproveGisUpload(projectID, null));
            var viewData = new ImportGdbFileViewData(mapFormID, newGisUploadUrl, approveGisUploadUrl);
            return RazorPartialView<ImportGdbFile, ImportGdbFileViewData, ImportGdbFileViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ImportGdbFile(ProjectPrimaryKey projectPrimaryKey, ImportGdbFileViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewImportGdbFile(viewModel, project.ProjectID);
            }

            var httpPostedFileBase = viewModel.FileResourceData;
            var fileEnding = ".gdb.zip";
            using (var disposableTempFile = DisposableTempFile.MakeDisposableTempFileEndingIn(fileEnding))
            {
                var gdbFile = disposableTempFile.FileInfo;
                httpPostedFileBase.SaveAs(gdbFile.FullName);
                project.ProjectLocationStagings.ToList().DeleteProjectLocationStaging();
                project.ProjectLocationStagings.Clear();
                ProjectLocationStaging.CreateProjectLocationStagingListFromGdb(gdbFile, project, CurrentPerson);
            }
            return ApproveGisUpload(project);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ProjectLocationDetailViewModel();
            return ViewApproveGisUpload(project, viewModel);
        }

        private PartialViewResult ViewApproveGisUpload(Project project, ProjectLocationDetailViewModel viewModel)
        {
            var projectLocationStagings = project.ProjectLocationStagings.ToList();
            var layerGeoJsons =
                projectLocationStagings.Select(
                    (projectLocationStaging, i) =>
                        new LayerGeoJson(projectLocationStaging.FeatureClassName,
                            projectLocationStaging.ToGeoJsonFeatureCollection(),
                            FirmaHelpers.DefaultColorRange[i],
                            1,
                            LayerInitialVisibility.Show)).ToList();

            var boundingBox = BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(layerGeoJsons);

            var mapInitJson = new MapInitJson($"project_{project.ProjectID}_PreviewMap", 10, layerGeoJsons, boundingBox, false) {AllowFullScreen = false, DisablePopups = true};
            var mapFormID = GenerateEditProjectLocationFormID(project.ProjectID);
            var approveGisUploadUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ApproveGisUpload(project, null));

            var viewData = new ApproveGisUploadViewData(new List<IProjectLocationStaging>(projectLocationStagings), mapInitJson, mapFormID, approveGisUploadUrl);
            return RazorPartialView<ApproveGisUpload, ApproveGisUploadViewData, ProjectLocationDetailViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey, ProjectLocationDetailViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewApproveGisUpload(project, viewModel);
            }
            SaveDetailedLocations(viewModel, project);
            DbSpatialHelper.Reduce(new List<IHaveSqlGeometry>(project.ProjectLocations.ToList()));
            return new ModalDialogFormJsonResult();
        }

        private static void SaveDetailedLocations(ProjectLocationDetailViewModel viewModel, Project project)
        {
            var projectLocations = project.ProjectLocations.ToList();
            projectLocations.DeleteProjectLocation();
            project.ProjectLocations.Clear();
            if (viewModel.WktAndAnnotations != null)
            {
                foreach (var wktAndAnnotation in viewModel.WktAndAnnotations)
                {
                    project.ProjectLocations.Add(new ProjectLocation(project, DbGeometry.FromText(wktAndAnnotation.Wkt), wktAndAnnotation.Annotation));
                }
            }
        }

        public static string GenerateEditProjectLocationFormID(int projectID)
        {
            return $"editMapForProject{projectID}";
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditWatershed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new WatershedViewModel(project);
            return ViewEditWatershed(project, viewModel);
        }

        private ViewResult ViewEditWatershed(Project project, WatershedViewModel viewModel)
        {
            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(project);
            var layers = MapInitJson.GetAllWatershedMapLayers(LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleAndDetailedMapLayers(project));
            var mapInitJson = new MapInitJson("projectWatershedMap", 0, layers, boundingBox) { AllowFullScreen = false, DisablePopups = true};
            var watershedIDs = viewModel.WatershedIDs ?? new List<int>();
            var watershedsInViewModel = HttpRequestStorage.DatabaseEntities.Watersheds.Where(x => watershedIDs.Contains(x.WatershedID)).ToList();
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            var editProjectWatershedsPostUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.EditWatershed(project, null));
            var editProjectWatershedsFormId = GenerateEditProjectWatershedFormID(project);

            var editProjectLocationViewData = new EditProjectWatershedsViewData(CurrentPerson, mapInitJson, watershedsInViewModel, tenantAttribute, editProjectWatershedsPostUrl, editProjectWatershedsFormId, project.HasProjectLocationPoint, project.HasProjectLocationDetail);

            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            proposalSectionsStatus.IsWatershedSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsWatershedSectionComplete;
            var viewData = new WatershedViewData(CurrentPerson, project, proposalSectionsStatus, editProjectLocationViewData);

            return RazorView<Views.ProjectCreate.Watershed, WatershedViewData, WatershedViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditWatershed(ProjectPrimaryKey projectPrimaryKey, WatershedViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewEditWatershed(project, viewModel);
            }
            var currentProjectWatersheds = project.ProjectWatersheds.ToList();
            var allProjectWatersheds = HttpRequestStorage.DatabaseEntities.AllProjectWatersheds.Local;
            viewModel.UpdateModel(project, currentProjectWatersheds, allProjectWatersheds);
            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} Watersheds succesfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.Watershed);
        }

        private static string GenerateEditProjectWatershedFormID(Project project)
        {
            return $"editMapForProject{project.ProjectID}";
        }

        [ProjectCreateFeature]
        public ViewResult DocumentsAndNotes(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var entityNotes = new List<IEntityNote>(project.ProjectNotes);
            var addNoteUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.NewNote(project));
            var canEditNotesAndDocuments = new ProjectCreateFeature().HasPermission(CurrentPerson, project).HasPermission;
            var entityNotesViewData = new EntityNotesViewData(EntityNote.CreateFromEntityNote(entityNotes), addNoteUrl, $"{FieldDefinition.Project.GetFieldDefinitionLabel()}", canEditNotesAndDocuments);

            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            var projectDocumentsDetailViewData = new ProjectDocumentsDetailViewData(
                EntityDocument.CreateFromEntityDocument(new List<IEntityDocument>(project.ProjectDocuments)),
                SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.NewDocument(project)), project.ProjectName,
                canEditNotesAndDocuments);
            var viewData = new DocumentsAndNotesViewData(CurrentPerson, project, proposalSectionsStatus, entityNotesViewData, projectDocumentsDetailViewData);
            return RazorView<DocumentsAndNotes, DocumentsAndNotesViewData>(viewData);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult NewNote(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEditNote(viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewNote(ProjectPrimaryKey projectPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditNote(viewModel);
            }
            var project = projectPrimaryKey.EntityObject;
            var projectNote = ProjectNote.CreateNewBlank(project);
            viewModel.UpdateModel(projectNote, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllProjectNotes.Add(projectNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult EditNote(ProjectNotePrimaryKey projectNotePrimaryKey)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(projectNote.Note);
            return ViewEditNote(viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditNote(ProjectNotePrimaryKey projectNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditNote(viewModel);
            }
            var projectNote = projectNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(projectNote, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditNote(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult DeleteNote(ProjectNotePrimaryKey projectNotePrimaryKey)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectNote.ProjectNoteID);
            return ViewDeleteNote(projectNote, viewModel);
        }

        private PartialViewResult ViewDeleteNote(ProjectNote projectNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this note for project '{projectNote.Project.DisplayName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"Proposed {FieldDefinition.ProjectNote.GetFieldDefinitionLabel()}");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteNote(ProjectNotePrimaryKey projectNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteNote(projectNote, viewModel);
            }
            projectNote.DeleteProjectNote();
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult NewDocument(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new NewProjectDocumentViewModel();
            return ViewNewDocument(viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewDocument(ProjectPrimaryKey projectPrimaryKey, NewProjectDocumentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewDocument(viewModel);
            }
            var project = projectPrimaryKey.EntityObject;
            viewModel.UpdateModel(project, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult EditDocument(ProjectDocumentPrimaryKey projectDocumentPrimaryKey)
        {
            var projectDocument = projectDocumentPrimaryKey.EntityObject;
            var viewModel = new EditProjectDocumentsViewModel(projectDocument);
            return ViewEditDocument(viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDocument(ProjectDocumentPrimaryKey projectDocumentPrimaryKey, EditProjectDocumentsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditDocument(viewModel);
            }
            var projectDocument = projectDocumentPrimaryKey.EntityObject;
            viewModel.UpdateModel(projectDocument);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditDocument(EditProjectDocumentsViewModel viewModel)
        {
            var viewData = new EditProjectDocumentsViewData();
            return RazorPartialView<EditProjectDocuments, EditProjectDocumentsViewData, EditProjectDocumentsViewModel>(viewData, viewModel);
        }

        private PartialViewResult ViewNewDocument(NewProjectDocumentViewModel viewModel)
        {
            var viewData = new NewProjectDocumentViewData();
            return RazorPartialView<NewProjectDocument, NewProjectDocumentViewData, NewProjectDocumentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult DeleteDocument(ProjectDocumentPrimaryKey projectDocumentPrimaryKey)
        {
            var projectDocument = projectDocumentPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectDocument.ProjectDocumentID);
            return ViewDeleteDocument(projectDocument, viewModel);
        }

        private PartialViewResult ViewDeleteDocument(ProjectDocument projectDocument, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectDocument.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete \"{projectDocument.DisplayName}\" from this {FieldDefinition.Project.GetFieldDefinitionLabel()}?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"Proposed Project Document");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteDocument(ProjectDocumentPrimaryKey projectDocumentPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectDocument = projectDocumentPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteDocument(projectDocument, viewModel);
            }
            projectDocument.DeleteProjectDocument();
            return new ModalDialogFormJsonResult();
        }

        [ProjectCreateFeature]
        public ViewResult Photos(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewData = BuildImageGalleryViewData(project, CurrentPerson);
            return RazorView<Photos, PhotoViewData>(viewData);
        }

        private static PhotoViewData BuildImageGalleryViewData(Project project, Person currentPerson)
        {
            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            var newPhotoForProjectUrl = SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.NewFromProposal(project));
            var galleryName = $"ProjectImage{project.ProjectID}";
            var projectImages = project.ProjectImages.ToList();
            var imageGalleryViewData = new PhotoViewData(currentPerson, galleryName, projectImages, newPhotoForProjectUrl, x => x.CaptionOnFullView, project, proposalSectionsStatus);
            return imageGalleryViewData;
        }

        [HttpGet]
        [ProjectDeleteProposalFeature]
        public PartialViewResult DeleteProjectProposal(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(projectPrimaryKey.PrimaryKeyValue);
            return ViewDeleteProject(projectPrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewDeleteProject(Project project, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to delete {FieldDefinition.Project.GetFieldDefinitionLabel()} \"{project.DisplayName}\"?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectDeleteProposalFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectProposal(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProject(project, viewModel);
            }
            var message = $"Project \"{project.DisplayName}\" succesfully deleted.";
            project.DeleteFull();
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult Submit(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(project.ProjectID);
            //TODO: Change "reviewer" to specific reviewer as determined by tentant review 
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to submit {FieldDefinition.Project.GetFieldDefinitionLabel()} \"{project.DisplayName}\" to the reviewer?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Submit(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            project.ProjectApprovalStatusID = ProjectApprovalStatus.PendingApproval.ProjectApprovalStatusID;
            project.SubmissionDate = DateTime.Now;
            NotificationProject.SendSubmittedMessage(project);
            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} succesfully submitted for review.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        [HttpGet]
        [ProjectApproveFeature]
        public PartialViewResult Approve(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(project.ProjectID);
            return ViewApprove(viewModel);
        }


        [HttpPost]
        [ProjectApproveFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Approve(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewApprove(viewModel);
            }
            var project = projectPrimaryKey.EntityObject;
            Check.Assert(project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval,
                $"{FieldDefinition.Project.GetFieldDefinitionLabel()} is not in Submitted state. Actual state is: " + project.ProjectApprovalStatus.ProjectApprovalStatusDisplayName);

            Check.Assert(ProposalSectionsStatus.AreAllSectionsValidForProject(project), "Proposal is not ready for submittal.");
            
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            project.ProjectApprovalStatusID = ProjectApprovalStatus.Approved.ProjectApprovalStatusID;
            project.ApprovalDate = DateTime.Now;
            project.ReviewedByPerson = CurrentPerson;

            // Business logic: An approved Proposal becomes an active project in the Planning and Design stage
            if (project.ProjectStageID == ProjectStage.Proposal.ProjectStageID)
            {
                project.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            }

            GenerateApprovalAuditLogEntries(project);

            NotificationProject.SendApprovalMessage(project);

            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} \"{UrlTemplate.MakeHrefString(project.GetDetailUrl(), project.DisplayName)}\" succesfully approved as an actual {FieldDefinition.Project.GetFieldDefinitionLabel()} in the {project.ProjectStage.ProjectStageDisplayName} stage.");

            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        private void GenerateApprovalAuditLogEntries(Project project)
        {
            var auditLog = new AuditLog(CurrentPerson, DateTime.Now, AuditLogEventType.Added, "Project", project.ProjectID, "ProjectID", project.ProjectID.ToString())
            {
                ProjectID = project.ProjectID,
                AuditDescription = $"Proposal {project.DisplayName} approved."
            };
            HttpRequestStorage.DatabaseEntities.AllAuditLogs.Add(auditLog);
        }

        private PartialViewResult ViewApprove(ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to approve this {FieldDefinition.Project.GetFieldDefinitionLabel()}?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult Withdraw(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(project.ProjectID);
            //TODO: Change "reviewer" to specific reviewer as determined by tentant review 
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to withdraw {FieldDefinition.Project.GetFieldDefinitionLabel()} \"{project.DisplayName}\" from review?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Withdraw(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            project.ProjectApprovalStatusID = ProjectApprovalStatus.Draft.ProjectApprovalStatusID;
            //TODO: Change "reviewer" to specific reviewer as determined by tentant review 
            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} withdrawn from review.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        [HttpGet]
        [ProjectApproveFeature]
        public PartialViewResult Return(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(project.ProjectID);
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to return {FieldDefinition.Project.GetFieldDefinitionLabel()} \"{project.DisplayName}\" to Submitter?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectApproveFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Return(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            project.ProjectApprovalStatusID = ProjectApprovalStatus.Returned.ProjectApprovalStatusID;
            project.ReviewedByPerson = CurrentPerson;
            NotificationProject.SendReturnedMessage(project);
            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} returned to Submitter for additional clarifactions/corrections.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        [HttpGet]
        [ProjectApproveFeature]
        public PartialViewResult Reject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(project.ProjectID);
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to reject {FieldDefinition.Project.GetFieldDefinitionLabel()} \"{project.DisplayName}\"?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectApproveFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Reject(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            project.ProjectApprovalStatusID = ProjectApprovalStatus.Rejected.ProjectApprovalStatusID;
            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} was rejected.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        [ProjectViewFeature]
        public GridJsonNetJObjectResult<AuditLog> AuditLogsGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var gridSpec = new AuditLogsGridSpec();
            var auditLogs1 = HttpRequestStorage.DatabaseEntities.AuditLogs.GetAuditLogEntriesForProject(projectPrimaryKey.EntityObject);
            var auditLogs = auditLogs1;
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<AuditLog>(auditLogs, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private void ShowValidationErrors(List<ValidationResult> validationResults)
        {
            var validationErrorMessages = string.Empty;
            if (validationResults.Any())
            {
                validationErrorMessages =$" Please fix these errors: <ul>{string.Join(Environment.NewLine, validationResults.Select(x => $"<li>{x.ErrorMessage}</li>"))}</ul>";
            }
            SetErrorForDisplay($"Could not save {FieldDefinition.Project.GetFieldDefinitionLabel()}.{validationErrorMessages}");
        }

        private ActionResult GoToNextSection(FormViewModel viewModel, Project project, ProjectCreateSection currentSection)
        {
            var applicableWizardSections = Project.GetApplicableProposalWizardSections(project);
            var nextProjectUpdateSection = applicableWizardSections.Where(x => x.SortOrder > currentSection.SortOrder).OrderBy(x => x.SortOrder).FirstOrDefault();
            var nextSection = viewModel.AutoAdvance && nextProjectUpdateSection != null ? nextProjectUpdateSection.GetSectionUrl(project) : currentSection.GetSectionUrl(project);
            return Redirect(nextSection);
        }

        private void DeletePerformanceMeasureActuals(Project project)
        {
            project.PerformanceMeasureActuals.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptions.Select(y => y.PerformanceMeasureActualSubcategoryOptionID)).ToList().DeletePerformanceMeasureActualSubcategoryOption();
            project.PerformanceMeasureActuals.DeletePerformanceMeasureActual();
            project.PerformanceMeasureActualYearsExemptionExplanation = null;
        }

        public void DeleteProjectExemptReportingYears(Project project)
        {
            project.ProjectExemptReportingYears.DeleteProjectExemptReportingYear();
        }

        public void DeleteProjectFundingSourceExpenditures(Project project)
        {
            project.ProjectFundingSourceExpenditures.DeleteProjectFundingSourceExpenditure(); 
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult Organizations(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new OrganizationsViewModel(project, CurrentPerson);
            return ViewOrganizations(project, viewModel);
        }

        private ViewResult ViewOrganizations(Project project, OrganizationsViewModel viewModel)
        {
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(p => p.FullNameFirstLastAndOrg).ToList();
            if (!allPeople.Contains(CurrentPerson))
            {
                allPeople.Add(CurrentPerson);
            }
            var allRelationshipTypes = HttpRequestStorage.DatabaseEntities.RelationshipTypes.ToList();
            var defaultPrimaryContact = project?.GetPrimaryContact() ?? CurrentPerson.Organization.PrimaryContactPerson;
            
            var editOrganizationsViewData = new EditOrganizationsViewData(allOrganizations, allPeople, allRelationshipTypes, defaultPrimaryContact);

            var proposalSectionsStatus = new ProposalSectionsStatus(project);
            proposalSectionsStatus.IsProjectOrganizationsSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsProjectOrganizationsSectionComplete;
            var viewData = new OrganizationsViewData(CurrentPerson, project, proposalSectionsStatus, editOrganizationsViewData);

            return RazorView<Organizations, OrganizationsViewData, OrganizationsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Organizations(ProjectPrimaryKey projectPrimaryKey, OrganizationsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewOrganizations(project, viewModel);
            }

            HttpRequestStorage.DatabaseEntities.ProjectOrganizations.Load();
            var allProjectOrganizations = HttpRequestStorage.DatabaseEntities.AllProjectOrganizations.Local;

            viewModel.UpdateModel(project, allProjectOrganizations);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} {FieldDefinition.Organization.GetFieldDefinitionLabelPluralized()} succesfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.Organizations);
        }
    }
}
