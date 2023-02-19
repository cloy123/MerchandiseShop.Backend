using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Queries.GetEventRoleDetails
{
    public class GetEventRoleDetailsQuery : IRequest<EventRoleDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
