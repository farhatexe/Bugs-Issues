(function () {

    function getColumn(scope, elm, callback) {
        $columnsPropName = $(elm).closest('table').data('dt-columns');

        var elmIndex = $(elm).closest('table').find('th').index(elm);

        var $DTColumnBuilder = angular.injector(['ng', 'datatables']).get('DTColumnBuilder');

        if (!scope[$columnsPropName])
            scope[$columnsPropName] = [];

        var column = scope[$columnsPropName][elmIndex];

        if (!column) {
            var column = $DTColumnBuilder.newColumn($(elm).data('dt-prop'));
            scope[$columnsPropName].push(column);
        }

        callback(column);
    }

    app.directive('datatable',  ['$compile', function ($compile) {
        return {
            restrict: 'A',
            replace: false,
            link: function (scope, elm, attributes) {
                if (attributes.dtOptions && scope[attributes.dtOptions]) {

                    if (attributes.dtLocalize != undefined) {
                        scope[attributes.dtOptions].withOption('language', {
                            paginate: {
                                first: app.localization.Global.First,
                                previous: app.localization.Global.Previous,
                                next: app.localization.Global.Next,
                                last: app.localization.Global.Last
                            }
                        });
                    }

                    if (!scope[attributes.dtOptions].order) {
                        scope[attributes.dtOptions].withOption('order', []);
                    }

                    if (attributes.dtTemplate) {
                        scope[attributes.dtOptions].withOption('fnRowCallback',
                            function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                                var data = $.extend(scope.$new(), aData);

                                var template = document.getElementById(attributes.dtTemplate).innerHTML;
                                nRow.innerHTML = template;

                                var templated = angular.element(nRow);

                                var compiled = $compile(templated);
                                data.$apply(function () { compiled(data); });
                            });
                    }
                }
            }
        };
    }]);

    app.directive('dtProp', function () {
        return {
            restrict: 'A',
            replace: false,
            priority: 0,
            link: function (scope, elm, attributes) {
                getColumn(scope, elm, function (column) {
                    return column.withTitle($(elm).text());
                });
            }
        };
    });

    app.directive('dtColumnOption', function () {
        return {
            restrict: 'A',
            replace: false,
            priority: 1,
            link: function (scope, elm, attributes) {
                getColumn(scope, elm, function (column) {
                    var options = JSON.parse(attributes.dtColumnOption);
                    options.forEach(function (option) {
                        column.withOption(option.key, option.value);
                    });
                });
            }
        };
    });
})();
