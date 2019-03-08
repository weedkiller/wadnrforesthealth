CREATE TABLE [dbo].[InvoiceApprovalStatus](
	[InvoiceApprovalStatusID] [int] NOT NULL,
	[InvoiceApprovalStatusName] [varchar](50) NOT NULL,
	[InvoiceApprovalStatusComment] [varchar](max) NOT NULL,
 CONSTRAINT [PK_InvoiceApprovalStatus_InvoiceApprovalStatusID] PRIMARY KEY CLUSTERED 
(
	[InvoiceApprovalStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_InvoiceApprovalStatus_InvoiceApprovalStatusName] UNIQUE NONCLUSTERED 
(
	[InvoiceApprovalStatusName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
)
GO
