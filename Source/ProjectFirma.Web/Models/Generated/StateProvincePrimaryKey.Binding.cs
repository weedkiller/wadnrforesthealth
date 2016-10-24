//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.StateProvince
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class StateProvincePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<StateProvince>
    {
        public StateProvincePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public StateProvincePrimaryKey(StateProvince stateProvince) : base(stateProvince){}

        public static implicit operator StateProvincePrimaryKey(int primaryKeyValue)
        {
            return new StateProvincePrimaryKey(primaryKeyValue);
        }

        public static implicit operator StateProvincePrimaryKey(StateProvince stateProvince)
        {
            return new StateProvincePrimaryKey(stateProvince);
        }
    }
}