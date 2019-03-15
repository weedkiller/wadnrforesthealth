﻿/*-----------------------------------------------------------------------
<copyright file="ProgramIndexSearchResultsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProgramIndex
{
    public class ProgramIndexSearchResultsViewData : FirmaViewData
    {
        public readonly List<Models.ProgramIndex> EntitySearchResults;
        public readonly string SearchCriteria;

        public ProgramIndexSearchResultsViewData(Person currentPerson, List<Models.ProgramIndex> entitySearchResults, string searchCriteria) : base(currentPerson)
        {
            EntitySearchResults = entitySearchResults;
            SearchCriteria = searchCriteria;
            PageTitle = $"{Models.FieldDefinition.ProgramIndex.GetFieldDefinitionLabel()} Search";
        }
    }
}