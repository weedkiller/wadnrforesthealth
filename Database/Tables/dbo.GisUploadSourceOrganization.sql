SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GisUploadSourceOrganization](
	[GisUploadSourceOrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[GisUploadSourceOrganizationName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectTypeDefaultName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TreatmentTypeDefaultName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ImportIsFlattened] [bit] NULL,
	[RequireCompletionDate] [bit] NOT NULL,
	[AdjustProjectTypeBasedOnTreatmentTypes] [bit] NOT NULL,
	[ProjectStageDefaultID] [int] NOT NULL,
	[DataDeriveProjectStage] [bit] NOT NULL,
	[DefaultLeadImplementerOrganizationID] [int] NOT NULL,
	[RelationshipTypeForDefaultOrganizationID] [int] NOT NULL,
	[ProjectDescriptionDefaultText] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_GisUploadSourceOrganization_GisUploadSourceOrganizationID] PRIMARY KEY CLUSTERED 
(
	[GisUploadSourceOrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[GisUploadSourceOrganization]  WITH CHECK ADD  CONSTRAINT [FK_GisUploadSourceOrganization_Organization_DefaultLeadImplementerOrganizationID_OrganizationID] FOREIGN KEY([DefaultLeadImplementerOrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[GisUploadSourceOrganization] CHECK CONSTRAINT [FK_GisUploadSourceOrganization_Organization_DefaultLeadImplementerOrganizationID_OrganizationID]
GO
ALTER TABLE [dbo].[GisUploadSourceOrganization]  WITH CHECK ADD  CONSTRAINT [FK_GisUploadSourceOrganization_ProjectStage_ProjectStageDefaultID_ProjectStageID] FOREIGN KEY([ProjectStageDefaultID])
REFERENCES [dbo].[ProjectStage] ([ProjectStageID])
GO
ALTER TABLE [dbo].[GisUploadSourceOrganization] CHECK CONSTRAINT [FK_GisUploadSourceOrganization_ProjectStage_ProjectStageDefaultID_ProjectStageID]
GO
ALTER TABLE [dbo].[GisUploadSourceOrganization]  WITH CHECK ADD  CONSTRAINT [FK_GisUploadSourceOrganization_RelationshipType_RelationshipTypeForDefaultOrganizationID_RelationshipTypeID] FOREIGN KEY([RelationshipTypeForDefaultOrganizationID])
REFERENCES [dbo].[RelationshipType] ([RelationshipTypeID])
GO
ALTER TABLE [dbo].[GisUploadSourceOrganization] CHECK CONSTRAINT [FK_GisUploadSourceOrganization_RelationshipType_RelationshipTypeForDefaultOrganizationID_RelationshipTypeID]