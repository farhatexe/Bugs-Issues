(function () {
    app.controller('sidebarController', ['$rootScope', '$location', function ($rootScope, $location) {
        $rootScope.$on('$viewContentLoaded', function () {
            //var currentUrl = $location.path();

            //$('.page-sidebar-wrapper li')
            //    .removeClass('active')
            //    .removeClass("open");


            //$('.page-sidebar-wrapper a[href]')
            //    .filter(function () {
            //        if (currentUrl == "/")
            //            return $(this).attr('href') == currentUrl;

            //        return this.href.toLowerCase().indexOf(currentUrl.toLowerCase()) >= 0;
            //    })
            //    .each(function () {
            //        $this = $(this);

            //        $this.closest("li").addClass("active");

            //        $this.parents("ul.sub-menu").each(function () {
            //            $item = $(this);
            //            $item.show();
            //            $item.closest("li").addClass("open").addClass("active");
            //        });
            //    });
        });
    }]);
})();