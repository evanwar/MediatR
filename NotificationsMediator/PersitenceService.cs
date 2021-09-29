using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsMediator
{
    public class PersitenceService
    {
        private readonly IMediator mediator;

        public PersitenceService(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public void SaveChanges()
        {
            mediator.Publish("Save");
        }

    }
}
