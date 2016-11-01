'use strict';

angular.module('Tothdev.Placemap.UI')
    .directive('placemapActionbar', function () {
        return {
            templateUrl: 'app/controllers/place/placemap-actionbar.html?v=1',
            restrict: 'EA',
            scope: {
                "currentStep": "="
            },
            link: function (scope, element, attrs, ctrl) {
                scope.showRightBar = function (bool) {
                    ctrl.showRightBar(bool);
                }

            },
            controller: function ($scope,  $rootScope) {

                var vm = this;

                $rootScope.$on('placeReady', function (junk, place) {
                    vm.place = place;
                    console.log(vm.place);
                });



                $rootScope.$on('markerDrag', function (junk, marker) {
                    vm.markerDragged = true;
                });



                vm.getStarted = function () {
                    //MapService.showPointer(true);
                    $scope.currentStep.starting = false;
                    $scope.currentStep.placing = true;
                    $rootScope.$broadcast('stepChange', $scope.currentStep);
               

                }

                vm.confirmPlacement = function () {
                   // MapService.pointer.toggleAnimation(false);
                   // MapService.pointer.options.draggable = false;
                    $scope.currentStep.placing = false;
                    $scope.currentStep.ranking = true;

                    $rootScope.$broadcast('stepChange', $scope.currentStep);
                };



                $rootScope.$on('selectLocation', function () {
                    //MapService.pointer.toggleAnimation(true);
                    //MapService.pointer.options.draggable = true;
                    $scope.currentStep.placing = true;
                    $scope.currentStep.ranking = false;

                    $scope.showRightBar(false);
                });


            },//end controller,
            controllerAs: 'vm'
        };
    });