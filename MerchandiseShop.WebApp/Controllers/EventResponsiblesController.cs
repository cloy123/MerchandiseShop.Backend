using AutoMapper;
using MerchandiseShop.Application.EventResponsibles.Commands.CreateEventResponsible;
using MerchandiseShop.Application.EventResponsibles.Commands.DeleteEventResponsible;
using MerchandiseShop.Application.EventResponsibles.Queries.GetEventResponsibleDetails;
using MerchandiseShop.Application.EventResponsibles.Queries.GetEventResponsibleList;
using MerchandiseShop.Application.Users.Queries.GetUserList;
using MerchandiseShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerchandiseShop.WebApp.Controllers
{
    public class EventResponsiblesController : BaseController
    {
        private readonly IMapper _mapper;

        public EventResponsiblesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(Guid eventId)
        {
            var query = new GetEventResponsibleListQuery()
            {
                EventId = eventId
            };
            var list = await Mediator.Send(query);
            return View("Index", list);
        }

        public async Task<IActionResult> Create(Guid eventId)
        {
            var vm = new EventResponsibleDto
            {
                EventId = eventId
            };


            var queryUsers = new GetUserListQuery();
            var users = await Mediator.Send(queryUsers);

            ViewData["UserId"] = new SelectList(users.Users, "Id", "UserFullInfo");

            return View("Create", vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(EventResponsibleDto eventResponsibleDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateEventResponsibleCommand>(eventResponsibleDto);
                var eventResponsibleId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index), new { eventId = eventResponsibleDto.EventId });
            }

            var queryUsers = new GetUserListQuery();
            var users = await Mediator.Send(queryUsers);

            ViewData["UserId"] = new SelectList(users.Users, "Id", "UserFullInfo");

            return View("Create", eventResponsibleDto);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetEventResponsibleDetailsQuery
            {
                Id = id.Value
            };
            var eventResponsibleDetails = await Mediator.Send(query);
            if (eventResponsibleDetails == null)
            {
                return NotFound();
            }

            var eventResponsibleDto = _mapper.Map<EventResponsibleDto>(eventResponsibleDetails);

            return View("Delete", eventResponsibleDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, Guid eventId)
        {
            var command = new DeleteEventResponsibleCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index), new { eventId = eventId });
        }
    }
}
