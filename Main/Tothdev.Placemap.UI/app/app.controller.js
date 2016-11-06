'use strict';

angular.module('Tothdev.Placemap.UI')
    .controller('AppCtrl', function ($rootScope, $scope, $state, $stateParams) {
        var vm = this;
        vm.PlaceName = "";

        $rootScope.$on("$stateChangeSuccess", function (event, toState, toParams, fromState, fromParams) {

            vm.CurrentState = toState;


            console.log(toState);

        });

    });

