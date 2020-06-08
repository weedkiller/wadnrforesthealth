﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.UnitTestCommon;
using ProjectFirma.Web.Views.GisProjectBulkUpdate;
using ProjectFirma.Web.Views.ProjectCreate;

namespace ProjectFirma.Web.Controllers
{
    public class GisProjectBulkUpdateController : FirmaBaseController
    {
        [HttpGet]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public PartialViewResult SourceOrganizationSelection()
        {
            var gisSourceOrganizations = HttpRequestStorage.DatabaseEntities.GisUploadSourceOrganizations.ToList();
            var viewData = new SourceOrganizationTypeSelectionViewData(gisSourceOrganizations);
            var viewModel = new SourceOrganizationTypeSelectionViewModel();
            return RazorPartialView<SourceOrganizationTypeSelection, SourceOrganizationTypeSelectionViewData, SourceOrganizationTypeSelectionViewModel>(viewData, viewModel);
        }


        [HttpPost]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult SourceOrganizationSelection(SourceOrganizationTypeSelectionViewModel viewModel)
        {
            var gisSourceOrganizations = HttpRequestStorage.DatabaseEntities.GisUploadSourceOrganizations.ToList();
            var viewData = new SourceOrganizationTypeSelectionViewData(gisSourceOrganizations);

            if (!ModelState.IsValid)
            {
                return RazorPartialView<SourceOrganizationTypeSelection, SourceOrganizationTypeSelectionViewData, SourceOrganizationTypeSelectionViewModel>(viewData, viewModel);
            }

            var gisAttempt = new GisUploadAttempt(viewModel.SourceOrganizationID.Value, CurrentPerson.PersonID, DateTime.Now);

            HttpRequestStorage.DatabaseEntities.GisUploadAttempts.Add(gisAttempt);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult(
                        SitkaRoute<GisProjectBulkUpdateController>.BuildUrlFromExpression(x => x.InstructionsGisImport(gisAttempt.GisUploadAttemptID)));

        }

        private static GisImportSectionStatus GetGisImportSectionStatus(GisUploadAttempt gisUploadAttempt)
        {
            return new GisImportSectionStatus(gisUploadAttempt);
        }


        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ActionResult InstructionsGisImport(int gisUploadAttemptID)
        {
            var firmaPageType = FirmaPageType.ToType(FirmaPageTypeEnum.GisUploadAttemptInstructions);
            var firmaPage = FirmaPage.GetFirmaPageByPageType(firmaPageType);
                var gisUploadAttempt = HttpRequestStorage.DatabaseEntities.GisUploadAttempts.GetGisUploadAttempt(gisUploadAttemptID);
                var gisImportSectionStatus = GetGisImportSectionStatus(gisUploadAttempt);
                var viewData = new InstructionsGisImportViewData(CurrentPerson, gisUploadAttempt, gisImportSectionStatus, firmaPage, false);

                return RazorView<InstructionsGisImport, InstructionsGisImportViewData>(viewData);

        }



        [HttpGet]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ActionResult UploadGisFile(int gisUploadAttemptID)
        {
            var uploadGisFileViewModel = new UploadGisFileViewModel();
            var gisUploadAttempt = HttpRequestStorage.DatabaseEntities.GisUploadAttempts.GetGisUploadAttempt(gisUploadAttemptID);

            return ViewUploadGisFile(uploadGisFileViewModel, gisUploadAttempt);
        }


        private ViewResult ViewUploadGisFile(UploadGisFileViewModel viewModel, GisUploadAttempt gisUploadAttempt)
        {
            var gisImportSectionStatus = GetGisImportSectionStatus(gisUploadAttempt);
            var newGisUploadUrl = SitkaRoute<GisProjectBulkUpdateController>.BuildUrlFromExpression(x => x.UploadGisFile(gisUploadAttempt.GisUploadAttemptID, null));

            var viewData = new UploadGisFileViewData(CurrentPerson, gisUploadAttempt, gisImportSectionStatus, newGisUploadUrl);

            return RazorView<UploadGisFile, UploadGisFileViewData, UploadGisFileViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult UploadGisFile(int gisUploadAttemptID, UploadGisFileViewModel viewModel)
        {
            return UploadGisFilePostImpl(gisUploadAttemptID, viewModel);
        }

        private ActionResult UploadGisFilePostImpl(int gisUploadAttemptID, UploadGisFileViewModel viewModel)
        {
            var gisUploadAttempt = HttpRequestStorage.DatabaseEntities.GisUploadAttempts.GetGisUploadAttempt(gisUploadAttemptID);
            if (!ModelState.IsValid)
            {
                return ViewUploadGisFile(viewModel, gisUploadAttempt);
            }

            var httpPostedFileBase = viewModel.FileResourceData;
            var fileEnding = ".gdb.zip";
            var importTableName = string.Empty;
            using (var disposableTempFile = DisposableTempFile.MakeDisposableTempFileEndingIn(fileEnding))
            {
                var gdbFile = disposableTempFile.FileInfo;
                httpPostedFileBase.SaveAs(gdbFile.FullName);
                GisUploadAttemptStaging.ImportIntoSqlTempTable(gdbFile, gisUploadAttempt, out importTableName);
            }

            gisUploadAttempt.ImportTableName = importTableName;
            var columns = GetListOfColumnNamesFromImportedGisData(importTableName);
            var realColumns = HttpRequestStorage.DatabaseEntities.GetfGetColumnNamesForTables(importTableName).ToList();
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay("The GIS file was imported. Please review the shape of the data");
            return new ModalDialogFormJsonResult();
        }


        private List<string> GetListOfColumnNamesFromImportedGisData(string importedTableName)
        {
            List<string> listOfColumnNames;
            var  sqlDatabaseConnectionString = FirmaWebConfiguration.DatabaseConnectionString;
            using (var command = new SqlCommand($"SELECT ColumnName from dbo.fGetColumnNamesForTable('{importedTableName}')"))
            {
                var sqlConnection = new SqlConnection(sqlDatabaseConnectionString);
                using (var conn = sqlConnection)
                {
                    command.Connection = conn;
                    using (var dt = ProjectFirmaSqlDatabase.ExecuteSqlCommand(command).Tables[0])
                    {
                        listOfColumnNames =
                            dt.Rows.Cast<DataRow>()
                                .Select(x => x["ColumnName"].ToString())
                                .ToList();
                    }
                }
            }

            return listOfColumnNames;
        }

    }
}