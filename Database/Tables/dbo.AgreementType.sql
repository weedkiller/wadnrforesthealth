SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgreementType](
	[AgreementTypeID] [int] IDENTITY(1,1) NOT NULL,
	[AgreementTypeAbbrev] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AgreementTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_AgreementType_AgreementTypeID] PRIMARY KEY CLUSTERED 
(
	[AgreementTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]