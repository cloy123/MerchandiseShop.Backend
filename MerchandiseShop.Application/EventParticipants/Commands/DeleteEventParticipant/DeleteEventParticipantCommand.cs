using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Commands.DeleteEventParticipant
{
    public class DeleteEventParticipantCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
