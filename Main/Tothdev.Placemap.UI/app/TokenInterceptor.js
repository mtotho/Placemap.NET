angular.module('Tothdev.Placemap.UI').factory('TokenInterceptor', function ($q, $window, $cookies) {
    return {
        request: function (config) {
            var sessionKey = $cookies.get("SESSIONKEY");
            if (!sessionKey) {
                sessionKey = Math.random().toString(36).substring(7);
                $cookies.put("SESSIONKEY", sessionKey);
            }

            config.headers = config.headers || {};
            config.headers['SESSIONKEY'] = sessionKey;
          //  config.headers['X-Access-Token'] = $window.sessionStorage.token;
            //config.headers['X-Key'] = $window.sessionStorage.user;
            //config.headers['Content-Type'] = "application/json";
         

            return config || $q.when(config);
        },

        response: function (response) {
            return response || $q.when(response);
        }
    };
});