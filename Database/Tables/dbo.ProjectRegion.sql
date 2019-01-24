SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectRegion](
	[ProjectRegionID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[RegionID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectRegion_ProjectRegionID] PRIMARY KEY CLUSTERED 
(
	[ProjectRegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectRegion_ProjectID_RegionID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[RegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectRegion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRegion_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectRegion] CHECK CONSTRAINT [FK_ProjectRegion_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectRegion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRegion_Region_RegionID] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Region] ([RegionID])
GO
ALTER TABLE [dbo].[ProjectRegion] CHECK CONSTRAINT [FK_ProjectRegion_Region_RegionID]