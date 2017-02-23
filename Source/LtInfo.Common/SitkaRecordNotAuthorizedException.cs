﻿/*-----------------------------------------------------------------------
<copyright file="SitkaRecordNotAuthorizedException.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
namespace LtInfo.Common
{
    public class SitkaRecordNotAuthorizedException : SitkaDisplayErrorException
    {
        public SitkaRecordNotAuthorizedException(string objectTypeName, int id) : base(string.Format("You are not authorized to view {0} ID# {1}", objectTypeName, id)) {}
        public SitkaRecordNotAuthorizedException(string objectTypeName, string stringID) : base(string.Format("You are not authorized to view {0} {1}", objectTypeName, stringID)) { }
        public SitkaRecordNotAuthorizedException(string message) : base(message) { }
    }
}
