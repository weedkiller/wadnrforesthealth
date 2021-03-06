SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TreatmentArea](
	[TreatmentAreaID] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentAreaFeature] [geometry] NOT NULL,
	[TemporaryTreatmentCacheID] [int] NULL,
 CONSTRAINT [PK_TreatmentArea_TreatmentAreaID] PRIMARY KEY CLUSTERED 
(
	[TreatmentAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
