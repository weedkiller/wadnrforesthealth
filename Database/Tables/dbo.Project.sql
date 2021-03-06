SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectTypeID] [int] NOT NULL,
	[ProjectStageID] [int] NOT NULL,
	[ProjectName] [varchar](140) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CompletionDate] [datetime] NULL,
	[EstimatedTotalCost] [money] NULL,
	[ProjectLocationPoint] [geometry] NULL,
	[PerformanceMeasureActualYearsExemptionExplanation] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsFeatured] [bit] NOT NULL,
	[ProjectLocationNotes] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PlannedDate] [datetime] NULL,
	[ProjectLocationSimpleTypeID] [int] NOT NULL,
	[ProjectApprovalStatusID] [int] NOT NULL,
	[ProposingPersonID] [int] NULL,
	[ProposingDate] [datetime] NULL,
	[PerformanceMeasureNotes] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubmissionDate] [datetime] NULL,
	[ApprovalDate] [datetime] NULL,
	[ReviewedByPersonID] [int] NULL,
	[DefaultBoundingBox] [geometry] NULL,
	[NoExpendituresToReportExplanation] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FocusAreaID] [int] NULL,
	[NoRegionsExplanation] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExpirationDate] [datetime] NULL,
	[FhtProjectNumber] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[NoPriorityLandscapesExplanation] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreateGisUploadAttemptID] [int] NULL,
	[LastUpdateGisUploadAttemptID] [int] NULL,
	[ProjectGisIdentifier] [varchar](140) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectFundingSourceNotes] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProgramID] [int] NULL,
 CONSTRAINT [PK_Project_ProjectID] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Project_FhtProjectNumber] UNIQUE NONCLUSTERED 
(
	[FhtProjectNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_FocusArea_FocusAreaID] FOREIGN KEY([FocusAreaID])
REFERENCES [dbo].[FocusArea] ([FocusAreaID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_FocusArea_FocusAreaID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_GisUploadAttempt_CreateGisUploadAttemptID_GisUploadAttemptID] FOREIGN KEY([CreateGisUploadAttemptID])
REFERENCES [dbo].[GisUploadAttempt] ([GisUploadAttemptID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_GisUploadAttempt_CreateGisUploadAttemptID_GisUploadAttemptID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_GisUploadAttempt_LastUpdateGisUploadAttemptID_GisUploadAttemptID] FOREIGN KEY([LastUpdateGisUploadAttemptID])
REFERENCES [dbo].[GisUploadAttempt] ([GisUploadAttemptID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_GisUploadAttempt_LastUpdateGisUploadAttemptID_GisUploadAttemptID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Person_ProposingPersonID_PersonID] FOREIGN KEY([ProposingPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Person_ProposingPersonID_PersonID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Person_ReviewedByPersonID_PersonID] FOREIGN KEY([ReviewedByPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Person_ReviewedByPersonID_PersonID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Program_ProgramID] FOREIGN KEY([ProgramID])
REFERENCES [dbo].[Program] ([ProgramID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Program_ProgramID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectApprovalStatus_ProjectApprovalStatusID] FOREIGN KEY([ProjectApprovalStatusID])
REFERENCES [dbo].[ProjectApprovalStatus] ([ProjectApprovalStatusID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectApprovalStatus_ProjectApprovalStatusID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectLocationSimpleType_ProjectLocationSimpleTypeID] FOREIGN KEY([ProjectLocationSimpleTypeID])
REFERENCES [dbo].[ProjectLocationSimpleType] ([ProjectLocationSimpleTypeID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectLocationSimpleType_ProjectLocationSimpleTypeID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectStage_ProjectStageID] FOREIGN KEY([ProjectStageID])
REFERENCES [dbo].[ProjectStage] ([ProjectStageID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectStage_ProjectStageID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectType_ProjectTypeID] FOREIGN KEY([ProjectTypeID])
REFERENCES [dbo].[ProjectType] ([ProjectTypeID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectType_ProjectTypeID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_ProjectCannotHaveProjectStageProposalAndApprovalStatusApproved] CHECK  (([ProjectStageID]<>(1) OR [ProjectApprovalStatusID]<>(3)))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_ProjectCannotHaveProjectStageProposalAndApprovalStatusApproved]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_ProjectLocationPoint_IsPointData] CHECK  (([ProjectLocationPoint] IS NULL OR [ProjectLocationPoint] IS NOT NULL AND [ProjectLocationPoint].[STGeometryType]()='Point'))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_ProjectLocationPoint_IsPointData]