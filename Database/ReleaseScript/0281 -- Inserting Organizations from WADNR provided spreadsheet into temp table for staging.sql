USE [WADNRForestHealthDB]
GO
/****** Object:  Table [dbo].[tmpWADNROrganizations]    Script Date: 1/28/2019 4:28:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WADNROrganizations](
	[Name] [nvarchar](255) NULL,
	[ShortName] [nvarchar](255) NULL,
	[OrganizationType] [nvarchar](255) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Alliance Ecological Services - Sam Israel', N'Alliance Ecological Services', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Bureau Indian Affairs Nwro', N'BIA', N'Federal')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Bureau Of Land Management', N'BLM', N'Federal')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Cascadia Conservation District', N'Cascadia CD', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Chelan County Dept Of Natural Resources', N'Chelan Co DNR', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Bremerton Parks & Rec', N'City Of Bremerton Parks & Rec', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Camas', N'City Of Camas', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Colville', N'City Of Colville', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Entiat', N'City Of Entiat', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Gig Harbor', N'City Of Gig Harbor', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Lakewood', N'City Of Lakewood', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Olympia', N'City Of Olympia', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Pasco', N'City Of Pasco', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Pullman', N'City Of Pullman', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Ritzville', N'City Of Ritzville', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Sammamish', N'City Of Sammamish', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Seattle', N'City Of Seattle', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Spokane  ', N'City Of Spokane  ', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Spokane Urban Forestry', N'City Of Spokane Urban Forestry', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Sumner', N'City Of Sumner', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'City Of Vancouver', N'City Of Vancouver', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Clemson University', N'Clemson University', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Columbia City Fire District #3', N'CCFD #3', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Department Of Ecology', N'WADOE', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Department Of Transportation', N'WSDOT', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Eco Dig Llc', N'Eco Dig Llc', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Everett Parks And Recreation', N'Everett Parks And Recreation', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Geoterra', N'Geoterra', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Grant County Fire Dictrict #5', N'GCFD #5', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Greater Spokane Dept Emergency Mgmt', N'Greater Spokane Dept Emergency Mgmt', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Kalispel Tribe Of Indians', N'Kalispel Tribe Of Indians', N'Tribe')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'King Conservation District', N'King CD', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Kittitas Conservation District', N'Kittitas CD', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'USFS OKANOGAN-WENATCHEE NAT''L FOREST', N'USFS OWNF', N'Federal')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Mt. Adams Resource Stewards', N'MARS', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'NOAA - NWS', N'NOAA', N'Federal')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Northeast Washington Forestry Coalition', N'NEWFC', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Northwest Management', N'Northwest Management', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Okanogan Conservation District', N'OCD', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Oregon State University', N'OSU', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Pinchot Parnters', N'Pinchot Parnters', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Resource Data Inc.', N'RDI', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Rudeen Associates', N'Rudeen Associates', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Sean Jeronimo', N'Sean Jeronimo', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Sitka Technology Group', N'Sitka', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Spokane Conservation District', N'Spokane Conservation District', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Tacoma Housing Authority', N'Tacoma Housing Authority', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'The Evergreen State College', N'TESC', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'The Nature Conservancy, Washington Field Office', N'TNC', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Timber Ventures', N'Timber Ventures', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Timberline Silvics Inc', N'Timberline Silvics Inc', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Town Of Coulee Dam', N'Town Of Coulee Dam', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Underwood Conservation District', N'Underwood CD', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'University Of Washington', N'UW', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Unlimited Land Services', N'Unlimited Land Services', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Upper Columbia Salmon Recovery Board', N'UCSRB', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'USFS', N'USFS', N'Federal')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'USFS - Colville National Forest', N'USFS CNF', N'Federal')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'USFS Good Neighbor Authority', N'USFS GNA', N'Federal')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'USFS PNW REGION STATE & PRIVATE FOREST', N'USFS PNW RO', N'Federal')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'UW Olympic Natural Resources Center', N'UW Olympic Natural Resources Center', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'WA Conservation Science Institute', N'WA Conservation Science Institute', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'WA Military Dept & WA State Patrol', N'WA Military Dept & WA State Patrol', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Washington Resource Conservation and Development Council', N'WRCDC', N'Local')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Washington State Parks Rec Comm', N'Washington State Parks Rec Comm', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Washington State Patrol', N'WSP', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Washington State University', N'WSU', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Washington Wild', N'WA Wild', N'Private')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Washington State Department of Fish and Wildlife', N'WDFW', N'State')
GO
INSERT [dbo].[WADNROrganizations] ([Name], [ShortName], [OrganizationType]) VALUES (N'Wildfire Home Protection', N'Wildfire Home Protection', N'Private')
GO
