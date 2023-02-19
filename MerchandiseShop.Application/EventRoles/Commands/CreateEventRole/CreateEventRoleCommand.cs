using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Commands.CreateEventRole
{
    public class CreateEventRoleCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public int UserTypeId { get; set; }
        public Guid EventId { get; set; }
        public int Prize { get; set; }
    }
}
