'use strict';

angular.module('Tothdev.Placemap.UI')
    .directive('placemapFeedbackArea', function () {
        return {
            templateUrl: 'app/controllers/place/placemap-feedback-area.html?v=1',
            restrict: 'EA',
            scope: {
                "place": "="
            },
            link: function (scope, element, attrs, ctrl) {
                scope.showRightBar = function () {
                    ctrl.showRightBar();
                }

            },
            controller: function ($scope, $mdDialog, $rootScope) {

                var vm = this;

                vm.CurrentQuestion = null;
                vm.QuestionIndex = 0;
                vm.questionCount = 0;
                vm.questionsComplete = false;
                vm.responses = [];

                vm.goBack = function () {
                    $rootScope.$broadcast('selectLocation');
                    vm.questionsComplete = false;
                }

                $scope.$watch('place', function () {
                    if (!angular.isUndefinedOrNull($scope.place)) {
                        vm.Place = $scope.place;
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
                        vm.CurrentQuestion = vm.place.question_set.questions[vm.QuestionIndex];
                    }
                };


                vm.submitFeedback = function (ev) {

                    if ((vm.CurrentQuestion.IsRequired && vm.responses[vm.CurrentQuestion._id].response_text !== "") || !vm.CurrentQuestion.IsRequired) {
                        var feedback = {
                            place: vm.place._id,
                            responses: []
                        };

                        for (var r in vm.responses) {
                            console.log(r);
                            feedback.responses.push(vm.responses[r]);
                        }
                        var Feedback = new Resources.feedback(feedback);

                        Feedback.$save(function (result) {
                            console.log(result);

                            vm.QuestionIndex = 0;
                            vm.responses = [];
                            vm.CurrentQuestion = vm.place.question_set.questions[vm.QuestionIndex];
                            vm.questionsComplete = true;
                        });
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