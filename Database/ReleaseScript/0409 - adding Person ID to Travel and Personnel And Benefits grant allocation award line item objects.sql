alter table dbo.GrantAllocationAwardPersonnelAndBenefitsLineItem
add PersonID int null constraint FK_GrantAllocationAwardPersonnelAndBenefitsLineItem_Person_PersonID foreign key references dbo.Person(PersonID);

alter table dbo.GrantAllocationAwardPersonnelAndBenefitsLineItem
drop column GrantAllocationAwardPersonnelAndBenefitsLineItemDescription;