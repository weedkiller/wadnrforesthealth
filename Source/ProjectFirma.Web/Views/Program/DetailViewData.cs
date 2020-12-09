﻿/*-----------------------------------------------------------------------
<copyright file="GrantDetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared.FileResourceControls;
using ProjectFirma.Web.Views.Shared.TextControls;

namespace ProjectFirma.Web.Views.Program
{
    public class DetailViewData : ProgramViewData
    {
        private ICollection<GisDefaultMapping> Defaults { get; set; }

        public DetailViewData(Person currentPerson,
                                    Models.Program program
                                   )
            : base(currentPerson, program)
        {
            PageTitle = program.ProgramName;
            BreadCrumbTitle = $"{Models.FieldDefinition.Program.GetFieldDefinitionLabel()} Detail";
            Defaults = GisUploadSourceOrganization != null ? GisUploadSourceOrganization.GisDefaultMappings : new List<GisDefaultMapping>();

        }
        private string GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition fieldDefinition)
        {
            var projectIdentifierDefault =
                Defaults.SingleOrDefault(x => x.FieldDefinition == fieldDefinition);
            if (projectIdentifierDefault != null)
            {
                return projectIdentifierDefault.GisDefaultMappingColumnName;
            }

            return null;
        }

        public string ProjectIdentifierColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.ProjectIdentifier);
            }

            return null;
        }

        public string ProjectNameColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.ProjectName);
            }

            return null;
        }

        public string TreatmentTypeColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.TreatmentType);
            }

            return null;
        }

        public string CompletionDateColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.CompletionDate);
            }

            return null;
        }


        public string StartDateColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.PlannedDate);
            }

            return null;
        }

        public string ProjectStageColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.ProjectStage);
            }

            return null;
        }


        public string FootprintAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.FootprintAcres);
            }

            return null;
        }

        public string PrivateLandownerColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.Landowner);
            }

            return null;
        }

        public string TreatmentDetailedActivityTypeColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.TreatmentDetailedActivityType);
            }

            return null;
        }

        public string TreatedAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.TreatedAcres);
            }

            return null;
        }

        public string PruningAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostSharePruningAcres);
            }

            return null;
        }

        public string ThinningAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareThinningAcres);
            }

            return null;
        }

        public string ChippingAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareChippingAcres);
            }

            return null;
        }

        public string MasticationAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareMasticationAcres);
            }

            return null;
        }

        public string GrazingAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareGrazingAcres);
            }

            return null;
        }

        public string LopAndScatterAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareLopAndScatterAcres);
            }

            return null;
        }

        public string BiomassRemovalAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareBiomassRemovalAcres);
            }

            return null;
        }

        public string HandPileAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareHandPileAcres);
            }

            return null;
        }

        public string HandPileBurnAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareHandPileBurnAcres);
            }

            return null;
        }

        public string MachinePileBurnAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareMachinePileBurnAcres);
            }

            return null;
        }

        public string BroadcastBurnAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareBroadcastBurnAcres);
            }

            return null;
        }

        public string OtherAcresColumnMapping()
        {
            if (GisUploadSourceOrganization != null)
            {
                return GetPossibleDefaultMetadataAttributeString(Models.FieldDefinition.GrantAllocationAwardLandownerCostShareOtherTreatmentAcres);
            }

            return null;
        }

    }
}
