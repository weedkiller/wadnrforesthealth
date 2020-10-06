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


update dbo.GisUploadSourceOrganization set ApplyCompletedDateToProject = 0
where GisUploadSourceOrganizationName = 'USFS';

update dbo.GisUploadSourceOrganization set ApplyCompletedDateToProject = 0
where GisUploadSourceOrganizationName = 'WDFW';

update dbo.GisUploadSourceOrganization set ApplyCompletedDateToProject = 0
where GisUploadSourceOrganizationName = 'DNR';

delete from dbo.GisDefaultMapping where GisDefaultMappingID = 5;


/*


select * from dbo.GisUploadSourceOrganization

USFS - started date unused
     - completed date on treatment

WDFW   Start Date: unused
        End Date: TreatmentDate on treatment


LOA      Start Date: unused
        Completion Date: Date_Completed - project


DNR State Uplands  Start Date: unused
        End Date: FMA_DT on treatment

DNR Stewardship Plans start Date: PLAN_START_DATE on project
                        End Date: unused



*/