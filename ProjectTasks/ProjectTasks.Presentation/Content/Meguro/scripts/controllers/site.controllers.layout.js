(function () {
    app.controller('layoutController', ['$scope', function ($scope) {

        var layout = {
            Normal: 'container',
            Fluid: 'container-fluid'
        };

        $scope.layoutMode = layout.Normal;

        $scope.layoutSwitching = function () {
            if ($scope.layoutMode === layout.Normal)
                $scope.layoutMode = layout.Fluid;
            else 
                $scope.layoutMode = layout.Normal
        };
    }]);
})();