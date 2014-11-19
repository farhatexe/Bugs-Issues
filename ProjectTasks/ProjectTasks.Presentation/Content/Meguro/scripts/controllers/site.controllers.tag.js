(function () {
    $(app).on('configureRouting', function (e, $routeProvider) {
        $routeProvider.when('/tag', {
            templateUrl: '/tag',
            controller: 'tagController'
        });
    });

    app.controller('tagController', ['$scope', '$http', 'toastr', 'DTOptionsBuilder', 'DTColumnBuilder', '$modal', function ($scope, $http, toastr, DTOptionsBuilder, DTColumnBuilder, $modal) {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withOption('ajax', {
                url: '/tag/getall',
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

        $scope.openTag = function (id) {
            $modal.open({
                templateUrl: "/tag/detail",
                controller: "tagDetailController",
                resolve: {
                    id: function () { return id; }
                }
            }).result.then(function () {
                $modal.open({
                    templateUrl: "/tag/edit?id=" + id,
                    controller: "tagEditController",
                    resolve: {
                        id: function () { return id; }
                    }
                }).result.then(function (state) {
                    switch (state) {
                        case 'deleted':
                            $scope.deleteTag(id);
                            console.log('tag [' + id + '] has been deleted');
                            break;
                        case 'saved':
                            $scope.reloadData();
                            toastr.show(toastr.type.success, 'tag has been updated', 'Operation successful')
                            console.log('tag [' + id + '] has been saved');
                            break;
                    }
                });
            });
        };

        $scope.createTag = function () {
            $modal.open({
                templateUrl: "/tag/create",
                controller: "tagCreateController"
            }).result.then(function (state) {
                switch (state) {
                    case 'created':
                        toastr.show(toastr.type.success, 'tag has been created', 'Operation successful')
                        $scope.reloadData();
                        break;
                }
            });
        };

        $scope.deleteTag = function (id) {
            $modal.open({
                templateUrl: "/template/confirm",
                controller: "confirmController"
            }).result.then(function (state) {
                switch (state) {
                    case 'confirm':
                        $http
                            .delete('/api/tag/' + id)
                            .success(function (data, statusCode, statusText) {
                                toastr.show(toastr.type.success, 'tag has been deleted', 'Operation successful')
                                $scope.reloadData();
                            }); break;
                }
            });
        };
    }]);

    app.controller('tagDetailController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http.get("/api/tag/" + id).success(function (data) {
            $scope.data = data;
        });

        $scope.openEdit = function () {
            $modalInstance.close();
        };

        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);

    app.controller('tagCreateController', ['$scope', '$http', '$modalInstance', function ($scope, $http, $modalInstance) {
        $scope.data = { Id: 0, StateLabel: 'unused' };

        $scope.add = function () {
            $http
                .put('/api/tag', $scope.data)
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

    app.controller('tagEditController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http
            .get('/api/tag/' + id)
            .success(function (data) {
                $scope.data = data;
            });

        $scope.save = function () {
            $http
                .post('/api/tag', $scope.data)
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