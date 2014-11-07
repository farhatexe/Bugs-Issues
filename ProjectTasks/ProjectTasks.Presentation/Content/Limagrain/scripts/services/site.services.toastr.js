(function () {
    app.factory('toastr', function () {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": 'toast-top-right',
            "onclick": null,
            "showDuration": "10000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        return {
            type: {
                info: 'info',
                success: 'success',
                warning: 'warning',
                error: 'error'
            },
            show: function (type, msg, title) {
                toastr[type](msg, title);
            }
        };
    });
})();