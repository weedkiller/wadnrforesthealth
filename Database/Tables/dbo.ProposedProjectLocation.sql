SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProjectLocation](
	[ProposedProjectLocationID] [int] IDENTITY(1,1) NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[ProjectLocationGeometry] [geometry] NOT NULL,
	[Annotation] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProposedProjectLocation_ProposedProjectLocationID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectLocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProjectLocation]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectLocation_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[ProposedProjectLocation] CHECK CONSTRAINT [FK_ProposedProjectLocation_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[ProposedProjectLocation]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectLocation_ProposedProject_ProposedProjectID_TenantID] FOREIGN KEY([ProposedProjectID], [TenantID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectLocation] CHECK CONSTRAINT [FK_ProposedProjectLocation_ProposedProject_ProposedProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectLocation]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectLocation_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectLocation] CHECK CONSTRAINT [FK_ProposedProjectLocation_Tenant_TenantID]