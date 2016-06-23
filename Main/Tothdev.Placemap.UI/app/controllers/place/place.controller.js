(function () {
    'use strict';

angular.module('Tothdev.Placemap.UI')
    .controller('PlaceCtrl', function ($rootScope, $scope, $http, $stateParams, Configuration) {
        var vm = this;
        var AppVm = $scope.$parent.AppVm;
        
        var PlaceKey = $stateParams.PlaceKey;

        $scope.PlaceViewModel = null;

        var _init = function () {

            $http({
                method: 'GET',
                url: Configuration.backend + '/vm/Place/GetViewModel?PlaceKey=' + PlaceKey
            }).then(function (response) {
                $scope.PlaceViewModel = response.data;
                console.log($scope.PlaceViewModel);
            }, function (response) {

            });
        };
     
         _init();
    });

})();