﻿/*-----------------------------------------------------------------------
<copyright file="ProjectController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.ExcelWorkbookUtilities;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.GrantAllocation;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.GrantAllocationControls;
using DetailViewData = ProjectFirma.Web.Views.GrantAllocation.DetailViewData;
using ProjectFirma.Web.Views.Shared.TextControls;

namespace ProjectFirma.Web.Controllers
{
    public class GrantAllocationController : FirmaBaseController
    {
        [HttpGet]
        [GrantAllocationDeleteFeature]
        public PartialViewResult DeleteGrantAllocation(GrantAllocationPrimaryKey grantAllocationPrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(grantAllocationPrimaryKey.PrimaryKeyValue);
            return ViewDeleteGrantAllocation(grantAllocationPrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewDeleteGrantAllocation(GrantAllocation grantAllocation, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to delete this {FieldDefinition.GrantAllocation.GetFieldDefinitionLabel()} '{grantAllocation.GrantAllocationName}'?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [GrantAllocationDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteGrantAllocation(GrantAllocationPrimaryKey grantAllocationPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var grantAllocation = grantAllocationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteGrantAllocation(grantAllocation, viewModel);
            }

            var message = $"{FieldDefinition.GrantAllocation.GetFieldDefinitionLabel()} \"{grantAllocation.GrantAllocationName}\" successfully deleted.";
            grantAllocation.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [GrantAllocationEditAsAdminFeature]
        public PartialViewResult NewGrantAllocationNote(GrantAllocationPrimaryKey grantAllocationPrimaryKey)
        {
            var viewModel = new EditGrantAllocationNoteViewModel();
            return ViewEditNote(viewModel, EditGrantAllocationNoteType.NewNote);
        }

        [HttpPost]
        [GrantAllocationEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewGrantAllocationNote(GrantAllocationPrimaryKey grantAllocationPrimaryKey, EditGrantAllocationNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditNote(viewModel, EditGrantAllocationNoteType.NewNote);
            }
            var grantAllocation = grantAllocationPrimaryKey.EntityObject;
            var grantAllocationNote = GrantAllocationNote.CreateNewBlank(grantAllocation, CurrentPerson);
            viewModel.UpdateModel(grantAllocationNote, CurrentPerson, EditGrantAllocationNoteType.NewNote);
            HttpRequestStorage.DatabaseEntities.GrantAllocationNotes.Add(grantAllocationNote);
            return new ModalDialogFormJsonResult();
        }


        private PartialViewResult ViewEditNote(EditGrantAllocationNoteViewModel viewModel, EditGrantAllocationNoteType editGrantAllocationNoteType)
        {
            var viewData = new EditGrantAllocationNoteViewData(editGrantAllocationNoteType);
            return RazorPartialView<EditGrantAllocationNote, EditGrantAllocationNoteViewData, EditGrantAllocationNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [GrantAllocationEditAsAdminFeature]
        public PartialViewResult NewGrantAllocationNoteInternal(GrantAllocationPrimaryKey grantAllocationPrimaryKey)
        {
            var viewModel = new EditGrantAllocationNoteInternalViewModel();
            return ViewEditGrantAllocationNoteInternal(viewModel, EditGrantAllocationNoteInternalType.NewNote);
        }

        [HttpPost]
        [GrantAllocationEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewGrantAllocationNoteInternal(GrantAllocationPrimaryKey grantAllocationPrimaryKey, EditGrantAllocationNoteInternalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditGrantAllocationNoteInternal(viewModel, EditGrantAllocationNoteInternalType.NewNote);
            }
            var grantAllocation = grantAllocationPrimaryKey.EntityObject;
            var grantAllocationNoteInternal = GrantAllocationNoteInternal.CreateNewBlank(grantAllocation, CurrentPerson);
            viewModel.UpdateModel(grantAllocationNoteInternal, CurrentPerson, EditGrantAllocationNoteType.NewNote);
            HttpRequestStorage.DatabaseEntities.GrantAllocationNoteInternals.Add(grantAllocationNoteInternal);
            return new ModalDialogFormJsonResult();
        }


        private PartialViewResult ViewEditGrantAllocationNoteInternal(EditGrantAllocationNoteInternalViewModel viewModel, EditGrantAllocationNoteInternalType editGrantAllocationNoteInternalType)
        {
            var viewData = new EditGrantAllocationNoteInternalViewData(editGrantAllocationNoteInternalType);
            return RazorPartialView<EditGrantAllocationNoteInternal, EditGrantAllocationNoteInternalViewData, EditGrantAllocationNoteInternalViewModel>(viewData, viewModel);
        }


        [HttpGet]
        [GrantAllocationNoteInternalEditAsAdminFeature]
        public PartialViewResult EditGrantAllocationNoteInternal(GrantAllocationNoteInternalPrimaryKey grantAllocationNoteInternalPrimaryKey)
        {
            var grantAllocationNoteInternal = grantAllocationNoteInternalPrimaryKey.EntityObject;
            var viewModel = new EditGrantAllocationNoteInternalViewModel(grantAllocationNoteInternal);
            return ViewEditGrantAllocationNoteInternal(viewModel, EditGrantAllocationNoteInternalType.ExistingGrantAllocationNoteInternal);
        }

        [HttpPost]
        [GrantAllocationNoteInternalEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditGrantAllocationNoteInternal(GrantAllocationNoteInternalPrimaryKey grantAllocationNoteInternalPrimaryKey, EditGrantAllocationNoteInternalViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditGrantAllocationNoteInternal(viewModel, EditGrantAllocationNoteInternalType.ExistingGrantAllocationNoteInternal);
            }

            var grantAllocationNoteInternal = grantAllocationNoteInternalPrimaryKey.EntityObject;
            viewModel.UpdateModel(grantAllocationNoteInternal, CurrentPerson, EditGrantAllocationNoteType.ExistingGrantAllocationNote);
            HttpRequestStorage.DatabaseEntities.GrantAllocationNoteInternals.AddOrUpdate(grantAllocationNoteInternal);
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [GrantAllocationNoteInternalEditAsAdminFeature]
        public PartialViewResult DeleteGrantAllocationNoteInternal(GrantAllocationNoteInternalPrimaryKey grantAllocationNoteInternalPrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(grantAllocationNoteInternalPrimaryKey.PrimaryKeyValue);
            return ViewDeleteGrantAllocationNoteInternal(grantAllocationNoteInternalPrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewDeleteGrantAllocationNoteInternal(GrantAllocationNoteInternal grantAllocationNoteInternal, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to delete this {FieldDefinition.GrantAllocationNoteInternal.GetFieldDefinitionLabel()} created on '{grantAllocationNoteInternal.CreatedDate}' by '{grantAllocationNoteInternal.CreatedByPerson.FullNameFirstLast}'?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [GrantAllocationNoteInternalEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteGrantAllocationNoteInternal(GrantAllocationNoteInternalPrimaryKey grantAllocationNoteInternalPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var grantAllocationNoteInternal = grantAllocationNoteInternalPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteGrantAllocationNoteInternal(grantAllocationNoteInternal, viewModel);
            }

            var message = $"{FieldDefinition.GrantAllocationNoteInternal.GetFieldDefinitionLabel()} created on '{grantAllocationNoteInternal.CreatedDate}' by '{grantAllocationNoteInternal.CreatedByPerson.FullNameFirstLast}' successfully deleted.";
            grantAllocationNoteInternal.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [GrantAllocationNoteEditAsAdminFeature]
        public PartialViewResult EditGrantAllocationNote(GrantAllocationNotePrimaryKey grantAllocationNotePrimaryKey)
        {
            var grantAllocationNote = grantAllocationNotePrimaryKey.EntityObject;
            var viewModel = new EditGrantAllocationNoteViewModel(grantAllocationNote);
            return ViewEditNote(viewModel, EditGrantAllocationNoteType.ExistingGrantAllocationNote);
        }

        [HttpPost]
        [GrantAllocationNoteEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditGrantAllocationNote(GrantAllocationNotePrimaryKey grantAllocationNotePrimaryKey, EditGrantAllocationNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditNote(viewModel, EditGrantAllocationNoteType.ExistingGrantAllocationNote);
            }

            var grantAllocationNote = grantAllocationNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(grantAllocationNote, CurrentPerson, EditGrantAllocationNoteType.ExistingGrantAllocationNote);
            HttpRequestStorage.DatabaseEntities.GrantAllocationNotes.AddOrUpdate(grantAllocationNote);
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [GrantAllocationNoteEditAsAdminFeature]
        public PartialViewResult DeleteGrantAllocationNote(GrantAllocationNotePrimaryKey grantAllocationNotePrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(grantAllocationNotePrimaryKey.PrimaryKeyValue);
            return ViewDeleteGrantAllocationNote(grantAllocationNotePrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewDeleteGrantAllocationNote(GrantAllocationNote grantAllocationNote, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to delete this {FieldDefinition.GrantAllocationNote.GetFieldDefinitionLabel()} created on '{grantAllocationNote.CreatedDate}' by '{grantAllocationNote.CreatedByPerson.FullNameFirstLast}'?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [GrantAllocationNoteEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteGrantAllocationNote(GrantAllocationNotePrimaryKey grantAllocationNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var grantAllocationNote = grantAllocationNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteGrantAllocationNote(grantAllocationNote, viewModel);
            }

            var message = $"{FieldDefinition.GrantAllocationNote.GetFieldDefinitionLabel()} created on '{grantAllocationNote.CreatedDate}' by '{grantAllocationNote.CreatedByPerson.FullNameFirstLast}' successfully deleted.";
            grantAllocationNote.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [GrantAllocationEditAsAdminFeature]
        public PartialViewResult Edit(GrantAllocationPrimaryKey grantAllocationPrimaryKey)
        {
            var grantAllocation = grantAllocationPrimaryKey.EntityObject;
            var viewModel = new EditGrantAllocationViewModel(grantAllocation);
            return GrantAllocationViewEdit(viewModel, EditGrantAllocationType.ExistingGrantAllocation);
        }

        [HttpPost]
        [GrantAllocationEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(GrantAllocationPrimaryKey grantAllocationPrimaryKey, EditGrantAllocationViewModel viewModel)
        {
            var grantAllocation = grantAllocationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return GrantAllocationViewEdit(viewModel, EditGrantAllocationType.ExistingGrantAllocation);
            }
            viewModel.UpdateModel(grantAllocation, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult GrantAllocationViewEdit(EditGrantAllocationViewModel viewModel, EditGrantAllocationType editGrantAllocationType)
        {
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var grantTypes = HttpRequestStorage.DatabaseEntities.GrantTypes;
            var grants = HttpRequestStorage.DatabaseEntities.Grants.ToList();
            var divisions = Division.All;
            var regions = HttpRequestStorage.DatabaseEntities.Regions;
            var federalFundCodes = HttpRequestStorage.DatabaseEntities.FederalFundCodes;
            var people = HttpRequestStorage.DatabaseEntities.People.ToList();

            var viewData = new EditGrantAllocationViewData(editGrantAllocationType,
                organizations,
                grantTypes,
                grants,
                divisions,
                regions,
                federalFundCodes,
                people
            );
            return RazorPartialView<EditGrantAllocation, EditGrantAllocationViewData, EditGrantAllocationViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [GrantAllocationCreateFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditGrantAllocationViewModel();
            return GrantAllocationViewEdit(viewModel, EditGrantAllocationType.NewGrantAllocation);
        }

        [HttpPost]
        [GrantAllocationCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditGrantAllocationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return GrantAllocationViewEdit(viewModel, EditGrantAllocationType.NewGrantAllocation);
            }
            var grant = HttpRequestStorage.DatabaseEntities.Grants.Single(g => g.GrantID == viewModel.GrantID);
            var grantAllocation = GrantAllocation.CreateNewBlank(grant);
            viewModel.UpdateModel(grantAllocation, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [GrantAllocationsViewFeature]
        public ViewResult GrantAllocationDetail(GrantAllocationPrimaryKey grantAllocationPrimaryKey)
        {
            var grantAllocation = HttpRequestStorage.DatabaseEntities.GrantAllocations.SingleOrDefault(g => g.GrantAllocationID == grantAllocationPrimaryKey.PrimaryKeyValue);
            if (grantAllocation == null)
            {
                throw new Exception($"Could not find GrantAllocationID # {grantAllocationPrimaryKey.PrimaryKeyValue}; has it been deleted?");
            }

            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();
            var grantAllocationBasicsViewData = new GrantAllocationBasicsViewData(grantAllocation, false, taxonomyLevel);
            var userHasEditGrantAllocationPermissions = new GrantAllocationEditAsAdminFeature().HasPermissionByPerson(CurrentPerson);
            var grantAllocationNotesViewData = new EntityNotesViewData(
                EntityNote.CreateFromEntityNote(new List<IEntityNote>(grantAllocation.GrantAllocationNotes)),
                SitkaRoute<GrantAllocationController>.BuildUrlFromExpression(x => x.NewGrantAllocationNote(grantAllocationPrimaryKey)),
                grantAllocation.GrantAllocationName,
                userHasEditGrantAllocationPermissions);
            var grantAllocationNoteInternalsViewData = new EntityNotesViewData(
                EntityNote.CreateFromEntityNote(new List<IEntityNote>(grantAllocation.GrantAllocationNoteInternals)),
                SitkaRoute<GrantAllocationController>.BuildUrlFromExpression(x => x.NewGrantAllocationNoteInternal(grantAllocationPrimaryKey)),
                grantAllocation.GrantAllocationName,
                userHasEditGrantAllocationPermissions);

            var viewData = new Views.GrantAllocation.DetailViewData(CurrentPerson, grantAllocation, grantAllocationBasicsViewData, grantAllocationNotesViewData, grantAllocationNoteInternalsViewData);
            return RazorView<Views.GrantAllocation.Detail, Views.GrantAllocation.DetailViewData>(viewData);
        }
    }
}
