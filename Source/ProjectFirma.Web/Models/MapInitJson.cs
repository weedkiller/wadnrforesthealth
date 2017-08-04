﻿/*-----------------------------------------------------------------------
<copyright file="MapInitJson.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
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

using System.Collections.Generic;
using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;

namespace ProjectFirma.Web.Models
{
    public class MapInitJson
    {
        public const int CoordinateSystemId = 4326;

        public string MapDivID;
        public BoundingBox BoundingBox;
        public int ZoomLevel;
        public List<LayerGeoJson> Layers;
        public readonly bool TurnOnFeatureIdentify;
        public bool AllowFullScreen = true;

        public MapInitJson(string mapDivID, int zoomLevel, List<LayerGeoJson> layers, BoundingBox boundingBox, bool turnOnFeatureIdentify)
        {
            MapDivID = mapDivID;
            ZoomLevel = zoomLevel;
            Layers = layers;
            BoundingBox = boundingBox;
            TurnOnFeatureIdentify = turnOnFeatureIdentify;
        }

        /// <summary>
        /// Summary maps with no editing should use this constructor
        /// </summary>
        public MapInitJson(string mapDivID, int zoomLevel, List<LayerGeoJson> layers, BoundingBox boundingBox) : this(mapDivID, zoomLevel, layers, boundingBox, true)
        {
        }

        public static List<LayerGeoJson> GetWatershedMapLayers()
        {
            return new List<LayerGeoJson> {Watershed.GetWatershedWmsLayerGeoJson("#90C3D4", 0.1m)};
        }

        public static List<LayerGeoJson> GetWatershedLayers(Watershed watershed, List<Project> projects)
        {
            var layerGeoJsons = new List<LayerGeoJson>
            {
                new LayerGeoJson(watershed.DisplayName, new List<Watershed> {watershed}.ToGeoJsonFeatureCollection(), "red", 1, LayerInitialVisibility.Show),
                Watershed.GetWatershedWmsLayerGeoJson("#59ACFF", 0.6m),
                new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - Simple", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show),
                new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show)
            };
            return layerGeoJsons;
        }

        public static List<LayerGeoJson> GetWatershedAndProjectLocationSimpleMapLayers(IProject project)
        {
            var layerGeoJsons = GetWatershedMapLayers();
            if (project.ProjectLocationPoint != null)
            {
                layerGeoJsons.Add(new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - Simple",
                    new FeatureCollection(new List<Feature>
                    {
                        DbGeometryToGeoJsonHelper.FromDbGeometry(project.ProjectLocationPoint)
                    }),
                    "#838383", 1, LayerInitialVisibility.Show));
            }
            return layerGeoJsons;
        }
    }
}
