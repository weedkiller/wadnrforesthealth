ALTER TABLE dbo.CostType ADD CostTypeName varchar(31) 

ALTER TABLE dbo.CostType ADD IsValidInvoiceLineItemCostType bit

go

update dbo.CostType 
set CostTypeName = 'IndirectCosts', IsValidInvoiceLineItemCostType = 1
where CostTypeID = 1

update dbo.CostType 
set CostTypeName = 'Supplies', IsValidInvoiceLineItemCostType = 1
where CostTypeID = 2

update dbo.CostType 
set CostTypeName = 'PersonnelAndBenefits', IsValidInvoiceLineItemCostType = 1
where CostTypeID = 3

update dbo.CostType 
set CostTypeName = 'Travel', IsValidInvoiceLineItemCostType = 1
where CostTypeID = 4

update dbo.CostType 
set CostTypeName = 'Contractual', IsValidInvoiceLineItemCostType = 1
where CostTypeID = 5

update dbo.CostType 
set CostTypeName = 'Agreements', IsValidInvoiceLineItemCostType = 0
where CostTypeID = 6

go

ALTER TABLE dbo.CostType ALTER COLUMN CostTypeName varchar(31) NOT NULL

ALTER TABLE dbo.CostType ALTER COLUMN IsValidInvoiceLineItemCostType bit NOT NULL