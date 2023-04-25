using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Notifications.Queries.GetNotificationList
{
    public class NotificationListVm
    {
        public IList<NotificationDetailsVm> Notifications { get; set; }
    }
}
