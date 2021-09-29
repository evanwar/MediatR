using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MadiatRDemo
{
    public class PingNotificationHandler1 : INotificationHandler<PingNotification>
    {
        public Task Handle(PingNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Pong 1....");

            return Task.CompletedTask;
        }
    }

    public class PingNotificationHandler2 : INotificationHandler<PingNotification>
    {
        public Task Handle(PingNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Pong 2.....");

            return Task.CompletedTask;
        }
    }

    public class PingNotificationHandler3 : INotificationHandler<PingNotification>
    {
        public Task Handle(PingNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Pong 3.....");

            return Task.CompletedTask;
        }
    }

}
