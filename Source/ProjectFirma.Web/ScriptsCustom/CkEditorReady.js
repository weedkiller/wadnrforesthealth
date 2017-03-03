﻿/*-----------------------------------------------------------------------
<copyright file="CkEditorReady.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
CKEDITOR.disableAutoInline = true;

jQuery(document).ready(function ()
{
    jQuery("form").on("submit", function () {

        for (var i in CKEDITOR.instances)
        {
            var ckEditorForDiv = CKEDITOR.instances[i];
            var id = ckEditorForDiv.name;
            var ckEditorHtml = ckEditorForDiv.getData();
            jQuery("#" + id).val(ckEditorHtml);
        }
    });
});