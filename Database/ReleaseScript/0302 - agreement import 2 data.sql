USE [WADNRForestHealthDB]
GO
/****** Object:  Table [dbo].[tmpAgreement2]    Script Date: 2/18/2019 12:48:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tmpAgreement2](
	TmpAgreement2ID int identity(1,1) not null CONSTRAINT [PK_tmpAgreement2_TmpAgreement2ID] PRIMARY KEY,
	[AgreementType] [nvarchar](50) NOT NULL,
	[AgreementNumber] [nvarchar](50) NOT NULL,
	[Organization] [nvarchar](100) NOT NULL,
	[AgreementTitle] [nvarchar](100) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[AgreementAmount] [money] NULL,
	[ExpendedMoney] [money] NULL,
	[BalanceMoney] [money] NULL,
	[FirstBillDueOn] [money] NULL,
	[Notes] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'14-159', N'University of Washington', N'NW Weather Prediction Models and Products', CAST(N'2013-11-15T00:00:00.0000000' AS DateTime2), CAST(N'2018-06-30T00:00:00.0000000' AS DateTime2), 125000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'14-159', N'University of Washington', N'Amendment #1 - NW Weather Prediction Models and Products', CAST(N'2018-10-10T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-21T00:00:00.0000000' AS DateTime2), 25000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'12-213', N'Washington State Parks & Recreation Commission', N'Master Agreement', CAST(N'2012-02-10T00:00:00.0000000' AS DateTime2), CAST(N'2016-12-31T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'113-091', N'Washington State Parks & Recreation Commission', N'Amendment #1 - Master Agreement', CAST(N'2016-12-08T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-31T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'TO', N'315-003', N'Washington State Parks & Recreation Commission', N'E. WA Forest Health/Wildfire Fuel Reduction Project', CAST(N'2017-08-09T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 25000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'315-003', N'Washington State Parks & Recreation Commission', N'Amendment #1 - E. WA Forest Health/Wildfire Fuel Reduction Project', CAST(N'2017-12-07T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 75000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'15-275', N'WDFW ', N'DNR/WDFW Master Agreement', CAST(N'2015-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'SPP', N'15-275 RP-001', N'WDFW', N'Habitat Enhancement/Grassland Restoration Support', CAST(N'2015-07-30T00:00:00.0000000' AS DateTime2), CAST(N'2017-06-30T00:00:00.0000000' AS DateTime2), 15000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'SPP', N'16-03', N'WDFW', N'Air Attack Platform', CAST(N'2015-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'SPP', N'16-04 / 93-094731', N'WDFW', N'Forest Health Insect and Disease Aerial Survey Flights', CAST(N'2015-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 50000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'16-04 / 93-094731', N'WDFW', N'Amendment #1 - Forest Health Insect and Disease Aerial Survey Flights', CAST(N'2016-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 400000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'16-291', N'Spokane Conservation District', N'Amendment #2 - ', CAST(N'2018-02-22T00:00:00.0000000' AS DateTime2), CAST(N'2020-02-29T00:00:00.0000000' AS DateTime2), 40000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'MOU', N'16-347', N'CITY OF OLYMPIA', N'Public Tree Inventory Project', CAST(N'2016-05-06T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-31T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'MOU', N'16-348', N'CITY OF LAKEWOOD', N'Public Tree Inventory Project', CAST(N'2016-05-13T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-31T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'MOU', N'16-349', N'CITY OF VANCOUVER', N'Public Tree Inventory Project', CAST(N'2016-05-13T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-31T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'MOU', N'16-350', N'EVERETT PARKS AND RECREATION', N'Public Tree Inventory Project', CAST(N'2016-05-20T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-31T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'MOU', N'16-351', N'CITY OF PASCO', N'Public Tree Inventory Project', CAST(N'2018-05-17T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-31T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'MOU', N'16-352', N'CITY OF GIG HARBOR', N'Public Tree Inventory Project', CAST(N'2016-04-26T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-31T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-095227', N'National Oceanic and Atmospheric Administration', N'IMET Support', CAST(N'2017-05-31T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-31T00:00:00.0000000' AS DateTime2), 500000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'WO', N'93-095950', N'Rudeen and Associates, LLC', N'Wildfire Discovery', CAST(N'2017-07-17T00:00:00.0000000' AS DateTime2), CAST(N'2017-12-31T00:00:00.0000000' AS DateTime2), 70643.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'93-095950', N'Rudeen and Associates, LLC', N'Amendment #1 - Wildfire Discovery', CAST(N'2017-11-08T00:00:00.0000000' AS DateTime2), CAST(N'2019-02-28T00:00:00.0000000' AS DateTime2), 126848.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'93-095950', N'Rudeen and Associates, LLC', N'Amendment #3 - Wildfire Discovery', CAST(N'2018-06-11T00:00:00.0000000' AS DateTime2), CAST(N'2018-07-31T00:00:00.0000000' AS DateTime2), 137248.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-096414', N'TIMBERLINE SILVICS INC', N'Mountain Home Road Fuels Reduction', CAST(N'2017-10-12T00:00:00.0000000' AS DateTime2), CAST(N'2018-06-30T00:00:00.0000000' AS DateTime2), 49020.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-096600', N'UNDERWOOD CONSERVATION DISTRICT', N'Prevention and Fuels Reduction Facilitation', CAST(N'2018-01-03T00:00:00.0000000' AS DateTime2), CAST(N'2018-07-15T00:00:00.0000000' AS DateTime2), 26132.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-096644', N'ECO DIG LLC', N'North Cle Elum Ridge Fuels Reduction', CAST(N'2018-01-23T00:00:00.0000000' AS DateTime2), CAST(N'2018-06-30T00:00:00.0000000' AS DateTime2), 24700.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-096811', N'UNIVERSITY OF WASHINGTON', N'W. WA Swiss Needle Cast Mitigation Plan', CAST(N'2018-04-04T00:00:00.0000000' AS DateTime2), CAST(N'2018-06-30T00:00:00.0000000' AS DateTime2), 25000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097147', N'Resource Data Inc.', N'Smoke Management and Burn Permit Tracking System', CAST(N'2018-08-20T00:00:00.0000000' AS DateTime2), CAST(N'2019-01-31T00:00:00.0000000' AS DateTime2), 267336.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'93-097147', N'Resource Data Inc.', N'Amendment #1 - Smoke Management and Burn Permit Tracking System', CAST(N'2019-01-29T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 277086.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097208', N'Washington Conservation Science Institute, LLC', N'20-Year Strategic Plan Implementation Support', CAST(N'2018-04-16T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-31T00:00:00.0000000' AS DateTime2), 9975.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-097209', N'UNIVERSITY OF WASHINGTON', N'20-Year Strategic PlanAnalysis and Research', CAST(N'2018-05-10T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 72161.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-097236', N'CASCADIA CONSERVATION DISTRICT', N'Outreach, Home Assessments, and Administer Cost-Share Projects', CAST(N'2018-04-12T00:00:00.0000000' AS DateTime2), CAST(N'2020-05-31T00:00:00.0000000' AS DateTime2), 62500.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-097300', N'OKANOGAN CONSERVATION DISTRICT', N'Outreach, Technical Assistance, and Cost-Share Funding', CAST(N'2018-06-12T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-31T00:00:00.0000000' AS DateTime2), 170000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CLA', N'93-097370', N'USFS OKANOGAN-WENATCHEE NAT''L FOREST', N'2018 LiDAR Acquisition', CAST(N'2018-05-30T00:00:00.0000000' AS DateTime2), CAST(N'2019-04-30T00:00:00.0000000' AS DateTime2), 150000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097417', N'SEAN JERONIMO', N'20-Year Forest Health Stretegic Plan Consulting Services', CAST(N'2018-05-18T00:00:00.0000000' AS DateTime2), CAST(N'2018-07-31T00:00:00.0000000' AS DateTime2), 9945.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'93-097417', N'SEAN JERONIMO', N'Amendment #1 - 20-Year Forest Health Stretegic Plan Consulting Services', CAST(N'2018-09-06T00:00:00.0000000' AS DateTime2), CAST(N'2018-09-30T00:00:00.0000000' AS DateTime2), 9945.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'93-097417', N'SEAN JERONIMO', N'Amendment #2 - 20-Year Forest Health Stretegic Plan Consulting Services', CAST(N'2018-09-14T00:00:00.0000000' AS DateTime2), CAST(N'2018-11-15T00:00:00.0000000' AS DateTime2), 17445.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097569', N'ALLIANCE ECOLOGICAL SERVICES', N'20-Year Forest Health Stretegic Plan Consulting Services', CAST(N'2018-07-02T00:00:00.0000000' AS DateTime2), CAST(N'2018-10-31T00:00:00.0000000' AS DateTime2), 9970.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097618', N'Washington Conservation Science Institute, LLC', N'20-Year Forest Health Stretegic Plan Implementation (photo interpretation)', CAST(N'2018-08-06T00:00:00.0000000' AS DateTime2), CAST(N'2019-12-31T00:00:00.0000000' AS DateTime2), 120085.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'SPP', N'93-097648', N'WDFW', N'Larch Correction Center - Pierce National Wildlife Refuge', CAST(N'2018-07-24T00:00:00.0000000' AS DateTime2), CAST(N'2018-08-31T00:00:00.0000000' AS DateTime2), 5000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097701', N'C+C', N'E. WA Social Marketing Plan', CAST(N'2018-09-05T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-31T00:00:00.0000000' AS DateTime2), 9819.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'93-097701', N'C+C', N'Amendment #1 - E. WA Social Marketing Plan', CAST(N'2018-12-28T00:00:00.0000000' AS DateTime2), CAST(N'2019-02-15T00:00:00.0000000' AS DateTime2), 9819.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-097725', N'Kittitas Conservation District', N'Landowner Assistance Program Support', CAST(N'2018-09-14T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-31T00:00:00.0000000' AS DateTime2), 30568.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097739', N'Washington Wild', N'Forest Collaborative Infrastructure Pilot - Olympic Collaborative', CAST(N'2018-09-21T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 25000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097760', N'WRCDC', N'Forest Collaborative Infrastructure Pilot - Tapash', CAST(N'2018-09-13T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 25000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-097761', N'Chelan County Dept of Natural Resources', N'Forest Collaborative Infrastructure Pilot - Stemilt Partnership', CAST(N'2018-09-21T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 6920.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097766', N'Sitka Technology Group', N'Forest Heatlh and Fuels Accomplishment Tracking System', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 313625.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'AMD', N'93-097766', N'Sitka Technology Group', N'Amendment #1 - Forest Heatlh and Fuels Accomplishment Tracking System', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 313625.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CA', N'93-097782', N'WASHINGTON RESOURCE CONSERVATION AND DEVELOPMENT COUNCIL', N'Cascadia Prescribed Fire Training Exchange', CAST(N'2018-09-14T00:00:00.0000000' AS DateTime2), CAST(N'2018-12-31T00:00:00.0000000' AS DateTime2), 26340.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-097798', N'DEPARTMENT OF ECOLOGY', N'Stormwater Mitigation Values', CAST(N'2018-08-20T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-15T00:00:00.0000000' AS DateTime2), 379495.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-097800', N'CLEMSON UNIVERSITY', N'Stormwater Mitigation Values', CAST(N'2019-01-16T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-15T00:00:00.0000000' AS DateTime2), 37967.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-097801', N'WASHINGTON STATE UNIVERSITY', N'Stormwater Mitigation Values', CAST(N'2019-01-15T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-15T00:00:00.0000000' AS DateTime2), 116158.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097809', N'WRCDC', N'Forest Collaborative Infrastructure Pilot - Chumstick Wildfire Stewardship Coalition', CAST(N'2018-09-13T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 25000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097812', N'Upper Columbia Salmon Recovery Board', N'Forest Collaborative Infrastructure Pilot - NCWFHC', CAST(N'2018-10-26T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 25000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-097846', N'OREGON STATE UNIVERSITY', N'State and Transistion Modeling', CAST(N'2018-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 25826.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097848', N'Pinchot Parnters', N'Forest Collaborative Infrastructure Pilot', CAST(N'2018-10-26T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 25000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097849', N'Mt. Adams Resource Stewards', N'Forest Collaborative Infrastructure Pilot - SGPC', CAST(N'2018-10-10T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 25000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-097976', N'Northeast Washington Forestry Coalition', N'Forest Collaborative Infrastructure Pilot - NEWFC', CAST(N'2018-11-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2), 25000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'IAA', N'93-098135', N'Chelan County Dept of Natural Resources', N'Cross-Boundary Competitive Grant Program - Stemilt Partnership', CAST(N'2018-12-05T00:00:00.0000000' AS DateTime2), CAST(N'2020-09-30T00:00:00.0000000' AS DateTime2), 107198.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-098204', N'Northeast Washington Forestry Coalition', N'Cross-Boundary Competitive Grant Program - NEWFC', CAST(N'2018-12-10T00:00:00.0000000' AS DateTime2), CAST(N'2020-09-30T00:00:00.0000000' AS DateTime2), 54000.0000, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tmpAgreement2] ([AgreementType], [AgreementNumber], [Organization], [AgreementTitle], [StartDate], [EndDate], [AgreementAmount], [ExpendedMoney], [BalanceMoney], [FirstBillDueOn], [Notes]) VALUES (N'CS', N'93-098377', N'WRCDC', N'Cross-Boundary Competitive Grant Program - Tapash', CAST(N'2019-01-25T00:00:00.0000000' AS DateTime2), CAST(N'2020-09-30T00:00:00.0000000' AS DateTime2), 65090.0000, NULL, NULL, NULL, NULL)
GO
