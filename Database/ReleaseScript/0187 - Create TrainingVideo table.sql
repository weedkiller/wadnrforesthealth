



CREATE TABLE dbo.TrainingVideo
(
	TrainingVideoID INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_TrainingVideo_TrainingVideoID PRIMARY KEY,
	TenantID INT NOT NULL CONSTRAINT FK_TrainingVideo_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),
	VideoName VARCHAR(100) NOT NULL,
	VideoDescription VARCHAR(500) NULL,
	VideoUploadDate DATETIME NOT NULL,
	VideoURL VARCHAR(100) NOT NULL,
	CONSTRAINT AK_TrainingVideo_TrainingVideoID_TenantID UNIQUE(TrainingVideoID, TenantID)
)
GO


INSERT INTO dbo.TrainingVideo (TenantID, VideoName, VideoDescription, VideoUploadDate, VideoURL)
VALUES 
(2, 'Adding a New Project', 'This is a ProjectFirma training video on how to add a new project to the system.', '2018-08-02 00:00:00.000', 'https://www.youtube.com/embed/mxPsJCKjVlY'),
(2, 'Updating an Existing Project', 'This is the ProjectFirma training video on how to update a project in the system.', '2018-08-02 00:00:00.000', 'https://www.youtube.com/embed/4Kh7d76km9A'),
(2, 'Account Management and User Details', 'This is a ProjectFirma training video on how to create an account, what to do if you forget your password, and how your account and organization are used in the system.', '2018-08-02 00:00:00.000', 'https://www.youtube.com/embed/pQR2T7KYsvg');