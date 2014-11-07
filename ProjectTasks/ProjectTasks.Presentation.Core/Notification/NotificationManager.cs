namespace ProjectTasks.Presentation.Core.Notification
{
    using Microsoft.AspNet.SignalR;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Notification manager to handle notifications sent to the client.
    /// </summary>
    public static class NotificationManager
    {
        private static Timer _timer;

        //private static Collection<Tuple<UserNotificationDto, AuthenticationToken>> _notifications = new Collection<Tuple<UserNotificationDto, AuthenticationToken>>();

        private static IList<Func<Task>> _tasks = new List<Func<Task>>();

        /// <summary>
        /// Register a new notification to push to the client.
        /// </summary>
        /// <param name="notification">Notification DTO to push</param>
        //public static void RegisterForPush(object notification)
        //{
        //    lock (_notifications)
        //    {
        //        //if (!_notifications.Any(x => x.Item1.Id == notification.Id))
        //        //    _notifications.Add(new Tuple<UserNotificationDto, AuthenticationToken>(notification, Thread.CurrentPrincipal.Identity.GetAuthToken()));
        //    }
        //}

        ///// <summary>
        ///// Gets all current user notifications.
        ///// </summary>
        //public static IEnumerable<UserNotificationDto> CurrentUserNotifications
        //{
        //    get
        //    {
        //        lock (_notifications)
        //        {
        //            return _notifications.Where(x => x.Item2.UserLogin == Thread.CurrentPrincipal.Identity.Name).Select(x => x.Item1).ToArray();
        //        }
        //    }
        //}

        ///// <summary>
        ///// Unsubscribe the client for a specific notification.
        ///// Stop updating its status.
        ///// </summary>
        ///// <param name="notificationId"></param>
        //public static void UnregisterForPush(int notificationId)
        //{
        //    lock (_notifications)
        //    {
        //        var item = _notifications.SingleOrDefault(x => x.Item1.Id == notificationId);

        //        if (item == null)
        //            return;

        //        _notifications.Remove(item);
        //    }
        //}

        ///// <summary>
        ///// Send to notification to the client.
        ///// </summary>
        ///// <param name="notification">Notification to send.</param>
        //public static void SendNotification(UserNotificationDto notification)
        //{
        //    CurrentClients.send(notification);
        //}

        ///// <summary>
        ///// Mark as read the specified notification.
        ///// </summary>
        ///// <param name="notification">Notification to mark.</param>
        //public static void MarkAsRead(UserNotificationDto notification)
        //{
        //    CurrentClients.markAsRead(notification);
        //}

        /// <summary>
        /// Register a new task to be executed.
        /// </summary>
        public static void RegisterTasks()
        {
            _tasks.Add(SendNotifications);

            _timer = new Timer(new TimerCallback(RunTasks), null, 0, Convert.ToInt32(ConfigurationManager.AppSettings["NotificationPushTimer"]));
        }

        #region < Private Members >

        /// <summary>
        /// Run all tasks.
        /// </summary>
        /// <param name="state">Current state</param>
        private static void RunTasks(object state)
        {
            Task.WaitAll(_tasks.Select(x => x()).ToArray());
        }

        /// <summary>
        /// Gets the current clients.
        /// </summary>
        private static dynamic CurrentClients
        {
            get
            {
                return GlobalHost.ConnectionManager.GetHubContext<NotificationHub>()
                    .Clients.Group(Thread.CurrentPrincipal.Identity.Name);
            }
        }

        /// <summary>
        /// Send all notifications to the clients.
        /// </summary>
        /// <returns></returns>
        private static Task SendNotifications()
        {
            //IUserNotificationServices notificationServices = IoCApplicationFactory.Resolve<IUserNotificationServices>();

            return Task.Factory.StartNew(() =>
            {
                //lock (_notifications)
                //{
                //    for (int i = 0; i < _notifications.Count; i++)
                //    {
                //        var item = _notifications[i];

                //        if (item == null || item.Item1 == null || item.Item2 == null)
                //        {
                //            _notifications.RemoveAt(i);
                //            continue;
                //        }

                //        var principal = new LimagrainPrincipal(item.Item2);
                //        Thread.CurrentPrincipal = principal;

                //        var notification = notificationServices.GetUserNotificationById(item.Item1.Id);

                //        _notifications[i] = new Tuple<UserNotificationDto, AuthenticationToken>(notification, item.Item2);

                //        GlobalHost.ConnectionManager.GetHubContext<NotificationHub>()
                //            .Clients.Group(Thread.CurrentPrincipal.Identity.Name).update(notification);
                //    }
                //}
            });
        }

        #endregion < Methods >
    }
}
