using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.FinishEvent
{
    public class ParticipantDto
    {
        public Guid ParticipantId { get; set; }
        public bool IsVisit { get; set; }
    }
}
