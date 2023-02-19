using AutoMapper;
using MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantList;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers
{
    public class EventParticipantsController : BaseController
    {
        private readonly IMapper _mapper;

        public EventParticipantsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(Guid eventId)
        {
            var query = new GetEventParticipantListQuery()
            {
                EventId = eventId
            };
            var list = await Mediator.Send(query);
            return View("Index", list);
        }
    }
}
