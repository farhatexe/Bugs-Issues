(function () {
    $(app).on('configureRouting', function (e, $routeProvider) {
        $routeProvider.when('/reason', {
            templateUrl: '/reason',
            controller: 'reasonController'
        });
    });

    app.controller('reasonController', ['$scope', '$http', 'toastr', 'DTOptionsBuilder', 'DTColumnBuilder', '$modal', function ($scope, $http, toastr, DTOptionsBuilder, DTColumnBuilder, $modal) {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withOption('ajax', {
                url: '/reason/getall',
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

        $scope.openReason = function (id) {
            $modal.open({
                templateUrl: "/reason/detail",
                controller: "reasonDetailController",
                resolve: {
                    id: function () { return id; }
                }
            }).result.then(function () {
                $modal.open({
                    templateUrl: "/reason/edit?id=" + id,
                    controller: "reasonEditController",
                    resolve: {
                        id: function () { return id; }
                    }
                }).result.then(function (state) {
                    switch (state) {
                        case 'deleted':
                            $scope.deleteReason(id);
                            console.log('reason [' + id + '] has been deleted');
                            break;
                        case 'saved':
                            $scope.reloadData();
                            toastr.show(toastr.type.success, 'reason has been updated', 'Operation successful')
                            console.log('reason [' + id + '] has been saved');
                            break;
                    }
                });
            });
        };

        $scope.createReason = function () {
            $modal.open({
                templateUrl: "/reason/create",
                controller: "reasonCreateController"
            }).result.then(function (state) {
                switch (state) {
                    case 'created':
                        toastr.show(toastr.type.success, 'reason has been created', 'Operation successful')
                        $scope.reloadData();
                        break;
                }
            });
        };

        $scope.deleteReason = function (id) {
            $modal.open({
                templateUrl: "/template/confirm",
                controller: "confirmController"
            }).result.then(function (state) {
                switch (state) {
                    case 'confirm':
                        $http
                            .delete('/api/reason/' + id)
                            .success(function (data, statusCode, statusText) {
                                toastr.show(toastr.type.success, 'reason has been deleted', 'Operation successful')
                                $scope.reloadData();
                            }); break;
                }
            });
        };
    }]);

    app.controller('reasonDetailController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http.get("/api/reason/" + id).success(function (data) {
            $scope.data = data;
        });

        $scope.openEdit = function () {
            $modalInstance.close();
        };

        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);

    app.controller('reasonCreateController', ['$scope', '$http', '$modalInstance', function ($scope, $http, $modalInstance) {
        $scope.data = { Id: 0, StateLabel: 'unused' };

        $scope.add = function () {
            $http
                .put('/api/reason', $scope.data)
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

    app.controller('reasonEditController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http
            .get('/api/reason/' + id)
            .success(function (data) {
                $scope.data = data;
            });

        $scope.save = function () {
            $http
                .post('/api/reason', $scope.data)
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