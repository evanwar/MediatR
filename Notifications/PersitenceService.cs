using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications
{
    public class PersitenceService
    {
        private readonly NotificationHandler1 notificationHandler1;
        private readonly NotificationHandler2 notificationHandler2;
        private readonly NotificationHandler3 notificationHandler3;

        public PersitenceService(NotificationHandler1 notificationHandler1,
                                 NotificationHandler2 notificationHandler2,
                                 NotificationHandler3 notificationHandler3)
        {
            this.notificationHandler1 = notificationHandler1;
            this.notificationHandler2 = notificationHandler2;
            this.notificationHandler3 = notificationHandler3;
        }


        public void SaveChanges()
        {
            notificationHandler1.Handle("SaveChanges................");
            notificationHandler2.Handle("SaveChanges................");
            notificationHandler3.Handle("SaveChanges................");
        }

    }
}
