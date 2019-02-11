﻿
angular.module("ProjectFirmaApp")
    .controller("ProjectLocationDetailController",
    function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;
            $scope.hasGeospatialAreaTypeLayers = $scope.AngularViewData.GeospatialAreaMapServiceLayerNames.length > 0;
            $scope.GeospatialAreaMapServiceLayerNamesCommaSeparated =
                $scope.AngularViewData.GeospatialAreaMapServiceLayerNames.join(",");


            $scope.selectedStyle = {
                fillColor: "#FFFF00",
                fill: true,
                fillOpacity: 0.2,
                color: "#FFFF00",
                weight: 5,
                stroke: true
            };

            $scope.unselectedStyle = {
                fillColor: "#405d74",
                fill: true,
                fillOpacity: 0.2,
                color: "#405d74",
                weight: 1,
                stroke: true
        };

        var createProjectLocationJson = function (wellKnownText, projectLocationId, featureType, locationTypeId, locationName, leafletID) {
            return {
                ProjectLocationGeometryWellKnownText: wellKnownText,
                ProjectLocationID: projectLocationId,
                ProjectLocationFeatureType: featureType,
                ProjectLocationTypeID: locationTypeId,
                ProjectLocationName: locationName,
                ProjectLocationLeafletID: leafletID
            };
        };

        var addFeatureToAngularModel = function (newestGeoJson, newestLeafletID, featureTypeName) {
            console.log('addFeatureToAngularModel');
            //debugger;
            //Terraformer.WKT.convert(geoJson.features[i].geometry)
            //var wkt = Terraformer.WKT.convert(feature.geometry);

            var locationJson = createProjectLocationJson(newestGeoJson, -1, featureTypeName, -1, '', newestLeafletID);
            $scope.AngularModel.ProjectLocationJsons.push(locationJson);
            $scope.$apply();
        };

        $scope.deleteProjectLocationRowAndRefreshMap = function (projectLocationLeafletID) {
            //debugger;
            console.log("inside deleteProjectLocationRowAndRefreshMap: " + projectLocationLeafletID);
            var layer = projectFirmaMap.editableFeatureGroup.getLayer(projectLocationLeafletID);
            projectFirmaMap.editableFeatureGroup.removeLayer(layer);//remove from map

            _.remove($scope.AngularModel.ProjectLocationJsons, function(n) {
                return n.ProjectLocationLeafletID == projectLocationLeafletID;
            });
            $scope.$apply();//added because the grid would not update after delete on map was used.
        };


        /*
         * ToDo for JJV / whomever
         *
         *
         * - Have yet to touch upload GDB yet at all. It might be working already, we just haven't tested at all. From the card "Uploading a GDB
         * should append features, not delete and replace the features"
         *
         * - Highlighting selected grid row and associated feature with same color needs to happen
         *
         *
         * -- TK & SLG -- 2/5/2019 - 5:20 PM
         * 
         *
         */



        var initializeMap = function () {
                console.log('initializeMap');
                var mapInitJson = $scope.AngularViewData.MapInitJson;
                var editableFeatureJsonObject = $scope.AngularViewData.EditableLayerGeoJson;
                projectFirmaMap = new ProjectFirmaMaps.Map(mapInitJson);

                projectFirmaMap.editableFeatureGroup = new L.FeatureGroup();
                console.log(editableFeatureJsonObject.GeoJsonFeatureCollection);

                var x = 0;
                var layerGroup = L.geoJson(editableFeatureJsonObject.GeoJsonFeatureCollection, {
                    onEachFeature: function (feature, layer) {
                        if (layer.getLayers) {
                            layer.getLayers().forEach(function (l) { projectFirmaMap.editableFeatureGroup.addLayer(l); });//might not be hit
                        }
                        else {
                            projectFirmaMap.editableFeatureGroup.addLayer(layer);
                            $scope.AngularModel.ProjectLocationJsons[x].ProjectLocationLeafletID = layer._leaflet_id;//hacky way to get leaflet_ids tied to locations on grid
                            x++;
                        }
                       
                    }
                });

                var drawOptions = getDrawOptions(projectFirmaMap.editableFeatureGroup);
                var drawControl = new L.Control.Draw(drawOptions);
                projectFirmaMap.map.addControl(drawControl);
                projectFirmaMap.map.addLayer(projectFirmaMap.editableFeatureGroup);

                projectFirmaMap.map.on('draw:created', function (e) {
                    
                    var layer = e.layer;
                    projectFirmaMap.editableFeatureGroup.addLayer(layer);
                    var leafletId = layer._leaflet_id;
                    console.log('draw:created called: ' + leafletId);
                    console.log(layer);
                    projectFirmaMap.editableFeatureGroup._layers[leafletId].feature = new Object();
                    projectFirmaMap.editableFeatureGroup._layers[leafletId].feature.properties = new Object();
                    projectFirmaMap.editableFeatureGroup._layers[leafletId].feature.type = "Feature";

                    var allGeoJson = projectFirmaMap.editableFeatureGroup.toGeoJSON();
                    var tempFeature = allGeoJson.features[allGeoJson.features.length - 1];
                    var newestGeoJson = Terraformer.WKT.convert(tempFeature.geometry);
                    console.log('draw:created tempFeature.geometry.type');
                    console.log(tempFeature.geometry.type);
                    //var feature = projectFirmaMap.editableFeatureGroup._layers[leafletId].feature;
                    //update grid with new drawing
                    addFeatureToAngularModel(newestGeoJson, leafletId, tempFeature.geometry.type.replace("LineString", "Line"));

                    console.log('end of draw:created location jsons: ');
                    console.log($scope.AngularModel.ProjectLocationJsons);

                });

                projectFirmaMap.map.on('draw:edited', function (e) {
                    console.log('draw:edited called');
                });

                projectFirmaMap.map.on('draw:deleted',
                    function(e) {
                        console.log('draw:deleted called');
                        //console.log('begin of draw:created location jsons: ');
                        //console.log($scope.AngularModel.ProjectLocationJsons);

                        //$scope.deleteProjectLocationRowAndRefreshMap(e.target._leaflet_id);
                        for (var layer in e.layers._layers) {
                            if (e.layers._layers.hasOwnProperty(layer)) {
                                console.log(layer);
                                $scope.deleteProjectLocationRowAndRefreshMap(layer);
                            }
                        }
                        //console.log('end of draw:deleted location jsons: ');
                        //console.log($scope.AngularModel.ProjectLocationJsons);

                });

            };

            initializeMap();

    });



