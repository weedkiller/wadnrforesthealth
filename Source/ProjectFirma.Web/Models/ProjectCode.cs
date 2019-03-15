﻿using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectCode : IAuditableEntity
    {

        public string AuditDescriptionString => ProjectCodeAbbrev;

        public static List<ProjectCode> GetListProjectCodesFromStrings(string projectCodesStrings)
        {
            List<ProjectCode> projectCodes = new List<ProjectCode>();

            foreach (var code in projectCodesStrings.Split(',').Select(s => s.Trim()))
            {
                var foundCode = HttpRequestStorage.DatabaseEntities.ProjectCodes.SingleOrDefault(x => x.ProjectCodeAbbrev == code);
                if (foundCode != null)
                {
                    projectCodes.Add(foundCode);
                }
            }

            return projectCodes;
        }

    }
}