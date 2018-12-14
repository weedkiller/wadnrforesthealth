﻿using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Delete Person")]
    public class PersonDeleteFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Person>
    {
        private readonly FirmaFeatureWithContextImpl<Person> _firmaFeatureWithContextImpl;

        public PersonDeleteFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.Normal, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Person>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Person contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, Person contextModelObject)
        {
            var hasPermissionByPerson = new ContactManageFeature().HasPermissionByPerson(person);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult(
                    $"You don't have permission to delete {contextModelObject.FullNameFirstLast}");
            }

            if (contextModelObject.PersonGuid != null)
            {
                return new PermissionCheckResult($"{contextModelObject.FullNameFirstLast} cannot be deleted because they are a user with an account.");
            }
            return new PermissionCheckResult();
        }
    }
}