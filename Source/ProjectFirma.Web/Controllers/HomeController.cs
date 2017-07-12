﻿/*-----------------------------------------------------------------------
<copyright file="HomeController.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Home;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Controllers
{
    public class HomeController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public FileResult ExportGridToExcel(string gridName, bool printFooter)
        {
            return ExportGridToExcelImpl(gridName, printFooter);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult Index()
        {
            var firmaPageType = FirmaPageType.ToType(FirmaPageTypeEnum.HomePage);
            var firmaPageByPageType = FirmaPage.GetFirmaPageByPageType(firmaPageType);

            var allProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList();
            var projects = IsCurrentUserAnonymous() ? allProjects.Where(p => p.IsVisibleToEveryone()).ToList() : allProjects;
            var projectMapCustomization = ProjectMapCustomization.CreateDefaultCustomization(projects);
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, false), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, false), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, projectMapCustomization, "ProjectLocationsMap")
            {
                AllowFullScreen = false
            };
            var firmaHomePageImages = new List<FirmaHomePageImage>();
            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.DisplayName, HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList());
            
            var featuredProjectsViewData = new FeaturedProjectsViewData(HttpRequestStorage.DatabaseEntities.Projects.Where(x => x.IsFeatured).ToList());

            var viewData = new IndexViewData(CurrentPerson, firmaPageByPageType, featuredProjectsViewData, projectLocationsMapViewData, projectLocationsMapInitJson, firmaHomePageImages);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult Error()
        {
            var viewData = new ErrorViewData(CurrentPerson);
            return RazorView<Error, ErrorViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult NotFound()
        {
            var viewData = new NotFoundViewData(CurrentPerson);
            return RazorView<NotFound, NotFoundViewData>(viewData);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult ViewPageContent(FirmaPageTypeEnum firmaPageTypeEnum)
        {
            var firmaPageType = FirmaPageType.ToType(firmaPageTypeEnum);
            var viewData = new DisplayPageContentViewData(CurrentPerson, firmaPageType);
            return RazorView<DisplayPageContent, DisplayPageContentViewData>(viewData);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult EditPageContent(FirmaPageTypeEnum firmaPageTypeEnum)
        {
            var firmaPageType = FirmaPageType.ToType(firmaPageTypeEnum);
            var viewModel = new EditPageContentViewModel(firmaPageType);
            var viewData = new EditPageContentViewData(CurrentPerson, firmaPageType);
            return RazorView<EditPageContent, EditPageContentViewData, EditPageContentViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPageContent(FirmaPageTypeEnum firmaPageTypeEnum, EditPageContentViewModel viewModel)
        {
            var firmaPageType = FirmaPageType.ToType(firmaPageTypeEnum);
            if (!ModelState.IsValid)
            {
                var viewData = new EditPageContentViewData(CurrentPerson, firmaPageType);
                return RazorView<EditPageContent, EditPageContentViewData, EditPageContentViewModel>(viewData, viewModel);
            }
            viewModel.UpdateModel(firmaPageType, CurrentPerson);

            return RedirectToAction((new SitkaRoute<HomeController>(c => c.ViewPageContent(firmaPageTypeEnum))));
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult About()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.About);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult Meetings()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.MeetingsandDocuments);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public ViewResult DemoScript()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.DemoScript);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult ManageHomePageImages()
        {
            var firmaHomePageImages = new List<FirmaHomePageImage>();
            var imageGalleryViewData = BuildImageGalleryViewData(CurrentPerson);
            var viewData = new ManageHomePageImagesViewData(CurrentPerson, firmaHomePageImages, imageGalleryViewData );
            return RazorView<ManageHomePageImages, ManageHomePageImagesViewData>(viewData);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult InternalSetupNotes()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.InternalSetupNotes);
        }

        private static ImageGalleryViewData BuildImageGalleryViewData(Person currentPerson)
        {
            var userCanAddPhotosToHomePage = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);
            var newPhotoForProjectUrl = SitkaRoute<FirmaHomePageImageController>.BuildUrlFromExpression(x => x.New());
            var galleryName = "HomePageImagesGallery";
            var firmaHomePageImages = HttpRequestStorage.DatabaseEntities.FirmaHomePageImages.ToList(); 
            var imageGalleryViewData = new ImageGalleryViewData(currentPerson,
                galleryName,
                firmaHomePageImages,
                userCanAddPhotosToHomePage,
                newPhotoForProjectUrl,
                null,
                true,
                x => x.CaptionOnFullView,
                "Photo");
            return imageGalleryViewData;
        }
    }
}
