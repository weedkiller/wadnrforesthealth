﻿/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierOneModelExtensions.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class TaxonomyTierOneModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this TaxonomyTierOne taxonomyTierOne)
        {
            return UrlTemplate.MakeHrefString(taxonomyTierOne.GetSummaryUrl(), taxonomyTierOne.DisplayName);
        }

        public static string GetSummaryUrl(this TaxonomyTierOne taxonomyTierOne)
        {
            return SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(x => x.Detail(taxonomyTierOne.TaxonomyTierOneID));
        }

        public static string GetDeleteUrl(this TaxonomyTierOne taxonomyTierOne)
        {
            return SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(c => c.DeleteTaxonomyTierOne(taxonomyTierOne.TaxonomyTierOneID));
        }

        public static IEnumerable<SelectListItem> ToGroupedSelectList(this List<TaxonomyTierOne> taxonomyTierOnes)
        {
            var selectListItems = new List<SelectListItem>();
            var groups = new Dictionary<string, SelectListGroup>();
            foreach (var taxonomyTierThreeGrouping in taxonomyTierOnes.GroupBy(x => x.TaxonomyTierTwo.TaxonomyTierThree).OrderBy(x => x.Key.DisplayName))
            {
                var taxonomyTierThree = taxonomyTierThreeGrouping.Key;
                var topLevelGroup = new SelectListGroup() {Name = taxonomyTierThree.DisplayName};
                groups.Add(taxonomyTierThree.DisplayName, topLevelGroup);
                
                foreach (var taxonomyTierTwoGrouping in taxonomyTierThreeGrouping.GroupBy(x => x.TaxonomyTierTwo).OrderBy(x => x.Key.DisplayName))
                {
                    var taxonomyTierTwo = taxonomyTierTwoGrouping.Key;
                    var selectListGroup = new SelectListGroup() {Name = taxonomyTierTwo.DisplayName};
                    groups.Add(taxonomyTierTwo.DisplayName, selectListGroup);

                    selectListItems.Add(new SelectListItem(){Text = taxonomyTierTwo.DisplayName, Group = topLevelGroup, Disabled = true});

                    foreach (var taxonomyTierOne in taxonomyTierTwoGrouping.OrderBy(x => x.DisplayName))
                    {
                        selectListItems.Add(new SelectListItem() { Value = taxonomyTierOne.TaxonomyTierOneID.ToString(), Text = taxonomyTierOne.DisplayName, Group = topLevelGroup });
                    }
                }

            }
            return selectListItems;
        }
    }
}
