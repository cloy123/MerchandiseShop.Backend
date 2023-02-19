using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Queries.GetEventResponsibleList
{
    public class EventResponsibleListVm
    {
        public IList<EventResponsibleDetailsVm> EventResponsibles { get; set; }

        public Guid EventId { get; set; }
    }
}
