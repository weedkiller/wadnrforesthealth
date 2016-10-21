using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProgramInfo
{
    public class TransportationTaxonomyViewData : EIPViewData
    {
        public readonly List<FancyTreeNode> TransportationStrategiesAsFancyTreeNodes;

        public TransportationTaxonomyViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage,
            List<FancyTreeNode> transportationStrategiesAsFancyTreeNodes) : base(currentPerson, projectFirmaPage)
        {
            TransportationStrategiesAsFancyTreeNodes = transportationStrategiesAsFancyTreeNodes;
            PageTitle = "Transportation Strategies and Objectives";
        }
    }
}