﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Views.Shared.UserStewardshipAreas;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectStewardshipAreaType
    {
        public abstract List<PersonStewardshipAreaSimple> GetPersonStewardshipAreaSimples(Person person);
        public abstract bool CanStewardProject(Person person, Project project);
        public abstract List<HtmlString> GetProjectStewardshipAreaHtmlStringList(Person person);

        public string GetProjectStewardshipAreaTypeDisplayName()
        {
            if (this == Watersheds)
            {
                return FieldDefinition.Watershed.GetFieldDefinitionLabelPluralized();
            }
            return ProjectStewardshipAreaTypeDisplayName;
        }
    }

    public partial class ProjectStewardshipAreaTypeProjectStewardingOrganizations
    {
        public override List<PersonStewardshipAreaSimple> GetPersonStewardshipAreaSimples(Person person)
        {
            return GetPersonStewardOrganizations(person).Select(x => new PersonStewardshipAreaSimple(x)).ToList();
        }

        public override bool CanStewardProject(Person person, Project project)
        {
            var canStewardProjectsOrganizationForProject = project.GetCanStewardProjectsOrganization();
            return canStewardProjectsOrganizationForProject != null && GetPersonStewardOrganizations(person).Any(x => x.OrganizationID == canStewardProjectsOrganizationForProject.OrganizationID);
        }

        public override List<HtmlString> GetProjectStewardshipAreaHtmlStringList(Person person)
        {
            return GetPersonStewardOrganizations(person).Select(x => x.Organization.GetDisplayNameAsUrl()).ToList();
        }

        private List<PersonStewardOrganization> GetPersonStewardOrganizations(Person person)
        {
            return person.PersonStewardOrganizations.OrderBy(x => x.Organization.DisplayName).ToList();
        }
    }

    public partial class ProjectStewardshipAreaTypeTaxonomyBranches
    {
        public override List<PersonStewardshipAreaSimple> GetPersonStewardshipAreaSimples(Person person)
        {
            return GetPersonStewardTaxonomyBranches(person).Select(x => new PersonStewardshipAreaSimple(x)).ToList();
        }

        public override bool CanStewardProject(Person person, Project project)
        {
            var canStewardProjectsTaxonomyBranchForProject = project.GetCanStewardProjectsTaxonomyBranch();
            return canStewardProjectsTaxonomyBranchForProject != null && GetPersonStewardTaxonomyBranches(person).Any(x => x.TaxonomyBranchID == canStewardProjectsTaxonomyBranchForProject.TaxonomyBranchID);
        }

        public override List<HtmlString> GetProjectStewardshipAreaHtmlStringList(Person person)
        {
            return GetPersonStewardTaxonomyBranches(person).Select(x => x.TaxonomyBranch.GetDisplayNameAsUrl()).ToList();
        }

        private List<PersonStewardTaxonomyBranch> GetPersonStewardTaxonomyBranches(Person person)
        {
            return person.PersonStewardTaxonomyBranches.OrderBy(x => x.TaxonomyBranch.SortOrder).ThenBy(x => x.TaxonomyBranch.DisplayName).ToList();
        }
    }

    public partial class ProjectStewardshipAreaTypeWatersheds
    {
        public override List<PersonStewardshipAreaSimple> GetPersonStewardshipAreaSimples(Person person)
        {
            return GetPersonStewardWatersheds(person).Select(x => new PersonStewardshipAreaSimple(x)).ToList();
        }

        public override bool CanStewardProject(Person person, Project project)
        {
            var canStewardProjectsWatershedsForProject = project.GetCanStewardProjectsWatersheds().Select(x => x.WatershedID).ToList();
            return GetPersonStewardWatersheds(person).Any(x => canStewardProjectsWatershedsForProject.Contains(x.WatershedID));
        }

        public override List<HtmlString> GetProjectStewardshipAreaHtmlStringList(Person person)
        {
            return GetPersonStewardWatersheds(person).Select(x => x.Watershed.GetDisplayNameAsUrl()).ToList();
        }

        private List<PersonStewardWatershed> GetPersonStewardWatersheds(Person person)
        {
            return person.PersonStewardWatersheds.OrderBy(x => x.Watershed.WatershedName).ToList();
        }
    }

}