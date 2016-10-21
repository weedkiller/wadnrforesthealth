SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitoringProgramPartner](
	[MonitoringProgramPartnerID] [int] IDENTITY(1,1) NOT NULL,
	[MonitoringProgramID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
 CONSTRAINT [PK_MonitoringProgramPartner_MonitoringProgramPartnerID] PRIMARY KEY CLUSTERED 
(
	[MonitoringProgramPartnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MonitoringProgramPartner_MonitoringProgramID_OrganizationID] UNIQUE NONCLUSTERED 
(
	[MonitoringProgramID] ASC,
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MonitoringProgramPartner]  WITH CHECK ADD  CONSTRAINT [FK_MonitoringProgramPartner_MonitoringProgram_MonitoringProgramID] FOREIGN KEY([MonitoringProgramID])
REFERENCES [dbo].[MonitoringProgram] ([MonitoringProgramID])
GO
ALTER TABLE [dbo].[MonitoringProgramPartner] CHECK CONSTRAINT [FK_MonitoringProgramPartner_MonitoringProgram_MonitoringProgramID]
GO
ALTER TABLE [dbo].[MonitoringProgramPartner]  WITH CHECK ADD  CONSTRAINT [FK_MonitoringProgramPartner_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[MonitoringProgramPartner] CHECK CONSTRAINT [FK_MonitoringProgramPartner_Organization_OrganizationID]