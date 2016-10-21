SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TownCenterType](
	[TownCenterTypeID] [int] NOT NULL,
	[TownCenterTypeName] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TownCenterTypeDisplayName] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_TownCenterType_TownCenterTypeID] PRIMARY KEY CLUSTERED 
(
	[TownCenterTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TownCenterType_TownCenterTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[TownCenterTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TownCenterType_TownCenterTypeName] UNIQUE NONCLUSTERED 
(
	[TownCenterTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
