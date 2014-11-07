namespace ProjectTasks.Presentation
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using ProjectTasks.Crosscuttings.IoC;
    using ProjectTasks.Presentation.Core.Notification;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Notification hub to handle web socket communication between server and its clients.
    /// </summary>
    public class NotificationHub : Hub
    {
        private static IList<HubCallerContext> contexts = new List<HubCallerContext>();

        /// <summary>
        /// Occurs when a new connection has been established.
        /// </summary>
        /// <returns>Async task</returns>
        public override Task OnConnected()
        {
            Groups.Add(Context.ConnectionId, Context.User.Identity.Name);

            NotificationHub.contexts.Add(Context);

            return base.OnConnected().ContinueWith((t) =>
            {
                //var notifications = userNotificationService.GetNotificationsForCurrentUser(true);

                //Clients.Caller.set(notifications);
            });
        }

        /// <summary>
        /// Occurs when a client disconnects from the hub.
        /// </summary>
        /// <returns>Async task</returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            //Groups.Remove(Context.ConnectionId, Context.User.Identity.Name);

            NotificationHub.contexts.Remove(Context);

            return base.OnDisconnected(stopCalled);
        }

        ///// <summary>
        ///// Stop updates for a specific notification id
        ///// </summary>
        ///// <param name="id">Notification id</param>
        //public void UnsuscribeNotificationUpdate(int id)
        //{
        //    NotificationManager.UnregisterForPush(id);
        //}
    }
}
