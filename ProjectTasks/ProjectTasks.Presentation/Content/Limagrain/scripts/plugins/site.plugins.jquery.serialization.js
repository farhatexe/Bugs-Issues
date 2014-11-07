/// <reference path="../../../Metronic/metronic/assets/global/scripts/metronic.js" />
(function ($) {
    jQuery.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        a.forEach(function (item) {
            if (o[item.name] !== undefined) {
                if (!o[item.name].push) {
                    o[item.name] = [o[item.name]];
                }
                o[item.name].push(item.value || '');
            } else {
                o[item.name] = item.value || '';
            }
        });
        return o;
    }
})();