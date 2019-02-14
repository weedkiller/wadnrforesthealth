﻿/*-----------------------------------------------------------------------
<copyright file="EditProject.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Views.Shared.GrantAllocationControls;

namespace ProjectFirma.Web.Views.GrantAllocation
{
    public abstract class EditGrantAllocationNote : TypedWebPartialViewPage<EditGrantAllocationNoteViewData, EditGrantAllocationNoteViewModel>
    {
    }

    public abstract class EditGrantAllocationNoteType
    {
        public readonly string IntroductoryText;

        internal EditGrantAllocationNoteType(string introductoryText)
        {
            IntroductoryText = introductoryText;
        }

        public static readonly EditGrantAllocationNoteTypeNewNote NewNote = EditGrantAllocationNoteTypeNewNote.Instance;
        public static readonly EditGrantAllocationNoteTypeExistingNote ExistingGrantAllocationNote = EditGrantAllocationNoteTypeExistingNote.Instance;
    }

    public class EditGrantAllocationNoteTypeNewNote : EditGrantAllocationNoteType
    {
        private EditGrantAllocationNoteTypeNewNote(string introductoryText) : base(introductoryText)
        {
        }

        public static readonly EditGrantAllocationNoteTypeNewNote Instance = new EditGrantAllocationNoteTypeNewNote(
            $"<p>Enter a new {Models.FieldDefinition.GrantAllocationNote.GetFieldDefinitionLabel()}.</p>");
    }

    public class EditGrantAllocationNoteTypeExistingNote : EditGrantAllocationNoteType
    {
        private EditGrantAllocationNoteTypeExistingNote(string introductoryText) : base(introductoryText)
        {
        }

        public static readonly EditGrantAllocationNoteTypeExistingNote Instance =
            new EditGrantAllocationNoteTypeExistingNote(
                $"<p>Update this {Models.FieldDefinition.GrantNote.GetFieldDefinitionLabel()}.</p>");
    }

    
}
