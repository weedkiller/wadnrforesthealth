delete from dbo.FieldDefinition
go

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName], [DefaultDefinition]) 
VALUES 
(1, N'ProjectType', N'Project Type', N'<p>The highest level record in the hierarchical project taxonomy system.</p>'),
(4, N'ExpectedValue', N'Expected Value', N'<p>The estimated cumulative Performance Measure value that the project or program is projected to achieve after implementation.</p>'),
(5, N'TaxonomyTrunk', N'Taxonomy Trunk', N'<p>The lowest level record in the hierarchical project taxonomy system.</p>'),
(12, N'PrimaryContactOrganization', N'Primary Contact Organization', N'<p>The entity with primary responsibility for organizing, planning, and executing implementation activities for a project or program. This is usually the lead implementer.</p>'),
(13, N'ProjectsStewardOrganizationRelationshipToProject', N'Projects Steward Organization Relationship To Project', N'<p>The relationship between a stewarding organization and a project.</p>'),
(14, N'Organization', N'Organization', N'<p>A partner entity that is directly involved with implementation or funding a project.&nbsp;</p>'),
(17, N'Password', N'Password', N'<p>Password required to log into the ProjectFirma tool in order to access and edit project and program information.</p>'),
(18, N'PerformanceMeasure', N'Performance Measure', N'<p>A consistent and targeted method to track actions taken through completed projects to improve the environment. Also known as &quot;Indicators.&quot;&nbsp;</p>'),
(19, N'PerformanceMeasureType', N'Performance Measure Type', N'<p>The type of a Performance Measure - either an Action or Outcome.</p>'),
(21, N'MeasurementUnit', N'Measurement Unit', N'<p>The unit of measure used by an Indicator (aka&nbsp;Performance Measure) to track the extent of implementation.</p>'),
(22, N'PhotoCaption', N'Photo Caption', N'<p>A concise yet descriptive explanation of an uploaded photo. Photo captions are displayed in the lower right-hand corner of the image as it appears on the webpage.</p>'),
(23, N'PhotoCredit', N'Photo Credit', N'<p>If needed, credit is given to the photographer or owner of an image on the website. Photo credits are displayed in the lower right-hand corner of the image as it appears on the webpage.</p>'),
(24, N'PhotoTiming', N'Photo Timing', N'<p>The phase in a project timeline during which the photograph was taken. Photo timing can be before, during or after project implementation.&nbsp;</p>'),
(25, N'OrganizationPrimaryContact', N'Organization Primary Contact', N'<p>An individual at the listed organization responsible for reporting accomplishments and expenditures achieved by the project or program, and who should be contacted when there are questions related to any project associated to the organization.</p>'),
(26, N'TaxonomyBranch', N'Taxonomy Branch', N'<p>The second level record in the hierarchical project taxonomy system.</p>'),
(28, N'CompletionDate', N'Completion Date', N'<p>The year implementation of the project was completed or is anticipated to be completed. Projects are considered &quot;complete&quot; when all activities have been performed, including post-implementation activities such as monitoring vegetation establishment, and all&nbsp;reporting requirements have been satisfied. &nbsp;For more detailed information, see the definition for &quot;Stage&quot;.</p>'),
(29, N'ProjectDescription', N'Project Description', N'<p>A concise/brief description for the project that includes the following: general locations of project, project area size, purpose and need of the project, and expected goals. &nbsp;Please not that project descriptions will be capped at 100 words.</p>'),
(30, N'ProjectName', N'Project Name', N'<p>The name of a project or program given by the organization responsible for reporting. Project names should generally include a reference to 1) the location of the project, 2) the primary implementation activity, and 3) the project phase (if a multi-phase project).</p>'),
(31, N'ProjectNote', N'Project Note', N'<p>Any important information about a project that would be useful to staff or project implementers.</p>'),
(32, N'ExpirationDate', N'Expiration Date', N'<p>The date the project expires. For more detailed information on implementation stages, see the definition for &quot;Stage&quot;.</p>'),
(33, N'ReportedValue', N'Reported Value', N'<p>The accomplishments achieved by a project after the accomplishments are realized. Accomplishments can be realized and reported throughout implementation and not only after the entire project is completed.</p>'),
(34, N'OrganizationType', N'Organization Type', N'<p>A categorization of an organization, e.g. Local, State, Federal or Private.</p>'),
(35, N'ProjectGrantAllocationRequestTotalAmount', N'Total Amount', N'<p>Funding that has been acquired for a project.</p>'),
(36, N'ProjectStage', N'Project Stage', N'<p>Where a project exists in the project life cycle - Planned, Implementation, Complete, Cancelled, etc.</p>'),
(39, N'ClassificationName', N'Classification Name', N'<p>The name of the grouping in this classification system.</p>'),
(40, N'EstimatedTotalCost', N'Estimated Total Cost', N'<p>The total estimated cost to complete all stages of project implementation.</p>'),
(41, N'UnfundedNeed', N'Unfunded Need', N'<p>The difference between the Total Cost and Secured Funding for a project or program.</p>'),
(42, N'Username', N'User name', N'<p>Password required to log into the system&nbsp;order to access and edit project and program information that is not allowed by public users.</p>'),
(44, N'Project', N'Project', N'<p>The core entity that ProjectFirma tracks - A collection of activities, with Performance Measures and Expenditures, that contribute to meeting program goals.</p>'),
(46, N'Classification', N'Classification', N'<p>One of the groupings in a logical system used to group projects according to overarching program themes or goals.</p>'),
(49, N'PerformanceMeasureSubcategory', N'Performance Measure Subcategory', N'<p>The Performance Measure subcategory or subcategories that are relevant to the project. Subcategories are dimensions of a Performance Measure that are used to report performance measure accomplishments at a more granular level.</p>'),
(50, N'PerformanceMeasureSubcategoryOption', N'Performance Measure Subcategory Option', N'<p>The selected attribute of a Performance Measure subcategory.</p>'),
(52, N'IsPrimaryTaxonomyBranch', N'Is Primary Taxonomy Branch', N'<p>If this box is checked, this is the primary area associated with a specific Performance Measure. The performance measure may also apply to other areas but this has been identified as the primary area for this performance measure.</p>'),
(56, N'FundedAmount', N'Funded Amount', N'<p>The amount of funding, by grant allocation, expended on a project for a specific year. To see the total amount of funding expended on a project, click on the specific project.</p>'),
(57, N'ProjectLocation', N'Project Location', N'<p>The location where the project was/is being implemented. Project locations can be set by picking a location description from a list or by plotting a point on the map. Project location information is used for summarizing project&nbsp;accomplishments by geospatial categories such as State, County, or GeospatialArea.</p>'),
(64, N'ExcludeFromFactSheet', N'Exclude from Fact Sheet', N'<p>Flags a photo so that it is not included in the photos shown on the project&#39;s Fact Sheet. Some projects have tons of photos -- use this checkbox to control which photos are included.</p>'),
(74, N'ProjectCostInYearOfExpenditure', N'Cost in Year of Expenditure', N'<p>This is the expected cost of the project in the year that it will be constructed, taking into account inflation.&nbsp;</p>'),
(75, N'GlobalInflationRate', N'Global Inflation Rate', N'<p>Annual rate of inflation expected for project costs.&nbsp;</p>'),
(76, N'ReportingYear', N'Reporting Year', N'<p>The current year used for reporting purposes, which is defined as the previous calendar year until after November 1st of the present calendar year.</p>'),
(77, N'TagName', N'Tag Name', N'<p>A word or phrase for the tag. Keep it short, and if possible avoid spaces (use dashes or underscores) for cleaner URLs. Don&#39;t add tags for things already captured (e.g. the program under which the project lives).</p>'),
(78, N'TagDescription', N'Tag Description', N'<p>A description of what this tag will be used for. Ideally the description should include the name of the user that created it, and an expected timeframe for use of this tag, if known.&nbsp;</p>'),
(80, N'ReportedExpenditure', N'Reported Expenditure', N'<p>An expenditure, tied to a Grant Allocation, as reported by the project implementer.</p>'),
(81, N'Application', N'Application', N'<p>A project suggested by an program partner that will be reviewed for inclusion in the program. The system administrators are responsible for reviewing, and if appropriate, approving proposals.</p>'),
(85, N'SpendingAssociatedWithPM', N'Spending Associated with PM', N'<p>The estimated spending allotted to the Performance Measure.</p>'),
(86, N'StartApprovalDate', N'Start/Approval Date', N'<p>The date on which project began.  Contrast with &quot;Approval/Start Date.&quot; For more detailed information, see the definition for &quot;Stage&quot;.</p>'),
(87, N'AssociatedTaxonomyBranches', N'Associated Taxonomy Branches', N'<p>External&nbsp;programs that are related to the content you are reviewing. You may wish to look up these programs to learn more.</p>'),
(88, N'ExternalLinks', N'External Links', N'<p>Links to external web pages where you might find additional information.</p>'),
(91, N'CurrentYearForPVCalculations', N'Current Year for PV Calculations', N'<p>The year to use as the starting point for inflation calculations.</p>'),
(92, N'LifecycleOperatingCost', N'Lifecycle Operating Cost', N'<p>Sum of the annual operating cost from the Approval/Start Date to Completion Date. Not inflation adjusted.</p>'),
(97, N'PerformanceMeasureChartTitle', N'Performance Measure Chart Title', N'<p>A short title for the Indicator (aka Performance Measure) used for charts throughout ProjectFirma.</p>'),
(182, N'RoleName', N'Role Name', N'<p>The name or title describing&nbsp;function or set of permissions that can be assigned to a user.</p>'),
(184, N'Region', N'Region (Geospatial)', N'<p>The region in which a project is located.</p>'),
(228, N'PerformanceMeasureChartCaption', N'Performance Measure Chart Caption', N'<p>The caption which will appear on Performance Measure charts throughout the system.</p>'),
(236, N'MonitoringProgram', N'Monitoring Program', N'<p>A on-going activity to collect environmental monitoring data.</p>'),
(237, N'MonitoringApproach', N'Monitoring Approach', N'<p>Monitoring Approach &ndash; provides a general description of the sampling design used to carry out the monitoring. Included is a description of the spatial distribution of sampling, sampling frequency, lab procedures, and references to data sources, monitoring plans, and protocols used to guide monitoring.</p>'),
(238, N'MonitoringProgramPartner', N'Monitoring Program Partner', N'<p>Monitoring Partners &ndash; provides a list of agencies and entities that fund, collect and analyze monitoring data.</p>'),
(239, N'MonitoringProgramUrl', N'Monitoring Program Home Page', N'<p>The external homepage of a related monitoring program.</p>'),
(240, N'ClassificationDescription', N'Classification Description', N'<p>The long-form description of the entries in the project classification system.</p>'),
(241, N'ClassificationGoalStatement', N'Classification Goal Statement', N'<p>The goal of this classification system record.</p>'),
(242, N'ClassificationNarrative', N'Classification Narrative', N'<p>Descriptive text describing the criteria for including a project in this classification system.</p>'),
(243, N'TaxonomySystemName', N'Taxonomy System Name', N'<p>The customized name for the hierarchical project taxonomy system.<p>'),
(244, N'ProjectTypeDisplayNameForProject', N'Project Type Tier One Display Name For Project', N'<p>A custom label describing how a Project relates to it''s highest Taxonomy tier..</p>'),
(245, N'ProjectRelationshipType', N'Project Relationship Type', N'<p>A categorization of a relationship between an organization and a project, e.g. Funder, Implementer.</p>'),
(246, N'ProjectSteward', N'Project Steward', N'<p>A person who can approve Project Applications, create new Projects, approve Project Updates, and create Grant Allocations for their Organization.</p>'),
(247, N'Chart Last Updated Date', N'ChartLastUpdatedDate', N'<p>The date this chart was last updated with current information.</p>'),
(248, N'UnsecuredFunding', N'Unsecured Funding', N'<p>Funding that has been identified for a project but has not been acquired such as planned grant applications.</p>'),
(249, N'ProjectStewardOrganizationDisplayName', N'Project Steward Organization Display Name', N'<p>Label for Organization types that can steward projects.</p>'),
(250, N'ClassificationSystem', N'Classification System', N'<p>The type of logical system used to group projects according to overarching program themes or goals.</p>'),
(251, N'ClassificationSystemName', N'Classification System Name', N'<p>The name of the logical grouping used to bin projects.</p>'),
(252, N'ProjectPrimaryContact', N'Project Primary Contact', N'<p>An individual responsible for reporting accomplishments and expenditures achieved by the project, and who should be contacted when there are questions related to the project.</p>'),
(253, N'CustomPageDisplayType', N'Custom Page Display Type', N'<p>The status of a custom About page, controls whether the page is visible to the public, protected and only visible for logged in users, or disabled and not shown on the About menu.</p>'),
(254, N'TaxonomyTrunkDescription', N'Taxonomy Trunk Description', N'<p>The long-form description of the entries in the project taxonomy system.</p>'),
(255, N'TaxonomyBranchDescription', N'Taxonomy Branch Description', N'<p>The long-form description of the entries in the project taxonomy system.</p>'),
(256, N'ProjectTypeDescription', N'Project Type Description', N'<p>The long-form description of the entries in the project taxonomy system.</p>'),
(257, N'ShowApplicationsToThePublic', N'Show Applications To The Public', N'<p>When this option is set, projects in the Pending Approval state will be shown on project maps and on the Application page. When not set, no proposals will be visible to anonymous users. All proposals should be shown on the proposals page for Normal+ users.</p>'),
(258, N'ShowLeadImplementerLogoOnFactSheet', N'Show Lead Implementer Logo on Project Fact Sheet?', N'<p>When this option is set, project fact sheets will include the lead implementer''s logo under the website logo. When not set, only the website logo will be shown on fact sheets.'),
(259, N'ProjectCustomAttribute', N'Custom Attribute', N''),
(260, N'ProjectCustomAttributeDataType', N'Data Type', N''),
(261, N'ProjectUpdateKickOffDate', N'Kick-off Date', N'The date to send the initial notification about Project Updates to Primary Contacts'),
(262, N'ProjectUpdateReminderInterval', N'Reminder Interval (days)', N'The number of days between repeated Project Update Reminders'),
(263, N'ProjectUpdateCloseOutDate', N'Close-out Date', N'The date on which to send the final Project Update Reminder'),
(264, 'PerformanceMeasureIsAggregatable', 'Is Aggregatable', 'Indicates whether the values for this Performance Measure can be aggregated across subcategory options.'),
(265, N'GrantAllocationAmount', N'Amount', N'<p>Grant Allocation Amount</p>'),
(266, N'NormalUser', N'Normal User', N'Users with this role can propose new Projects, update existing Projects where their organization is the Lead Implementer, and view almost every page within the Project Tracker.'),
(267, N'ProjectStewardshipArea', N'Project Stewardship Area', 'Indicates which attribute of a project is used to determine if a Project Steward is permitted to edit that project.'),
(268, N'ProjectInternalNote', N'Internal Note', N'<p>Any important information about a project that should only be visible to Administrators.</p>'),
(269, N'StatewideVendorNumber', 'Statewide Vendor Number', 'A number assigned by the State to vendors.'),
(270, N'Contact', 'Contact', 'A person who is associated with a project who may or may not have an account in the system.'),
(271, N'ContactRelationshipType', 'Contact Relationship Type', N'<p>A categorization of a relationship between an organization and a contact, e.g. Landowner, Contractor.</p>'),
(272, N'Contractor', 'Contractor', 'Placeholder definition for Contractor.'),
(273, N'Landowner', 'Landowner', 'Placeholder definition for Landowner.'),
(274, N'Partner', 'Partner', 'Placeholder definition for Partner.'),
(275, N'PrimaryContact', 'Primary Contact', 'Placeholder definition for Primary Contact.'),
(276, N'FocusArea', 'Focus Area', 'Placeholder definition for Focus Area'),
(277, N'Grant', 'Grant', 'Placeholder definition for Grant'),
(278, N'GrantAllocation', 'Grant Allocation', 'Placeholder definition for Grant Allocation.'),
(279, N'CostType', 'CostType', 'Placeholder definition for CostType.'),
(280, N'ProjectCode', 'Project Code', 'Placeholder definition for Project Code.'),
(281, N'GrantAllocationProjectCode', 'Grant Allocation Project Code', 'Placeholder definition for Grant Allocation Project Code.'),
(282, N'ProgramIndex', 'Program Index', 'Placeholder definition for Program Index.'),
(283, N'GrantName', 'Grant Name', N'<p>The name of a grant. Grant names should generally include a reference to 1) the location of the grant, 2) the primary implementation activity, and 3) the grant year</p>'),
(284, N'GrantShortName', 'Short Name', N'<p>The short hand name to reference a grant</p>'),
(285, N'GrantStatus', 'Status', N'<p>The status of a grant. This can be Active, Pending, Planned, or Closeout</p>'),
(286, N'GrantType', 'Type', N'<p>The type of grant. This can either be Stand Alone, or CPG. </p>'),
(287, N'GrantNumber', 'Grant Number', N'<p>The grant number. </p>'),
(288, N'CFDA', 'CFDA', N'<p>The CFDA code for a grant. </p>'),
(289, N'TotalAwardAmount', 'Total Award Amount', N'<p>The total amount of money awarded by the grant. This may include the sum of all associated grant allocations. </p>'),
(290, N'GrantStartDate', 'Start Date', N'<p>The start date of the grant. </p>'),
(291, N'GrantEndDate', 'End Date', N'<p>The end date of the grant. </p>'),
(292, N'GrantNote', 'Grant Note', N'<p>Any additional important information about the grant. </p>'),
(293, N'PriorityArea', 'Priority Area', 'Placeholder definition for Priority Area'),
(294, N'Invoice', 'Invoice', N'<p>Placeholder for Invoice</p>'),
(295, N'Agreement', 'Agreement', N'<p>Placeholder for Agreement.</p>'),
(296, N'FederalFundCode', 'Federal Fund Code', 'Placeholder definition for Federal Fund Code description.'),
(297, N'AllocationAmount', 'Allocation Amount', 'Placeholder for GrantAllocation Allocation Amount.'),
(298, N'AgreementType', 'Agreement Type', '<p>The type of Agreement.</p>'),
(299, N'AgreementNumber', 'Agreement Number', '<p>The number for referencing the Agreement</p>'),
(300, N'AgreementTitle', 'Agreement Title', '<p>The Agreement Title should generally include a 1) reference to the location, 2) the primary implementation activity, and 3) the year.</p>'),
(301, N'AgreementStartDate', 'Agreement Start Date', '<p>The start date of the Agreement.</p>'),
(302, N'AgreementEndDate', 'Agreement End Date', '<p>The end date of the Agreement.</p>'),
(303, N'AgreementAmount', 'Agreement Amount', '<p>The amount of the Agreement.</p>'),
(304, N'ProgramManager', 'Program Manager', 'Placeholder for Program Manager.'),
(305, N'AgreementNotes', 'Agreement Notes', 'Placeholder for Agreement Notes.'),
(306, N'AgreementStatus', 'Agreement Status', 'Placeholder for Agreement Status.'),
(307, N'GrantAllocationNote', 'Grant Allocation Note', N'<p>Any additional important information about the grant allocation.</p>'),
(308, N'FileResource', 'File Resource', 'Placeholder for File Resource.'),
(309, N'ProjectTotalCompletedFootprintAcres', 'Project Completed Footprint Acres', 'Sum of Footprint Acres on all completed Treatment Activities under a Project.'),
(310, N'FocusAreaTotalProjectReportedExpendiures', 'Sum of Project Reported Expendiures', 'Sum of reported expenditures on all Projects within a Focus Area that are in an Implementation, Post-Implementation, or Completed Project Stage.'),
(311, N'FocusAreaTotalProjectEstimatedTotalCosts', 'Sum of Project Estimated Total Costs', 'Sum of estimated total costs on all Projects within a Focus Area that are in an Implementation, Post-Implementation, or Completed Project Stage.'),
(312, N'FocusAreaTotalCompletedFootprintAcres', 'Total Footprint Acres - Completed', 'Sum of Footprint Acres on all completed Treatment Activities under all Projects within a Focus Area that are in an Implementation, Post-Implementation, or Completed Project Stage.'),
(313, N'FocusAreaTotalPlannedFootprintAcres', 'Total Footprint Acres - Planned', 'The value entered in the Planned Footprint Acres field of a Focus Area'),
(314, N'FocusAreaCloseoutReportProjectList', 'Project List', 'All projects within a Focus Area that are in an Implementation, Post-Implementation, or Completed Project Stage.'),
(315, N'RequestorName', 'Requestor Name', 'The name of the person/vendor preparing the invoice requesting payment.' ),
(316, N'InvoiceDate', 'Invoice Date', 'The date the invoice was submitted.'),
(317, N'PurchaseAuthority', 'Purchase Authority', 'Typically describes an Agreement Number or that the invoice is part of landowner cost-share agreement.'),
(318, N'TotalRequestedInvoicePaymentAmount', 'Total Invoice Amount', 'The total amount of funding requested by a given invoice'),
(319, N'PreparedByPerson', 'Prepared By', 'The person preparing the invoice for submission to IPR'),
(320, N'InvoiceIdentifyingName', 'Invoice Nickname', 'This name is a nickname to make identification of particular invoices easier.'),
(321, N'GrantNoteInternal', 'Internal Grant Note', N'<p>Any additional important information about the grant. These notes are only visible to internal users </p>'),
(322, N'GrantAllocationNoteInternal', 'Internal Grant Allocation Note', N'<p>Any additional important information about the grant allocation. These notes are only visible to internal users </p>'),
(323, N'InvoiceStatus', 'Invoice Status', N'<p>Any important information about the overall status of an invoice </p>'),
(324, N'InvoiceApprovalStatus', 'Invoice Approval Status', N'<p>Important information about the approval status of an invoice</p>'),
(325, N'InvoiceApprovalComment', 'Invoice Approval Comment', N'<p>Important rationale about the approval status of an invoice</p>'),
(326, N'MatchAmount', 'Match Amount', N'<p>The amount of this invoice matched by another agency</p>'),
(327, N'Vendor', 'Vendor', N'Vendor Placeholder'),
(328, N'EstimatedIndirectCost', N'Estimated Indirect Cost', N'<p>The estimated indirect cost to complete all stages of project implementation.</p>'),
(329, N'EstimatedPersonnelAndBenefitsCost', N'Estimated Personnel & Benefits Cost', N'<p>The estimated personnel and benefits costs to complete all stages of project implementation.</p>'),
(330, N'EstimatedSuppliesCost', N'Estimated Supplies Cost', N'<p>The estimated supplies cost to complete all stages of project implementation.</p>'),
(331, N'EstimatedTravelCost', N'Estimated Travel Cost', N'<p>The estimated travel costs to complete all stages of project implementation.</p>'),
(332, N'InvoiceID', N'Invoice ID', N'<p>The System-unique identifier for a given Invoice.</p>'),
(333, N'InvoiceLineItem', N'Invoice Line Item', N'<p>A line item on an invoice which includes an amount and the associated grant allocation/grant.</p>'),
(334, N'InteractionEvent', N'Interaction/Event', N'<p>Placeholder definition for Interaction/Event description.</p>'),
(335, N'InteractionEventType', N'Interaction/Event Type', N'<p>Placeholder definition for Interaction/Event Type description.</p>'),
(336, N'DNRStaffPerson', N'DNR Staff Person', N'<p>Placeholder definition for DNR Staff Person assigned to an Interaction/Event.</p>'),
(337, N'InteractionEventContact', N'Interaction/Event Contact', N'<p>Placeholder definition for Interaction/Event Contact description.</p>'),
(338, N'InteractionEventProject', N'Interaction/Event Project', N'<p>Placeholder definition for Interaction/Event Project description.</p>'),
(339, N'InteractionEventLocation', N'Interaction/Event Location', N'<p>Placeholder definition for Interaction/Event Location description.</p>'),
(340, N'GrantAllocationName', 'Grant Allocation Name', N'<p>Placeholder definition for Grant Allocation Name description.</p>'),
(341, N'Division', 'Division', N'<p>Placeholder definition for Division description.</p>'),
(342, N'GrantManager', 'Grant Manager', N'<p>Placeholder definition for Grant Manager description.</p>')
