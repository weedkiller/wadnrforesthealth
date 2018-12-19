﻿/*-----------------------------------------------------------------------
<copyright file="UserController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.User;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.KeystoneDataService;
using ProjectFirma.Web.Views.Shared.UserStewardshipAreas;
using Organization = ProjectFirma.Web.Models.Organization;

namespace ProjectFirma.Web.Controllers
{
    public class UserController : FirmaBaseController
    {
        [ContactManageFeature]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [ContactManageFeature]
        public GridJsonNetJObjectResult<Person> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentPerson);
            var persons = HttpRequestStorage.DatabaseEntities.People.ToList().Where(x => new UserViewFeature().HasPermission(CurrentPerson, x).HasPermission).OrderBy(x => x.FullNameLastFirst).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Person>(persons, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [UserEditFeature]
        public PartialViewResult EditRoles(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var viewModel = new EditRolesViewModel(person);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditRoles(PersonPrimaryKey personPrimaryKey, EditRolesViewModel viewModel)
        {
            var person = personPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            viewModel.UpdateModel(person, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditRolesViewModel viewModel)
        {
            var roles = CurrentPerson.IsSitkaAdministrator() ? Role.All : Role.All.Except(new[] {Role.SitkaAdmin});
            var rolesAsSelectListItems = roles.ToSelectListWithEmptyFirstRow(x => x.RoleID.ToString(CultureInfo.InvariantCulture), x => x.GetRoleDisplayName());
            var viewData = new EditRolesViewData(rolesAsSelectListItems);
            return RazorPartialView<EditRoles, EditRolesViewData, EditRolesViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [PersonDeleteFeature]
        public PartialViewResult Delete(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(person.PersonID);
            return ViewDelete(person, viewModel);
        }

        private PartialViewResult ViewDelete(Person person, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !person.HasDependentObjects() && person != CurrentPerson;
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete {person.FullNameFirstLast}?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Person", SitkaRoute<UserController>.BuildLinkFromExpression(x => x.Detail(person), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [PersonDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(PersonPrimaryKey personPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var person = personPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(person, viewModel);
            }
            person.DeletePerson();
            return new ModalDialogFormJsonResult();
        }

        [UserViewFeature]
        public ViewResult Detail(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var userNotificationGridSpec = new UserNotificationGridSpec();
            var userNotificationGridDataUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.UserNotificationsGridJsonData(personPrimaryKey));
            var basicProjectInfoGridSpec = new Views.Project.BasicProjectInfoGridSpec(CurrentPerson, false)
            {
                ObjectNameSingular = $"{FieldDefinition.Project.GetFieldDefinitionLabel()} where {person.FullNameFirstLast} is the {FieldDefinition.OrganizationPrimaryContact.GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} where {person.FullNameFirstLast} is the {FieldDefinition.OrganizationPrimaryContact.GetFieldDefinitionLabel()}",
                SaveFiltersInCookie = true
            };
            const string basicProjectInfoGridName = "userProjectListGrid";
            var basicProjectInfoGridDataUrl = SitkaRoute<UserController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(person));
            var activateInactivateUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.ActivateInactivatePerson(person));
            var viewData = new DetailViewData(CurrentPerson,
                person,
                basicProjectInfoGridSpec,
                basicProjectInfoGridName,
                basicProjectInfoGridDataUrl,
                userNotificationGridSpec,
                "userNotifications",
                userNotificationGridDataUrl,
                activateInactivateUrl);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [UserViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var gridSpec = new Views.Project.BasicProjectInfoGridSpec(CurrentPerson, false);
            var projectPersons = person.GetPrimaryContactProjects(CurrentPerson).OrderBy(x => x.DisplayName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectPersons, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [UserViewFeature]
        public GridJsonNetJObjectResult<Notification> UserNotificationsGridJsonData(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var gridSpec = new UserNotificationGridSpec();
            var notifications = person.Notifications.OrderByDescending(x => x.NotificationDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Notification>(notifications, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [UserEditFeature]
        public PartialViewResult ActivateInactivatePerson(PersonPrimaryKey personPrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(personPrimaryKey.PrimaryKeyValue);
            return ViewActivateInactivatePerson(personPrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewActivateInactivatePerson(Person person, ConfirmDialogFormViewModel viewModel)
        {
            string confirmMessage;
            if (person.IsActive)
            {
                var isPrimaryContactForAnyOrganization = person.OrganizationsWhereYouAreThePrimaryContactPerson.Any();
                if (isPrimaryContactForAnyOrganization)
                {
                    confirmMessage =
                        $@"You cannot inactive user '{person.FullNameFirstLast}' because {person.FirstName} is the {FieldDefinition.OrganizationPrimaryContact.GetFieldDefinitionLabel()} for the following organizations: <ul> {string.Join("\r\n", person.PrimaryContactOrganizations.Select(x =>$"<li>{x.OrganizationName}</li>"))}</ul>";
                }
                else
                {
                    confirmMessage = $"Are you sure you want to inactivate user '{person.FullNameFirstLast}'?";
                }
                var viewData = new ConfirmDialogFormViewData(confirmMessage, !isPrimaryContactForAnyOrganization);
                return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
            }
            else
            {
                confirmMessage = $"Are you sure you want to activate user '{person.FullNameFirstLast}'?";
                var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
                return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
            }
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ActivateInactivatePerson(PersonPrimaryKey personPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var person = personPrimaryKey.EntityObject;
            if (person.IsActive)
            {
                Check.Require(!person.OrganizationsWhereYouAreThePrimaryContactPerson.Any(),
                    $@"You cannot inactive user '{person.FullNameFirstLast}' because {
                            person.FirstName
                        } is the {FieldDefinition.OrganizationPrimaryContact.GetFieldDefinitionLabel()} for one or more {FieldDefinition.Organization.GetFieldDefinitionLabelPluralized()}!");
            }
            if (!ModelState.IsValid)
            {
                return ViewActivateInactivatePerson(person, viewModel);
            }
            if (person.IsActive)
            {
                // if the person is currently active, we need to remove them from the support email list no matter what since we are about to inactivate the person
                person.ReceiveSupportEmails = false;
            }
            person.IsActive = !person.IsActive;
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult PullUserFromKeystone()
        {
            var viewModel = new PullUserFromKeystoneViewModel();

            return ViewPullUserFromKeystone(viewModel);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult PullUserFromKeystone(PullUserFromKeystoneViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewPullUserFromKeystone(viewModel);
            }

            var keystoneClient = new KeystoneDataClient();

            UserProfile keystoneUser = keystoneClient.GetUserProfileByUsername(FirmaWebConfiguration.KeystoneWebServiceApplicationGuid, viewModel.LoginName);
            if (keystoneUser == null)
            {
                SetErrorForDisplay($"Person not added. The {FieldDefinition.Username.GetFieldDefinitionLabel()} was not found in Keystone");
                return new ModalDialogFormJsonResult();    
            }
            
            if (!keystoneUser.OrganizationGuid.HasValue)
            {
                SetErrorForDisplay($"Person not added. They have no {FieldDefinition.Organization.GetFieldDefinitionLabel()} in Keystone");
            }

            KeystoneDataService.Organization keystoneOrganization = null;
            try
            {
                keystoneOrganization = keystoneClient.GetOrganization(keystoneUser.OrganizationGuid.Value);
            }
            catch (Exception)
            {
                SetErrorForDisplay($"Person not added. Could not find their {FieldDefinition.Organization.GetFieldDefinitionLabel()} in Keystone");
            }

            if (keystoneOrganization == null)
            {
                SetErrorForDisplay("Person not added. Could not find their Organization in Keystone");

            }
            else
            {
                var firmaOrganization =
                    HttpRequestStorage.DatabaseEntities.Organizations.SingleOrDefault(
                        x => x.OrganizationGuid == keystoneUser.OrganizationGuid);
                if (firmaOrganization == null)
                {
                    var defaultOrganizationType = HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetDefaultOrganizationType();
                    firmaOrganization = new Organization(keystoneOrganization.FullName, true, defaultOrganizationType)
                    {
                        OrganizationGuid = keystoneOrganization.OrganizationGuid,
                        OrganizationShortName = keystoneOrganization.ShortName,
                        OrganizationUrl = keystoneOrganization.URL
                    };
                    HttpRequestStorage.DatabaseEntities.AllOrganizations.Add(firmaOrganization);
                }

                var firmaPerson =
                    HttpRequestStorage.DatabaseEntities.People.SingleOrDefault(
                        x => x.PersonGuid == keystoneUser.UserGuid);
                if (firmaPerson != null)
                {
                    firmaPerson.OrganizationID = firmaOrganization.OrganizationID;
                }
                else
                {
                    firmaPerson = new Person(keystoneUser.FirstName, keystoneUser.LastName,
                        Role.Unassigned, DateTime.Now, true, false)
                    {
                        PersonGuid = keystoneUser.UserGuid,
                        Email = keystoneUser.Email,
                        LoginName = keystoneUser.LoginName,
                        Organization = firmaOrganization
                    };
                    HttpRequestStorage.DatabaseEntities.AllPeople.Add(firmaPerson);
                }

                HttpRequestStorage.DatabaseEntities.SaveChanges();

                SetMessageForDisplay($"{firmaPerson.GetFullNameFirstLastAndOrgAsUrl()} successfully added. You may want to <a href=\"{firmaPerson.GetDetailUrl()}\">assign them a role</a>.");
            }
            return new ModalDialogFormJsonResult();

            
        }

        private PartialViewResult ViewPullUserFromKeystone(PullUserFromKeystoneViewModel viewModel)
        {
            var viewData = new PullUserFromKeystoneViewData();
            return RazorPartialView<PullUserFromKeystone, PullUserFromKeystoneViewData, PullUserFromKeystoneViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [UserEditFeature]
        public PartialViewResult EditStewardshipAreas(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var viewModel = new EditUserStewardshipAreasViewModel(person, MultiTenantHelpers.GetProjectStewardshipAreaType());
            return ViewEditStewardshipAreas(viewModel);
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditStewardshipAreas(PersonPrimaryKey personPrimaryKey, EditUserStewardshipAreasViewModel viewModel)
        {
            var person = personPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditStewardshipAreas(viewModel);
            }
            var projectStewardshipAreaType = MultiTenantHelpers.GetProjectStewardshipAreaType().ToEnum;

            switch (projectStewardshipAreaType)
            {
                case ProjectStewardshipAreaTypeEnum.ProjectStewardingOrganizations:
                    HttpRequestStorage.DatabaseEntities.Organizations.Load();
                    viewModel.UpdateModel(person, HttpRequestStorage.DatabaseEntities.AllPersonStewardOrganizations.Local);
                    break;
                case ProjectStewardshipAreaTypeEnum.TaxonomyBranches:
                    HttpRequestStorage.DatabaseEntities.TaxonomyBranches.Load();
                    viewModel.UpdateModel(person, HttpRequestStorage.DatabaseEntities.AllPersonStewardTaxonomyBranches.Local);
                    break;
                case ProjectStewardshipAreaTypeEnum.GeospatialAreas:
                    HttpRequestStorage.DatabaseEntities.GeospatialAreas.Load();
                    viewModel.UpdateModel(person, HttpRequestStorage.DatabaseEntities.AllPersonStewardGeospatialAreas.Local);
                    break;
                default:
                    throw new InvalidOperationException(
                        "The Stewardship Area editor should only be allowed for tenants with a Project Stewardship Area Type");
            }


            SetMessageForDisplay($"Assigned {FieldDefinition.ProjectStewardshipArea.GetFieldDefinitionLabelPluralized()} successfully changed for {person.FullNameFirstLast}.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditStewardshipAreas(EditUserStewardshipAreasViewModel viewModel)
        {
            EditUserStewardshipAreasViewData viewData;
            var projectStewardshipAreaType = MultiTenantHelpers.GetProjectStewardshipAreaType().ToEnum;

            switch (projectStewardshipAreaType)
            {
                case ProjectStewardshipAreaTypeEnum.ProjectStewardingOrganizations:
                    var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().Where(x=>x.CanStewardProjects()).ToList();
                    viewData = new EditUserStewardshipAreasViewData(CurrentPerson, allOrganizations, false);
                    break;
                case ProjectStewardshipAreaTypeEnum.TaxonomyBranches:
                    var allTaxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList();
                    viewData = new EditUserStewardshipAreasViewData(CurrentPerson, allTaxonomyBranches, false);
                    break;
                case ProjectStewardshipAreaTypeEnum.GeospatialAreas:
                    var allGeospatialAreas = HttpRequestStorage.DatabaseEntities.GeospatialAreas.ToList();
                    viewData = new EditUserStewardshipAreasViewData(CurrentPerson, allGeospatialAreas, false);
                    break;
                default:
                    throw new InvalidOperationException(
                        "The Stewardship Area editor should only be allowed for tenants with a Project Stewardship Area Type");
            }

            return RazorPartialView<EditUserStewardshipAreas, EditUserStewardshipAreasViewData, EditUserStewardshipAreasViewModel>(viewData, viewModel);
        }


        [HttpGet]
        [ContactManageFeature]
        public PartialViewResult AddContact()
        {
            var viewModel = new EditContactViewModel();
            return ViewAddContact(viewModel, false);
        }

        [HttpPost]
        [ContactManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult AddContact(EditContactViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewAddContact(viewModel, false);
            }

            var firmaPerson = new Person(viewModel.FirstName, viewModel.LastName,
                    Role.Unassigned.RoleID, DateTime.Now, true, false)
                { PersonAddress = viewModel.Address, Email = viewModel.Email, Phone = viewModel.Phone, OrganizationID = viewModel.OrganizationID, AddedByPersonID = CurrentPerson.PersonID};
            HttpRequestStorage.DatabaseEntities.AllPeople.Add(firmaPerson);

            SetMessageForDisplay($"Successfully added {viewModel.FirstName} {viewModel.LastName}");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewAddContact(EditContactViewModel viewModel, bool fullUpUser)
        {
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.AsEnumerable()
                .ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture),
                    x => x.DisplayName.ToString(CultureInfo.InvariantCulture), "No Organization");
            var viewData = new EditContactViewData(organizations, fullUpUser);
            return RazorPartialView<EditContact, EditContactViewData, EditContactViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [UserEditFeature]
        public ActionResult EditContact(PersonPrimaryKey personPrimaryKey)
            {
            var person = personPrimaryKey.EntityObject;
            var viewModel = new EditContactViewModel(person);
            return ViewAddContact(viewModel, person.PersonGuid.HasValue);
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditContact(PersonPrimaryKey personPrimaryKey, EditContactViewModel viewModel)
        {
            var person = personPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewAddContact(viewModel, person.PersonGuid.HasValue);
            }

            viewModel.UpdateModel(person);

            SetMessageForDisplay($"Successfully updated {person.FullNameFirstLast}");
            return new ModalDialogFormJsonResult();
        }
    }
}
