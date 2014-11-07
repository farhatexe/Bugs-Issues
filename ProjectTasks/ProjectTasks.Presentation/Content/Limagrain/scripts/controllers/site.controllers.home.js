/// <reference path="../../Angular/angular.min.js" />
/// <reference path="../app.js" />
(function () {
    $(app).on('configureRouting', function (e, $routeProvider) {
        $routeProvider.when('/dashboard', {
            templateUrl: '/home/dashboard',
            controller: 'homeController'
        }).when('/', {
            templateUrl: '/home/dashboard',
            controller: 'homeController'
        }).when('/home/dashboard', {
            templateUrl: '/home/dashboard',
            controller: 'homeController'
        })
    });

    app.controller('homeController', ['$scope', 'resourceProxy', function ($scope, resourceProxy) {
        resourceProxy.loadResource(['Home']);
        $scope.localization = app.localization;

        $('#test').formWizard();
    }]);
})();