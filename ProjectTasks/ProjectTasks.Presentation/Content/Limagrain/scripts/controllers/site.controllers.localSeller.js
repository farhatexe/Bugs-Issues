/// <reference path="../../Angular/angular.min.js" />
/// <reference path="../app.js" />
(function () {
    $(app).on('configureRouting', function (e, $routeProvider) {
        $routeProvider.when('/localSeller', {
            templateUrl: '/localSeller',
            controller: 'localSellerController'
        })
    });

    app.controller('localSellerController', ['$scope', '$http', 'toastr', 'DTOptionsBuilder', 'DTColumnBuilder', '$modal', function ($scope, $http, toastr, DTOptionsBuilder, DTColumnBuilder, $modal) {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withOption('ajax', {
                url: '/localSeller/getall',
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

        $scope.openLocalSeller = function (id) {
            $modal.open({
                windowClass: 'fullscreen',
                templateUrl: "/localSeller/detail",
                controller: "localSellerDetailController",
                resolve: {
                    id: function () { return id; }
                }
            }).result.then(function () {
                $modal.open({
                    windowClass: 'fullscreen',
                    templateUrl: "/localSeller/edit?id=" + id,
                    controller: "localSellerEditController",
                    resolve: {
                        id: function () { return id; }
                    }
                }).result.then(function (state) {
                    switch (state) {
                        case 'deleted':
                            $scope.deleteLocalSeller(id);
                            console.log('Local seller [' + id + '] has been deleted');
                            break;
                        case 'saved':
                            $scope.reloadData();
                            toastr.show(toastr.type.success, 'local seller has been updated', 'Operation successful')
                            console.log('local seller [' + id + '] has been saved');
                            break;
                    }
                });
            })
        };

        $scope.deleteLocalSeller = function (id) {
            $modal.open({
                templateUrl: "/template/confirm",
                controller: "confirmController"
            }).result.then(function (state) {
                switch (state) {
                    case 'confirm':
                        $http
                            .delete('/api/localseller/' + id)
                            .success(function (data, statusCode, statusText) {
                                toastr.show(toastr.type.success, 'Local seller has been deleted', 'Operation successful')
                                $scope.reloadData();
                            });
                        break;
                }
            });
        };

        $scope.createLocalSeller = function () {
            $modal.open({
                windowClass: 'fullscreen',
                templateUrl: "/localSeller/create",
                controller: "localSellerCreateController"
            }).result.then(function (state) {
                switch (state) {
                    case 'created':
                        toastr.show(toastr.type.success, 'local seller has been created', 'Operation successful')
                        $scope.reloadData();
                        break;
                }
            });
        };
    }]);

    app.controller('localSellerDetailController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http
            .get('/api/localSeller/' + id)
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

    app.controller('localSellerEditController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http
           .get('/api/localSeller/' + id)
           .success(function (data) {
               $scope.data = data;
           });

        $scope.save = function () {
            $http
                .post('/api/localSeller', $scope.data)
                .success(function (data) {
                    $modalInstance.close('saved');
                });
        };

        $scope.delete = function (id) {
            $modalInstance.close('deleted');
        }

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);

    app.controller('localSellerCreateController', ['$scope', '$modalInstance', '$http', function ($scope, $modalInstance, $http) {
        $scope.data = {};

        $scope.add = function () {
            $http
                .put('/api/localSeller', $scope.data)
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