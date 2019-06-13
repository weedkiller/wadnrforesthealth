
create table dbo.GrantAllocationAward(
	GrantAllocationAwardID int not null identity(1,1) constraint PK_GrantAllocationAward_GrantAllocationAwardID primary key,
	GrantAllocationID int not null constraint FK_GrantAllocationAward_GrantAllocation_GrantAllocationID foreign key references dbo.GrantAllocation(GrantAllocationID),
	FocusAreaID int not null constraint FK_GrantAllocationAward_FocusArea_FocusAreaID foreign key references dbo.FocusArea(FocusAreaID),
	GrantAllocationAwardName varchar(250) not null,
	GrantAllocationAwardAmount money not null,
	GrantAllocationAwardExpirationDate DateTime not null
);


--create table dbo.GrantAllocationAwardLineItem(
--	GrantAllocationAwardLineItemID int not null identity(1,1) constraint PK_GrantAllocationAwardLineItem_GrantAllocationAwardLineItemID primary key,
--	GrantAllocationAwardID int not null constraint FK_GrantAllocationAwardLineItem_GrantAllocationAward_GrantAllocationAwardID foreign key references dbo.GrantAllocationAward(GrantAllocationAwardID),
--	CostTypeID int not null constraint FK_GrantAllocationAwardLineItem_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID),


--);