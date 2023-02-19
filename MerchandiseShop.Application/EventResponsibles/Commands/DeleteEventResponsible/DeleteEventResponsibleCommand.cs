using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Commands.DeleteEventResponsible
{
    public class DeleteEventResponsibleCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
