insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values (65, 'ProgramsList', 'Programs List', 1)

go

insert into dbo.FirmaPage(FirmaPageTypeID, FirmaPageContent)
values(65,'Programs exist under an Organization')


