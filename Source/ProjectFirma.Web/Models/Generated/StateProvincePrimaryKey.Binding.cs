//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.StateProvince
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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