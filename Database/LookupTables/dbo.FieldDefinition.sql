delete from dbo.FieldDefinition
go

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName], [DefaultDefinition], CanCustomizeLabel) 
VALUES 
(1, N'TaxonomyTierOne', N'Taxonomy Tier One', N'<p>The highest level record in the hierarchical project taxonomy system.</p>', 1),
(4, N'ExpectedValue', N'Expected Value', N'<p>The estimated cumulative Performance Measure value that the project or program is projected to achieve after implementation.</p>', 1),
(5, N'TaxonomyTierThree', N'Taxonomy Tier Three', N'<p>The lowest level record in the hierarchical project taxonomy system.</p>', 1),
(8, N'FundingSource', N'Funding Source', N'<p>The institution, fund, legislation or bond from which funds for the project were provided.</p>', 1),
(12, N'IsPrimaryContactOrganization', N'Is Primary Contact Organization', N'<p>The entity with primary responsibility for organizing, planning, and executing implementation activities for a project or program. This is usually the lead implementer.</p>', 1),
(13, N'ProjectsStewardOrganizationRelationshipToProject', N'Projects Steward Organization Relationship To Project', N'<p>The relationship between a stewarding organization and a project.</p>', 1),
(14, N'Organization', N'Organization', N'<p>A partner entity that is directly involved with implementation or funding a project.&nbsp;</p>', 1),
(17, N'Password', N'Password', N'<p>Password required to log into the ProjectFirma tool in order to access and edit project and program information.</p>', 0),
(18, N'PerformanceMeasure', N'Performance Measure', N'<p>A consistent and targeted method to track actions taken through completed projects to improve the environment. Also known as &quot;Indicators.&quot;&nbsp;</p>', 1),
(19, N'PerformanceMeasureType', N'Performance Measure Type', N'<p>The type of a Performance Measure - either an Action or Outcome.</p>', 1),
(21, N'MeasurementUnit', N'Measurement Unit', N'<p>The unit of measure used by an Indicator (aka&nbsp;Performance Measure) to track the extent of implementation.</p>', 1),
(22, N'PhotoCaption', N'Photo Caption', N'<p>A concise yet descriptive explanation of an uploaded photo. Photo captions are displayed in the lower right-hand corner of the image as it appears on the webpage.</p>', 1),
(23, N'PhotoCredit', N'Photo Credit', N'<p>If needed, credit is given to the photographer or owner of an image on the website. Photo credits are displayed in the lower right-hand corner of the image as it appears on the webpage.</p>', 1),
(24, N'PhotoTiming', N'Photo Timing', N'<p>The phase in a project timeline during which the photograph was taken. Photo timing can be before, during or after project implementation.&nbsp;</p>', 1),
(25, N'PrimaryContact', N'Primary Contact', N'<p>An individual at the listed organization responsible for reporting accomplishments and expenditures achieved by the project or program, and who should be contacted when there are questions related to any project associated to the organization.</p>', 1),
(26, N'TaxonomyTierTwo', N'Taxonomy Tier Two', N'<p>The second level record in the hierarchical project taxonomy system.</p>', 1),
(28, N'CompletionYear', N'Completion Year', N'<p>The year implementation of the project was completed or is anticipated to be completed. Projects are considered &quot;complete&quot; when all activities have been performed, including post-implementation activities such as monitoring vegetation establishment, and all&nbsp;reporting requirements have been satisfied. &nbsp;For more detailed information, see the definition for &quot;Stage&quot;.</p>', 1),
(29, N'ProjectDescription', N'Project Description', N'<p>A concise/brief description for the project that includes the following: general locations of project, project area size, purpose and need of the project, and expected goals. &nbsp;Please not that project descriptions will be capped at 100 words.</p>', 1),
(30, N'ProjectName', N'Project Name', N'<p>The name of a project or program given by the organization responsible for reporting. Project names should generally include a reference to 1) the location of the project, 2) the primary implementation activity, and 3) the project phase (if a multi-phase project).</p>', 1),
(31, N'ProjectNote', N'Project Note', N'<p>Any important information about a project that would be useful to staff or project implementers.</p>', 1),
(32, N'ImplementationStartYear', N'Implementation Start Year', N'<p>The year during which project construction or program implementation was started or is expected to be started. Contrast with &quot;Planning / Design Start Year.&quot; For more detailed information on implementation stages, see the definition for &quot;Stage&quot;.</p>', 1),
(33, N'ReportedValue', N'Reported Value', N'<p>The accomplishments achieved by a project after the accomplishments are realized. Accomplishments can be realized and reported throughout implementation and not only after the entire project is completed.</p>', 1),
(34, N'OrganizationType', N'Organization Type', N'<p>A categorization of an organization, e.g. Local, State, Federal or Private.</p>', 1),
(35, N'SecuredFunding', N'Secured Funding', N'<p>Funding that has been acquired for a project but may not have necessarily been expended.</p>', 1),
(36, N'ProjectStage', N'Project Stage', N'<p>Where a project exists in the project life cycle - Planning/Design, Implementation, Complete, Terminated, etc.</p>', 1),
(39, N'ClassificationName', N'Classification Name', N'<p>The name of the grouping in this classification system.</p>', 1),
(40, N'EstimatedTotalCost', N'Estimated Total Cost', N'<p>The total estimated cost to complete all stages of project implementation.</p>', 1),
(41, N'UnfundedNeed', N'Unfunded Need', N'<p>The difference between the Total Cost and Secured Funding for a project or program.</p>', 1),
(42, N'Username', N'User name', N'<p>Password required to log into the system&nbsp;order to access and edit project and program information that is not allowed by public users.</p>', 1),
(44, N'Project', N'Project', N'<p>The core entity that ProjectFirma tracks - A collection of activities, with Performance Measures and Expenditures, that contribute to meeting program goals.</p>', 0),
(46, N'Classification', N'Classification', N'<p>One of the groupings in a logical system used to group projects according to overarching program themes or goals.</p>', 1),
(48, N'Watershed', N'Watershed', N'<p>The watershed where the project or program is located.</p>', 1),
(49, N'PerformanceMeasureSubcategory', N'Performance Measure Subcategory', N'<p>The Performance Measure subcategory or subcategories that are relevant to the project. Subcategories are dimensions of a Performance Measure that are used to report performance measure accomplishments at a more granular level.</p>', 1),
(50, N'PerformanceMeasureSubcategoryOption', N'Performance Measure Subcategory Option', N'<p>The selected attribute of a Performance Measure subcategory.</p>', 1),
(52, N'IsPrimaryTaxonomyTierTwo', N'Is Primary Taxonomy Tier Two', N'<p>If this box is checked, this is the primary area associated with a specific Performance Measure. The performance measure may also apply to other areas but this has been identified as the primary area for this performance measure.</p>', 1),
(56, N'FundedAmount', N'Funded Amount', N'<p>The amount of funding, by funding source, expended on a project for a specific year. To see the total amount of funding expended on a project, click on the specific project.</p>', 1),
(57, N'ProjectLocation', N'Project Location', N'<p>The location where the project was/is being implemented. Project locations can be set by picking a location description from a list or by plotting a point on the map. Project location information is used for summarizing project&nbsp;accomplishments by geospatial categories such as State, County, or Watershed.</p>', 1),
(64, N'ExcludeFromFactSheet', N'Exclude from Fact Sheet', N'<p>Flags a photo so that it is not included in the photos shown on the project&#39;s Fact Sheet. Some projects have tons of photos -- use this checkbox to control which photos are included.</p>', 1),
(73, N'FundingType', N'Funding Type', N'<p>Field shows whether project is a capital (Capital) versus operations and maintenance (Operations and Maintenance) project.&nbsp;</p>', 1),
(74, N'ProjectCostInYearOfExpenditure', N'Cost in Year of Expenditure', N'<p>This is the expected cost of the project in the year that it will be constructed, taking into account inflation.&nbsp;</p>', 1),
(75, N'GlobalInflationRate', N'Global Inflation Rate', N'<p>Annual rate of inflation expected for project costs.&nbsp;</p>', 1),
(76, N'ReportingYear', N'Reporting Year', N'<p>The current year used for reporting purposes, which is defined as the previous calendar year until after November 1st of the present calendar year.</p>', 1),
(77, N'TagName', N'Tag Name', N'<p>A word or phrase for the tag. Keep it short, and if possible avoid spaces (use dashes or underscores) for cleaner URLs. Don&#39;t add tags for things already captured (e.g. the program under which the project lives).</p>', 1),
(78, N'TagDescription', N'Tag Description', N'<p>A description of what this tag will be used for. Ideally the description should include the name of the user that created it, and an expected timeframe for use of this tag, if known.&nbsp;</p>', 1),
(80, N'ReportedExpenditure', N'Reported Expenditure', N'<p>An expenditure, tied to a Funding Source, as reported by the project implementer.</p>', 1),
(81, N'Proposal', N'Proposal', N'<p>A project suggested by an program partner that will be reviewed for inclusion in the program. The system administrators are responsible for reviewing, and if appropriate, approving proposals.</p>', 1),
(85, N'SpendingAssociatedWithPM', N'Spending Associated with PM', N'<p>The estimated spending allotted to the Performance Measure.</p>', 1),
(86, N'PlanningDesignStartYear', N'Planning / Design Start Year', N'<p>The year during which project planning and design began. All projects should have a Planning / Design Start Year and it may not be a year in the future. Contrast with &quot;Implementation Start Year.&quot; For more detailed information, see the definition for &quot;Stage&quot;.</p>', 1),
(87, N'AssociatedTaxonomyTierTwos', N'Associated Taxonomy Tier Twos', N'<p>External&nbsp;programs that are related to the content you are reviewing. You may wish to look up these programs to learn more.</p>', 1),
(88, N'ExternalLinks', N'External Links', N'<p>Links to external web pages where you might find additional information.</p>', 1),
(89, N'EstimatedAnnualOperatingCost', N'Est. Annual Operating Cost', N'<p>This is the estimated cost of one year of operation in present-year dollars (present-year is set by the tool administrators). This field is only available to operations and maintenance projects.&nbsp;</p>', 1),
(90, N'CalculatedTotalRemainingOperatingCost', N'Remaining Operating Cost', N'<p>This field uses the transportation annual inflation factor (set by the administrators) to inflate the &quot;Estimated Annual Operating Cost&quot; to a cost-in-year-of-expenditure dollars for each year that the project will be in operation, then sums the costs across all years of operation. This field is only calculated for transportation operations and maintenance projects.&nbsp;</p>', 1),
(91, N'CurrentYearForPVCalculations', N'Current Year for PV Calculations', N'<p>The year to use as the starting point for inflation calculations.</p>', 1),
(92, N'LifecycleOperatingCost', N'Lifecycle Operating Cost', N'<p>Sum of the annual operating cost from the Implementation Start Year to Completion Year. Not inflation adjusted.</p>', 1),
(97, N'PerformanceMeasureChartTitle', N'Performance Measure Chart Title', N'<p>A short title for the Indicator (aka Performance Measure) used for charts throughout ProjectFirma.</p>', 1),
(182, N'RoleName', N'Role Name', N'<p>The name or title describing&nbsp;function or set of permissions that can be assigned to a user.</p>', 1),
(184, N'Region', N'Region (Geospatial)', N'<p>The region in which a project is located.</p>', 1),
(228, N'PerformanceMeasureChartCaption', N'Performance Measure Chart Caption', N'<p>The caption which will appear on Performance Measure charts throughout the system.</p>', 1),
(236, N'MonitoringProgram', N'Monitoring Program', N'<p>A on-going activity to collect environmental monitoring data</p>', 1),
(237, N'MonitoringApproach', N'Monitoring Approach', N'<p>Monitoring Approach &ndash; provides a general description of the sampling design used to carry out the monitoring. Included is a description of the spatial distribution of sampling, sampling frequency, lab procedures, and references to data sources, monitoring plans, and protocols used to guide monitoring.</p>', 1),
(238, N'MonitoringProgramPartner', N'Monitoring Program Partner', N'<p>Monitoring Partners &ndash; provides a list of agencies and entities that fund, collect and analyze monitoring data.</p>', 1),
(239, N'MonitoringProgramUrl', N'Monitoring Program Home Page', N'<p>The external homepage of a related monitoring program</p>', 1),
(240, N'ClassificationDescription', N'Classification Description', N'<p>The long-form description of the entries in the project classification system.-</p>', 1),
(241, N'ClassificationGoalStatement', N'Classification Goal Statement', N'<p>The goal of this classification system record.-</p>', 1),
(242, N'ClassificationNarrative', N'Classification Narrative', N'<p>Descriptive text describing the criteria for including a project in this classification system..-</p>', 1),
(243, N'TaxonomySystemName', N'Taxonomy System Name', N'<p>The customized name for the hierarchical project taxonomy system.<p>', 1),
(244, N'TaxonomyTierOneDisplayNameForProject', N'Taxonomy Tier One Display Name For Project', N'<p>A custom label describing how a Project relates to it''s highest Taxonomy tier..</p>', 1),
(245, N'ProjectRelationshipType', N'Project Relationship Type', N'<p>A categorization of a relationship between an organization and a project, e.g. Funder, Implementer.</p>', 1),
(246, N'ProjectSteward', N'Project Steward', N'<p>A person who can approve Project Proposals, create new Projects, approve Project Updates, and create Funding Sources for their Organization.</p>', 1),
(247, 'Chart Last Updated Date', 'ChartLastUpdatedDate','<p>The date this chart was last updated with current information.</p>', 3),
(248, N'UnsecuredFunding', N'Unsecured Funding', N'<p>Funding that has been identified for a project but has not been acquired such as planned grant applications.</p>', 1),
(249, N'ProjectStewardOrganizationDisplayName', N'Project Steward Organization Display Name', N'<p>Label for Organization types that can steward projects.</p>', 1),
(250, N'ClassificationSystem', N'Classification System', N'<p>The type of logical system used to group projects according to overarching program themes or goals.</p>', 0),
(251, N'ClassificationSystemName', N'Classification System Name', N'<p>The name of type of logical system used to group projects according to overarching program themes or goals.</p>', 0)