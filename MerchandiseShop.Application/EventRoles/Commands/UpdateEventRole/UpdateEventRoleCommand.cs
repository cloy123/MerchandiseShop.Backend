using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Commands.UpdateEventRole
{
    public class UpdateEventRoleCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UserTypeId { get; set; }
        public Guid EventId { get; set; }
        public int Prize { get; set; }
    }
}
