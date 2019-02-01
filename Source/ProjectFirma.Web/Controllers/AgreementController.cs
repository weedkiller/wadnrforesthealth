﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Agreement;
using ProjectFirma.Web.Views.Grant;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class AgreementController : FirmaBaseController
    {


        [HttpGet]
        [AgreementCreateFeature]
        public PartialViewResult New()
        {

            var viewModel = new EditAgreementViewModel();
            return ViewEdit(viewModel, EditAgreementType.NewAgreement);
        }

        [HttpPost]
        [AgreementCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditAgreementViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, EditAgreementType.NewAgreement);
            }
           

            var grant =
                HttpRequestStorage.DatabaseEntities.Grants.Single(
                    g => g.GrantID == viewModel.GrantID);
            var agreementOrganization =
                HttpRequestStorage.DatabaseEntities.Organizations.Single(g =>
                    g.OrganizationID == viewModel.OrganizationID);
            var agreement = Agreement.CreateNewBlank(agreementOrganization, grant);
            viewModel.UpdateModel(agreement, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditAgreementViewModel viewModel, EditAgreementType editAgreementType)
        {
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var agreementTypes = HttpRequestStorage.DatabaseEntities.AgreementTypes;
            var grants = HttpRequestStorage.DatabaseEntities.Grants;

            var viewData = new EditAgreementViewData(editAgreementType,
                organizations,
                grants,
                agreementTypes
            );
            return RazorPartialView<EditAgreement, EditAgreementViewData, EditAgreementViewModel>(viewData, viewModel);
        }

        [AgreementsViewFullListFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.FullAgreementList);
            var viewData = new AgreementIndexViewData(CurrentPerson, firmaPage);
            return RazorView<AgreementIndex, AgreementIndexViewData>(viewData);
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

    }
}