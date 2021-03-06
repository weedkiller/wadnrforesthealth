﻿/*-----------------------------------------------------------------------
<copyright file="EditAgreementPersonViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using LtInfo.Common.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Invoice
{
    public class EditInvoiceLineItemViewModel : FormViewModel
    {
        public int InvoiceID { get; set; }
        public int InvoiceLineItemID { get; set; }

        [Required]
        [DisplayName("Cost Type")]
        public int CostTypeID { get; set; }

        [Required]
        [DisplayName("Line Item Amount")]
        [ValidateMoneyInRangeForSqlServer]
        public Money InvoiceLineItemAmount { get; set; }

        [Required]
        [DisplayName("Grant Allocation")]
        public int GrantAllocationID { get; set; }

        [DisplayName("Note")]
        public string InvoiceLineItemNote { get; set; }



        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditInvoiceLineItemViewModel()
        {
        }

        public EditInvoiceLineItemViewModel(int invoiceID)
        {
            InvoiceID = invoiceID;
        }


        public EditInvoiceLineItemViewModel(Models.InvoiceLineItem invoiceLineItem)
        {
            InvoiceLineItemID = invoiceLineItem.InvoiceLineItemID;
            CostTypeID = invoiceLineItem.CostTypeID;
            GrantAllocationID = invoiceLineItem.GrantAllocationID;
            InvoiceID = invoiceLineItem.InvoiceID;
            InvoiceLineItemAmount = invoiceLineItem.InvoiceLineItemAmount;
            InvoiceLineItemNote = invoiceLineItem.InvoiceLineItemNote;
        }

        public void UpdateModel(Models.InvoiceLineItem invoiceLineItem)
        {
            invoiceLineItem.CostTypeID = CostTypeID;
            invoiceLineItem.GrantAllocationID = GrantAllocationID;
            invoiceLineItem.InvoiceLineItemAmount = InvoiceLineItemAmount;
            invoiceLineItem.InvoiceLineItemNote = InvoiceLineItemNote;
        }
    }
}