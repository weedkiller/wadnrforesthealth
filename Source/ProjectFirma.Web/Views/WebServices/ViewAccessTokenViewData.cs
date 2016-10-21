﻿using System;

namespace ProjectFirma.Web.Views.WebServices
{
    public class ViewAccessTokenViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Guid WebServiceAccessToken;
        public readonly string WebServicesListUrl;

        public ViewAccessTokenViewData(Guid webServiceAccessToken, string webServicesListUrl)
        {
            WebServiceAccessToken = webServiceAccessToken;
            WebServicesListUrl = webServicesListUrl;
        }
    }
}