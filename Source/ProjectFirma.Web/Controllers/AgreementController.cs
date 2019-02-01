﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Agreement;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class AgreementController : FirmaBaseController
    {
        [AgreementsViewFullListFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.FullAgreementList);
            var viewData = new AgreementIndexViewData(CurrentPerson, firmaPage);
            return RazorView<AgreementIndex, AgreementIndexViewData>(viewData);
        }

        [AgreementsViewFeature]
        public ViewResult AgreementDetail(AgreementPrimaryKey agreementPrimaryKey)
        {
            var agreement = agreementPrimaryKey.EntityObject;
            var viewData = new Views.Agreement.DetailViewData(CurrentPerson, agreement);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [AgreementsViewFullListFeature]
        public GridJsonNetJObjectResult<Agreement> AgreementGridJsonData()
        {
            var gridSpec = new AgreementGridSpec(CurrentPerson);
            var agreements = HttpRequestStorage.DatabaseEntities.Agreements.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Agreement>(agreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AgreementsViewFullListFeature]
        public ExcelResult AgreementsExcelDownload()
        {
            var agreements = HttpRequestStorage.DatabaseEntities.Agreements.ToList();
            var workbookTitle = FieldDefinition.Agreement.GetFieldDefinitionLabelPluralized();
            return AgreementsExcelDownloadImpl(agreements, workbookTitle);
        }

        private ExcelResult AgreementsExcelDownloadImpl(List<Agreement> agreements,  string workbookTitle)
        {
            var workSheets = new List<IExcelWorkbookSheetDescriptor>();

            // Agreements
            var agreementExcelSpec = new AgreementExcelSpec();
            var agreementWorkSheet = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinition.Agreement.GetFieldDefinitionLabelPluralized()}", agreementExcelSpec, agreements);
            workSheets.Add(agreementWorkSheet);

            // Overall excel file
            var wbm = new ExcelWorkbookMaker(workSheets);
            var excelWorkbook = wbm.ToXLWorkbook();

            return new ExcelResult(excelWorkbook, workbookTitle);
        }


        [HttpGet]
        [AgreementDeleteFeature]
        public PartialViewResult DeleteAgreement(AgreementPrimaryKey agreementPrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(agreementPrimaryKey.PrimaryKeyValue);
            return ViewDeleteAgreement(agreementPrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewDeleteAgreement(Agreement agreement, ConfirmDialogFormViewModel viewModel)
        {
            //TODO use AgreementTitle
            var confirmMessage = $"Are you sure you want to delete this {FieldDefinition.Agreement.GetFieldDefinitionLabel()} '{"AgreementTitleGoesHere"}'?";

            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [AgreementDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteAgreement(AgreementPrimaryKey agreementPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var agreement = agreementPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteAgreement(agreement, viewModel);
            }

            //TODO use AgreementTitle
            var message = $"{FieldDefinition.Grant.GetFieldDefinitionLabel()} \"{"AgreementTitleGoesHere"}\" successfully deleted.";

            //TODO actually delete the agreement
            //agreement.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [AgreementDeleteFeature]
        public PartialViewResult DeleteAgreementPerson(AgreementPersonPrimaryKey agreementPersonPrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(agreementPersonPrimaryKey.PrimaryKeyValue);
            return ViewDeleteAgreementPerson(agreementPersonPrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewDeleteAgreementPerson(AgreementPerson agreementPerson, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to remove this {FieldDefinition.Agreement.GetFieldDefinitionLabel()} Contact '{agreementPerson.Person.FullNameFirstLastAndOrg}' from this {FieldDefinition.Agreement.GetFieldDefinitionLabel()}?";

            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [AgreementDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteAgreementPerson(AgreementPersonPrimaryKey agreementPersonPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var agreementPerson = agreementPersonPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteAgreementPerson(agreementPerson, viewModel);
            }

            var message = $"{FieldDefinition.Agreement.GetFieldDefinitionLabel()} Contact '{agreementPerson.Person.FullNameFirstLastAndOrg}' successfully removed from this {FieldDefinition.Agreement.GetFieldDefinitionLabel()}.";

            agreementPerson.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [AgreementEditAsAdminFeature]
        public PartialViewResult EditAgreementPerson(AgreementPersonPrimaryKey agreementPersonPrimaryKey)
        {
            var agreementPerson = agreementPersonPrimaryKey.EntityObject;
            var viewModel = new EditAgreementPersonViewModel(agreementPerson);
            return ViewEditAgreementPerson(viewModel);
        }

        [HttpPost]
        [AgreementEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditAgreementPerson(AgreementPersonPrimaryKey agreementPersonPrimaryKey, EditAgreementPersonViewModel viewModel)
        {
            var agreementPerson = agreementPersonPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditAgreementPerson(viewModel);
            }
            viewModel.UpdateModel(agreementPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditAgreementPerson(EditAgreementPersonViewModel viewModel)
        {
            var agreementPersonRoles = AgreementPersonRole.All.ToSelectListWithEmptyFirstRow(k => k.AgreementPersonRoleID.ToString(), v => v.AgreementPersonRoleDisplayName);
            var allPeople = HttpRequestStorage.DatabaseEntities.People.GetActivePeople();
            if (!allPeople.Contains(CurrentPerson))
            {
                allPeople.Add(CurrentPerson);
            }

            var contacts = allPeople.OrderBy(x => x.LastName)
                .ToSelectListWithEmptyFirstRow(k => k.PersonID.ToString(), v => v.FullNameFirstLastAndOrg);

            var viewData = new EditAgreementPersonViewData(agreementPersonRoles, contacts);
            return RazorPartialView<EditAgreementPerson, EditAgreementPersonViewData, EditAgreementPersonViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AgreementEditAsAdminFeature]
        public PartialViewResult NewAgreementPerson()
        {
            var viewModel = new EditAgreementPersonViewModel();
            return ViewEditAgreementPerson(viewModel);
        }

        [HttpPost]
        [AgreementEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewAgreementPerson(EditAgreementPersonViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditAgreementPerson(viewModel);
            }

            var agreementPerson = new AgreementPerson(viewModel.AgreementID, viewModel.PersonID,
                viewModel.AgreementPersonRoleID);
            viewModel.UpdateModel(agreementPerson);
            HttpRequestStorage.DatabaseEntities.AgreementPeople.Add(agreementPerson);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"Agreement Contact '{agreementPerson.Person.FullNameFirstLastAndOrg}' successfully added to this agreement.");

            return new ModalDialogFormJsonResult();
        }

        [AgreementsViewFeature]
        public GridJsonNetJObjectResult<AgreementPerson> AgreementPersonGridJsonData(Agreement agreement)
        {
            var gridSpec = new AgreementPersonGridSpec(CurrentPerson);
            var agreementPeople = agreement.AgreementPeople.OrderBy(x => x.Person.LastName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<AgreementPerson>(agreementPeople, gridSpec);
            return gridJsonNetJObjectResult;
        }



        [HttpGet]
        [AgreementEditAsAdminFeature]
        public PartialViewResult Edit(AgreementPrimaryKey agreementPrimaryKey)
        {
            var agreement = agreementPrimaryKey.EntityObject;
            var viewModel = new EditAgreementViewModel(agreement);
            return ViewEdit(viewModel, EditAgreementType.ExistingAgreement);
        }

        [HttpPost]
        [AgreementEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(AgreementPrimaryKey agreementPrimaryKey, EditAgreementViewModel viewModel)
        {
            var agreement = agreementPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, EditAgreementType.ExistingAgreement);
            }
            //viewModel.UpdateModel(agreement, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditAgreementViewModel viewModel, EditAgreementType editAgreementType)
        {
            //var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();

            var viewData = new EditAgreementViewData(editAgreementType);
            return RazorPartialView<EditAgreement, EditAgreementViewData, EditAgreementViewModel>(viewData, viewModel);
        }

    }
}