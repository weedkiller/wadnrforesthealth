﻿/*-----------------------------------------------------------------------
<copyright file="FactSheetViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared.SortOrder;
using LtInfo.Common;
using LtInfo.Common.Views;


namespace ProjectFirma.Web.Views.Project
{
    public class BackwardLookingFactSheetViewData : ProjectViewData
    {
        public string EstimatedTotalCost { get; }
        public string NoFundingSourceIdentified { get; }
        public string SecuredFunding { get; }
        public string UnsecuredFunding { get; }
        public ImageGalleryViewData ImageGalleryViewData { get; }
        public ProjectLocationSummaryViewData ProjectLocationSummaryViewData { get; }
        public List<IGrouping<Models.PerformanceMeasure, PerformanceMeasureReportedValue>> PerformanceMeasureReportedValues { get; }
        public List<GooglePieChartSlice> ExpenditureGooglePieChartSlices { get; }
        public string ChartID { get; }
        public Models.ProjectImage KeyPhoto { get; }
        public List<IGrouping<ProjectImageTiming, Models.ProjectImage>> ProjectImagesExceptKeyPhotoGroupedByTiming { get; }
        public int ProjectImagesPerTimingGroup { get; }
        public List<string> ChartColorRange { get; }
        public List<Models.Classification> Classifications { get; }
        public GoogleChartJson GoogleChartJson { get; }
        public int CalculatedChartHeight { get; }
        public string FactSheetPdfUrl { get; }

        public string TaxonomyColor { get; }
        public string TaxonomyLeafName { get; }
        public string TaxonomyBranchName { get; }

        public string TaxonomyLeafDisplayName { get; }
        public Person PrimaryContactPerson { get; }

        public BackwardLookingFactSheetViewData(Person currentPerson, Models.Project project, ProjectLocationSummaryMapInitJson projectLocationSummaryMapInitJson, GoogleChartJson projectFactSheetGoogleChart,
            List<GooglePieChartSlice> expenditureGooglePieChartSlices, List<string> chartColorRange) : base(currentPerson, project)
        {
            PageTitle = project.DisplayName;
            BreadCrumbTitle = "Fact Sheet";

            EstimatedTotalCost = Project.EstimatedTotalCost.HasValue ? Project.EstimatedTotalCost.ToStringCurrency() : "";
            NoFundingSourceIdentified = project.GetNoFundingSourceIdentifiedAmount() != null ? Project.GetNoFundingSourceIdentifiedAmount().ToStringCurrency() : "";
            SecuredFunding = Project.GetSecuredFunding() != null ? Project.GetSecuredFunding().ToStringCurrency() : "";
            UnsecuredFunding = Project.GetUnsecuredFunding().ToStringCurrency();

            const bool userCanAddPhotosToThisProject = false;
            var newPhotoForProjectUrl = string.Empty;
            var selectKeyImageUrl = string.Empty;
            var galleryName = $"ProjectImage{project.ProjectID}";
            ImageGalleryViewData = new ImageGalleryViewData(currentPerson,
                galleryName,
                project.ProjectImages,
                userCanAddPhotosToThisProject,
                newPhotoForProjectUrl,
                selectKeyImageUrl,
                true,
                x => x.CaptionOnFullView,
                "Photo");

            PerformanceMeasureReportedValues =
                project.GetReportedPerformanceMeasures().GroupBy(x => x.PerformanceMeasure).OrderBy(x => x.Key.PerformanceMeasureSortOrder).ThenBy(x => x.Key.PerformanceMeasureDisplayName).ToList();

            ProjectLocationSummaryViewData = new ProjectLocationSummaryViewData(project, projectLocationSummaryMapInitJson);

            ChartID = $"fundingChartForProject{project.ProjectID}";
            KeyPhoto = project.KeyPhoto;
            ProjectImagesExceptKeyPhotoGroupedByTiming =
                project.ProjectImages.Where(x => !x.IsKeyPhoto && x.ProjectImageTiming != ProjectImageTiming.Unknown && !x.ExcludeFromFactSheet)
                    .GroupBy(x => x.ProjectImageTiming)
                    .OrderBy(x => x.Key.SortOrder)
                    .ToList();
            ProjectImagesPerTimingGroup = ProjectImagesExceptKeyPhotoGroupedByTiming.Count == 1 ? 6 : 2;
            Classifications = project.ProjectClassifications.Select(x => x.Classification).ToList().SortByOrderThenName().ToList();

            GoogleChartJson = projectFactSheetGoogleChart;

            ExpenditureGooglePieChartSlices = expenditureGooglePieChartSlices;
            ChartColorRange = chartColorRange;
            //Dynamically resize chart based on how much space the legend requires
            CalculatedChartHeight = 350 - ExpenditureGooglePieChartSlices.Count * 19;
            FactSheetPdfUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.FactSheetPdf(project));

            if (project.TaxonomyLeaf == null)
            {
                TaxonomyColor = "blue";
            }
            else
            {
                switch (MultiTenantHelpers.GetTaxonomyLevel().ToEnum)
                {
                    case TaxonomyLevelEnum.Leaf:
                        TaxonomyColor = project.TaxonomyLeaf.ThemeColor;
                        break;
                    case TaxonomyLevelEnum.Branch:
                        TaxonomyColor = project.TaxonomyLeaf.TaxonomyBranch.ThemeColor;
                        break;
                    case TaxonomyLevelEnum.Trunk:
                        TaxonomyColor = project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.ThemeColor;
                        break;
                }
            }
            TaxonomyLeafName = project.TaxonomyLeaf == null ? $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Taxonomy Not Set" : project.TaxonomyLeaf.DisplayName;
            TaxonomyBranchName = project.TaxonomyLeaf == null ? $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Taxonomy Not Set" : project.TaxonomyLeaf.TaxonomyBranch.DisplayName;
            TaxonomyLeafDisplayName = Models.FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabel();
            PrimaryContactPerson = project.GetPrimaryContact();
        }
    }
}
