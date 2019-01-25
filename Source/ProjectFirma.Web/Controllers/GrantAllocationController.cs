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

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.ExcelWorkbookUtilities;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.GrantAllocation;
using ProjectFirma.Web.Views.Shared;

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
            var confirmMessage = $"Are you sure you want to delete this {FieldDefinition.GrantAllocation.GetFieldDefinitionLabel()} '{grantAllocation.ProjectName}'?";
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

            var message = $"{FieldDefinition.GrantAllocation.GetFieldDefinitionLabel()} \"{grantAllocation.ProjectName}\" successfully deleted.";
            grantAllocation.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [GrantAllocationEditAsAdminFeature]
        public PartialViewResult Edit(GrantAllocationPrimaryKey grantAllocationPrimaryKey)
        {
            var grantAllocation = grantAllocationPrimaryKey.EntityObject;
            var viewModel = new EditGrantAllocationViewModel(grantAllocation);
            return ViewEdit(viewModel, EditGrantAllocationType.ExistingGrantAllocation);
        }

        [HttpPost]
        [GrantAllocationEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(GrantAllocationPrimaryKey grantAllocationPrimaryKey, EditGrantAllocationViewModel viewModel)
        {
            var grantAllocation = grantAllocationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, EditGrantAllocationType.ExistingGrantAllocation);
            }
            // Listify the ProjectCodes
            viewModel.UpdateModel(grantAllocation, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditGrantAllocationViewModel viewModel, EditGrantAllocationType editGrantAllocationType)
        {
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var grantStatuses = HttpRequestStorage.DatabaseEntities.GrantStatuses;
            var grantTypes = HttpRequestStorage.DatabaseEntities.GrantTypes;
            var grants = HttpRequestStorage.DatabaseEntities.Grants;
            var regions = HttpRequestStorage.DatabaseEntities.Regions;
            var projectCodes = HttpRequestStorage.DatabaseEntities.ProjectCodes;

            var viewData = new EditGrantAllocationViewData(editGrantAllocationType,
                organizations,
                grantStatuses,
                grantTypes,
                grants,
                regions,
                projectCodes
            );
            return RazorPartialView<EditGrantAllocation, EditGrantAllocationViewData, EditGrantAllocationViewModel>(viewData, viewModel);
        }

        [GrantAllocationsViewFeature]
        public ViewResult GrantAllocationDetail(GrantAllocationPrimaryKey grantAllocationPrimaryKey)
        {
            var grantAllocation = HttpRequestStorage.DatabaseEntities.GrantAllocations.Single(g => g.GrantAllocationID == grantAllocationPrimaryKey.PrimaryKeyValue);
            var viewData = new Views.GrantAllocation.DetailViewData(CurrentPerson, grantAllocation);
            return RazorView<Views.GrantAllocation.Detail, Views.GrantAllocation.DetailViewData>(viewData);
        }
    }
}
