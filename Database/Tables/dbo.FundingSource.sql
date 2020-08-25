SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingSource](
	[FundingSourceID] [int] NOT NULL,
	[FundingSourceName] [varchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FundingSourceDisplayName] [varchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_FundingSource_FundingSourceID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
