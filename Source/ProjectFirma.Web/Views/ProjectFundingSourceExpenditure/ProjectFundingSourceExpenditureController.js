﻿/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditureController.js" company="Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("ProjectFundingSourceExpenditureController", function ($scope, angularModelAndViewData)
{
    $scope.resetFundingSourceToAdd = function () { $scope.FundingSourceToAdd = ($scope.FromFundingSource) ? $scope.getFundingSource(angularModelAndViewData.AngularViewData.FundingSourceID) : null; };

    $scope.resetProjectToAdd = function () { $scope.ProjectToAdd = ($scope.FromProject) ? $scope.getProject(angularModelAndViewData.AngularViewData.ProjectID) : null; };

    $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray = function() { return _($scope.AngularModel.ProjectFundingSourceExpenditures).pluck("CalendarYearExpenditures").flatten(); }

    $scope.getAllUsedCalendarYears = function () {
        return $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray().pluck("CalendarYear").flatten().union().sortBy().value();
    };

    $scope.getCalendarYearRange = function () {
        return _.union($scope.getAllUsedCalendarYears(), angularModelAndViewData.AngularViewData.CalendarYearRange);
    };

    $scope.getAllUsedFundingSourceIds = function () {
        return _.map($scope.AngularModel.ProjectFundingSourceExpenditures, function (p) { return p.FundingSourceID; });
    };

    $scope.filteredFundingSources = function () {
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIds();
        var projectFundingOrganizationFundingSourceIDs = _.map($scope.AngularViewData.AllFundingSources, function (p) { return p.FundingSourceID; });
        if ($scope.ShowOnlyProjectFunders) {
            projectFundingOrganizationFundingSourceIDs = $scope.AngularViewData.ProjectFundingOrganizationFundingSourceIDs;
        }
        return _($scope.AngularViewData.AllFundingSources).filter(function (f) { return f.IsActive && _.contains(projectFundingOrganizationFundingSourceIDs, f.FundingSourceID) && !_.contains(usedFundingSourceIDs, f.FundingSourceID); }).sortByAll(["OrganizationName", "FundingSourceName"]).value();
    };

    $scope.getAllUsedProjectIds = function () {
        return _.map($scope.AngularModel.ProjectFundingSourceExpenditures, function (p) { return p.ProjectID; });
    };

    $scope.filteredProjects = function () {
        var usedProjectIDs = $scope.getAllUsedProjectIds();
        return _($scope.AngularViewData.AllProjects).filter(function (f) { return !_.contains(usedProjectIDs, f.ProjectID); }).sortBy(["DisplayName"]).value();
    };

    $scope.getProjectName = function (projectFundingSourceExpenditure)
    {
        var projectToFind = $scope.getProject(projectFundingSourceExpenditure.ProjectID);
        return projectToFind.DisplayName;
    };

    $scope.getProject = function (projectId) {
        return _.find($scope.AngularViewData.AllProjects, function (f) { return projectId == f.ProjectID; });
    };

    $scope.getFundingSourceName = function (projectFundingSourceExpenditure) {
        var fundingSourceToFind = $scope.getFundingSource(projectFundingSourceExpenditure.FundingSourceID);
        return fundingSourceToFind.DisplayName;
    };

    $scope.getFundingSource = function (fundingSourceId) {
        return _.find($scope.AngularViewData.AllFundingSources, function (f) { return fundingSourceId == f.FundingSourceID; });
    };

    $scope.getExpenditureTotalForCalendarYear = function (calendarYear)
    {
        var calendarYearExpendituresAsFlattenedArray = $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray().filter(function (pfse) { return Sitka.Methods.isUndefinedNullOrEmpty(calendarYear) || pfse.CalendarYear == calendarYear; }).value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.getExpenditureTotalForRow = function (projectFundingSourceExpenditure)
    {
        var calendarYearExpendituresAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceExpenditures).filter(function(pfse) { return pfse.ProjectID == projectFundingSourceExpenditure.ProjectID && pfse.FundingSourceID == projectFundingSourceExpenditure.FundingSourceID; }).pluck("CalendarYearExpenditures").flatten().value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.calculateExpenditureTotal = function (expenditures) { return _.reduce(expenditures, function (m, x) { return m + x.MonetaryAmount; }, 0); }

    $scope.addCalendarYear = function (calendarYear) {
        if (Sitka.Methods.isUndefinedNullOrEmpty(calendarYear)) {
            return;
        }
        if ($scope.FromProject)
        {
            _.each($scope.getAllUsedFundingSourceIds(), function (fundingSourceId) {
                $scope.addCalendarYearExpenditureRow($scope.ProjectToAdd.ProjectID, fundingSourceId, calendarYear);
            });
        }
        else if ($scope.FromFundingSource) {
            _.each($scope.getAllUsedProjectIds(), function (projectId) {
                $scope.addCalendarYearExpenditureRow(projectId, $scope.FundingSourceToAdd.FundingSourceID, calendarYear);
            });
        }
    };

    $scope.findProjectFundingSourceExpenditureRow = function(projectId, fundingSourceId) { return _.find($scope.AngularModel.ProjectFundingSourceExpenditures, function(pfse) { return pfse.ProjectID == projectId && pfse.FundingSourceID == fundingSourceId; }); }

    $scope.addRow = function()
    {
        if (($scope.FundingSourceToAdd == null) || ($scope.ProjectToAdd == null))
        {
            return;
        }
        var newProjectFundingSourceExpenditure = $scope.createNewRow($scope.ProjectToAdd.ProjectID, $scope.FundingSourceToAdd.FundingSourceID, $scope.getCalendarYearRange());
        $scope.AngularModel.ProjectFundingSourceExpenditures.push(newProjectFundingSourceExpenditure);
        $scope.resetFundingSourceToAdd();
        $scope.resetProjectToAdd();
    };

    $scope.createNewRow = function (projectId, fundingSourceId, calendarYearsToAdd)
    {
        var newProjectFundingSourceExpenditure = {
            ProjectID: projectId,
            FundingSourceID: fundingSourceId,
            CalendarYearExpenditures: _.map(calendarYearsToAdd, $scope.createNewCalendarYearExpenditureRow)
        };
        return newProjectFundingSourceExpenditure;
    };

    $scope.addCalendarYearExpenditureRow = function (projectId, fundingSourceId, calendarYear) {
        var projectFundingSourceExpenditure = $scope.findProjectFundingSourceExpenditureRow(projectId, fundingSourceId);
        if (!Sitka.Methods.isUndefinedNullOrEmpty(projectFundingSourceExpenditure)) {
            projectFundingSourceExpenditure.CalendarYearExpenditures.push($scope.createNewCalendarYearExpenditureRow(calendarYear));
        }
    };

    $scope.createNewCalendarYearExpenditureRow = function (calendarYear) {
        return {
            CalendarYear: calendarYear,
            ExpenditureAmount: null
        };
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectFundingSourceExpenditures, rowToDelete);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.FromFundingSource = angularModelAndViewData.AngularViewData.FromFundingSource;
    $scope.FromProject = !$scope.FromFundingSource;
    $scope.ShowOnlyProjectFunders = false;
    $scope.resetFundingSourceToAdd();
    $scope.resetProjectToAdd();
});

