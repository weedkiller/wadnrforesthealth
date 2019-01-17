﻿/*-----------------------------------------------------------------------
<copyright file="BasicsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BasicsViewData : ProjectUpdateViewData
    {
        public IEnumerable<SelectListItem> PlannedDateRange { get; }
        public IEnumerable<SelectListItem> ImplementationStartYearRange { get; }
        public IEnumerable<SelectListItem> CompletionDateRange { get; }
        public IEnumerable<SelectListItem> ProjectStages { get; }
        public IEnumerable<SelectListItem> FocusAreas { get; }
        public string TaxonomyLeafDisplayName { get; }
        public string RefreshUrl { get; }
        public string DiffUrl { get; }

        public Models.ProjectUpdate ProjectUpdate { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }

        public IEnumerable<Models.ProjectCustomAttributeType> ProjectCustomAttributeTypes { get; private set; }


        public BasicsViewData(Person currentPerson, Models.ProjectUpdate projectUpdate,
            IEnumerable<ProjectStage> projectStages, UpdateStatus updateStatus,
            BasicsValidationResult basicsValidationResult,
            IEnumerable<Models.ProjectCustomAttributeType> projectCustomAttributeTypes, IEnumerable<Models.FocusArea> focusAreas)
            : base(currentPerson, projectUpdate.ProjectUpdateBatch, updateStatus, basicsValidationResult.GetWarningMessages(), ProjectUpdateSection.Basics.ProjectUpdateSectionDisplayName)
        {
            ProjectUpdate = projectUpdate;
            TaxonomyLeafDisplayName = projectUpdate.ProjectUpdateBatch.Project.TaxonomyLeaf.DisplayName;
            ProjectStages = projectStages.OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);
            FocusAreas = focusAreas.OrderBy(x => x.FocusAreaName)
                .ToSelectListWithEmptyFirstRow(x => x.FocusAreaID.ToString(CultureInfo.InvariantCulture), y => y.FocusAreaName);
            PlannedDateRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay);
            ImplementationStartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay);
            CompletionDateRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay);
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshBasics(Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffBasics(Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdate.ProjectUpdateBatch.BasicsComment, projectUpdate.ProjectUpdateBatch.IsReturned);            
                        
            ProjectCustomAttributeTypes = projectCustomAttributeTypes;
        }
    }
}
