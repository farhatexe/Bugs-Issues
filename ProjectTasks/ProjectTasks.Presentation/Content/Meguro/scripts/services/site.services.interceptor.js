(function () {
    app.factory('httpRequestInterceptor', ['$q', '$location', 'toastr', function ($q, $location, toastr) {
        return {
            'responseError': function (rejection) {
                if (rejection.status === 401) {
                    var $http = angular.element(document).injector().get('$http');
                    return $http.get('/static/error_401.html');
                }
                if (rejection.status === 500) {
                    toastr.show(toastr.type.error, rejection.status + ' - ' + rejection.statusText, 'An error occured')
                    return $q.reject(rejection);
                }
            }
        }
    }]);
})();