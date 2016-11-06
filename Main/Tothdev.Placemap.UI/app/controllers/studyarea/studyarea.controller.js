(function () {
    'use strict';

    angular.module('Tothdev.Placemap.UI')
        .controller('StudyAreaCtrl', function ($rootScope, $scope, $http, $stateParams, $timeout, Configuration, uiGmapGoogleMapApi) {
            var vm = this;
         
            var AppVm = $scope.$parent.AppVm;
        

            var PlaceKey = $stateParams.PlaceKey;
            vm.PlaceKey = PlaceKey;

            vm.GoogleReady = false;
            uiGmapGoogleMapApi.then(function () {
                vm.GoogleReady = true;
                //  angular.map_resize();
            });

            $scope.PlaceViewModel = null;

            var _init = function () {
                angular.map_resize(80);
                $scope.map = {
                    center:
                    {
                        latitude: 40.748817,
                        longitude: -73.985428
                    },
                    zoom: 3,
                    control: {},
                    options: {

                    },
                    markersControl: {}
                };
            };

            $scope.mapControl = {};
            $http({
                method: 'GET',
                url: Configuration.backend + '/vm/Place/GetViewModel?PlaceKey=' + PlaceKey
            }).then(function (response) {

                var viewmodel = response.data;

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
                    });
                }, 100);
               
                $scope.map.zoom = viewmodel.Place.DefaultZoom;
                $scope.PlaceViewModel = viewmodel;
                AppVm.PlaceName = viewmodel.Place.Name;
                angular.map_resize(80);
                console.log($scope.PlaceViewModel);
            }, function (response) {

            });

            _init();
        });

})();