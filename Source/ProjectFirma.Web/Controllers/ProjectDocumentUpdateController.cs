﻿using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectDocument;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectDocumentUpdateController : FirmaBaseController
    {
        [HttpGet]
        [ProjectDocumentUpdateNewFeature]
        public PartialViewResult New(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey)
        {
            var viewModel = new NewViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [ProjectDocumentUpdateNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey, NewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var projectUpdateBatch = projectUpdateBatchPrimaryKey.EntityObject;
            //var projectDocumentUpdate = ProjectDocumentUpdate.CreateNewBlank(projectUpdateBatch, null);
            viewModel.UpdateModel(projectUpdateBatch, CurrentPerson);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            //HttpRequestStorage.DatabaseEntities.AllProjectDocumentUpdates.Add(projectDocumentUpdate);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectDocumentUpdateEditFeature]
        public PartialViewResult Edit(ProjectDocumentUpdatePrimaryKey projectDocumentUpdatePrimaryKey)
        {
            var projectDocumentUpdate = projectDocumentUpdatePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(projectDocumentUpdate);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectDocumentUpdateEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectDocumentUpdatePrimaryKey projectDocumentUpdatePrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var projectDocumentUpdate = projectDocumentUpdatePrimaryKey.EntityObject;
            viewModel.UpdateModel(projectDocumentUpdate);
            projectDocumentUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(NewViewModel viewModel)
        {
            var viewData = new NewViewData();
            return RazorPartialView<New, NewViewData, NewViewModel>(viewData, viewModel);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectDocumentUpdateEditFeature]
        public PartialViewResult Delete(ProjectDocumentUpdatePrimaryKey projectDocumentUpdatePrimaryKey)
        {
            var projectDocumentUpdate = projectDocumentUpdatePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectDocumentUpdate.ProjectDocumentUpdateID);
            return ViewDelete(projectDocumentUpdate, viewModel);
        }

        private PartialViewResult ViewDelete(ProjectDocumentUpdate projectDocumentUpdate, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectDocumentUpdate.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this document for {FieldDefinition.Project.GetFieldDefinitionLabel()} '{projectDocumentUpdate.ProjectUpdateBatch.Project.DisplayName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"Document"); // todo field definition

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectDocumentUpdateEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ProjectDocumentUpdatePrimaryKey projectDocumentUpdatePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectDocumentUpdate = projectDocumentUpdatePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(projectDocumentUpdate, viewModel);
            }
            projectDocumentUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            projectDocumentUpdate.DeleteProjectDocumentUpdate();
            return new ModalDialogFormJsonResult();
        }
    }
}