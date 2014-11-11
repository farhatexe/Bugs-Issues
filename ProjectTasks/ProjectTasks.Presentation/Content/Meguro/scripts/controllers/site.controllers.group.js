(function () {
    $(app).on('configureRouting', function (e, $routeProvider) {
        $routeProvider.when('/group', {
            templateUrl: '/group',
            controller: 'groupController'
        });
    });

    app.controller('groupController', ['$scope', '$http', 'toastr', 'DTOptionsBuilder', 'DTColumnBuilder', '$modal', function ($scope, $http, toastr, DTOptionsBuilder, DTColumnBuilder, $modal) {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withOption('ajax', {
                url: '/group/getall',
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

        $scope.openGroup = function (id) {
            $modal.open({
                templateUrl: "/group/detail",
                controller: "groupDetailController",
                resolve: {
                    id: function () { return id; }
                }
            }).result.then(function () {
                $modal.open({
                    templateUrl: "/group/edit?id=" + id,
                    controller: "groupEditController",
                    resolve: {
                        id: function () { return id; }
                    }
                }).result.then(function (state) {
                    switch (state) {
                        case 'deleted':
                            $scope.deleteGroup(id);
                            console.log('group [' + id + '] has been deleted');
                            break;
                        case 'saved':
                            $scope.reloadData();
                            toastr.show(toastr.type.success, 'group has been updated', 'Operation successful')
                            console.log('group [' + id + '] has been saved');
                            break;
                    }
                });
            });
        };

        $scope.createGroup = function () {
            $modal.open({
                templateUrl: "/group/create",
                controller: "groupCreateController"
            }).result.then(function (state) {
                switch (state) {
                    case 'created':
                        toastr.show(toastr.type.success, 'group has been created', 'Operation successful')
                        $scope.reloadData();
                        break;
                }
            });
        };

        $scope.deleteGroup = function (id) {
            $modal.open({
                templateUrl: "/template/confirm",
                controller: "confirmController"
            }).result.then(function (state) {
                switch (state) {
                    case 'confirm':
                        $http
                            .delete('/api/group/' + id)
                            .success(function (data, statusCode, statusText) {
                                toastr.show(toastr.type.success, 'group has been deleted', 'Operation successful')
                                $scope.reloadData();
                            }); break;
                }
            });
        };
    }]);

    app.controller('groupDetailController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http.get("/api/group/" + id).success(function (data) {
            $scope.data = data;
        });

        $scope.openEdit = function () {
            $modalInstance.close();
        };

        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);

    app.controller('groupCreateController', ['$scope', '$http', '$modalInstance', function ($scope, $http, $modalInstance) {
        $scope.data = { Id: 0, StateLabel: 'unused' };

        $scope.add = function () {
            $http
                .put('/api/group', $scope.data)
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

    app.controller('groupEditController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http
            .get('/api/group/' + id)
            .success(function (data) {
                $scope.data = data;
            });

        $scope.save = function () {
            $http
                .post('/api/group', $scope.data)
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