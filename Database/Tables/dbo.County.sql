SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[County](
	[CountyID] [int] NOT NULL,
	[CountyName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StateProvinceID] [int] NOT NULL,
	[CountyFeature] [geometry] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_County_CountyID] PRIMARY KEY CLUSTERED 
(
	[CountyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_County_CountyName] UNIQUE NONCLUSTERED 
(
	[CountyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[County]  WITH CHECK ADD  CONSTRAINT [FK_County_StateProvince_StateProvinceID] FOREIGN KEY([StateProvinceID])
REFERENCES [dbo].[StateProvince] ([StateProvinceID])
GO
ALTER TABLE [dbo].[County] CHECK CONSTRAINT [FK_County_StateProvince_StateProvinceID]
GO
ALTER TABLE [dbo].[County]  WITH CHECK ADD  CONSTRAINT [FK_County_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[County] CHECK CONSTRAINT [FK_County_Tenant_TenantID]