using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Queries.GetEventResponsibleList
{
    public class GetEventResponsibleListQuery : IRequest<EventResponsibleListVm>
    {
        public Guid EventId { get; set; }
    }
}
