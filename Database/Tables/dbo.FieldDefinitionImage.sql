SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDefinitionImage](
	[FieldDefinitionImageID] [int] IDENTITY(1,1) NOT NULL,
	[FieldDefinitionID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_FieldDefinitionImage_FieldDefinitionImageID] PRIMARY KEY CLUSTERED 
(
	[FieldDefinitionImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FieldDefinitionImage_FieldDefinitionImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[FieldDefinitionImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FieldDefinitionImage]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinitionImage_FieldDefinition_FieldDefinitionID] FOREIGN KEY([FieldDefinitionID])
REFERENCES [dbo].[FieldDefinition] ([FieldDefinitionID])
GO
ALTER TABLE [dbo].[FieldDefinitionImage] CHECK CONSTRAINT [FK_FieldDefinitionImage_FieldDefinition_FieldDefinitionID]
GO
ALTER TABLE [dbo].[FieldDefinitionImage]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinitionImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[FieldDefinitionImage] CHECK CONSTRAINT [FK_FieldDefinitionImage_FileResource_FileResourceID]