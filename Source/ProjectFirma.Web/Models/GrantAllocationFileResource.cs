﻿using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class GrantAllocationFileResource : IAuditableEntity, IEntityDocument
    {
        public string AuditDescriptionString => $"{Models.FieldDefinition.Grant.GetFieldDefinitionLabel()}  \" {GrantAllocation?.GrantAllocationName ?? "<Not Found>"}\" document \"{FileResource?.OriginalCompleteFileName ?? "<Not Found>"}\"";
        public string DeleteUrl
        {
            get
            {
                return SitkaRoute<GrantAllocationController>.BuildUrlFromExpression(x =>
                    x.DeleteGrantAllocationFile(GrantAllocationFileResourceID));
            }
        }
        public string EditUrl
        {
            get
            {
                return string.Empty;
            }
        }
        public string DisplayCssClass { get; set; }
    }
}