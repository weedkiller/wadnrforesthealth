﻿/*-----------------------------------------------------------------------
<copyright file="EditRolesViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.User
{
    public class EditRolesViewModel : FormViewModel
    {
        [Required]
        public int PersonID { get; set; }

        [Required]
        [DisplayName("Role")]
        public int? RoleID { get; set; }

        [Required]
        [DisplayName("Should Receive Support Emails?")]
        public bool ShouldReceiveSupportEmails { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditRolesViewModel()
        {
        }

        public EditRolesViewModel(Person person)
        {
            PersonID = person.PersonID;
            RoleID = person.RoleID;

            ShouldReceiveSupportEmails = person.ReceiveSupportEmails;
        }

        public void UpdateModel(Person person, Person currentPerson)
        {
            var downgradingFromSteward = person.Role == Models.Role.ProjectSteward &&
                                         RoleID != Models.Role.ProjectSteward.RoleID &&
                                         RoleID != Models.Role.Admin.RoleID && RoleID != Models.Role.SitkaAdmin.RoleID;
            
            // RoleID is required so this should not really happen, but map to unassigned as a safety
            person.RoleID = RoleID ?? Models.Role.Unassigned.RoleID;
            person.ReceiveSupportEmails = ShouldReceiveSupportEmails;

            if (ModelObjectHelpers.IsRealPrimaryKeyValue(person.PersonID))
            {
                person.UpdateDate = DateTime.Now; // Existing person
            }
            else
            {
                person.CreateDate = DateTime.Now; // New person
            }

            if (downgradingFromSteward)
            {                
                HttpRequestStorage.DatabaseEntities.PersonStewardRegions.DeletePersonStewardRegion(person.PersonStewardRegions);
                HttpRequestStorage.DatabaseEntities.PersonStewardTaxonomyBranches.DeletePersonStewardTaxonomyBranch(person.PersonStewardTaxonomyBranches);
                HttpRequestStorage.DatabaseEntities.PersonStewardOrganizations.DeletePersonStewardOrganization(person.PersonStewardOrganizations);
            }
        }
    }
}
