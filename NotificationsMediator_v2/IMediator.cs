using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsMediator
{
    public interface IMediator
    {
        void Publish(string message);
    }
}
