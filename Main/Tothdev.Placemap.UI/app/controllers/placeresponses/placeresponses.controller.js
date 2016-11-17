(function () {
    'use strict';

angular.module('Tothdev.Placemap.UI')
    .controller('PlaceResponsesCtrl', function ($rootScope, $scope, $http, $stateParams,$timeout, Configuration, uiGmapGoogleMapApi) {
        var vm = this;
        var AppVm = $scope.$parent.AppVm;
        
        var PlaceKey = $stateParams.PlaceKey;

        vm.GoogleReady = false;
        uiGmapGoogleMapApi.then(function (maps) {
            vm.GoogleReady = true;
        });
        vm.ShowMarkerResponses = false;
        $scope.ResponsesViewModel = null;
     
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
       
            var icons = {
                "red": "http://maps.google.com/mapfiles/ms/icons/red-dot.png",
                "yellow": "http://maps.google.com/mapfiles/ms/icons/yellow-dot.png",
                "green": "http://maps.google.com/mapfiles/ms/icons/green-dot.png",
                "blue": "http://maps.google.com/mapfiles/ms/icons/blue-dot.png"
            };


            $scope.ResponseMarkers = [];
            $scope.mapControl = {};
            $http({
                method: 'GET',
                url: Configuration.backend + '/vm/Place/GetResponseViewModel?PlaceKey=' + PlaceKey
            }).then(function (response) {
           
                var viewmodel = response.data;
                AppVm.PlaceName = viewmodel.Place.Name;
                    
                $timeout(function () {
                    uiGmapGoogleMapApi.then(function (maps) {
                        $scope.mapControl.refresh();
                        $scope.map.center = {
                            latitude: viewmodel.Place.Latitude,
                            longitude: viewmodel.Place.Longitude
                        };
                        $scope.map.zoom = viewmodel.Place.DefaultZoom;
                        //showPointer(true);
                    });
                },100);

            

                $scope.ResponsesViewModel = viewmodel;
                angular.map_resize(80);
               
                vm.SelectedResponse = null;

                if ($scope.ResponsesViewModel.Responses.length > 0) {
                    for (var i = 0; i < $scope.ResponsesViewModel.Responses.length; i++) {
                        var response = $scope.ResponsesViewModel.Responses[i];
                        console.log(response);
                        $scope.ResponseMarkers.push({
                            id: response.Id,
                            responseObject:response,
                            coords: {
                                latitude: response.Latitude,
                                longitude: response.Longitude
                            },
                            click:function(e){
                                console.log(e);

                                if (vm.SelectedResponse == null || e.key != vm.SelectedResponse.Id) {

                                    if (vm.SelectedResponse != null) {
                                        var responseMarker = $scope.ResponseMarkers.filter(function (m) {
                                            return m.id == vm.SelectedResponse.Id;
                                        })[0];
                                        if (responseMarker)
                                            responseMarker.options.animation = null;
                                    }


                                    vm.SelectedResponse = {
                                        Id:e.key,
                                        Responses: e.model.responseObject.SurveyResponseAnswers
                                    };

                                    uiGmapGoogleMapApi.then(function (maps) {
                                        var responseMarker = $scope.ResponseMarkers.filter(function (m) {
                                            return m.id == e.key;
                                        })[0];
                                        responseMarker.options.animation = maps.Animation.BOUNCE;
                                     });


                                    vm.ShowMarkerResponses = true;
                                } else {

                                    var responseMarker = $scope.ResponseMarkers.filter(function (m) {
                                        return m.id == e.key;
                                    })[0];
                                    if(responseMarker)
                                        responseMarker.options.animation = null;
                                

                                    vm.SelectedResponse = null;
                                    vm.ShowMarkerResponses = false;
                                }
                               
                            },
                            options: {
                                icon: icons[response.MarkerColor],
                                draggable: false,
                                visible: true,
                                animation: null
                            },
                        });

                     
                    }
                    console.log($scope.ResponseMarkers);
                }

                console.log($scope.ResponsesViewModel);
            }, function (response) {

            });
        };
     
         _init();
    });


})();