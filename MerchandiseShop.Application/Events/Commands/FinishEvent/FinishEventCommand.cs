using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.FinishEvent
{
    public class FinishEventCommand : IRequest<FinishEventResultVm>
    {
        public Guid ResponsibleId { get; set; }
        public Guid EventId { get; set; }
        public List<ParticipantDto> Participants { get; set; }
    }
}
