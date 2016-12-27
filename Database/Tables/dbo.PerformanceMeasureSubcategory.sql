SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureSubcategory](
	[PerformanceMeasureSubcategoryID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PerformanceMeasureSubcategoryDisplayName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NULL,
	[ChartConfigurationJson] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ChartType] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SwapChartAxes] [bit] NULL,
 CONSTRAINT [PK_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureSubcategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureSubcategoryID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryName] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureSubcategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureSubcategory_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureSubcategory] CHECK CONSTRAINT [FK_PerformanceMeasureSubcategory_PerformanceMeasure_PerformanceMeasureID]