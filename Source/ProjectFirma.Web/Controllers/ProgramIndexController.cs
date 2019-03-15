﻿using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class ProgramIndexController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public JsonResult FindProgramIndex(string term)
        {

            var programIndicesFound = HttpRequestStorage.DatabaseEntities.ProgramIndices
                .GetProgramIndexFindResults(term).Take(20);
            var programIndicesFound2 = programIndicesFound.Select(p => new ListItem(p.ProgramIndexAbbrev, p.ProgramIndexID.ToString(CultureInfo.InvariantCulture))).ToList();

            return Json(programIndicesFound2.Select(v => new { label = v.Text, value = v.Text, actualValue = v.Value }), JsonRequestBehavior.AllowGet);//use JSON structure for jquerys autocomplete functionality

        }

    }
}