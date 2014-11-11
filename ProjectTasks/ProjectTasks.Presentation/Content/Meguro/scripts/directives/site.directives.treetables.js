(function () {
    app.directive('tt',  ['$timeout', function ($timeout) {
        return {
            restrict: 'A',
            replace: false,
            link: function (scope, elm, attributes) {
                scope.$on('dataloaded', function () {
                    $timeout(function () {
                        if(scope.ttOptions)
                            $(elm).treetable(scope.ttOptions);
                    })
                }, 0, false);
            }
        };
    }]);
})();
