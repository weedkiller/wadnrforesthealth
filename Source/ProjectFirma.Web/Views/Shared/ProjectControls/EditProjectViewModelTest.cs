﻿/*-----------------------------------------------------------------------
<copyright file="EditProjectViewModelTest.cs" company="Sitka Technology Group">
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
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    [TestFixture]
    public class EditProjectViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create();

            // Act
            var viewModel = new EditProjectViewModel(project, false);

            // Assert
            Assert.That(viewModel.ProjectID, Is.EqualTo(project.ProjectID));
            Assert.That(viewModel.ProjectName, Is.EqualTo(project.ProjectName));
            Assert.That(viewModel.ProjectDescription, Is.EqualTo(project.ProjectDescription));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create();
            var viewModel = new EditProjectViewModel(project, false);
            viewModel.ProjectName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProjectName), Models.Project.FieldLengths.ProjectName);
            viewModel.ProjectDescription = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProjectDescription), Models.Project.FieldLengths.ProjectDescription);
            viewModel.LeadImplementerOrganizationID = TestFramework.TestOrganization.Create().OrganizationID;

            // Act
            viewModel.UpdateModel(project);

            // Assert
            Assert.That(project.ProjectName, Is.EqualTo(viewModel.ProjectName));
            Assert.That(project.ProjectDescription, Is.EqualTo(viewModel.ProjectDescription));
        }
    }
}
