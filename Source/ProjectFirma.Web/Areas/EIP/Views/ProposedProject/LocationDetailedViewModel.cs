using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class LocationDetailedViewModel : ProjectLocationDetailViewModel
    {
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public LocationDetailedViewModel()
        {
        }
    }
}