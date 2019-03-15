﻿/*-----------------------------------------------------------------------
<copyright file="HttpRequestStorage.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Models;
using Person = ProjectFirma.Web.Models.Person;

namespace ProjectFirma.Web.Common
{
    public class HttpRequestStorage : SitkaHttpRequestStorage
    {
        static HttpRequestStorage()
        {
            LtInfoEntityTypeLoaderFactoryFunction = () => MakeNewContext(false);
        }

        protected override List<string> BackingStoreKeys => new List<string>();

        public static Person Person
        {
            get
            {
                var person = GetValueOrDefault<Person>(PersonKey, () => null);
                Check.RequireNotNull(person, "Attempting to access Person before OnAuthentication is complete. Unexpected, some code may be running too soon in event lifecycle.");

                return person;
            }
            set => SetValue(PersonKey, value);
        }

        public static DatabaseEntities DatabaseEntities => (DatabaseEntities) LtInfoEntityTypeLoader;

        private static DatabaseEntities MakeNewContext(bool autoDetectChangesEnabled)
        {
            var databaseEntities = new DatabaseEntities();
            databaseEntities.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            return databaseEntities;
        }

        public static void StartContextForTest()
        {
            var context = MakeNewContext(true);
            SetValue(DatabaseContextKey, context);
        }

        public static void EndContextForTest()
        {
            if (!BackingStore.Contains(DatabaseContextKey))
            {
                return;
            }

            if (BackingStore[DatabaseContextKey] is DatabaseEntities databaseEntities)
            {
                databaseEntities.Dispose();
                BackingStore[DatabaseContextKey] = null;
            }

            BackingStore.Remove(DatabaseContextKey);

            if (!BackingStore.Contains(PersonKey))
            {
                return;
            }

            if (BackingStore[PersonKey] is Person)
            {
                BackingStore[PersonKey] = null;
            }

            BackingStore.Remove(PersonKey);
        }
    }
}