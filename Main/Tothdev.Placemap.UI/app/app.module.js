'use strict';

angular.module('Tothdev.Placemap.UI', [
    'ngMaterial',
    'ngAnimate',
    'ui.router',
    'uiGmapgoogle-maps'
])

    .config(function ($httpProvider, uiGmapGoogleMapApiProvider) {
        /*  $mdThemingProvider.theme('default')
			  .primaryPalette('light-green', {
				  'default': '400', // by default use shade 400 from the pink palette for primary intentions
				  'hue-1': '100', // use shade 100 for the <code>md-hue-1</code> class
				  'hue-2': '600', // use shade 600 for the <code>md-hue-2</code> class
				  'hue-3': 'A100' // use shade A100 for the <code>md-hue-3</code> class
  
	   //  $httpProvider.interceptors.push('TokenInterceptor');            })*/

        //uiGmapGoogleMapApiProvider.configure({
        //    // key: 'AIzaSyD93JNhuGDGJKKgp8JGBpj60bDbbpMgJis',
        //    v: '3.17',
        //    libraries: 'weather,geometry,visualization,places'
        //});


    }).run(function ($rootScope, $window, $location) {
        // when the page refreshes, check if the user is already logged in


    })
    .factory('Configuration', function () {

        var configuration = {
            backend: 'backend'
        };

        if (location.host.indexOf('localhost') > -1) {
            configuration.backend = 'http://localhost:49408';
        }

        return configuration;
    })
    .filter('getByProp', function () {
        return function (input, prop, val) {

            var i = 0, len = input.length;
            for (i = 0; i < len; i++) {

                if (input[i][prop] === val) {
                    return input[i];
                }
            }
            return null;
        }
    }).filter('getIndexByProp', function () {
        return function (input, prop, val) {

            var i = 0, len = input.length;
            for (i = 0; i < len; i++) {

                if (input[i][prop] === val) {
                    return i;
                }
            }
            return null;
        }
    });
angular.isUndefinedOrNull = function (val) {
    return angular.isUndefined(val) || val === null
}



angular.map_resize = function (offset) {
    //var headerheight = $("#header").outerHeight();
    //  var mapbarheight = $("placemap-actionbar md-toolbar").outerHeight();
    // console.log(mapbarheight);
    var windowheight = $(window).outerHeight();

    var targetheight = windowheight;// - (mapbarheight);

    if (offset) {
        targetheight = targetheight - offset;
    }

    $("#placemap .angular-google-map-container").css('height', targetheight + 'px');
    $(".full-height").css('height', targetheight + 'px');
    $(".full-height-window").css('height', windowheight + 'px');

    console.log("setting height " + targetheight);
}

$(window).resize(function () {
    angular.map_resize()
});