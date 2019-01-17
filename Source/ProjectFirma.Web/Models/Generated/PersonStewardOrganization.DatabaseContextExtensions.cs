//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardOrganization]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PersonStewardOrganization GetPersonStewardOrganization(this IQueryable<PersonStewardOrganization> personStewardOrganizations, int personStewardOrganizationID)
        {
            var personStewardOrganization = personStewardOrganizations.SingleOrDefault(x => x.PersonStewardOrganizationID == personStewardOrganizationID);
            Check.RequireNotNullThrowNotFound(personStewardOrganization, "PersonStewardOrganization", personStewardOrganizationID);
            return personStewardOrganization;
        }

        public static void DeletePersonStewardOrganization(this IQueryable<PersonStewardOrganization> personStewardOrganizations, List<int> personStewardOrganizationIDList)
        {
            if(personStewardOrganizationIDList.Any())
            {
                personStewardOrganizations.Where(x => personStewardOrganizationIDList.Contains(x.PersonStewardOrganizationID)).Delete();
            }
        }

        public static void DeletePersonStewardOrganization(this IQueryable<PersonStewardOrganization> personStewardOrganizations, ICollection<PersonStewardOrganization> personStewardOrganizationsToDelete)
        {
            if(personStewardOrganizationsToDelete.Any())
            {
                var personStewardOrganizationIDList = personStewardOrganizationsToDelete.Select(x => x.PersonStewardOrganizationID).ToList();
                personStewardOrganizations.Where(x => personStewardOrganizationIDList.Contains(x.PersonStewardOrganizationID)).Delete();
            }
        }

        public static void DeletePersonStewardOrganization(this IQueryable<PersonStewardOrganization> personStewardOrganizations, int personStewardOrganizationID)
        {
            DeletePersonStewardOrganization(personStewardOrganizations, new List<int> { personStewardOrganizationID });
        }

        public static void DeletePersonStewardOrganization(this IQueryable<PersonStewardOrganization> personStewardOrganizations, PersonStewardOrganization personStewardOrganizationToDelete)
        {
            DeletePersonStewardOrganization(personStewardOrganizations, new List<PersonStewardOrganization> { personStewardOrganizationToDelete });
        }
    }
}