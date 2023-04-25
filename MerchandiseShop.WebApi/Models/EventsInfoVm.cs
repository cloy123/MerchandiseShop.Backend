using MerchandiseShop.Application.Events;
using MerchandiseShop.Domain.Event;

namespace MerchandiseShop.WebApi.Models
{
    public class EventsInfoVm
    {
        public List<EventVm> Events { get; set; } 
    }
}
