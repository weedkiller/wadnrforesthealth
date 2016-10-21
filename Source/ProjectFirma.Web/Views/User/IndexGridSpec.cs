﻿using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.User
{
    public class IndexGridSpec : GridSpec<Person>
    {
        public IndexGridSpec()
        {
            Add("Last Name", a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.LastName), 100, DhtmlxGridColumnFilterType.Html);
            Add("First Name", a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.FirstName), 100, DhtmlxGridColumnFilterType.Html);
            Add("Email", a => a.Email, 200);
            Add("Organization", a => a.Organization.GetDisplayNameAsUrl(), 200);
            Add("Phone", a => a.Phone.ToPhoneNumberString(), 100);
            Add("Last Activity", a => a.LastActivityDate, 120);
            Add("Lake Tahoe Info Role", a => a.LTInfoRole.GetDisplayNameAsUrl(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Sustainability Role", a => a.SustainabilityRole.GetDisplayNameAsUrl(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("EIP Role", a => a.EIPRole.GetDisplayNameAsUrl(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Commodities Role", a => a.ParcelTrackerRole.GetDisplayNameAsUrl(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);            
            Add("Thresholds Role", a => a.ThresholdRole.GetDisplayNameAsUrl(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);            
            Add("Active?", a => a.IsActive.ToYesNo(), 75, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Receives LTInfo Emails?", a => a.ShouldReceiveSupportEmails(LTInfoArea.LTInfo.LTInfoAreaID).ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Receives EIP Emails?", a => a.ShouldReceiveSupportEmails(LTInfoArea.EIP.LTInfoAreaID).ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Receives Sustainability Emails?", a => a.ShouldReceiveSupportEmails(LTInfoArea.Sustainability.LTInfoAreaID).ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Receives Commodities Emails?", a => a.ShouldReceiveSupportEmails(LTInfoArea.ParcelTracker.LTInfoAreaID).ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Receives Thresholds Emails?", a => a.ShouldReceiveSupportEmails(LTInfoArea.Threshold.LTInfoAreaID).ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("# of Orgs as Primary Contact", a => a.PrimaryContactOrganizations.Count, 120);
        }
    }
}