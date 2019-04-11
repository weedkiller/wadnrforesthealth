﻿
angular.module("ProjectFirmaApp")
    .controller("ProjectMapController",
    function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;
            $scope.selectedLocationLeafletID = null;
        
            $scope.IconStyleDefault = new L.icon({
                iconUrl: 'https://api.tiles.mapbox.com/v3/marker/pin-m-marker+0000ff.png'
            });
            $scope.IconStyleSelected = new L.icon({
                iconUrl: 'https://api.tiles.mapbox.com/v3/marker/pin-m-marker+fff200.png'
            });


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

        $scope.isSelectedProjectLocation = function (projectLocation) {
            if ($scope.selectedLocationLeafletID) {
                return $scope.selectedLocationLeafletID == projectLocation.ProjectLocationLeafletID;
            }
            return false;
        };

        $scope.toggleProjectLocationDetails = function (locationLeafletID) {
            $scope.selectedLocationLeafletID = locationLeafletID;
            console.log('toggleProjectLocationDetails passed in leafletID :' + locationLeafletID);
            projectFirmaMap.projectLocationsLayer.eachLayer(function (layer) {
                var currentLocationLeafletID = layer._leaflet_id;
                if ($scope.selectedLocationLeafletID == currentLocationLeafletID) {
                    if (layer._icon) {
                        layer.setIcon($scope.IconStyleSelected);
                    } else {
                        layer.setStyle({
                            color: '#fff200',
                            fillColor: '#fff200',
                            weight: 6,
                            opacity: 0.6
                        });
                    }
                    
                } else {
                    if (layer._icon) {
                        layer.setIcon($scope.IconStyleDefault);
                    } else {
                        layer.setStyle({
                            color: '#02ffff',
                            fillColor: '#02ffff',
                            weight: 3,
                            opacity: 0.6
                        });
                    }
                }
            });
        };

        var bindProjectLocationSelectClickEvent = function (feature, layer) {
            var leafletID = layer._leaflet_id;
            layer.on('click', function (f) {
                if (layer.editing.enabled()) {
                    return;
                }

                $scope.$apply(function () {
                    $scope.selectedLocationLeafletID = leafletID;
                });
                $scope.toggleProjectLocationDetails(leafletID);
            });
        };


        var initializeMap = function () {
                console.log('initializeMap');
                var mapInitJson = $scope.AngularViewData.MapInitJson;
                var layerGeoJsonObject = $scope.AngularViewData.LayerGeoJson;

                var x = 0;
                

            jQuery.each(projectFirmaMap.projectLocationsLayer._layers, function(index, layer) {
                if (!layer.getLayers) {
                    $scope.AngularViewData.ProjectLocationJsons[x].ProjectLocationLeafletID = layer._leaflet_id;//hacky way to get leaflet_ids tied to locations on grid
                    bindProjectLocationSelectClickEvent(layer.feature, layer);
                    x++;
                }
            });

        };


        jQuery(document).ready(function() {
            initializeMap();
        });

    });



