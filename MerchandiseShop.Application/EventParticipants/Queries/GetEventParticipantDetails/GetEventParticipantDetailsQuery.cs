using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantDetails
{
    public class GetEventParticipantDetailsQuery : IRequest<EventParticipantDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
