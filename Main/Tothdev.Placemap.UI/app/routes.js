(function () {
    'use strict';
    angular.module('Tothdev.Placemap.UI')
        .config(function ($stateProvider, $locationProvider, $urlRouterProvider) {

            $stateProvider
                  .state('Place', {
                      controller: 'PlaceCtrl as vm',
                      url: '/place/:PlaceKey',
                      templateUrl: 'app/controllers/place/place.html?v=2',
                  })
                 .state('PlaceResponses', {
                     controller: 'PlaceResponsesCtrl as vm',
                     url: '/placeresponses/:PlaceKey',
                     templateUrl: 'app/controllers/placeresponses/placeresponses.html?v=3',
                 })
                 .state('StudyArea', {
                     controller: 'StudyAreaCtrl as vm',
                     url: '/studyarea/:PlaceKey',
                     templateUrl: 'app/controllers/studyarea/studyarea.html?v=2',
                 })
              
            $urlRouterProvider.otherwise('/');

        });
})();