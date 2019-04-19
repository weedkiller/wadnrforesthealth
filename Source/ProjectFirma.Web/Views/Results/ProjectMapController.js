﻿
angular.module("ProjectFirmaApp")
    .controller("ProjectMapController",
    function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;
            $scope.selectedLocationLeafletID = null;

            $scope.IconStyleSelected = new L.MakiMarkers.icon({ icon: "marker", color: "#fff200", size: "s" });


        $scope.isSelectedProjectMapLocation = function (projectLocation) {
            if ($scope.selectedLocationLeafletID) {
                return $scope.selectedLocationLeafletID == projectLocation.ProjectMapLocationLeafletID;
            }
            return false;
        };

        var setLayerIconColors = function () {
            projectFirmaMap.projectLocationsLayer.eachLayer(function (layer) {
                var currentLocationLeafletID = layer._leaflet_id;
                if ($scope.selectedLocationLeafletID == currentLocationLeafletID) {
                    if (layer._icon) {
                        layer.setIcon($scope.IconStyleSelected);
                    } else {
                        layer.setStyle({
                            color: '#fff200',
                            fillColor: '#fff200',
                            weight: 3,
                            opacity: 0.6
                        });
                    }
                } else {
                    if (layer._icon) {
                        var iconColor = layer.feature.properties.ProjectStageColor;
                        var icon = new L.MakiMarkers.icon({ icon: "marker", color: iconColor, size: "s" });
                        layer.setIcon(icon);
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

        $scope.toggleProjectMapLocationDetails = function (locationLeafletID) {
            $scope.selectedLocationLeafletID = locationLeafletID;
            //console.log('toggleProjectLocationDetails passed in leafletID :' + locationLeafletID);
            projectFirmaMap.projectLocationsLayer.eachLayer(function (layer) {
                var currentLocationLeafletID = layer._leaflet_id;
                if ($scope.selectedLocationLeafletID == currentLocationLeafletID) {
                    if (!Sitka.Methods.isUndefinedNullOrEmpty(layer.feature.properties.PopupUrl)) {
                        jQuery.get(layer.feature.properties.PopupUrl).done(function (data) {
                            layer._map.setView(layer._latlng);
                            layer._map.openPopup(L.popup({ maxWidth: 200 }).setLatLng(layer._latlng).setContent(data).openOn(layer._map));
                        });
                    }
                }
            });
            setLayerIconColors();
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
                setLayerIconColors();
            });
        };


        var initializeMap = function () {
            //console.log('initializeMap');

            var x = 0;
            jQuery.each(projectFirmaMap.projectLocationsLayer._layers, function(index, layer) {
                if (!layer.getLayers) {
                    $scope.AngularViewData.ProjectMapLocationJsons[x].ProjectMapLocationLeafletID = layer._leaflet_id;//hacky way to get leaflet_ids tied to locations on grid
                    bindProjectLocationSelectClickEvent(layer.feature, layer);
                    x++;
                }
            });

        };


        jQuery(document).ready(function() {
            initializeMap();
        });

        jQuery(document).on('change', ':checkbox.leaflet-control-layers-selector',
            function () {
                // This hardcoding is not great, but TK and SLG both can't see a better way.
                // This check at least will ensure that the control we looking for actually exists.
                if (jQuery(this).parents("div.leaflet-control-layers-overlays").find("span:contains('Mapped Projects')").length > 0) {
                    if (jQuery(this).siblings("span:contains(' Mapped Projects')").length > 0) {
                        var checkbox = jQuery(this);
                        if (checkbox.is(':checked')) {
                            jQuery('.mapGridContainer').show();
                        } else {
                            jQuery('.mapGridContainer').hide();
                        }
                    }
                } else {
                    alert("No 'Mapped Projects' layer found. Please contact an admin.");
                }
      
            });

    });



