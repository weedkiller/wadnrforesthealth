﻿using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    /// <summary>
    /// Base class for admin level features; we do not want to use this on Controller Security Feature Attribute
    /// However we can use this to verify role permissions
    /// </summary>
    [SecurityFeatureDescription("_Admin ")]
    public class AdminFeature : FirmaFeature
    {
        public AdminFeature() : base(new List<Role> {Role.SitkaAdmin, Role.Admin})
        {
        }
    }
}