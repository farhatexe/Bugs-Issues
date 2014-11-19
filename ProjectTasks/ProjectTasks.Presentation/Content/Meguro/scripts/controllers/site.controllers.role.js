(function () {
    $(app).on('configureRouting', function (e, $routeProvider) {
        $routeProvider.when('/role', {
            templateUrl: '/role',
            controller: 'roleController'
        });
    });

    app.controller('roleController', ['$scope', '$http', 'toastr', 'DTOptionsBuilder', 'DTColumnBuilder', '$modal', function ($scope, $http, toastr, DTOptionsBuilder, DTColumnBuilder, $modal) {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withOption('ajax', {
                url: '/role/getall',
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

        $scope.openRole = function (id) {
            $modal.open({
                templateUrl: "/role/detail",
                controller: "roleDetailController",
                resolve: {
                    id: function () { return id; }
                }
            }).result.then(function () {
                $modal.open({
                    templateUrl: "/role/edit?id=" + id,
                    controller: "roleEditController",
                    resolve: {
                        id: function () { return id; }
                    }
                }).result.then(function (state) {
                    switch (state) {
                        case 'deleted':
                            $scope.deleteRole(id);
                            console.log('role [' + id + '] has been deleted');
                            break;
                        case 'saved':
                            $scope.reloadData();
                            toastr.show(toastr.type.success, 'role has been updated', 'Operation successful')
                            console.log('role [' + id + '] has been saved');
                            break;
                    }
                });
            });
        };

        $scope.createRole = function () {
            $modal.open({
                templateUrl: "/role/create",
                controller: "roleCreateController"
            }).result.then(function (state) {
                switch (state) {
                    case 'created':
                        toastr.show(toastr.type.success, 'role has been created', 'Operation successful')
                        $scope.reloadData();
                        break;
                }
            });
        };

        $scope.deleteRole = function (id) {
            $modal.open({
                templateUrl: "/template/confirm",
                controller: "confirmController"
            }).result.then(function (state) {
                switch (state) {
                    case 'confirm':
                        $http
                            .delete('/api/role/' + id)
                            .success(function (data, statusCode, statusText) {
                                toastr.show(toastr.type.success, 'role has been deleted', 'Operation successful')
                                $scope.reloadData();
                            }); break;
                }
            });
        };
    }]);

    app.controller('roleDetailController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http.get("/api/role/" + id).success(function (data) {
            $scope.data = data;
        });

        $scope.openEdit = function () {
            $modalInstance.close();
        };

        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);

    app.controller('roleCreateController', ['$scope', '$http', '$modalInstance', function ($scope, $http, $modalInstance) {
        $scope.data = { Id: 0 };

        $scope.add = function () {
            $http
                .put('/api/role', $scope.data)
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

    app.controller('roleEditController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http
            .get('/api/role/' + id)
            .success(function (data) {
                $scope.data = data;
            });

        $scope.save = function () {
            $http
                .post('/api/role', $scope.data)
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