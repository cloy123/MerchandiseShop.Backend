using AutoMapper;

namespace MerchandiseShop.WebApp.Controllers
{
    public class EventParticipantController : BaseController
    {
        private readonly IMapper _mapper;

        public EventParticipantController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var query = new GetEventListQuery();
        //    var list = await Mediator.Send(query);
        //    return View("Index", list);
        //}
    }
}
