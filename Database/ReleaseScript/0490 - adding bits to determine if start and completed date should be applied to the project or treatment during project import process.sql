alter table dbo.GisUploadSourceOrganization
add ApplyCompletedDateToProject bit null
go

update dbo.GisUploadSourceOrganization set ApplyCompletedDateToProject = 1;

alter table dbo.GisUploadSourceOrganization
alter column ApplyCompletedDateToProject bit not null
go

alter table dbo.GisUploadSourceOrganization
add ApplyStartDateToProject bit null
go

update dbo.GisUploadSourceOrganization set ApplyStartDateToProject = 1;

alter table dbo.GisUploadSourceOrganization
alter column ApplyStartDateToProject bit not null
go


/*


*/