SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostType](
	[CostTypeID] [int] IDENTITY(1,1) NOT NULL,
	[CostTypeDisplayName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CostTypeName] [varchar](31) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsValidInvoiceLineItemCostType] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_CostType_CostTypeID] PRIMARY KEY CLUSTERED 
(
	[CostTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
