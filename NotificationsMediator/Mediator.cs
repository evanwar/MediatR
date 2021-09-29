using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsMediator
{
    public class Mediator : IMediator
    {
        private readonly IEnumerable<INotificationHandler> handlers;

        public Mediator(IEnumerable<INotificationHandler> handlers)
        {
            this.handlers = handlers;
        }


        public void Publish(string message)
        {
            foreach (var handler in handlers)
            {
                handler.Handle(message);
            }
        }
    }
}
