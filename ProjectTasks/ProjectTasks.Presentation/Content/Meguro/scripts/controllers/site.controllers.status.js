(function () {
    $(app).on('configureRouting', function (e, $routeProvider) {
        $routeProvider.when('/status', {
            templateUrl: '/status',
            controller: 'statusController'
        });
    });

    app.controller('statusController', ['$scope', '$http', 'toastr', 'DTOptionsBuilder', 'DTColumnBuilder', '$modal', function ($scope, $http, toastr, DTOptionsBuilder, DTColumnBuilder, $modal) {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withOption('ajax', {
                url: '/status/getall',
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

        $scope.openStatus = function (id) {
            $modal.open({
                templateUrl: "/status/detail",
                controller: "statusDetailController",
                resolve: {
                    id: function () { return id; }
                }
            }).result.then(function () {
                $modal.open({
                    templateUrl: "/status/edit?id=" + id,
                    controller: "statusEditController",
                    resolve: {
                        id: function () { return id; }
                    }
                }).result.then(function (state) {
                    switch (state) {
                        case 'deleted':
                            $scope.deleteStatus(id);
                            console.log('status [' + id + '] has been deleted');
                            break;
                        case 'saved':
                            $scope.reloadData();
                            toastr.show(toastr.type.success, 'status has been updated', 'Operation successful')
                            console.log('status [' + id + '] has been saved');
                            break;
                    }
                });
            });
        };

        $scope.createStatus = function () {
            $modal.open({
                templateUrl: "/status/create",
                controller: "statusCreateController"
            }).result.then(function (state) {
                switch (state) {
                    case 'created':
                        toastr.show(toastr.type.success, 'status has been created', 'Operation successful')
                        $scope.reloadData();
                        break;
                }
            });
        };

        $scope.deleteStatus = function (id) {
            $modal.open({
                templateUrl: "/template/confirm",
                controller: "confirmController"
            }).result.then(function (state) {
                switch (state) {
                    case 'confirm':
                        $http
                            .delete('/api/status/' + id)
                            .success(function (data, statusCode, statusText) {
                                toastr.show(toastr.type.success, 'status has been deleted', 'Operation successful')
                                $scope.reloadData();
                            }); break;
                }
            });
        };
    }]);

    app.controller('statusDetailController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http.get("/api/status/" + id).success(function (data) {
            $scope.data = data;
        });

        $scope.openEdit = function () {
            $modalInstance.close();
        };

        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);

    app.controller('statusCreateController', ['$scope', '$http', '$modalInstance', function ($scope, $http, $modalInstance) {
        $scope.data = { Id: 0, StateLabel: 'unused' };

        $scope.add = function () {
            $http
                .put('/api/status', $scope.data)
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

    app.controller('statusEditController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http
            .get('/api/status/' + id)
            .success(function (data) {
                $scope.data = data;
            });

        $scope.save = function () {
            $http
                .post('/api/status', $scope.data)
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
})();