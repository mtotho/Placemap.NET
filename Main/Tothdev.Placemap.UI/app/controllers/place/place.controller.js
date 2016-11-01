(function () {
    'use strict';

angular.module('Tothdev.Placemap.UI')
    .controller('PlaceCtrl', function ($rootScope, $scope, $http, $stateParams, Configuration, uiGmapGoogleMapApi) {
        var vm = this;
        var AppVm = $scope.$parent.AppVm;
        
        var PlaceKey = $stateParams.PlaceKey;

        $scope.PlaceViewModel = null;
        vm.ShowFeedbackArea = false;

        var _init = function () {

            $scope.currentStep = {
                "starting": true,
                "placing": false,
                "ranking": false
            }

            angular.map_resize();
            $scope.map = {
                center:
                {
                    latitude: 40.748817,
                    longitude: -73.985428
                },
                zoom: 13,
                control: {},
                options: {

                },
                markersControl: {}
            };

            $scope.pointer = {
                id: "pointer",
                coords: {
                    latitude: 40.733973,
                    longitude: -73.986695
                },
                options: {
                    draggable: true,
                    visible: true,
                    animation: null
                },
                events: {
                    drag: function (marker) {
                        //console.log(marker.getPosition());
                       $rootScope.$broadcast('markerDrag', marker);
                    }
                },
                control: {},
                toggleAnimation: function (bool) {
                    uiGmapGoogleMapApi.then(function (maps) {

                        if (!bool) {
                            $scope.pointer.options.animation = null;
                        } else {
                            $scope.pointer.options.animation = maps.Animation.BOUNCE;
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

            $rootScope.$on('stepChange', function (junk, step) {
                console.log(step);
                if (step.placing) {
                    showPointer(true);
                    vm.ShowFeedbackArea = false;
                }
              
                if (step.ranking) {
                    showPointer(false);
                    vm.ShowFeedbackArea = true;
                }
            });



            $http({
                method: 'GET',
                url: Configuration.backend + '/vm/Place/GetViewModel?PlaceKey=' + PlaceKey
            }).then(function (response) {
                $scope.PlaceViewModel = response.data;

                $scope.map.center = {
                    latitude: $scope.PlaceViewModel.Place.Latitude,
                    longitude: $scope.PlaceViewModel.Place.Longitude
                };
                showPointer(false);
                $scope.map.zoom = $scope.PlaceViewModel.Place.DefaultZoom;
                console.log($scope.PlaceViewModel);
            }, function (response) {

            });
        };
     
         _init();
    });



angular.map_resize = function (offset) {
    //var headerheight = $("#header").outerHeight();
    //var mapbarheight = $("map-action-bar md-toolbar").outerHeight();
    var windowheight = $(window).outerHeight();

    var targetheight = windowheight;// - (headerheight + mapbarheight);

    if (offset) {
        targetheight = targetheight - offset;
    }

    $("#placemap .angular-google-map-container").css('height', targetheight + 'px');
    $(".full-height").css('height', targetheight + 'px');

}

$(window).resize(function () {
    angular.map_resize()
});

})();