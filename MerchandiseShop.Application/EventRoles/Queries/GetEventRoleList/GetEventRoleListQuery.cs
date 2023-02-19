using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Queries.GetEventRoleList
{
    public class GetEventRoleListQuery : IRequest<EventRoleListVm>
    {
        public Guid EventId { get; set; }
    }
}
