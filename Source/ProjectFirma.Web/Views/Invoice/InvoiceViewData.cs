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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Invoice
{
    public abstract class InvoiceViewData : FirmaViewData
    {
        public Models.Invoice Invoice { get; }
        public string EditInvoiceUrl { get; set; }
        public bool UserHasEditInvoicePermissions { get; set; }
        public string BackToInvoicesText { get; set; }
        public string InvoicesListUrl { get; set; }

        protected InvoiceViewData(Person currentPerson, Models.Invoice invoice) : base(currentPerson, null)
        {
            Invoice = invoice;
            HtmlPageTitle = invoice.InvoiceIdentifyingName;
            EntityName = $"{Models.FieldDefinition.Invoice.GetFieldDefinitionLabel()}";
            //EditInvoiceUrl = invoice.GetEditUrl();
            UserHasEditInvoicePermissions = new InvoiceEditAsAdminFeature().HasPermissionByPerson(currentPerson);
            BackToInvoicesText = "Back to all Invoices";
            InvoicesListUrl = SitkaRoute<InvoiceController>.BuildUrlFromExpression(c => c.Index());
        }
    }
}
