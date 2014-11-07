(function () {
    $.fn.serverSelect = function (options) {
        var $this = $(this);

        if ($this.data('ServerSelect'))
            return $this.data('ServerSelect');

        var serverSelect = (function () {
            var element = $this;
            var datasource = [];

            var defaults = {
                method: 'GET',
                minimumInputLength: 2,
                allowClear: true,
                placeholder: '',
                loadDataUrl: '',
                initSelectionUrl: '',
                multiple: false,
                onServerPost: null
            };

            var params = $.extend({}, defaults, options);

            element.select2({
                multiple: params.multiple,
                minimumInputLength: params.minimumInputLength,
                placeholder: params.placeholder,
                allowClear: params.allowClear,
                ajax: {
                    method: params.method,
                    url: params.loadDataUrl,
                    datatype: "json",
                    data: function (term, page) {
                        var result = { term: term };

                        if (params.onServerPost)
                            result = params.onServerPost(result);

                        return result;
                    },
                    results: function (data, page) {
                        datasource = [];

                        $.each(data, function (index, item) {
                            datasource.push({ id: item.Id, text: item.Label });
                        });
                        return { results: datasource };
                    }
                },
                initSelection: function (element, callback) {
                    var val = $(element).val();
                    if (val !== '') {
                        var ids = val.split(",").map(function (x) { return parseInt(x); });

                        $.get(
                            params.initSelectionUrl,
                            $.param({ ids: ids }, true),
                            function (data) {
                                if (data.length) callback({ id: data[0].Id, text: data[0].Label });
                            }
                        );
                    }
                }
            });
        })();

        $this.data('ServerSelect', serverSelect);

        return serverSelect;
    }
})();