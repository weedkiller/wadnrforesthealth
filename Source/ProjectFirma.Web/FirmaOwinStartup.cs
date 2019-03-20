﻿using ProjectFirma.Web;
using Microsoft.Owin;
using Owin;
using ProjectFirma.Web.ScheduledJobs;

// This is how Owin figures out the class to call on startup
[assembly: OwinStartupAttribute(typeof(FirmaOwinStartup))]

namespace ProjectFirma.Web
{
    /// <summary>
    /// Owin Startup for Corral
    /// </summary>
    public partial class FirmaOwinStartup
    {
        /// <summary>
        /// Function required by <see cref="OwinStartupAttribute"/>
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            ScheduledBackgroundJobBootstrapper.ConfigureHangfireAndScheduledBackgroundJobs(app);
            ConfigureAuth(app);
        }
    }
}
