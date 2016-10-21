﻿using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Areas.EIP.Views.Tag
{
    public class IndexViewData : EIPViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Tags";

            var hasTagManagePermissions = new TagManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasTagManagePermissions) {ObjectNameSingular = "Tag", ObjectNamePlural = "Tags", SaveFiltersInCookie = true};

            if (hasTagManagePermissions)
            {
                var contentUrl = SitkaRoute<TagController>.BuildUrlFromExpression(t => t.New());
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(contentUrl, "Create a new Tag");
            }

            GridName = "TagsGrid";
            GridDataUrl = SitkaRoute<TagController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}