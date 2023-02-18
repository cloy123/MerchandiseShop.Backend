using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantList
{
    public class GetEventParticipantListQuery : IRequest<EventParticipantListVm>
    {
        public Guid EventId { get; set; }
    }
}
