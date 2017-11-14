﻿/*-----------------------------------------------------------------------
<copyright file="ProjectNoteController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectNoteController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var project = projectPrimaryKey.EntityObject;
            var projectNote = ProjectNote.CreateNewBlank(project);
            viewModel.UpdateModel(projectNote, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllProjectNotes.Add(projectNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectNoteManageAsAdminFeature]
        public PartialViewResult Edit(ProjectNotePrimaryKey projectNotePrimaryKey)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(projectNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectNoteManageAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectNotePrimaryKey projectNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var projectNote = projectNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(projectNote, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectNoteManageAsAdminFeature]
        public PartialViewResult DeleteProjectNote(ProjectNotePrimaryKey projectNotePrimaryKey)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectNote.ProjectNoteID);
            return ViewDeleteProjectNote(projectNote, viewModel);
        }

        private PartialViewResult ViewDeleteProjectNote(ProjectNote projectNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this note for {FieldDefinition.Project.GetFieldDefinitionLabel()} '{projectNote.Project.DisplayName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinition.ProjectNote.GetFieldDefinitionLabel()}");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectNoteManageAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectNote(ProjectNotePrimaryKey projectNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectNote(projectNote, viewModel);
            }
            projectNote.DeleteProjectNote();
            return new ModalDialogFormJsonResult();
        }
    }
}
