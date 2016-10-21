using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.ProposedProjectImage;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class ProposedProjectImageController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [ProposedProjectImageNewFeature]
        public PartialViewResult New(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new NewViewModel();
            return ViewNew(proposedProject, viewModel);
        }

        private PartialViewResult ViewNew(ProposedProject proposedProject, NewViewModel viewModel)
        {
            var viewData = new NewViewData(proposedProject);
            return RazorPartialView<New, NewViewData, NewViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectImageNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProposedProjectPrimaryKey proposedProjectPrimaryKey, NewViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewNew(proposedProject, viewModel);
            }
            var projectImage = new ProposedProjectImage(proposedProject);
            viewModel.UpdateModel(projectImage, CurrentPerson);
            proposedProject.ProposedProjectImages.Add(projectImage);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProposedProjectImageEditOrDeleteFeature]
        public PartialViewResult Edit(ProposedProjectImagePrimaryKey proposedProjectImagePrimaryKey)
        {            
            var proposedProjectImage = proposedProjectImagePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(proposedProjectImage);
            return ViewEdit(proposedProjectImage, viewModel);
        }

        private PartialViewResult ViewEdit(ProposedProjectImage proposedProjectImage, EditViewModel viewModel)
        {            
            var viewData = new EditViewData(proposedProjectImage);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectImageEditOrDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProposedProjectImagePrimaryKey proposedProjectImagePrimaryKey, EditViewModel viewModel)
        {
            var proposedProjectImage = proposedProjectImagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(proposedProjectImage, viewModel);
            }
            viewModel.UpdateModel(proposedProjectImage, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProposedProjectImageEditOrDeleteFeature]
        public PartialViewResult Delete(ProposedProjectImagePrimaryKey proposedProjectImagePrimaryKey)
        {
            var proposedProjectImage = proposedProjectImagePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(proposedProjectImage.ProposedProjectImageID);
            return ViewDelete(proposedProjectImage, viewModel);
        }

        private PartialViewResult ViewDelete(ProposedProjectImage proposedProjectrojectImage, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !proposedProjectrojectImage.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this image from Proposed Project '{0}'? ({1})", proposedProjectrojectImage.ProposedProject.DisplayName, proposedProjectrojectImage.Caption)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Proposed Project Image");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectImageEditOrDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ProposedProjectImagePrimaryKey proposedProjectImagePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var proposedProjectImage = proposedProjectImagePrimaryKey.EntityObject;
            var proposedProject = proposedProjectImage.ProposedProject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(proposedProjectImage, viewModel);
            }
            DeleteProposedProjectImages(new[] { proposedProjectImage });
            return new ModalDialogFormJsonResult();
        }

        public static void DeleteProposedProjectImages(ICollection<ProposedProjectImage> proposedProjectImages)
        {
            var proposedProjectImageFileResourceIDsToDelete = proposedProjectImages.Select(x => x.FileResourceID).ToList();
            var proposedProjectImageIDsToDelete = proposedProjectImages.Select(x => x.ProposedProjectImageID).ToList();
            HttpRequestStorage.DatabaseEntities.ProposedProjectImages.DeleteProposedProjectImage(proposedProjectImageIDsToDelete);
            HttpRequestStorage.DatabaseEntities.FileResources.DeleteFileResource(proposedProjectImageFileResourceIDsToDelete);
        }
    }
}