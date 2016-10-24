using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("List Tags")]
    public class TagListFeature : EIPFeature
    {
        public TagListFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ReadOnlyAdmin, Role.TMPOManager })
        {
        }
    }
}