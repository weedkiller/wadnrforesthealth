﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.ProjectWatershed;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class ProjectWatershedController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [ProjectWatershedManageFromProjectFeature]
        public PartialViewResult EditProjectWatershedsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectWatershedSimples = project.ProjectWatersheds.Select(x => new ProjectWatershedSimple(x)).ToList();
            var viewModel = new EditProjectWatershedsViewModel(projectWatershedSimples);
            return ViewEditProjectWatershedsForProject(project, viewModel);
        }

        [HttpPost]
        [ProjectWatershedManageFromProjectFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectWatershedsForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectWatershedsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectWatershedsForProject(project, viewModel);
            }
            var currentProjectWatersheds = project.ProjectWatersheds.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectWatersheds.Load();
            var allProjectWatersheds = HttpRequestStorage.DatabaseEntities.ProjectWatersheds.Local;
            viewModel.UpdateModel(currentProjectWatersheds, allProjectWatersheds);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectWatershedsForProject(Project project, EditProjectWatershedsViewModel viewModel)
        {
            var allWatersheds = HttpRequestStorage.DatabaseEntities.Watersheds.ToList().Select(x => new WatershedSimple(x)).OrderBy(p => p.WatershedName).ToList();
            var viewData = new EditProjectWatershedsViewData(project, allWatersheds);
            return RazorPartialView<EditProjectWatersheds, EditProjectWatershedsViewData, EditProjectWatershedsViewModel>(viewData, viewModel);
        }
    }
}