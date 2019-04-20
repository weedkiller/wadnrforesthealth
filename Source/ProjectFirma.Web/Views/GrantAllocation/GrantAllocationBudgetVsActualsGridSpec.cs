﻿using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Invoice;

namespace ProjectFirma.Web.Views.GrantAllocation
{
    public class GrantAllocationBudgetVsActualsGridSpec : GridSpec<BudgetVsActualLineItem>
    {
        public GrantAllocationBudgetVsActualsGridSpec()
        {
            ObjectNameSingular = $"{Models.FieldDefinition.GrantAllocation.GetFieldDefinitionLabel()} Budget Vs Actuals";
            ObjectNamePlural = $"{Models.FieldDefinition.GrantAllocation.GetFieldDefinitionLabelPluralized()} Budget Vs Actuals";


            Add("Cost Type", x => x.CostType.CostTypeDescription, 125, DhtmlxGridColumnFilterType.Text);
            Add("Budget", x => x.Budget, 125, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Expenditures From Datamart", x => x.ExpendituresFromDatamart, 125, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Budget Minus Expenditures", x => x.BudgetMinusExpendituresFromDatamart, 125, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Invoiced To Date", x => x.InvoicedToDate, 125, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Budget Minus Invoiced", x => x.BudgetMinusInvoicedToDate, 125, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);

        }
    }
}