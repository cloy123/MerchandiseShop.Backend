using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Commands.CreateEventResponsible
{
    public class CreateEventResponsibleCommand : IRequest<Guid>
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
    }
}
