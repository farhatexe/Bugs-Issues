/// <reference path="../../Angular/angular.min.js" />
/// <reference path="../app.js" />
(function () {
    $(app).on('configureRouting', function (e, $routeProvider) {
        $routeProvider.when('/legalArea', {
            templateUrl: '/legalArea',
            controller: 'legalAreaController'
        })
    });

    app.controller('legalAreaController', ['$scope', '$http', 'toastr', 'DTOptionsBuilder', 'DTColumnBuilder', '$modal', function ($scope, $http, toastr, DTOptionsBuilder, DTColumnBuilder, $modal) {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withOption('ajax', {
                url: '/legalArea/getall',
                type: 'POST'
            })
            .withOption('order', [[2, 'asc']])
            .withDataProp('data')
            .withOption('serverSide', true)
            .withOption('bFilter', false)
            .withOption('bAutoWidth', false)
            .withPaginationType('simple_numbers');

        $scope.reloadData = function () {
            $scope.dtOptions.reloadData();
        };

        $scope.openLegalArea = function (id) {
            $modal.open({
                templateUrl: "/legalArea/detail",
                controller: "legalAreaDetailController",
                resolve: {
                    id: function () { return id; }
                }
            }).result.then(function () {
                $modal.open({
                    templateUrl: "/legalArea/edit?id=" + id,
                    controller: "legalAreaEditController",
                    resolve: {
                        id: function () { return id; }
                    }
                }).result.then(function (state) {
                    switch (state) {
                        case 'deleted':
                            $scope.deleteLegalArea(id);
                            console.log('Legal Area [' + id + '] has been deleted');
                            break;
                        case 'saved':
                            $scope.reloadData();
                            toastr.show(toastr.type.success, 'legal area has been updated', 'Operation successful')
                            console.log('legal area [' + id + '] has been saved');
                            break;
                    }
                });
            })
        };

        $scope.deleteLegalArea = function (id) {
            $modal.open({
                templateUrl: "/template/confirm",
                controller: "confirmController"
            }).result.then(function (state) {
                switch (state) {
                    case 'confirm':
                        $http
                            .delete('/api/legalArea/' + id)
                            .success(function (data, statusCode, statusText) {
                                toastr.show(toastr.type.success, 'Legal area has been deleted', 'Operation successful')
                                $scope.reloadData();
                            });
                        break;
                }
            });
        };

        $scope.createLegalArea = function () {
            $modal.open({
                templateUrl: "/legalArea/create",
                controller: "legalAreaCreateController"
            }).result.then(function (state) {
                switch (state) {
                    case 'created':
                        toastr.show(toastr.type.success, 'legal area has been created', 'Operation successful')
                        $scope.reloadData();
                        break;
                }
            });
        };
    }]);

    app.controller('legalAreaDetailController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http
            .get('/api/legalArea/' + id)
            .success(function (data) {
                $scope.data = data;
            });

        $scope.openEdit = function () {
            $modalInstance.close();
        };

        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);

    app.controller('legalAreaEditController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $scope.action = "edit";
        $scope.data = {Code:""};
        $http
           .get('/api/legalArea/' + id)
           .success(function (data) {
               $scope.data = data;
           });

        $scope.save = function () {
            $http
                .post('/api/legalArea', $scope.data)
                .success(function (data) {
                    $modalInstance.close('saved');
                });
        };

        $scope.delete = function (id) {
            $modalInstance.close('deleted');
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);

    app.controller('legalAreaCreateController', ['$scope', '$modalInstance', '$http', function ($scope, $modalInstance, $http) {
        $scope.data = {};
        $scope.action = "create";


        $scope.add = function () {
            $http
                .put('/api/legalArea', $scope.data)
                .success(function (data) {
                    $modalInstance.close('created');
                });
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);

})();