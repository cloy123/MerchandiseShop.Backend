using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.Notifications
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsSend { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
