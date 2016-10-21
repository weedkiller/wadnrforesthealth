﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.User
{
    public class EditRolesViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> EIPRoles;
        public readonly IEnumerable<SelectListItem> SustainabilityRoles;
        public readonly IEnumerable<SelectListItem> ParcelTrackerRoles; 
        public readonly IEnumerable<SelectListItem> LtInfoRoles;
        public readonly IEnumerable<SelectListItem> ThresholdRoles;

        public EditRolesViewData(IEnumerable<SelectListItem> eipRoles, IEnumerable<SelectListItem> sustainabilityRoles, IEnumerable<SelectListItem> ParcelTrackerRole, IEnumerable<SelectListItem> ltInfoRoles, IEnumerable<SelectListItem> thresholdRoles)
        {
            EIPRoles = eipRoles;
            SustainabilityRoles = sustainabilityRoles;
            ParcelTrackerRoles = ParcelTrackerRole;
            LtInfoRoles = ltInfoRoles;
            ThresholdRoles = thresholdRoles;
        }
    }
}