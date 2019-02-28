SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authenticator](
	[AuthenticatorID] [int] IDENTITY(1,1) NOT NULL,
	[AuthenticatorShortName] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AuthenticatorFullName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Authenticator_AuthenticatorID] PRIMARY KEY CLUSTERED 
(
	[AuthenticatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
