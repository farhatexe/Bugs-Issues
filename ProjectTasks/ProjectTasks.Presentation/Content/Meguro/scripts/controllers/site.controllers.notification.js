(function () {
    app.controller('notificationController', ['$scope', 'resourceProxy', 'notificationProxy', function ($scope, resourceProxy, notificationProxy) {
        $scope.notifications = notificationProxy.all;
        resourceProxy.loadResource(['Notification']) 
        
        var setNotifications = function () {
            $scope.$apply(function () {
                $scope.notifications = notificationProxy.all.filter(function(item){
                    return !item.DateViewed;
                });

                $scope.message = app.localization.Notification.Notification_Head_Title.format($scope.notifications.length);
            });
        };

        notificationProxy.events.on('set', setNotifications);
        notificationProxy.events.on('updated', setNotifications);
        notificationProxy.events.on('read', setNotifications);
        notificationProxy.events.on('sent', setNotifications);
    }]);
})();