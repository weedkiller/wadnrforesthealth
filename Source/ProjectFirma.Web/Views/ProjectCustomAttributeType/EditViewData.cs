﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeType
{
    public class EditViewData : FirmaViewData
    {
        public string ProjectCustomAttributeTypeIndexUrl { get; }
        public string SubmitUrl { get; }

        public ViewPageContentViewData ViewInstructionsFirmaPage { get; }
        public ViewPageContentViewData ViewProjectCustomAttributeInstructionsFirmaPage { get; }

        public IEnumerable<SelectListItem> ProjectCustomAttributeDataTypes { get; }
        public IEnumerable<SelectListItem> MeasurementUnitTypes { get; }
        public IEnumerable<SelectListItem> ProjectCustomAttributeTypePurposes { get; }
        public IEnumerable<SelectListItem> YesNos { get; }
        public EditViewDataForAngular ViewDataForAngular { get; }

        public EditViewData(Person currentPerson, IEnumerable<MeasurementUnitType> measurementUnitTypes,
            List<ProjectCustomAttributeDataType> projectCustomAttributeDataTypes, string submitUrl,
            Models.FirmaPage instructionsFirmaPage, Models.FirmaPage projectCustomAttributeInstructionsFirmaPage,
            Models.ProjectCustomAttributeType projectCustomAttributeType) : base(currentPerson)
        {
            EntityName = "Attribute Type";
            //EntityUrl = SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(x => x.Manage());
            PageTitle =
                $"{(projectCustomAttributeType != null ? "Edit" : "New")} Attribute Type";

            //if (projectCustomAttributeType != null)
            //{
            //    SubEntityName = projectCustomAttributeType.ProjectCustomAttributeTypeName;
            //    SubEntityUrl = projectCustomAttributeType.GetDetailUrl();
            //}

            YesNos = BooleanFormats.GetYesNoSelectList();
            ProjectCustomAttributeDataTypes = projectCustomAttributeDataTypes.ToSelectListWithEmptyFirstRow(
                x => x.ProjectCustomAttributeDataTypeID.ToString(), x => x.ProjectCustomAttributeDataTypeDisplayName);
            MeasurementUnitTypes = measurementUnitTypes.OrderBy(x => x.MeasurementUnitTypeDisplayName).ToSelectListWithEmptyFirstRow(
                x => x.MeasurementUnitTypeID.ToString(), x => x.MeasurementUnitTypeDisplayName, ViewUtilities.NoneString);
            ProjectCustomAttributeTypePurposes =
                ProjectCustomAttributeTypePurpose.All.ToSelectListWithEmptyFirstRow(
                    x => x.ProjectCustomAttributeTypePurposeID.ToString(CultureInfo.InvariantCulture),
                    x => x.ProjectCustomAttributeTypePurposeDisplayName);

            ProjectCustomAttributeTypeIndexUrl =
                SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(x => x.Manage());
            SubmitUrl = submitUrl;

            ViewInstructionsFirmaPage = new ViewPageContentViewData(instructionsFirmaPage, currentPerson);
            ViewProjectCustomAttributeInstructionsFirmaPage = new ViewPageContentViewData(projectCustomAttributeInstructionsFirmaPage, currentPerson);

            ViewDataForAngular = new EditViewDataForAngular(projectCustomAttributeDataTypes);
        }

        public class EditViewDataForAngular
        {
            public IEnumerable<ProjectCustomAttributeDataTypeSimple> ProjectCustomAttributeDataTypes { get; }

            public EditViewDataForAngular(IEnumerable<ProjectCustomAttributeDataType> projectCustomAttributeDataTypes)
            {
                ProjectCustomAttributeDataTypes = projectCustomAttributeDataTypes.Select(x => new ProjectCustomAttributeDataTypeSimple(x)).ToList();
            }
        }

        public class ProjectCustomAttributeDataTypeSimple
        {
            public int ID { get; }
            public string DisplayName { get; }
            public bool HasOptions { get; }
            public bool HasMeasurementUnit { get; }

            public ProjectCustomAttributeDataTypeSimple(ProjectCustomAttributeDataType projectCustomAttributeDataType)
            {
                ID = projectCustomAttributeDataType.ProjectCustomAttributeDataTypeID;
                DisplayName = projectCustomAttributeDataType.ProjectCustomAttributeDataTypeDisplayName;
                HasOptions = projectCustomAttributeDataType.HasOptions();
                HasMeasurementUnit = projectCustomAttributeDataType.HasMeasurementUnit();
            }
        }
    }
}
