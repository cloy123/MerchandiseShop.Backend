using MerchandiseShop.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events
{
    public class EventParticipantVm
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid EventRoleId { get; set; }
        public Guid UserId { get; set; }
        public bool IsVisit { get; set; }
        public ActionType actionType { get; set; } = ActionType.Nothing; 
    }
}
