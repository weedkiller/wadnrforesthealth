﻿/*-----------------------------------------------------------------------
<copyright file="GrantViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Grant
{
    public abstract class GrantViewData : FirmaViewData
    {
        public Models.Grant Grant { get; }

        protected GrantViewData(Person currentPerson, Models.Grant grant) : base(currentPerson, null)
        {
            Grant = grant;
            HtmlPageTitle = grant.GrantNumber;
            EntityName = $"{Models.FieldDefinition.Grant.GetFieldDefinitionLabel()}";
        }
    }
}
