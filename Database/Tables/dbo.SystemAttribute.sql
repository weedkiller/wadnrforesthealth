SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemAttribute](
	[SystemAttributeID] [int] IDENTITY(1,1) NOT NULL,
	[DefaultBoundingBox] [geometry] NOT NULL,
	[MinimumYear] [int] NOT NULL,
	[PrimaryContactPersonID] [int] NULL,
	[SquareLogoFileResourceID] [int] NULL,
	[BannerLogoFileResourceID] [int] NULL,
	[RecaptchaPublicKey] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RecaptchaPrivateKey] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShowApplicationsToThePublic] [bit] NOT NULL,
	[TaxonomyLevelID] [int] NOT NULL,
	[AssociatePerfomanceMeasureTaxonomyLevelID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ShowLeadImplementerLogoOnFactSheet] [bit] NOT NULL,
	[EnableAccomplishmentsDashboard] [bit] NOT NULL,
	[ProjectStewardshipAreaTypeID] [int] NULL,
	[SocrataAppToken] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_SystemAttribute_SystemAttributeID] PRIMARY KEY CLUSTERED 
(
	[SystemAttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[SystemAttribute]  WITH CHECK ADD  CONSTRAINT [FK_SystemAttribute_FileResource_BannerLogoFileResourceID_FileResourceID] FOREIGN KEY([BannerLogoFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[SystemAttribute] CHECK CONSTRAINT [FK_SystemAttribute_FileResource_BannerLogoFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[SystemAttribute]  WITH CHECK ADD  CONSTRAINT [FK_SystemAttribute_FileResource_SquareLogoFileResourceID_FileResourceID] FOREIGN KEY([SquareLogoFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[SystemAttribute] CHECK CONSTRAINT [FK_SystemAttribute_FileResource_SquareLogoFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[SystemAttribute]  WITH CHECK ADD  CONSTRAINT [FK_SystemAttribute_Person_PrimaryContactPersonID_PersonID] FOREIGN KEY([PrimaryContactPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[SystemAttribute] CHECK CONSTRAINT [FK_SystemAttribute_Person_PrimaryContactPersonID_PersonID]
GO
ALTER TABLE [dbo].[SystemAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeID] FOREIGN KEY([ProjectStewardshipAreaTypeID])
REFERENCES [dbo].[ProjectStewardshipAreaType] ([ProjectStewardshipAreaTypeID])
GO
ALTER TABLE [dbo].[SystemAttribute] CHECK CONSTRAINT [FK_TenantAttribute_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeID]
GO
ALTER TABLE [dbo].[SystemAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_TaxonomyLevel_AssociatePerfomanceMeasureTaxonomyLevelID_TaxonomyLevelID] FOREIGN KEY([AssociatePerfomanceMeasureTaxonomyLevelID])
REFERENCES [dbo].[TaxonomyLevel] ([TaxonomyLevelID])
GO
ALTER TABLE [dbo].[SystemAttribute] CHECK CONSTRAINT [FK_TenantAttribute_TaxonomyLevel_AssociatePerfomanceMeasureTaxonomyLevelID_TaxonomyLevelID]
GO
ALTER TABLE [dbo].[SystemAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_TaxonomyLevel_TaxonomyLevelID] FOREIGN KEY([TaxonomyLevelID])
REFERENCES [dbo].[TaxonomyLevel] ([TaxonomyLevelID])
GO
ALTER TABLE [dbo].[SystemAttribute] CHECK CONSTRAINT [FK_TenantAttribute_TaxonomyLevel_TaxonomyLevelID]
GO
ALTER TABLE [dbo].[SystemAttribute]  WITH CHECK ADD  CONSTRAINT [CK_TenantAttribute_AssociatedPerfomanceMeasureTaxonomyLevelLessThanEqualToTaxonomyLevelID] CHECK  (([AssociatePerfomanceMeasureTaxonomyLevelID]<=[TaxonomyLevelID]))
GO
ALTER TABLE [dbo].[SystemAttribute] CHECK CONSTRAINT [CK_TenantAttribute_AssociatedPerfomanceMeasureTaxonomyLevelLessThanEqualToTaxonomyLevelID]