﻿/*-----------------------------------------------------------------------
<copyright file="TestProjectNote.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectNote
        {
            public static ProjectNote Create()
            {
                var project = TestProject.Create();
                var projectNote = ProjectNote.CreateNewBlank(project);
                projectNote.Note = MakeTestProjectNoteString();
                projectNote.CreateDate = DateTime.Now;
                return projectNote;
            }

            public static ProjectNote Create(DatabaseEntities dbContext)
            {
                var project = TestProject.Create(dbContext);
                var projectNote = ProjectNote.CreateNewBlank(project);
                projectNote.Note = MakeTestProjectNoteString();
                projectNote.CreateDate = DateTime.Now;
                dbContext.ProjectNotes.Add(projectNote);
                return projectNote;
            }

            private static string MakeTestProjectNoteString()
            {
                return TestFramework.MakeTestName("TestProjectNote", ProjectNote.FieldLengths.Note);
            }
        }
    }
}
