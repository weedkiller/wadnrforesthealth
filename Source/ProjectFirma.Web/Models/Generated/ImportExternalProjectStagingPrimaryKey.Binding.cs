//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ImportExternalProjectStaging
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ImportExternalProjectStagingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ImportExternalProjectStaging>
    {
        public ImportExternalProjectStagingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ImportExternalProjectStagingPrimaryKey(ImportExternalProjectStaging importExternalProjectStaging) : base(importExternalProjectStaging){}

        public static implicit operator ImportExternalProjectStagingPrimaryKey(int primaryKeyValue)
        {
            return new ImportExternalProjectStagingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ImportExternalProjectStagingPrimaryKey(ImportExternalProjectStaging importExternalProjectStaging)
        {
            return new ImportExternalProjectStagingPrimaryKey(importExternalProjectStaging);
        }
    }
}