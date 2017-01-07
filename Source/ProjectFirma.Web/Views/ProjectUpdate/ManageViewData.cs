﻿using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ManageViewData : FirmaViewData
    {
        public readonly int ReportingYear;

        public readonly ProjectUpdateStatusGridSpec ProjectsRequiringUpdateGridSpec;
        public readonly string ProjectsRequiringUpdateGridName;
        public readonly string ProjectsRequiringUpdateGridDataUrl;

        public readonly PeopleReceivingReminderGridSpec PeopleReceivingReminderGridSpec;
        public readonly string PeopleReceivingReminderGridName;
        public readonly string PeopleReceivingReminderGridDataUrl;

        public readonly int ProjectsWithNoContactCount;

        public ManageViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            string customNotificationUrl,
            ProjectUpdateStatusGridSpec projectsRequiringUpdateGridSpec,
            string projectsRequiringUpdateGridDataUrl,
            PeopleReceivingReminderGridSpec peopleReceivingReminderGridSpec,
            string peopleReceivingReminderGridDataUrl, int projectsWithNoContactCount) : base(currentPerson, firmaPage, false)
        {
            var reportingYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            PageTitle = string.Format("Project Update Notifications for Reporting Year: {0}", reportingYear);
            ReportingYear = reportingYear;

            ProjectsRequiringUpdateGridDataUrl = projectsRequiringUpdateGridDataUrl;
            ProjectsRequiringUpdateGridSpec = projectsRequiringUpdateGridSpec;
            ProjectsRequiringUpdateGridName = "projectsRequiringAnUpdateGrid";

            PeopleReceivingReminderGridDataUrl = peopleReceivingReminderGridDataUrl;
            ProjectsWithNoContactCount = projectsWithNoContactCount;
            PeopleReceivingReminderGridSpec = peopleReceivingReminderGridSpec;
            PeopleReceivingReminderGridName = "peopleReceivingAnReminderGrid";

            var getPersonIDFunctionString = string.Format("function() {{ return Sitka.{0}.getValuesFromCheckedGridRows({1}, '{2}', '{3}'); }}",
                PeopleReceivingReminderGridName,
                0,
                "PersonID",
                "PersonIDList");


            var modalDialogFormLink = ModalDialogFormHelper.ModalDialogFormLink("<span class=\"glyphicon glyphicon-envelope\" style=\"margin-right:5px\"></span>Send Notification to Selected People",
                customNotificationUrl,
                "Send Notification to Selected People",
                700,
                "Send",
                "Cancel",
                new List<string>(),
                null,
                getPersonIDFunctionString);

            PeopleReceivingReminderGridSpec.ArbitraryHtml = new List<string> {modalDialogFormLink.ToString()};
        }
    }
}