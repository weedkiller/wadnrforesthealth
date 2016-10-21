﻿using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory
{
    public abstract class IndicatorRelationships : TypedWebPartialViewPage<IndicatorRelationshipsViewData>
    {
        public static void RenderPartialView(HtmlHelper html, IndicatorRelationshipsViewData viewData)
        {
            html.RenderRazorSitkaPartial<IndicatorRelationships, IndicatorRelationshipsViewData>(viewData);
        }
    }
}