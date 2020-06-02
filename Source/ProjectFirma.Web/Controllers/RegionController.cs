﻿/*-----------------------------------------------------------------------
<copyright file="RegionController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Region;
using LtInfo.Common.MvcResults;
using MoreLinq;
using NUnit.Framework;
using Detail = ProjectFirma.Web.Views.Region.Detail;
using DetailViewData = ProjectFirma.Web.Views.Region.DetailViewData;
using Index = ProjectFirma.Web.Views.Region.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Region.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Region.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class RegionController : FirmaBaseController
    {
        [RegionViewFeature]
        public ViewResult Index()
        {
            var layerGeoJsons = new List<LayerGeoJson>();
            layerGeoJsons = new List<LayerGeoJson>
            {
                DNRUplandRegion.GetRegionWmsLayerGeoJson("#59ACFF", 0.2m, LayerInitialVisibility.Show)
            };

            var mapInitJson = new MapInitJson("regionIndex", 10, layerGeoJsons, BoundingBox.MakeNewDefaultBoundingBox());
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.RegionsList);
            var viewData = new IndexViewData(CurrentPerson, mapInitJson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [RegionViewFeature]
        public GridJsonNetJObjectResult<DNRUplandRegion> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentPerson);
            var regions = HttpRequestStorage.DatabaseEntities.Regions.OrderBy(x => x.DNRUplandRegionName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<DNRUplandRegion>(regions, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [RegionViewFeature]
        public ViewResult Detail(RegionPrimaryKey regionPrimaryKey)
        {
            var region = regionPrimaryKey.EntityObject;
            var mapDivID = $"region_{region.DNRUplandRegionID}_Map";

            var associatedProjects = region.GetAssociatedProjects(CurrentPerson);
            var layers = DNRUplandRegion.GetRegionAndAssociatedProjectLayers(region, associatedProjects);
            var mapInitJson = new MapInitJson(mapDivID, 10, layers, new BoundingBox(region.DNRUplandRegionLocation));

            var grantAllocationExpenditures = new List<GrantAllocationExpenditure>();
            region.GrantAllocations.ForEach(x => grantAllocationExpenditures.AddRange(x.GrantAllocationExpenditures));
            var costTypes = CostType.GetLineItemCostTypes();

            const string chartTitle = "Grant Allocation Expenditures By Cost Type";
            var chartContainerID = chartTitle.Replace(" ", "");
            var googleChart = grantAllocationExpenditures.ToGoogleChart(x => x.CostType?.CostTypeDisplayName,
                costTypes.Select(ct => ct.CostTypeDisplayName).ToList(),
                x => x.CostType?.CostTypeDisplayName,
                chartContainerID,
                chartTitle);

            var viewGoogleChartViewData = new ViewGoogleChartViewData(googleChart, chartTitle, 405, true);

            var performanceMeasures = associatedProjects
                .SelectMany(x => x.PerformanceMeasureActuals)
                .Select(x => x.PerformanceMeasure).Distinct()
                .OrderBy(x => x.PerformanceMeasureDisplayName)
                .ToList();

            var viewData = new DetailViewData(CurrentPerson, region, mapInitJson, viewGoogleChartViewData, performanceMeasures);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [RegionManageFeature]
        public PartialViewResult DeleteRegion(RegionPrimaryKey regionPrimaryKey)
        {
            var region = regionPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(region.DNRUplandRegionID);
            return ViewDeleteRegion(region, viewModel);
        }

        private PartialViewResult ViewDeleteRegion(DNRUplandRegion dnrUplandRegion, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !dnrUplandRegion.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this Region '{dnrUplandRegion.DNRUplandRegionName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"<p>Washington State Department of Natural Resources has&nbsp;six upland region offices&nbsp;that help to&nbsp;provide localized services throughout Washington.</p>", SitkaRoute<RegionController>.BuildLinkFromExpression(x => x.Detail(dnrUplandRegion), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [RegionManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteRegion(RegionPrimaryKey regionPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var region = regionPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteRegion(region, viewModel);
            }
            region.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        [RegionViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(RegionPrimaryKey regionPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false);
            var projectRegions = regionPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectRegions, gridSpec);
            return gridJsonNetJObjectResult;
        }
        
        [AnonymousUnclassifiedFeature]
        public PartialViewResult MapTooltip(RegionPrimaryKey regionPrimaryKey)
        {
            var viewData = new MapTooltipViewData(CurrentPerson, regionPrimaryKey.EntityObject);
            return RazorPartialView<MapTooltip, MapTooltipViewData>(viewData);
        }
    }
}
