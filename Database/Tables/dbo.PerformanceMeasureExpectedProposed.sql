SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureExpectedProposed](
	[PerformanceMeasureExpectedProposedID] [int] IDENTITY(1,1) NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[ExpectedValue] [float] NULL,
 CONSTRAINT [PK_PerformanceMeasureExpectedProposed_PerformanceMeasureExpectedProposedID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureExpectedProposedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureExpectedProposed_PerformanceMeasureExpectedProposedID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureExpectedProposedID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedProposed_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedProposed_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedProposed_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedProposed_ProposedProject_ProposedProjectID]