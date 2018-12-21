ALTER TABLE [dbo].[Person] DROP CONSTRAINT [AK_Person_PersonGuid_TenantID]
GO

alter table dbo.Person alter column PersonGuid varchar(100) null
GO
exec sp_rename 'dbo.Person.PersonGuid', 'PersonUniqueIdentifier', 'COLUMN'
GO

Create Unique Nonclustered Index AK_Person_PersonUniqueIdentifier_TenantID
on dbo.Person(PersonUniqueIdentifier, TenantID)
where PersonUniqueIdentifier is not null


update dbo.Person 
set PersonUniqueIdentifier = 'DP3TP7WZ2MM7W-1DZ8DP4Q-1DL2VV0ZF1-D1FV3ZT5VM'
where PersonUniqueIdentifier = 'CD3DAB18-4242-4FE9-AB10-874CA43AAEE2'

