(function () {
    app.controller('confirmController', ['$scope', '$modalInstance', function ($scope, $modalInstance) {
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        $scope.confirm = function () {
            $modalInstance.close('confirm');
        };
    }]);
})();