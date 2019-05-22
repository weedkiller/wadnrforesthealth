CREATE TABLE [dbo].[tmpCostTypeMapping]
(
	[OBJECT_CODE] [nvarchar](255) NULL,
	[OBJECT_NAME] [nvarchar](255) NULL,
	[SUB_OBJECT_CODE] [nvarchar](255) NULL,
	[SUB_OBJECT_NAME] [nvarchar](255) NULL,
	[CostTypeDescription] [nvarchar](255) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'A', N'SALARIES AND WAGES', N'AA', N'STATE CLASSIFIED', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'A', N'SALARIES AND WAGES', N'AC', N'STATE EXEMPT', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'A', N'SALARIES AND WAGES', N'AJ', N'STATE OTHER', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'A', N'SALARIES AND WAGES', N'AS', N'SICK LEAVE BUY-OUT', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'A', N'SALARIES AND WAGES', N'AT', N'TERMINAL LEAVE', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'A', N'SALARIES AND WAGES', N'AU', N'OVERTIME AND CALL-BACK', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'B', N'EMPLOYEE BENEFITS', N'BA', N'OLD AGE AND SURVIVORS INSURANCE', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'B', N'EMPLOYEE BENEFITS', N'BB', N'RETIREMENT AND PENSIONS', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'B', N'EMPLOYEE BENEFITS', N'BC', N'MEDICAL AID & INDUSTRIAL INSURANCE', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'B', N'EMPLOYEE BENEFITS', N'BD', N'HEALTH, LIFE & DISABILITY INSURANCE', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'B', N'EMPLOYEE BENEFITS', N'BF', N'UNEMPLOYMENT COMPENSATION', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'B', N'EMPLOYEE BENEFITS', N'BH', N'HOSPITAL INSURANCE (MEDICARE)', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'B', N'EMPLOYEE BENEFITS', N'BK', N'PAID FAMILY AND MEDICAL LEAVE', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'C', N'PROFESSIONAL SERVICE CONTRACTS', N'CH', N'COMMUNICATIONS SERVICES', N'Contractual')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EA', N'SUPPLIES AND MATERIALS', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EB', N'COMMUNICATIONS/TELECOMMUNICATIONS', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EC', N'UTILITIES', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'ED', N'RENTALS AND LEASES - LAND & BUILDINGS', NULL)
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EE', N'REPAIRS, ALTERATIONS & MAINTENANCE', NULL)
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EF', N'PRINTING AND REPRODUCTION', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EG', N'EMPLOYEE PROF DEV & TRAINING', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EH', N'RENTAL & LEASES - FURN & EQUIPMENT', NULL)
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EJ', N'SUBSCRIPTIONS', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EK', N'FACILITIES AND SERVICES', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EL', N'DATA PROCESSING SERVICES (INTERAGENCY)', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EP', N'INSURANCE', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'ER', N'OTHER CONTRACTUAL SERVICES', N'Contractual')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'ES', N'VEHICLE MAINTENANCE & OPERATING CST', N'Travel')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EY', N'SOFTWARE LICENSES AND MAINTENANCE', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND OTHER SERVICES', N'EZ', N'OTHER GOODS AND SERVICES', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EA', N'SUPPLIES AND MATERIALS', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EB', N'COMMUNICATIONS/TELECOMMUNICATIONS', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EC', N'UTILITIES', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'ED', N'RENTALS AND LEASES - LAND & BUILDINGS', NULL)
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EE', N'REPAIRS, ALTERATIONS & MAINTENANCE', NULL)
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EF', N'PRINTING AND REPRODUCTION', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EG', N'EMPLOYEE PROF DEV & TRAINING', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EH', N'RENTAL & LEASES - FURN & EQUIPMENT', NULL)
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EK', N'FACILITIES AND SERVICES', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EL', N'DATA PROCESSING SERVICES (INTERAGENCY)', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EP', N'INSURANCE', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'ER', N'OTHER CONTRACTUAL SERVICES', N'Contractual')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'ES', N'VEHICLE MAINTENANCE & OPERATING CST', N'Travel')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EY', N'SOFTWARE LICENSES AND MAINTENANCE', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'E', N'GOODS AND SERVICES', N'EZ', N'OTHER GOODS AND SERVICES', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'G', N'TRAVEL', N'GA', N'IN-STATE SUBSISTENCE & LODGING', N'Travel')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'G', N'TRAVEL', N'GB', N'IN-STATE AIR TRANSPORTATION', N'Travel')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'G', N'TRAVEL', N'GC', N'PRIVATE AUTOMOBILE MILEAGE', N'Travel')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'G', N'TRAVEL', N'GD', N'OTHER TRAVEL EXPENSES', N'Travel')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'G', N'TRAVEL', N'GF', N'OUT-OF-STATE SUBSISTENCE & LODGING', N'Travel')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'G', N'TRAVEL', N'GG', N'OUT-OF-STATE AIR TRANSPORTATION', N'Travel')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'G', N'TRAVEL', N'GN', N'MOTOR POOL SERVICES', N'Travel')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'J', N'CAPITAL OUTLAYS', N'JA', N'NONCAPITALIZED ASSETS', NULL)
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'J', N'CAPITAL OUTLAYS', N'JB', N'NONCAPITALIZED SOFTWARE', NULL)
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'J', N'CAPITAL OUTLAYS', N'JC', N'FURNISHINGS & EQUIPMENT', NULL)
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'J', N'CAPITAL OUTLAYS', N'JK', N'ARCHITECTURAL & ENGINEERING SERVICE', NULL)
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'N', N'GRANTS, BENEFITS & CLIENT SERVICES', N'NZ', N'OTHER GRANTS AND BENEFITS', N'Contractual')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'S', N'INTERAGENCY REIMBURSEMENTS', N'SA', N'SALARIES AND WAGES', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'S', N'INTERAGENCY REIMBURSEMENTS', N'SE', N'GOODS AND OTHER SERVICES', N'Supplies')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'S', N'INTERAGENCY REIMBURSEMENTS', N'SG', N'TRAVEL', N'Travel')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'T', N'INTRA-AGENCY REIMBURSEMENTS', N'TA', N'SALARIES AND WAGES', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'T', N'INTRA-AGENCY REIMBURSEMENTS', N'TB', N'EMPLOYEE BENEFITS', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'T', N'INTRA-AGENCY REIMBURSEMENTS', N'TE', N'GOODS AND OTHER SERVICES', N'Personnel and Benefits')
GO
INSERT [dbo].[tmpCostTypeMapping] ([OBJECT_CODE], [OBJECT_NAME], [SUB_OBJECT_CODE], [SUB_OBJECT_NAME], [CostTypeDescription]) VALUES (N'T', N'INTRA-AGENCY REIMBURSEMENTS', N'TE', N'GOODS AND SERVICES', N'Supplies')
GO
