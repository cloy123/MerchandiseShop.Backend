using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> AvalibleFor { get; set; }
    }
}
