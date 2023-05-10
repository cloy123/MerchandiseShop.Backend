using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.SignupEvent
{
    public class SignupEventCommand : IRequest<SignupEventResultVm>
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public Guid EventRoleId { get; set; }
    }
}
