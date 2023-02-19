using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Queries.GetEventRoleList
{
    public class EventRoleListVm
    {
        public IList<EventRoleDetailsVm> EventRoles { get; set; }

        public Guid EventId { get; set; }
    }
}
