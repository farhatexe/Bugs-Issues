(function () {
    app.factory('resourceProxy', ['$resource', '$locale', function ($resource, $locale) {
        var loadResource = function (resources) {
            var filter = resources.filter(function (item) {
                return !app.localization[item];
            });

            if (filter.length) {
                $resource('/resource').get({ res: filter }, function (data) {
                    app.localization = $.extend({}, app.localization, data);
                });
            }
        };
        return { loadResource: loadResource, currentLocale: $locale.id };
    }]);
})();