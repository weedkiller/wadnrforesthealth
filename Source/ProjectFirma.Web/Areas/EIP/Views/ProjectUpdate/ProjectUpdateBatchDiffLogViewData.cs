﻿using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class ProjectUpdateBatchDiffLogViewData
    {
        public readonly ProjectUpdateBatch ProjectUpdateBatch;

        public ProjectUpdateBatchDiffLogViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch)
        {
            ProjectUpdateBatch = projectUpdateBatch;
        }
    }
}