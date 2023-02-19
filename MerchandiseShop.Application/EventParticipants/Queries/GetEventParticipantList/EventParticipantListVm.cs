using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantList
{
    public class EventParticipantListVm
    {
        public IList<EventParticipantDetailsVm> EventParticipants { get; set; }

        public Guid EventId { get; set; }
    }
}
