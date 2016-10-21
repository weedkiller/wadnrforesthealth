using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Areas.EIP.Controllers;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public enum ProposedProjectSectionEnum
    {
        Instructions,
        Basics,
        EIPPerformanceMeasures,
        LocationSimple,
        LocationDetailed,
        ThresholdCategories,
        TransportationAssessment,
        Notes,
        History,
        Photos
    }

    public class ProposalSectionsStatus
    {
        public bool IsBasicsSectionComplete { get; set; }
        public bool IsEIPPerformanceMeasureSectionComplete { get; set; }
        public bool IsProjectLocationSimpleSectionComplete { get; set; }
        public bool IsProjectLocationDetailedSectionComplete { get; set; }
        public bool IsThresholdCategoriesComplete { get; set; }
        public bool IsTransportationAssessmentComplete { get; set; }
        public bool IsNotesSectionComplete { get; set; }
        public bool AreAllSectionsValid
        {
            get
            {
                return IsBasicsSectionComplete && IsEIPPerformanceMeasureSectionComplete && IsThresholdCategoriesComplete && IsTransportationAssessmentComplete && IsProjectLocationSimpleSectionComplete && IsProjectLocationSimpleSectionComplete && IsNotesSectionComplete;
            }
        }

        public ProposalSectionsStatus(Models.ProposedProject proposedProject)
        {
            var basicsValidator = new BasicsViewModelValidator(new List<Models.ProposedProject> { proposedProject });
            var validationResult = basicsValidator.Validate(new BasicsViewModel(proposedProject));
            IsBasicsSectionComplete = validationResult.IsValid;

            var locationSimpleValidationResults = new LocationSimpleViewModel(proposedProject).GetValidationResults();
            IsProjectLocationSimpleSectionComplete = !locationSimpleValidationResults.Any();

            IsProjectLocationDetailedSectionComplete = IsBasicsSectionComplete;

            var pmValidationResults = new ExpectedEipPerformanceMeasureValuesViewModel(proposedProject).GetValidationResults();
            IsEIPPerformanceMeasureSectionComplete = !pmValidationResults.Any();

            var proposedProjectThresholdCategorySimples = ProposedProjectController.GetProposedProjectThresholdCategorySimples(proposedProject);
            var thresholdValidationResults = new EditProposedProjectThresholdCategoriesViewModel(proposedProjectThresholdCategorySimples).GetValidationResults();
            IsThresholdCategoriesComplete = !thresholdValidationResults.Any();

            var allQuestionsAnswered = ProposedProjectController.GetProposedProjectTransportationQuestionSimples(proposedProject).All(simple => simple.Answer.HasValue);
            IsTransportationAssessmentComplete = !proposedProject.IsTransportationProject || allQuestionsAnswered;

            IsNotesSectionComplete = IsBasicsSectionComplete; //there is no validation required on Notes
        }

        public ProposalSectionsStatus()
        {
            IsBasicsSectionComplete = false;
            IsEIPPerformanceMeasureSectionComplete = false;
            IsThresholdCategoriesComplete = false;
            IsTransportationAssessmentComplete = false;
            IsProjectLocationSimpleSectionComplete = false;
            IsProjectLocationDetailedSectionComplete = false;
            IsNotesSectionComplete = false;
        }
    }
}