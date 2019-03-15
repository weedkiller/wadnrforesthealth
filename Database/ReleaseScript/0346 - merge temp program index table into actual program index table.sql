--SELECT tpc.project, tpc.title FROM dbo.tmpProjectCode as tpc left join dbo.ProjectCode as pc on tpc.project = pc.ProjectCodeAbbrev where pc.ProjectCodeAbbrev is null
alter table dbo.ProgramIndex add
ProgramIndexTitle varchar(255) null,
IsHistoric bit;

--this works for now, if we decide to pull in all years, we may need to include the fy_biennium field in this table and unique on ProgramIndexAbbrev and fy_biennium
ALTER TABLE dbo.ProgramIndex ADD CONSTRAINT AK_ProgramIndex_ProgramIndexAbbrev UNIQUE(ProgramIndexAbbrev)

GO


--update existing records with the title field
UPDATE
    dbo.ProgramIndex
SET
    dbo.ProgramIndex.ProgramIndexTitle = tpix.title
FROM
    dbo.ProgramIndex pix
INNER JOIN
    dbo.tmpProgramIndex tpix
ON 
    pix.ProgramIndexAbbrev = tpix.program_index
WHERE
	tpix.fy_biennium = '2019'


--add missing records
INSERT INTO dbo.ProgramIndex (ProgramIndexAbbrev, ProgramIndexTitle) 
	SELECT tpix.program_index, tpix.title 
	FROM dbo.tmpProgramIndex as tpix 
	left join dbo.ProgramIndex as pix 
	on tpix.program_index = pix.ProgramIndexAbbrev 
	where pix.ProgramIndexAbbrev is null and tpix.fy_biennium = '2019'

--update records with no title to be historic (meaning they do not have any information in the 2019 data)
update dbo.ProgramIndex
set IsHistoric = 1
where ProgramIndexTitle is null

--lets not allow nulls in this bit
update dbo.ProgramIndex
set IsHistoric = 0
where ProgramIndexTitle is not null


alter table dbo.ProgramIndex alter column IsHistoric bit not null