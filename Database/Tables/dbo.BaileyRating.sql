SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaileyRating](
	[BaileyRatingID] [int] NOT NULL,
	[BaileyRatingName] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BaileyRatingDisplayName] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_BaileyRating_BaileyRatingID] PRIMARY KEY CLUSTERED 
(
	[BaileyRatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_BaileyRating_BaileyRatingDisplayName] UNIQUE NONCLUSTERED 
(
	[BaileyRatingDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_BaileyRating_BaileyRatingName] UNIQUE NONCLUSTERED 
(
	[BaileyRatingName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
