delete from dbo.ThresholdEvaluationManagementStatusType
go

insert into dbo.ThresholdEvaluationManagementStatusType(ThresholdEvaluationManagementStatusTypeID, ThresholdEvaluationManagementStatusTypeName, ThresholdEvaluationManagementStatusTypeDisplayName, ThresholdEvaluationManagementStatusTypeAbbreviation, ThresholdEvaluationManagementStatusTypeDescription) 
values 
(1, 'Implemented', 'Implemented', 'I', 'The Management Standard has been integrated into the Regional Plan as a policy and/or as an ordinance of regulation and is consistently applied to a project design or as a condition of project approval as a result of project review process.  Greater than three examples of programs or actions can be represented to support the Management Standard''s implementation.  Adopted programs or actions support all aspects of the Management Standard''s implementation, or address all major threats to implementation of the Management Standard.'),
(2, 'PartiallyImplemented', 'Partially Implemented', 'PI', 'The Management Standard has been integrated into the Regional Plan, but is not consistently applied during the course of the project review process.  No more than two examples of programs or actions can be identified to support the Management Standard''s implementation and/or adopted programs or actions support some aspects of the Management Standard or address some major threats to implementation of the Management Standard.'),
(3, 'NotImplemented', 'Not Implemented', 'NI', 'The Management Standard has not been integrated into the Regional Plan and is not applied during the course of project review.  No examples of programs or actions can be identified to support implementation of the Management Standard.')