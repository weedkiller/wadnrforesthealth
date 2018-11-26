using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectGeospatialAreaUpdate : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var geospatialArea = GeospatialArea != null ? GeospatialArea.DisplayName : ViewUtilities.NotFoundString;
                var projectUpdate = ProjectUpdateBatch != null ? ProjectUpdateBatch.ProjectUpdate.DisplayName : ViewUtilities.NotFoundString;
                return $"GeospatialArea: {geospatialArea}, {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Update: {projectUpdate}";
            }
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            var projectGeospatialAreaUpdates = project.ProjectGeospatialAreas.Select(
                projectGeospatialAreaToClone => new ProjectGeospatialAreaUpdate(projectUpdateBatch, projectGeospatialAreaToClone.GeospatialArea)).ToList();
            projectUpdateBatch.ProjectGeospatialAreaUpdates = projectGeospatialAreaUpdates;
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectGeospatialArea> allProjectGeospatialAreas)
        {
            var project = projectUpdateBatch.Project;
            var currentProjectGeospatialAreas = project.ProjectGeospatialAreas.ToList();
            currentProjectGeospatialAreas.ForEach(projectGeospatialArea =>
            {
                allProjectGeospatialAreas.Remove(projectGeospatialArea);
            });
            currentProjectGeospatialAreas.Clear();

            if (projectUpdateBatch.ProjectGeospatialAreaUpdates.Any())
            {
                // Completely rebuild the list
                projectUpdateBatch.ProjectGeospatialAreaUpdates.ToList().ForEach(x =>
                {
                    var projectGeospatialArea = new ProjectGeospatialArea(project, x.GeospatialArea);
                    allProjectGeospatialAreas.Add(projectGeospatialArea);
                });
            }
        }
    }
}