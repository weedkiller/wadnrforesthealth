CREATE TABLE dbo.ProjectCode
(
    ProjectCodeID int not NULL identity(1,1) Constraint PK_ProjectCode_ProjectCodeID primary key,
	ProjectCode nvarchar(100) not null
)

-- Picking this name at least in part because "grant" is a SQL keyword. 
CREATE TABLE dbo.GrantAllocation
(
    -- Just a few fields to start -- very incomplete
    GrantAllocationID int not NULL identity(1,1) Constraint PK_GrantAllocation_GrantAllocationID primary key,
	GrantID int not null constraint FK_GrantAllocation_Grant_GrantID references dbo.[Grant](GrantID),
	ProjectName nvarchar(100) NULL,
    StartDate DateTime not NULL,
    EndDate DateTime not NULL,
    AllocationAmount money null,
	CostTypeID int null, -- This is FK'd to CostType lookup table in subsequent release script
	ProgramIndex nvarchar(100) NULL,
	ProgramManagerPersonID int NULL,	
)

CREATE TABLE dbo.GrantAllocationProjectCode
(
    GrantAllocationProjectCodeID int not NULL identity(1,1) Constraint PK_GrantAllocationProjectCode_GrantAllocationProjectCodeID primary key,
	GrantAllocationID int not NULL constraint FK_GrantAllocationProjectCode_GrantAllocation_GrantAllocationID references dbo.GrantAllocation(GrantAllocationID),
	ProjectCodeID int not null constraint FK_GrantAllocationProjectCode_ProjectCode_ProjectCodeID references dbo.ProjectCode(ProjectCodeID)
)

ALTER TABLE [dbo].GrantAllocationProjectCode ADD  CONSTRAINT [AK_GrantAllocationProjectCode_GrantAllocationID_ProjectCodeID] UNIQUE NONCLUSTERED 
(
	GrantAllocationID ASC,
	ProjectCodeID ASC
)ON [PRIMARY]
GO

insert into FieldDefinition values
(278, N'GrantAllocation', 'Grant Allocation', 'Placeholder definition for Grant Allocation.')
GO

insert into FieldDefinitionData (FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
select 278, Null, Null

GO

insert into FieldDefinition values
(280, N'ProjectCode', 'Project Code', 'Placeholder definition for Project Code.')
GO

insert into FieldDefinitionData (FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
select 280, Null, Null

GO

insert into FieldDefinition values
(281, N'GrantAllocationProjectCode', 'Grant Allocation Project Code', 'Placeholder definition for Grant Allocation Project Code.')
GO

insert into FieldDefinitionData (FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
select 281, Null, Null

GO

