USE [WADNRForestHealthDB]
GO
/****** Object:  Table [dbo].[tmpFuzzyMatchingRegionsToGrants]    Script Date: 1/23/2019 3:13:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tmpFuzzyMatchingRegionsToGrants](
	[REGION] [nvarchar](50) NOT NULL,
	[SUMMARY] [nvarchar](50) NOT NULL,
	[GRANTS] [nvarchar](50) NOT NULL,
	[Levenshtein_Distance_Ratio] [float] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Genetic Resources', N'Genetic Resources', 1)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Winthrop', N'Winthrop', 1)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Volunteer Fire Assistance ', N'Volunteer Fire Assistance', 0.980392157)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'State Fire Assistance ', N'State Fire Assistance', 0.976744186)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Forest Stewardship ', N'Forest Stewardship', 0.972972973)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Volunteer Fire Assistance ', N'Volunteer Fire Assistance - VFA', 0.912280702)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'State Fire Assistance ', N'State Fire Assistance - SFA', 0.897959184)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'State Fire Assistance ', N'State Fire Assistance-NFP', 0.893617021)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Urban and Community Forest', N'Urban & Community Forestry', 0.884615385)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'PC', N'Collins/Goat Point ', N'Collins/Goat Pt', 0.882352941)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'State Fire Assistance ', N'State Fire Assitance-NFP', 0.869565217)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'PC', N'LSR - Chehalis River Basin - Gibbs', N'LSR - Chehalis River Basin', 0.866666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Urban & Community Forestry - Lampman', N'Urban & Community Forestry - UCF', 0.852941176)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Forest Health Monitoring - Ripley', N'Forest Health Monitoring', 0.842105263)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Urban & Community Forestry - Lampman', N'Urban & Community Forestry', 0.838709677)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Volunteer Fire Assistance - Johnston', N'Volunteer Fire Assistance - VFA', 0.835820896)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'WSFM - Upper Kettle - Boles', N'WSFM - Upper Kettle', 0.826086957)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Volunteer Fire Assistance ', N'Volunteer Fire Assistance-Recurrent', 0.819672131)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Volunteer Fire Assistance - Johnston', N'Volunteer Fire Assistance', 0.819672131)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Forest Stewardship - Gibbs', N'Forest Stewardship', 0.818181818)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'WSFM - Clear Lake - Boles', N'WSFM - Clear Lake', 0.80952381)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'State Fire Assistance ', N'State Fire Assistance - Recurrent', 0.8)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'WSFM - West Klickitat', N'West Klickitat', 0.8)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'WSFM - East Box Canyon - Chambers', N'WSFM - East Box Canyon', 0.8)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'State Fire Assistance - Kaikkonen', N'State Fire Assistance - SFA', 0.8)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Urban and Community Forest', N'Urban & Community Forestry - UCF', 0.793103448)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'State Fire Assistance ', N'State Fire Assistance-Recurrent', 0.79245283)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Volunteer Fire Assistance - Johnston', N'Volunteer Fire Assistance-Recurrent', 0.788732394)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'State Fire Assistance - Kaikkonen', N'State Fire Assistance - Recurrent', 0.787878788)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - Urban & Community Forestry - Lampman', N'Urban & Community Forestry - UCF', 0.783783784)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'NFP WUI Upper Kittitas', N'Upper Kittitas', 0.777777778)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'State Fire Assistance - Kaikkonen', N'State Fire Assistance', 0.777777778)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'WSFM - North Yakima - Chambers', N'WSFM - North Yakima', 0.775510204)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N' Stewardship ', N'Forest Stewardship', 0.774193548)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'State Fire Assistance ', N'State Fire Assitance-Recurrent', 0.769230769)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - Volunteer Fire Assistance - Johnston', N'Volunteer Fire Assistance - VFA', 0.767123288)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Volunteer Fire Assistance ', N'State Fire Assistance', 0.765957447)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'State Fire Assistance ', N'Volunteer Fire Assistance', 0.765957447)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'WSFM - Leavenworth - Chambers', N'WSFM - Leavenworth', 0.765957447)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - Urban & Community Forestry - Lampman', N'Urban & Community Forestry', 0.764705882)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Urban & Community Forestry - Lampman', N'Urban & Community Forestry-Inmate Education', 0.759493671)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'State Fire Assistance - Kaikkonen', N'State Fire Assistance-NFP', 0.75862069)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Urban and Community Forest', N'Regional Urban & Community Forestry', 0.754098361)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'NFP WUI Metaline Pend Oreille', N'Metaline (Pend Oreille Cty)', 0.75)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'State Fire Assistance - Kaikkonen', N'State Fire Assistance-Recurrent', 0.75)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - Volunteer Fire Assistance - Johnston', N'Volunteer Fire Assistance', 0.746268657)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'WSFM SE - Upper Kittitas', N'WSFM - Upper Kettle', 0.744186047)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Genetics Resource - DeBell', N'Genetic Resources', 0.744186047)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Volunteer Fire Assistance ', N'Volunteer Fire Assistance-National Fire Plan', 0.742857143)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'WSFM SE - Upper Kittitas', N'Upper Kittitas', 0.736842105)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'State Fire Assistance - Kaikkonen', N'State Fire Assitance-NFP', 0.736842105)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Forest Stewardship - Gibbs', N'Forest Stewardship - Resource Mgmt', 0.733333333)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Urban & Community Forestry - Lampman', N'Regional Urban & Community Forestry', 0.732394366)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'State Fire Assistance - Kaikkonen', N'State Fire Assitance-Recurrent', 0.73015873)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - Volunteer Fire Assistance - Johnston', N'Volunteer Fire Assistance-Recurrent', 0.727272727)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - State Fire Assistance - Kaikkonen', N'State Fire Assistance - SFA', 0.727272727)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Volunteer Fire Assistance - Johnston', N'Volunteer Fire Assistance-National Fire Plan', 0.725)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'NFP WUI East Klickitat', N'West Klickitat', 0.722222222)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - State Fire Assistance - Kaikkonen', N'State Fire Assistance - Recurrent', 0.722222222)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - Forest Stewardship - Gibbs', N'Forest Stewardship', 0.72)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'WSFM - Chiwawa - Chambers', N'WSFM - Chiwawa', 0.717948718)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'West Klickitat - Chambers', N'West Klickitat', 0.717948718)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Forest Stewardship ', N'Forest Stewardship - Resource Mgmt', 0.716981132)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Volunteer Fire Assistance ', N'State Fire Assistance - SFA', 0.716981132)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'State Fire Assistance ', N'Volunteer Fire Assistance - VFA', 0.716981132)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'NFP WUI Horseshoe Stevens', N'Horseshoe (Stevens Cty)', 0.708333333)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'NFP WUI Sawtooth Okanogan', N'Sawtooth (Okanogan Cty)', 0.708333333)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'Upper East Klickitat - Chambers', N'Upper E Klickitat', 0.708333333)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Volunteer Fire Assistance ', N'State Fire Assistance-NFP', 0.705882353)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - Urban & Community Forestry - Lampman', N'Urban & Community Forestry-Inmate Education', 0.705882353)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Forest Health', N'Forest Health Monitoring', 0.702702703)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - Urban & Community Forestry - Lampman', N'Regional Urban & Community Forestry', 0.701298701)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - State Fire Assistance - Kaikkonen', N'State Fire Assistance', 0.7)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'2015 WSFM - Diamond Lake - Boles', N'WSFM-Diamond Lake', 0.693877551)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'WSFM SE - Upper Kittitas', N'WSFM Hazard Mitigation-Upper Kittitas', 0.68852459)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Forest Health Protect (Monitor/Co-op)', N'Forest Health Monitoring', 0.68852459)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - State Fire Assistance - Kaikkonen', N'State Fire Assistance-NFP', 0.6875)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - State Fire Assistance - Kaikkonen', N'State Fire Assistance-Recurrent', 0.685714286)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Forest Health', N'Forest Health Cooperative', 0.684210526)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'WSFM SE - Hells Canyon', N'WSFM - East Box Canyon', 0.681818182)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Volunteer Fire Assistance ', N'State Fire Assitance-NFP', 0.68)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'NFP WUI SE - Chumstick', N'NFP WUI Community Assist-Chumstick', 0.678571429)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - Volunteer Fire Assistance - Johnston', N'Volunteer Fire Assistance-National Fire Plan', 0.674418605)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'Urban and Community Forest', N'Urban & Community Forestry-Inmate Education', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'NFP WUI East Klickitat', N'Upper E Klickitat', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - Forest Stewardship - Gibbs', N'Forest Stewardship - Resource Mgmt', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'WSFM - Deer Creek', N'WSFM - Upper Kettle', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - State Fire Assistance - Kaikkonen', N'State Fire Assitance-NFP', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'CPG - State Fire Assistance - Kaikkonen', N'State Fire Assitance-Recurrent', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'WSFM - Clear Lake - Boles', N'WSFM-Bear Lake', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Volunteer Fire Assistance - Johnston', N'State Fire Assistance - SFA', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Volunteer Fire Assistance - Johnston', N'State Fire Assistance - Recurrent', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'Upper Kittatas - Chambers', N'Upper Kittitas', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'Upper KittItas - Chambers', N'Upper Kittitas', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'SE', N'East Chelan - Chambers', N'East Chelan', 0.666666667)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'State Fire Assistance - Kaikkonen', N'Volunteer Fire Assistance - VFA', 0.65625)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'DIV', N'Forest Health Monitoring - Ripley', N'Forest Health Cooperative', 0.655172414)
GO
INSERT [dbo].[tmpFuzzyMatchingRegionsToGrants] ([REGION], [SUMMARY], [GRANTS], [Levenshtein_Distance_Ratio]) VALUES (N'NE', N'CPG - Genetics Resource - DeBell', N'Genetic Resources', 0.653061224)
GO
