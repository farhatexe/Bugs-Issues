(function () {
    $(app).on('configureRouting', function (e, $routeProvider) {
        $routeProvider.when('/area', {
            templateUrl: '/area',
            controller: 'areaController'
        });
    });

    app.controller('areaController', ['$scope', '$http', 'toastr', 'ngTreetableParams', '$q', '$modal', function ($scope, $http, toastr, ngTreetableParams, $q, $modal) {

        $scope.areaParams = new ngTreetableParams({
            getNodes: function () {
                var deferred = $q.defer();
                $http.get("/area/GetAll").success(function (data) {
                    deferred.resolve(data);
                });
                return deferred.promise;
            },
            options: {
                column: 2,
                expandable: true

            }
        });

        $scope.openArea = function (id) {
            $modal.open({
                templateUrl: "/area/detail",
                controller: "areaDetailController",
                resolve: {
                    id: function () { return id; }
                }
            }).result.then(function () {
                $modal.open({
                    templateUrl: "/area/edit?id=" + id,
                    controller: "areaEditController",
                    resolve: {
                        id: function () { return id; }
                    }
                }).result.then(function (state) {
                    switch (state) {
                        case 'deleted':
                            $scope.deleteArea(id);
                            console.log('area [' + id + '] has been deleted');
                            break;
                        case 'saved':
                            $scope.areaParams.refresh();
                            toastr.show(toastr.type.success, 'area has been updated', 'Operation successful')
                            console.log('area [' + id + '] has been saved');
                            break;
                    }
                });
            });
        };

        $scope.createArea = function () {
            $modal.open({
                templateUrl: "/area/create",
                controller: "areaCreateController"
            }).result.then(function (state) {
                switch (state) {
                    case 'created':
                        toastr.show(toastr.type.success, 'area has been created', 'Operation successful')
                        $scope.areaParams.refresh();
                        break;
                }
            });
        };

        $scope.deleteArea = function (id) {
            $modal.open({
                templateUrl: "/template/confirm",
                controller: "confirmController"
            }).result.then(function (state) {
                switch (state) {
                    case 'confirm':
                        $http
                            .delete('/api/area/' + id)
                            .success(function (data, statusCode, statusText) {
                                toastr.show(toastr.type.success, 'area has been deleted', 'Operation successful')
                                $scope.areaParams.refresh();
                            }); break;
                }
            });
        };
    }]);

    app.controller('areaDetailController', ['$scope', '$modalInstance', '$http', 'id', function ($scope, $modalInstance, $http, id) {
        $http.get("/api/area/" + id).success(function (data) {
            $scope.data = data;
        });

        $scope.openEdit = function () {
            $modalInstance.close();
        };

        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);

    app.controller('areaCreateController', ['$scope', '$http', '$modal', '$modalInstance', function ($scope, $http, $modal, $modalInstance) {
        $scope.data = { ParentId: null };

        $scope.openAreaTree = function () {
            $modal.open({
                templateUrl: '/area/AreaTree',
                controller: 'areaTreeController',
                resolve: {
                    id: function () { return $scope.data.ParentId; }
                }
            }).result.then(function (result) {
                $scope.data.ParentId = result.id;
                $scope.data.ParentLabel = result.text;
            });
        };

        $scope.add = function () {
            $http
                .put('/api/area', $scope.data)
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

    app.controller('areaEditController', ['$scope', '$modal', '$modalInstance', '$http', 'id', function ($scope, $modal, $modalInstance, $http, id) {
        $http
            .get('/api/area/' + id)
            .success(function (data) {
                $scope.data = data;
            });

        $scope.save = function () {
            $http
                .post('/api/area', $scope.data)
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

        $scope.openAreaTree = function () {
            $modal.open({
                templateUrl: '/area/AreaTree',
                controller: 'areaTreeController',
                resolve: {
                    id: function () { return $scope.data.ParentId; }
                }
            }).result.then(function (result) {
                $scope.data.ParentId = result.id;
                $scope.data.ParentLabel = result.text;
            });
        };
    }]);

    app.controller('areaTreeController', ['$scope', '$modalInstance', 'id', function ($scope, $modalInstance, id) {
        $scope.id = id;
        $scope.select = function (event, area) {
            if (area.node)
                $modalInstance.close(area.node);
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
        $scope.close = function () {
            $modalInstance.dismiss('close');
        };
    }]);
})();