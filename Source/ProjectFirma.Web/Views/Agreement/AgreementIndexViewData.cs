﻿/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Grant;

namespace ProjectFirma.Web.Views.Agreement
{
    public class AgreementIndexViewData : FirmaViewData
    {
        public readonly AgreementGridSpec AgreementGridSpec;
        public readonly string AgreementGridName;
        public readonly string AgreementGridDataUrl;


        public AgreementIndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = $"Full Agreement List";

            AgreementGridSpec = new AgreementGridSpec(currentPerson);
            AgreementGridName = "agreementsGridName";
            AgreementGridDataUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(tc => tc.AgreementGridJsonData());
        }
    }
}