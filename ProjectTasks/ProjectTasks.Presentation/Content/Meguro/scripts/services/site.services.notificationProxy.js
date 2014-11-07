/// <reference path="../../Metronic/metronic/assets/global/plugins/jquery-1.11.0.min.js" />
/// <reference path="../../../SignalR/jquery.signalR-2.1.2.min.js" />
/// <reference path="../../Angular/angular.min.js" />
(function () {
    var notificationHub = $.connection.notificationHub;
    notificationHub.client.send = function (message) { alert(message); };

    app.factory('notificationProxy', function () {
        var appProxy = {
            events: $({}),
            all: [],
            max: 10,
            parse: function (notification) {
                if (notification.WorkspaceLink)
                    notification.WorkspaceLink = JSON.parse(notification.WorkspaceLink);
                return notification;
            },
            unsubscribe: function (notification) {
                notificationHub.server.unsuscribeNotificationUpdate(notification.Id);
                appProxy.events.trigger("unsuscribed");

            },
            open: function (notification) {
                $modal.open({
                    templateUrl: "/notification/open?id=" + id
                });
            }
        };

        notificationHub.client.set = function (notifications) {
            notifications.forEach(appProxy.parse);

            $.merge(appProxy.all, notifications);

            appProxy.events.trigger("set");
            console.log("Notifications set.");
        };

        notificationHub.client.send = function (notification) {
            appProxy.all.unshift(notification);

            appProxy.events.trigger("sent", notification);
            console.log("Notifications sent.");
        };

        notificationHub.client.update = function (notification) {
            if (!notification) return;

            appProxy.all.filter(function (item) {
                item.Id == notification.Id;
            }).forEach(function () {
                appProxy.all.splice(appProxy.all.indexOf(this), 1, notification);
            });

            appProxy.parse(notification);
            console.log("Notification updated : " + notification.Id + ".");
            appProxy.events.trigger("updated", notification);
        };

        notificationHub.client.markAsRead = function (notification) {
            if (!notification) return;

            var current = appProxy.filter(function (item) {
                return item.Id == notification.Id;
            })[0];

            if (!current) return;

            appProxy.all.splice(appProxy.all.indexOf(current), 1);

            appProxy.parse(notification);

            console.log("Notification read : " + notification.Id + ".");
            appProxy.events.trigger("read", notification);
        }

        return appProxy;
    });
})();