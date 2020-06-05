SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GisUploadAttemptWorkflowSectionGrouping](
	[GisUploadAttemptWorkflowSectionGroupingID] [int] NOT NULL,
	[GisUploadAttemptWorkflowSectionGroupingName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GisUploadAttemptWorkflowSectionGroupingDisplayName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_GisUploadAttemptWorkflowSectionGrouping_GisUploadAttemptWorkflowSectionGroupingID] PRIMARY KEY CLUSTERED 
(
	[GisUploadAttemptWorkflowSectionGroupingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GisUploadAttemptWorkflowSectionGrouping_GisUploadAttemptWorkflowSectionGroupingDisplayName] UNIQUE NONCLUSTERED 
(
	[GisUploadAttemptWorkflowSectionGroupingDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GisUploadAttemptWorkflowSectionGrouping_GisUploadAttemptWorkflowSectionGroupingName] UNIQUE NONCLUSTERED 
(
	[GisUploadAttemptWorkflowSectionGroupingName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
