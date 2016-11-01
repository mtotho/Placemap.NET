angular.module('Tothdev.Placemap.UI')
    .config(function ($mdThemingProvider) {
    	$mdThemingProvider.definePalette('placemapPrimary', {
    		'50': 'FFFDE7',
    		'100': 'C8E6C9',
    		'200': 'FFF59D',
    		'300': 'FFF176',
    		'400': '689F38',//primary green
    		'500': '4CAF50',
    		'600': 'FDD835',
    		'700': '689F38',
    		'800': 'F8A825',
    		'900': 'F57F17',
    		'A100': 'ff8a80',
    		'A200': 'ff5252',
    		'A400': 'ff1744',
    		'A700': 'd50000',
    		'contrastDefaultColor': 'light',    // whether, by default, text (contrast)
    		// on this palette should be dark or light
    		'contrastDarkColors': ['50', '100', //hues which contrast should be 'dark' by default
                '200', '300', '400', 'A100'],
    		'contrastLightColors': undefined    // could also specify this if default was 'dark'
    	});

    	$mdThemingProvider.definePalette('placemapAccent', {
    		'50': 'FFFDE7',
    		'100': 'F0F4C3',
    		'200': 'EDECEE',//primary light gray
    		'300': 'DCE775',
    		'400': 'A7A9Ab',//primary Gray
    		'500': 'CDDC39',
    		'600': 'FDD835',
    		'700': 'FBC02D',
    		'800': '9E9D24',//primary black
    		'900': 'F57F17',
    		'A100': 'ff8a80',
    		'A200': 'ff5252',
    		'A400': 'ff1744',
    		'A700': 'd50000',
    		'contrastDefaultColor': 'light',    // whether, by default, text (contrast)
    		// on this palette should be dark or light
    		'contrastDarkColors': ['50', '100', //hues which contrast should be 'dark' by default
                '200', '300', '400', 'A100'],
    		'contrastLightColors': undefined    // could also specify this if default was 'dark'
    	});





    	$mdThemingProvider.theme('default')
            .primaryPalette('placemapPrimary', {
            	'default': '400', // by default use shade 400 from the pink palette for primary intentions
            	'hue-1': '100', // use shade 100 for the <code>md-hue-1</code> class
            	'hue-2': '500', // use shade 600 for the <code>md-hue-2</code> class
            	'hue-3': '700' // use shade A100 for the <code>md-hue-3</code> class
            }).accentPalette('placemapAccent', {
            	'default': '500', // by default use shade 400 from the pink palette for primary intentions
            	'hue-1': '100', // use shade 100 for the <code>md-hue-1</code> class
            	'hue-2': '500', // use shade 600 for the <code>md-hue-2</code> class
            	'hue-3': '800' // use shade A100 for the <code>md-hue-3</code> class
            });;
    });