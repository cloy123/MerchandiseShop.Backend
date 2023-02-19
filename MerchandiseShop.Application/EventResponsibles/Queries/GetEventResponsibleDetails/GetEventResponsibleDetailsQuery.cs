using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Queries.GetEventResponsibleDetails
{
    public class GetEventResponsibleDetailsQuery : IRequest<EventResponsibleDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
