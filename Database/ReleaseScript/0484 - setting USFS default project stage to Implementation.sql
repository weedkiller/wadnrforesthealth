
  update dbo.GisUploadSourceOrganization
  set ProjectStageDefaultID = 3
  Where GisUploadSourceOrganizationName = 'USFS'

  
  update dbo.GisUploadSourceOrganization
  set DataDeriveProjectStage = 0
  Where GisUploadSourceOrganizationName = 'USFS'


