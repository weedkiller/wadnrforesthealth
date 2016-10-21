SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalAndRegionalPlan](
	[LocalAndRegionalPlanID] [int] IDENTITY(1,1) NOT NULL,
	[LocalAndRegionalPlanName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PlanDocumentUrl] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PlanDocumentLinkText] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsTransportationPlan] [bit] NOT NULL,
 CONSTRAINT [PK_LocalAndRegionalPlan_LocalAndRegionalPlanID] PRIMARY KEY CLUSTERED 
(
	[LocalAndRegionalPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_LocalAndRegionalPlan_LocalAndRegionalPlanName] UNIQUE NONCLUSTERED 
(
	[LocalAndRegionalPlanName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
