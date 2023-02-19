using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Commands.DeleteEventRole
{
    public class DeleteEventRoleCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
