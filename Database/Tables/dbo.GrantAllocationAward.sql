SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrantAllocationAward](
	[GrantAllocationAwardID] [int] IDENTITY(1,1) NOT NULL,
	[GrantAllocationID] [int] NOT NULL,
	[FocusAreaID] [int] NOT NULL,
	[GrantAllocationAwardName] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GrantAllocationAwardAmount] [money] NOT NULL,
	[GrantAllocationAwardExpirationDate] [datetime] NOT NULL,
	[IndirectCostAllocationTotal] [money] NULL,
	[SuppliesAllocationTotal] [money] NULL,
	[PersonnelAndBenefitsAllocationTotal] [money] NULL,
	[PersonnelAndBenefitsForester] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TravelAllocationTotal] [money] NULL,
	[TravelForester] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LandownerCostShareAllocationTotal] [money] NULL,
	[LandownerCostShareTargetFootprintAcreage] [int] NULL,
	[LandownerCostShareTargetTotalAcreage] [int] NULL,
	[LandownerCostShareForester] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContractorInvoicesAllocationTotal] [money] NULL,
	[ContractorInvoicesContractor] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContractorInvoicesTargetTotalAcreage] [int] NULL,
 CONSTRAINT [PK_GrantAllocationAward_GrantAllocationAwardID] PRIMARY KEY CLUSTERED 
(
	[GrantAllocationAwardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[GrantAllocationAward]  WITH CHECK ADD  CONSTRAINT [FK_GrantAllocationAward_FocusArea_FocusAreaID] FOREIGN KEY([FocusAreaID])
REFERENCES [dbo].[FocusArea] ([FocusAreaID])
GO
ALTER TABLE [dbo].[GrantAllocationAward] CHECK CONSTRAINT [FK_GrantAllocationAward_FocusArea_FocusAreaID]
GO
ALTER TABLE [dbo].[GrantAllocationAward]  WITH CHECK ADD  CONSTRAINT [FK_GrantAllocationAward_GrantAllocation_GrantAllocationID] FOREIGN KEY([GrantAllocationID])
REFERENCES [dbo].[GrantAllocation] ([GrantAllocationID])
GO
ALTER TABLE [dbo].[GrantAllocationAward] CHECK CONSTRAINT [FK_GrantAllocationAward_GrantAllocation_GrantAllocationID]