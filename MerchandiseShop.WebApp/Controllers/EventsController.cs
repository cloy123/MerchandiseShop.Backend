using AutoMapper;
using MerchandiseShop.Application.Events.Commands.CreateEvent;
using MerchandiseShop.Application.Events.Commands.DeleteEvent;
using MerchandiseShop.Application.Events.Commands.UpdateEvent;
using MerchandiseShop.Application.Events.Queries.GetEventDetails;
using MerchandiseShop.Application.Events.Queries.GetEventList;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApp.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IMapper _mapper;

        public EventsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetEventListQuery();
            var list = await Mediator.Send(query);
            return View("Index", list);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(EventDto eventDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateEventCommand>(eventDto);
                var eventId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View("Create", eventDto);
        }


        [HttpPost]
        public ActionResult AddAvalibleFor(EventDto eventDto)
        {
            if (eventDto.NewAvalibleFor != null || eventDto.NewAvalibleFor != string.Empty)
            {
                eventDto.AvalibleFor.Add(eventDto.NewAvalibleFor);
                eventDto.NewAvalibleFor = string.Empty;
            }
            if(eventDto.Id == Guid.Empty)
            {
                return View("Create", eventDto);
            }
            else
            {
                return View("Edit", eventDto);
            }
        }

        [HttpPost]
        public ActionResult DeleteAvalibleFor(EventDto eventDto, int index)
        {
            eventDto.AvalibleFor.RemoveAt(index);
            if (eventDto.Id == Guid.Empty)
            {
                return View("Create", eventDto);
            }
            else
            {
                return View("Edit", eventDto);
            }
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetEventDetailsQuery
            {
                Id = id.Value
            };
            var eventDetails = await Mediator.Send(query);
            var eventDto = _mapper.Map<EventDto>(eventDetails);

            return View("Edit", eventDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventDto eventDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateEventCommand>(eventDto);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", eventDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetEventDetailsQuery
            {
                Id = id.Value
            };
            var eventDetails = await Mediator.Send(query);
            if (eventDetails == null)
            {
                return NotFound();
            }

            var eventDto = _mapper.Map<EventDto>(eventDetails);

            return View("Delete", eventDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var command = new DeleteEventCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
