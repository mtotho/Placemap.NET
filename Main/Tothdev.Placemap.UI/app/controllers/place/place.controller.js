(function () {
    'use strict';

angular.module('Tothdev.Placemap.UI')
    .controller('PlaceCtrl', function ($rootScope, $scope, $http, $stateParams,$timeout, Configuration, uiGmapGoogleMapApi) {
        var vm = this;
        var AppVm = $scope.$parent.AppVm;
        
        var PlaceKey = $stateParams.PlaceKey;

        vm.GoogleReady = false;
        uiGmapGoogleMapApi.then(function (maps) {
            vm.GoogleReady = true;
            //  angular.map_resize();
          
        });

        $scope.PlaceViewModel = null;
        vm.ShowFeedbackArea = false;
        $scope.mapControl = null;
        var _init = function () {

            $scope.currentStep = {
                "starting": false,
                "placing": true,
                "ranking": false
            }

            angular.map_resize(80);
            $scope.map = {
                center:
                {
                    latitude: 40.748817,
                    longitude: -73.985428
                },
                zoom: 3,
                control: {},
                refresh:true,
                options: {

                },
                markersControl: {}
            };
            //$timeout(function () {
            //    uiGmapGoogleMapApi.then(function (maps) {
            //        //  angular.map_resize();
            //        maps.event.trigger($scope.map.control.getGMap(), 'resize')
            //    });
            //},100);
            $scope.pointer = {
                id: "pointer",
                coords: {
                    latitude: 40.733973,
                    longitude: -73.986695
                },
                options: {
                    draggable: true,
                    visible: false,
                    animation: null
                },
                events: {
                    drag: function (marker) {
                        //console.log(marker.getPosition());
                       $rootScope.$broadcast('markerDrag', marker);
                    }
                },
                toggleAnimation: function (bool) {
                    uiGmapGoogleMapApi.then(function (maps) {

                        if (!bool) {
                            $scope.pointer.options.animation = null;
                            $scope.pointer.options.draggable = false;
                        } else {
                            $scope.pointer.options.animation = maps.Animation.BOUNCE;
                            $scope.pointer.options.draggable = true;
                        }
                    });
                }

            }

            var showPointer = function (bool) {
                if (bool) {
                    $scope.pointer.coords = {
                        latitude: $scope.map.center.latitude,
                        longitude: $scope.map.center.longitude
                    };
                    $scope.pointer.toggleAnimation(true);

                } else {

                }
                $scope.pointer.options.visible = bool;
            }

            var confirmedAtLeastOnce = false;
            $rootScope.$on('stepChange', function (junk, step) {
                console.log(step);


                if (step.placing) {
                    showPointer(true);
                    vm.ShowFeedbackArea = false;

                    //$scope.map.zoom = 20;

                    if (confirmedAtLeastOnce) {
                        $scope.map.zoom = $scope.map.zoom - 2;
                    }
                }
              
                if (step.ranking) { //marker placement confirmed
                    $scope.pointer.toggleAnimation(false);
                    vm.ShowFeedbackArea = true;
                    confirmedAtLeastOnce = true;
                    $timeout(function () {
                        $scope.map.center = {
                            latitude: $scope.pointer.coords.latitude,
                            longitude: $scope.pointer.coords.longitude
                        };
                        $scope.map.zoom = 20;

                    }, 200);
                }
            });

            $scope.ResponseMarkers = [];
            $scope.mapControl = {};
            $http({
                method: 'GET',
                url: Configuration.backend + '/vm/Place/GetViewModel?PlaceKey=' + PlaceKey
            }).then(function (response) {
           
                var viewmodel = response.data;
                AppVm.PlaceName = viewmodel.Place.Name;
                for (var i = 0; i < viewmodel.Place.PlacemapSurvey.SurveyItems.length; i++) {
                    var item = viewmodel.Place.PlacemapSurvey.SurveyItems[i];
                    if (item.OptionJson) {
                        item.Options = angular.fromJson(item.OptionJson);
                    }
                } 
                    
                $timeout(function () {
                    uiGmapGoogleMapApi.then(function (maps) {
                        $scope.mapControl.refresh();
                        $scope.map.center = {
                            latitude: viewmodel.Place.Latitude,
                            longitude: viewmodel.Place.Longitude
                        };
                        showPointer(true);
                    });
                },100);

            
                $scope.map.zoom = viewmodel.Place.DefaultZoom;
                $scope.PlaceViewModel = viewmodel;
                angular.map_resize(80);
               

                if ($scope.PlaceViewModel.Place.ShowResponses) { 
                    for (var i = 0; i < $scope.PlaceViewModel.Responses.length; i++) {
                        var response = $scope.PlaceViewModel.Responses[i];

                        $scope.ResponseMarkers.push({
                            id: response.Id,
                            coords: {
                                latitude: response.Latitude,
                                longitude: response.Longitude
                            },
                            options: {
                                icon:'http://maps.google.com/mapfiles/ms/icons/blue-dot.png',
                                draggable: false,
                                visible: true,
                                animation: null
                            },
                        });

                     
                    }
                    console.log($scope.ResponseMarkers);
                }

                console.log($scope.PlaceViewModel);
            }, function (response) {

            });
        };
     
         _init();
    });


})();