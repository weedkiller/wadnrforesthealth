using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Classification
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {
            PageTitle = MultiTenantHelpers.GetClassificationDisplayNamePluralized();
            GridSpec = new IndexGridSpec(new PerformanceMeasureManageFeature().HasPermissionByPerson(CurrentPerson))
            {
                ObjectNameSingular = MultiTenantHelpers.GetClassificationDisplayName(),
                ObjectNamePlural = MultiTenantHelpers.GetClassificationDisplayNamePluralized(),
                SaveFiltersInCookie = true,
                CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<ClassificationController>.BuildUrlFromExpression(tc => tc.New()), "New Project Classification"),
            };

            GridName = "classificationsGrid";
            GridDataUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}