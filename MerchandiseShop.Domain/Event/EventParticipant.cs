using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.Event
{
    public class EventParticipant
    {
        public Guid Id { get; set; }
        public Guid EnentId { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public bool IsVisit { get; set; }
    }
}
