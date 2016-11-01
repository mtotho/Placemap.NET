'use strict';

angular.module('Tothdev.Placemap.UI')
    .directive('placemapFeedbackArea', function () {
        return {
            templateUrl: 'app/controllers/place/placemap-feedback-area.html?v=2',
            restrict: 'EA',
            scope: {
                "placeviewmodel": "=",
                "currentStep": "="
            },
            link: function (scope, element, attrs, ctrl) {
                scope.showRightBar = function () {
                    ctrl.showRightBar();
                }

            },
            controller: function ($scope, $mdDialog, $rootScope, Configuration, $http) {

                var vm = this;

                vm.CurrentQuestion = null;
                vm.QuestionIndex = 0;
                vm.questionCount = 0;
                vm.questionsComplete = false;
                vm.responses = [];

                vm.goBack = function () {
                    $rootScope.$broadcast('selectLocation');
                    vm.questionsComplete = false;
                    $scope.currentStep.ranking = false;
                    $scope.currentStep.placing = true;
                    $rootScope.$broadcast('stepChange', $scope.currentStep);
                }

                $scope.$watch('placeviewmodel', function () {
                    if (!angular.isUndefinedOrNull($scope.placeviewmodel)) {
                        vm.Place = $scope.placeviewmodel.Place;
                        console.log(vm.Place);
                        //vm.newFeedback.place = vm.place._id;
                        vm.questionCount = vm.Place.PlacemapSurvey.SurveyItems.length;

                        if (vm.questionCount > 0) {
                        //    vm.responses = new ResponseObject(vm.place.question_set.questions);
                            // console.log(vm.responses);
                            vm.CurrentQuestion = vm.Place.PlacemapSurvey.SurveyItems[0];

                        }
                    }
                });

                function ResponseObject(questions) {
                    var response = [];

                    for (var i = 0; i < questions.length; i++) {
                        response[questions[i]._id] = {
                            question: questions[i]._id,
                            response_text: ""
                        }
                    }

                    return response;
                }

                vm.nextQuestion = function (ev) {
                    if (vm.QuestionIndex < vm.questionCount) {


                        if ((vm.CurrentQuestion.IsRequired && vm.responses[vm.CurrentQuestion._id].response_text !== "") || !vm.CurrentQuestion.IsRequired) {
                            vm.QuestionIndex++;
                            vm.CurrentQuestion = vm.Place.PlacemapSurvey.SurveyItems[vm.QuestionIndex];
                        } else {
                            $mdDialog.show(
                                $mdDialog.alert()
                                    .parent(angular.element(document.body))
                                    .title('Oops')
                                    .content('Please complete this question before moving on')
                                    .ariaLabel('Alert Dialog')
                                    .ok('Got it!')
                                    .targetEvent(ev)
                            );
                        }

                    }
                };

                vm.previousQuestion = function () {
                    if (vm.QuestionIndex > 0) {
                        vm.QuestionIndex--;
                        vm.CurrentQuestion = vm.Place.PlacemapSurvey.SurveyItems[vm.QuestionIndex];
                    }
                };


                vm.submitFeedback = function (ev) {

                    if ((vm.CurrentQuestion.IsRequired && $scope.placeviewmodel.SurveyResponse.SurveyResponseAnswers[vm.CurrentQuestion.Id].response_text !== "") || !vm.CurrentQuestion.IsRequired) {
                     

                        for (var r in $scope.placeviewmodel.SurveyResponse.SurveyResponseAnswers) {
                            var response = $scope.placeviewmodel.SurveyResponse.SurveyResponseAnswers[r];
                            console.log(response);
                            var responseArr = [];
                            if (response.hasOwnProperty("_selectedResponse")) {
                                for (var _r in response._selectedResponse) {
                                    if (response._selectedResponse[_r])
                                        responseArr.push(_r);
                                }
                            }
                            response.ResponseOptionJson = angular.toJson(responseArr);
                        }

                        $scope.placeviewmodel.SurveyResponse.BrowserAndVersion = navigator.userAgent,
                        console.log($scope.placeviewmodel.SurveyResponse.SurveyResponseAnswers);


                        $http({
                            method: 'post',
                            url: Configuration.backend + '/api/PlaceFeedback/Post',
                            data: $scope.placeviewmodel.SurveyResponse
                        }).then(function (response) {
                            location.reload();
                        
                            console.log(response);
                        }, function (response) {

                        });
                        //var Feedback = new Resources.feedback(feedback);

                        //Feedback.$save(function (result) {
                        //    console.log(result);

                        //    vm.QuestionIndex = 0;
                        //    vm.responses = [];
                        //    vm.CurrentQuestion = vm.place.question_set.questions[vm.QuestionIndex];
                        //    vm.questionsComplete = true;
                        //});
                    } else {
                        $mdDialog.show(
                            $mdDialog.alert()
                                .parent(angular.element(document.body))
                                .title('Oops')
                                .content('Please complete this question before moving on')
                                .ariaLabel('Alert Dialog')
                                .ok('Got it!')
                                .targetEvent(ev)
                        );
                    }

                };

                // size_content();
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