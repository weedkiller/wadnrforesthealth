﻿/*-----------------------------------------------------------------------
<copyright file="FirmaSetupFixture.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Net;
using ProjectFirma.Web.Controllers;
using NUnit.Framework;
using ProjectFirma.Web;
using ProjectFirma.Web.Common;

/// <summary>
/// Sets up the global logger for the project
/// </summary>
/// <remarks>A SetUpFixture outside of any namespace provides SetUp and TearDown for the entire assembly</remarks>
[SetUpFixture]
// ReSharper disable CheckNamespace
public class FirmaSetupFixture
    // ReSharper restore CheckNamespace
{
    [SetUp]
    public void RunBeforeAnyTests()
    {
        // This is a *partial* fix for some of the issues discovered when disabling TLS 1.0 as part of the following story: https://projects.sitkatech.com/projects/gemini/cards/4197
        // Allow multiple protocols so that we can connect to more than one endpoint, over time we may need to add Tls13 etc
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

        // This is necessary for tests to pass, since many will try to initialize a URL route, and we normally create the route table when the web app starts.
        // So we deliberately build the route table ahead of time.
        RouteTableBuilder.Build(FirmaBaseController.AllControllerActionMethods, null, Global.AreasDictionary);
    }
}
