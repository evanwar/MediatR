using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsMediator
{
    public abstract class NotificationHandlerBase : INotificationHandler
    {
        public virtual void Handle(string message)
        {
            Debug.WriteLine($"{this.GetType()} => {message}");
        }
    }
}
