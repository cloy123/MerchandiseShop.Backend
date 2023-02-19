using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants.Commands.UpdateEventParticipant
{
    public class UpdateEventParticipantCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid EventRoleId { get; set; }
        public Guid UserId { get; set; }
        public bool IsVisit { get; set; }
    }
}
