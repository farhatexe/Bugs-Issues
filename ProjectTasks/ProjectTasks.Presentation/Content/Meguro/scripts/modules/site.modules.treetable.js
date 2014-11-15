(function () {
    angular.module('ngTreetable', [])
        .factory('ngTreetableParams', [function () {
            var params = function (baseConfiguration) {
                var self = this;

                this.getNodes = function () { };

                this.options = {};

                this.refresh = function () { };

                if (angular.isObject(baseConfiguration)) {
                    angular.forEach(baseConfiguration, function (val, key) {
                        if (['getNodes', 'options'].indexOf(key) > -1) {
                            self[key] = val;
                        }
                    });
                }
            }
            return params;
        }])
    .controller('treetableController', ['$scope', '$element', '$compile', '$q', function ($scope, $element, $compile, $q) {
        var params = $scope.ttParams;

        var ttChildrenSelector = $element.data('tt-children-selector');
        var ttIdselector = $element.data("tt-id-selector");

        var addRowsRecursively = function (item, parent, ttElement) {
            var result = $($scope.compileElement(item)).data('tt-id', item[ttIdselector]);

            if (parent) result.data('tt-parent-id', parent.id);

            if (item[ttChildrenSelector] && item[ttChildrenSelector].length)
                result.data('tt-branch', true);
            else
                result.data('tt-branch', false);



            ttElement.treetable('loadBranch', parent, result);

            var node = ttElement.treetable('node', item[ttIdselector]);

            angular.forEach(item[ttChildrenSelector], function (child) {
                addRowsRecursively(child, node, ttElement);
            });
        };

        var table = $element;

        $scope.compileElement = function (node) {

            var scope = $scope.$parent.$new();

            angular.extend(scope, {
                node: node
            });

            var templated = angular.element(document.getElementById($element.data('ttRowtemplate')).innerHTML);


            var result = $compile(templated)(scope);

            return result.get(0);
        };

        $scope.addNodes = function () {

            $q.when(params.getNodes()).then(function (data) {
                angular.forEach(data, function (row) {
                    addRowsRecursively(row, null, $element);
                });
                if(params.options.initialState === "collapsed")
                    $element.treetable('collapseAll');
            });
        }

        $scope.refresh = function () {
            var rootNodes = table.data('treetable').nodes;
            while (rootNodes.length > 0) {
                table.treetable('removeNode', rootNodes[0].id);
            }
            $scope.addNodes();
        };
        params.refresh = $scope.refresh;

        if (!params.options)
            params.options = { expandable: true };
        table.treetable(params.options);

        $scope.addNodes();

    }])
    .directive('ttTable', [function () {
        return {
            restrict: 'A',
            scope: {
                ttParams: '='
            },
            controller: 'treetableController'
        }
    }]);
})();