(function () {
    app.directive('serverdropdown', function () {
        return {
            restrict: 'A',
            replace: false,
            link: function (scope, elm, attributes) {
                var params = {
                    method: 'GET',
                    minimumInputLength: 0,
                    allowClear: true,
                    placeholder: '',
                    loadDataUrl: '',
                    initSelectionUrl: '',
                    multiple: false,
                    onServerPost: null
                };
                
                if (attributes.sdMultiple) {
                    params.multiple = JSON.parse(attributes.sdMultiple);
                }
                if (attributes.sdMethod) {
                    params.method = attributes.sdMethod;
                }

                if (attributes.sdMinInputLength){
                    params.minimumInputLength = attributes.sdMinInputLength;
                }

                elm.select2({
                    multiple: params.multiple,
                    minimumInputLength: params.minimumInputLength,
                    placeholder: params.placeholder,
                    allowClear: params.allowClear,
                    ajax: {
                        method: params.method,
                        url: attributes.sdUrl,
                        datatype: "json",
                        data: function (term, page) {
                            var result = { term: term };
                            if (attributes.sdOnServerPost && scope[attributes.sdOnServerPost])
                                result = scope[attributes.sdOnServerPost](result);
                            return result;
                        },
                        results: function (data, page) {
                            datasource = [];
                            $.each(data, function (index, item) {
                                datasource.push({ id: item[attributes.sdVal], text: item[attributes.sdLabel] });
                            });
                            return { results: datasource };
                        }
                    },
                    initSelection: function (element, callback) {
                        var elementValue = [];

                        if ($(element).val())
                            elementValue = $(element).val().split(',');

                        if (!elementValue.length) return;

                        $.ajax({
                            method: params.method,
                            url: attributes.sdUrl,
                            datatype: "json",
                            data: { values: elementValue },
                            success: function (data) {
                                if (!data)
                                    return;

                                var mappedValues = data.filter(function (item) {

                                    var exists = elementValue.filter(function (val) {
                                        return item[attributes.sdVal] == val;
                                    });

                                    return exists.length;
                                }).map(function (item) {
                                    return { id: item[attributes.sdVal], text: item[attributes.sdLabel] };
                                });

                                if (!mappedValues.length)
                                    return;

                                if (params.multiple)
                                    callback(mappedValues);
                                else
                                    callback(mappedValues[0]);

                                if (attributes.sdInit && scope[attributes.sdInit]) {
                                    scope[attributes.sdInit](elm);
                                }
                            }
                        });
                    }
                });

                var ngDirBindModel = (attributes.ngModel) ? attributes.ngModel : attributes.ngBind;
                if (ngDirBindModel) {
                    scope.$watch(ngDirBindModel, function () {
                        var scopeVariableName = "scope";
                        ngDirBindModel.split('.').map(function (item) {
                            if (scopeVariableName && eval(scopeVariableName + '.' + item))
                                scopeVariableName = scopeVariableName + '.' + item;
                            else
                                scopeVariableName = undefined;
                        });
                        
                        if (scopeVariableName)
                            $(elm).select2('val', eval(scopeVariableName));
                    });
                }
            }
        };
    });
})();