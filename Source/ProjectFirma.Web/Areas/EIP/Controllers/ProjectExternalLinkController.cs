﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.ProjectExternalLink;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class ProjectExternalLinkController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [ProjectExternalLinkManageFeature]
        public PartialViewResult EditProjectExternalLinks(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectExternalLinkSimples = project.ProjectExternalLinks.Select(x => new ProjectExternalLinkSimple(x)).ToList();
            var viewModel = new EditProjectExternalLinksViewModel(projectExternalLinkSimples);
            return ViewEditProjectExternalLinks(project, viewModel);
        }

        [HttpPost]
        [ProjectExternalLinkManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectExternalLinks(ProjectPrimaryKey projectPrimaryKey, EditProjectExternalLinksViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectExternalLinks(project, viewModel);
            }
            var currentProjectExternalLinks = project.ProjectExternalLinks.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectExternalLinks.Load();
            var allProjectExternalLinks = HttpRequestStorage.DatabaseEntities.ProjectExternalLinks.Local;
            viewModel.UpdateModel(currentProjectExternalLinks, allProjectExternalLinks);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectExternalLinks(Project project, EditProjectExternalLinksViewModel viewModel)
        {
            var viewData = new EditProjectExternalLinksViewData(project);
            return RazorPartialView<EditProjectExternalLinks, EditProjectExternalLinksViewData, EditProjectExternalLinksViewModel>(viewData, viewModel);
        }
    }
}