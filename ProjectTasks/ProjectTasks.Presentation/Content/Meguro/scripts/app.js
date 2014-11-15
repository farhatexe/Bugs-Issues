/// <reference path="../../Metronic/metronic/assets/global/plugins/jquery-1.11.0.min.js" />
/// <reference path="../../Angular/angular.min.js" />
var app = angular.module("webApp", ['ngRoute', 'ngResource', 'datatables', 'ui.bootstrap', 'angularMoment', 'ngTreetable', 'jsTree.directive']);

(function () {
    app.localization = {};

    app.config(['$httpProvider', '$routeProvider', function ($httpProvider, $routeProvider) {
        $(app).trigger('configureRouting', $routeProvider);
        $routeProvider.when('/404', {
            templateUrl: '/static/error_404.html'
        }).otherwise('/404');
        $httpProvider.interceptors.push('httpRequestInterceptor');
    }]);

    app.run(['$rootScope', 'resourceProxy', 'amMoment', '$templateCache', function ($rootScope, resourceProxy, amMoment, $templateCache) {
        $rootScope.$on('$viewContentLoaded', function () {
            Metronic.init();
        });
        resourceProxy.loadResource(['Global']);
        amMoment.changeLocale(resourceProxy.currentLocale);
    }]);

    $(function () {
        $.connection.hub.start();
        Layout.init();
    });    
})();