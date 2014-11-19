(function () {
    app.controller('layoutController', ['$scope', function ($scope) {

        var layout = {
            Normal: 'container',
            Fluid: 'container-fluid'
        };

        var icon = {
            Expand: 'fluid',
            Normal: 'normal'
        };

        $scope.layoutMode = layout.Normal;
        $scope.icon = $scope.layoutMode === layout.Normal ? icon.Normal : icon.Expand;

        $scope.layoutSwitching = function () {
            if ($scope.layoutMode === layout.Normal) {
                $scope.layoutMode = layout.Fluid;
                $scope.icon = icon.Expand;
            }
            else {
                $scope.layoutMode = layout.Normal;
                $scope.icon = icon.Normal;
            }
        };
        $scope.handlePortletFullscreen = function (portletId) {
            var portlet = $('#' + portletId);
            if (portlet.hasClass('portlet-fullscreen')) {
                $(this).removeClass('on');
                portlet.removeClass('portlet-fullscreen');
                $('body').removeClass('page-portlet-fullscreen');
                portlet.children('.portlet-body').css('height', 'auto');
            } else {
                var height = Metronic.getViewPort().height -
                    portlet.children('.portlet-title').outerHeight() -
                    parseInt(portlet.children('.portlet-body').css('padding-top')) -
                    parseInt(portlet.children('.portlet-body').css('padding-bottom'));

                $(this).addClass('on');
                portlet.addClass('portlet-fullscreen');
                $('body').addClass('page-portlet-fullscreen');
                portlet.children('.portlet-body').css('height', height);
            }
            
        };
    }]);
})();