using System.Web;
using Hangfire.Dashboard;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class HangfireFirmaWebAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            HttpRequestStorage.Person = ClaimsIdentityHelper.PersonFromClaimsIdentity(System.Web.Mvc.HttpContext.GetOwinContext().Authentication);

            // Due to jury-rigged way we do Person authentication, we have to trap for a possible error here.
            // This is really poor, but we'd need to overall session to make it right.  --SLG
            var person = HttpRequestStorage.PersonWithWrappedException;
            return person != null && person.IsAdministrator();
            //return true;
        }
    }
}
