using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Notifications.Queries.GetNotificationList
{
    public class GetNotificationListQuery : IRequest<NotificationListVm>
    {
        public Guid UserId { get; set; }
    }
}
