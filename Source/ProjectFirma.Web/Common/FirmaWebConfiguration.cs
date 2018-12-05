﻿/*-----------------------------------------------------------------------
<copyright file="FirmaWebConfiguration.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using LtInfo.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Common
{
    public class FirmaWebConfiguration : SitkaWebConfiguration
    {
        public static readonly int MaximumAllowedUploadFileSize = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("MaximumAllowedUploadFileSize"));
        public static readonly int MaximumAllowedUploadImageSize = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("MaximumAllowedUploadImageSize"));
        public static readonly string DatabaseConnectionString = SitkaConfiguration.GetRequiredAppSetting("DatabaseConnectionString");
        public static readonly string RecaptchaValidatorUrl = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("RecaptchaValidatorUrl");
        public static readonly string SitkaSupportEmail = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("SitkaSupportEmail");
        public static readonly string DoNotReplyEmail = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("DoNotReplyEmail");
        public static readonly string Ogr2OgrExecutable = SitkaConfiguration.GetRequiredAppSetting("Ogr2OgrExecutable");
        public static readonly string OgrInfoExecutable = SitkaConfiguration.GetRequiredAppSetting("OgrInfoExecutable");
        public static readonly int DefaultSupportPersonID = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("DefaultSupportPersonID"));

        public static readonly TimeSpan HttpRuntimeExecutionTimeout = ((HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime")).ExecutionTimeout;       
        public static readonly string SAWUrl = SitkaConfiguration.GetRequiredAppSetting("SAWUrl");

        public static readonly FirmaEnvironment FirmaEnvironment = FirmaEnvironment.MakeFirmaEnvironment(SitkaConfiguration.GetRequiredAppSetting("FirmaEnvironment"));

        public static readonly string CanonicalHostName = CanonicalHostNames.FirstOrDefault();
        public static readonly string Saml2EntityID = SitkaConfiguration.GetRequiredAppSetting("Saml2EntityID");
        public static readonly string Saml2EndPoint = SitkaConfiguration.GetRequiredAppSetting("Saml2EndPoint");

        public static List<string> CanonicalHostNames => Tenant.All.OrderBy(x => x.TenantID).Select(x => FirmaEnvironment.GetCanonicalHostNameForEnvironment(x)).ToList();
        public static string SamlIDPCertificateSerialNumber = SitkaConfiguration.GetRequiredAppSetting("SamlIDPCertificateSerialNumber");

        public static string GetCanonicalHost(string hostName, bool useApproximateMatch)
        {
            //First search for perfect match
            var canonicalHostNames = CanonicalHostNames;
            var result = canonicalHostNames.FirstOrDefault(h => string.Equals(h, hostName, StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(result) || !useApproximateMatch)
            {
                return result;
            }

            //Use the domain name  (laketahoeinfo.org -->  should use www.laketahoeinfo.org for the match)
            return canonicalHostNames.FirstOrDefault(h => h.EndsWith(hostName, StringComparison.InvariantCultureIgnoreCase)) ?? CanonicalHostName;
        }
    }
}
