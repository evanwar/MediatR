using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications
{
    public abstract class NotificationHandlerBase
    {
        public virtual void Handle(string message)
        {
            Debug.WriteLine($"{this.GetType()} => {message}");
        }
    }
}
