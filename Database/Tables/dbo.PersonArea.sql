SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonArea](
	[PersonAreaID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[LTInfoAreaID] [int] NOT NULL,
	[ReceiveSupportEmails] [bit] NOT NULL,
 CONSTRAINT [PK_PersonArea_PersonAreaID] PRIMARY KEY CLUSTERED 
(
	[PersonAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PersonArea_PersonID_LTInfoAreaID] UNIQUE NONCLUSTERED 
(
	[PersonID] ASC,
	[LTInfoAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PersonArea]  WITH CHECK ADD  CONSTRAINT [FK_PersonArea_LTInfoArea_LTInfoAreaID] FOREIGN KEY([LTInfoAreaID])
REFERENCES [dbo].[LTInfoArea] ([LTInfoAreaID])
GO
ALTER TABLE [dbo].[PersonArea] CHECK CONSTRAINT [FK_PersonArea_LTInfoArea_LTInfoAreaID]
GO
ALTER TABLE [dbo].[PersonArea]  WITH CHECK ADD  CONSTRAINT [FK_PersonArea_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonArea] CHECK CONSTRAINT [FK_PersonArea_Person_PersonID]