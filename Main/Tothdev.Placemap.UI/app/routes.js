(function () {
    'use strict';
    angular.module('Tothdev.Placemap.UI')
        .config(function ($stateProvider, $locationProvider, $urlRouterProvider) {

            $stateProvider
                  .state('Place', {
                      controller: 'PlaceCtrl as vm',
                      url: '/place/:PlaceKey',
                      templateUrl: 'app/controllers/place/place.html?v=1',
                  })
                 .state('StudyArea', {
                     controller: 'StudyAreaCtrl as vm',
                     url: '/studyarea/:PlaceKey',
                     templateUrl: 'app/controllers/studyarea/studyarea.html?v=1',
                 })
              
            $urlRouterProvider.otherwise('/');

        });
})();