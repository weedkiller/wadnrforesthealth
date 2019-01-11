﻿/*-----------------------------------------------------------------------
<copyright file="FocusAreaModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using GeoJSON.Net.Feature;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.GeoJson;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static class FocusAreaModelExtensions
    {
        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<FocusAreaController>.BuildUrlFromExpression(t => t.DeleteFocusArea(UrlTemplate.Parameter1Int)));


        public static HtmlString GetDisplayNameAsUrl(this FocusArea focusArea)
        {          
            return focusArea != null ? UrlTemplate.MakeHrefString(focusArea.GetDetailUrl(), focusArea.FocusAreaName) : new HtmlString(null);
        }

        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<FocusAreaController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this FocusArea focusArea)
        {
            return focusArea == null ? "" : SummaryUrlTemplate.ParameterReplace(focusArea.FocusAreaID);
        }

        public static List<Project> GetAllAssociatedProjects(this FocusArea focusArea)
        {
            return focusArea.Projects.ToList();
        }

        public static List<Project> GetAllActiveProjects(this FocusArea focusArea, Person person)
        {
            return focusArea.GetAllAssociatedProjects().GetActiveProjects();
        }

        public static List<Project> GetProposalsVisibleToUser(this FocusArea focusArea, Person person)
        {
            return focusArea.GetAllAssociatedProjects().GetProposalsVisibleToUser(person);
        }


    }
}