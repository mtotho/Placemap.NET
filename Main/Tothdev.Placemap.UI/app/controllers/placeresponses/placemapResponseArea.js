'use strict';

angular.module('Tothdev.Placemap.UI')
    .directive('placemapResponseArea', function () {
        return {
            templateUrl: 'app/controllers/placeresponses/placemap-response-area.html?v=5',
            restrict: 'EA',
            scope: {
                "selectedResponse": "="
            },
            link: function (scope, element, attrs, ctrl) {
                scope.showRightBar = function () {
                    ctrl.showRightBar();
                }

            },
            controller: function ($scope, $mdDialog, $rootScope, Configuration, $http) {

                var vm = this;

                vm.CurrentResponseAnswer = null;
                vm.ResponseAnswerIndex = 0;
                vm.responseAnswerCt = 0;
       
                $scope.$watch('selectedResponse', function () {
                    if (!angular.isUndefinedOrNull($scope.selectedResponse)) {
                        vm.responseAnswerCt = $scope.selectedResponse.Responses.length;
                        console.log($scope.selectedResponse);
                        if (vm.responseAnswerCt > 0) {
                            vm.CurrentResponseAnswer = $scope.selectedResponse.Responses[0];
                        }
                    }
                });


                vm.nextResponseAnswer = function (ev) {
                    if (vm.ResponseAnswerIndex < vm.responseAnswerCt) {
                        vm.ResponseAnswerIndex++;
                        vm.CurrentResponseAnswer = $scope.selectedResponse.Responses[vm.ResponseAnswerIndex];
                    }
                };

                vm.previousResponseAnswer = function () {
                    if (vm.ResponseAnswerIndex > 0) {
                        vm.ResponseAnswerIndex--;
                        vm.CurrentResponseAnswer = $scope.selectedResponse.Responses[vm.ResponseAnswerIndex];
                    }
                };

            },//end controller,
            controllerAs: 'vm'
        };
    });

function size_content() {

    var headerheight = $("#header").outerHeight();
    var mapbarheight = $("map-action-bar md-toolbar").outerHeight();
    var windowheight = $(window).outerHeight();

    var targetheight = windowheight - (headerheight + mapbarheight + 100 + 16 + 48);



    $("#feedback-question-content").css('height', targetheight + 'px');

}
$(window).resize(function () {
    //  size_content()
});