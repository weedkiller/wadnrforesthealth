
/*
-- Working Prototype
select o.OrganizationID,
       o.OrganizationName,
       p.OrganizationID,
       tac.*
from dbo.tmpAgreementContactsImportTemplate as tac
inner join Person as p on p.FirstName = tac.FirstName and p.LastName = tac.LastName
inner join Organization as o on tac.Organization = o.OrganizationName
*/

-- Attempt to do simple match by name. Works for many, but not all
-- records, so we'll have to manually match some below.
update Person
set OrganizationID = o.OrganizationID
from dbo.tmpAgreementContactsImportTemplate as tac
inner join Person as p on p.FirstName = tac.FirstName and p.LastName = tac.LastName
inner join Organization as o on tac.Organization = o.OrganizationName

-- Update WADNR
update Person
set OrganizationID = 4704  -- WADNR
where PersonID in 
(
    select p.PersonID
    from dbo.tmpAgreementContactsImportTemplate as tac
    inner join Person as p on p.FirstName = tac.FirstName and p.LastName = tac.LastName
    where p.OrganizationID is null
    and tac.Organization = 'WADNR'
)

-- Update WDFW
update Person
set OrganizationID = 5797  -- WDFW
where PersonID in 
(
    select p.PersonID
    from dbo.tmpAgreementContactsImportTemplate as tac
    inner join Person as p on p.FirstName = tac.FirstName and p.LastName = tac.LastName
    where p.OrganizationID is null
    and tac.Organization = 'WDFW'
)

-- Update NOAA - NWS
update Person
set OrganizationID = 5797  -- NOAA - National Weather Service
where PersonID in 
(
    -- These people were labelled "IMET SUPPORT", which appears to be National Weather Service, so I feel secure
    -- in putting these on the NWS-specific NOAA. -- SLG 2/26/2019
    select p.PersonID
    from dbo.tmpAgreementContactsImportTemplate as tac
    inner join Person as p on p.FirstName = tac.FirstName and p.LastName = tac.LastName
    where p.OrganizationID is null
    and tac.Organization = 'National Oceanic and Atmospheric Administration'
)






-- Update Washington State Parks and Recreation Commission
update Person
set OrganizationID = 5793  -- Washington State Parks and Recreation Commission
where PersonID in 
(
    select p.PersonID
    from dbo.tmpAgreementContactsImportTemplate as tac
    inner join Person as p on p.FirstName = tac.FirstName and p.LastName = tac.LastName
    where p.OrganizationID is null
    and tac.Organization = 'Washington State Parks & Recreation Commission'
)





-- Update Alliance Ecological Services
update Person
set OrganizationID = 5729  -- Alliance Ecological Services
where PersonID in 
(
    select p.PersonID
    from dbo.tmpAgreementContactsImportTemplate as tac
    inner join Person as p on p.FirstName = tac.FirstName and p.LastName = tac.LastName
    where p.OrganizationID is null
    and tac.Organization = 'Alliance Ecological Services'
)

-- Update Sean Jeronimo
update Person
set OrganizationID = 5772  -- Sean Jeronimo
where PersonID in 
(
    select p.PersonID
    from dbo.tmpAgreementContactsImportTemplate as tac
    inner join Person as p on p.FirstName = tac.FirstName and p.LastName = tac.LastName
    where p.OrganizationID is null
    and tac.FirstName = 'Sean' and tac.LastName = 'Jeronimo'
)

/*
-- What's left unmatched?
select --o.OrganizationID,
       --o.OrganizationName,
       p.OrganizationID,
       tac.*
from dbo.tmpAgreementContactsImportTemplate as tac
inner join Person as p on p.FirstName = tac.FirstName and p.LastName = tac.LastName
where p.OrganizationID is null
--and tac.Organization = 'WADNR'
--inner join Organization as o on tac.Organization = o.OrganizationName
*/

-- This may not hold, but let's try for the moment
alter table Person 
alter column OrganizationID int not null

/*
select * from Person
where OrganizationID is null
*/

-- select * from Organization

