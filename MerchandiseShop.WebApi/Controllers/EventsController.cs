using AutoMapper;
using MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantList;
using MerchandiseShop.Application.EventResponsibles.Queries.GetEventResponsibleList;
using MerchandiseShop.Application.EventRoles.Queries.GetEventRoleList;
using MerchandiseShop.Application.Events.Commands.FinishEvent;
using MerchandiseShop.Application.Events.Commands.SignupEvent;
using MerchandiseShop.Application.Events.Queries.GetEventList;
using MerchandiseShop.Application.Users.Queries.GetUserDetails;
using MerchandiseShop.Domain.Users;
using MerchandiseShop.WebApi.AuthCommon;
using MerchandiseShop.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApi.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IMapper _mapper;

        public EventsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<EventsInfoVm>> GetEventsInfo()
        {

            var userIdClaim = User.Claims.FirstOrDefault(i => i.Type == "Id");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var queryUser = new GetUserDetailsQuery() { Id = Guid.Parse(userIdClaim.Value) };
            var user = await Mediator.Send(queryUser);
            if(user == null)
            {
                return Unauthorized();
            }


            var queryEvents = new GetEventListQuery();
            var events = (await Mediator.Send(queryEvents)).Events;

            if(user.ClassLetter != null && user.ClassNumber != null)
            {
                events = events.Where(e => e.AvalibleFor.Contains(user.ClassNumber.ToString() + user.ClassLetter)).ToList();
            }

            if(user.UserTypeId == UserType.Student.Id)
            {
                events = events.Where(e => e.EventResponsibles.Any()).ToList();
            }

            var result = new List<EventVm>();

            foreach (var evnt in events)
            {
                var evntVm = _mapper.Map<EventVm>(evnt);
                evntVm.EventResponsibles = _mapper.Map<List<EventResponsibleVm>>(evnt.EventResponsibles);
                evntVm.EventParticipants = _mapper.Map<List<EventParticipantVm>>(evnt.EventParticipants);
                result.Add(evntVm);
            }

            return Ok(new EventsInfoVm
            {
                Events = result
            }) ;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<FinishEventResultVm>> FinishEvent([FromBody] FinishEventDto finishEventDto)
        {

            var userIdClaim = User.Claims.FirstOrDefault(i => i.Type == "Id");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var queryUser = new GetUserDetailsQuery() { Id = Guid.Parse(userIdClaim.Value) };
            var user = await Mediator.Send(queryUser);
            if (user == null)
            {
                return Unauthorized();
            }

            var command = new FinishEventCommand();
            command.UserId = user.Id;
            command.EventId = finishEventDto.EventId;
            command.Participants = new List<ParticipantDto>();

            foreach (var p in finishEventDto.Participants)
            {
                command.Participants.Add(new ParticipantDto { ParticipantId = p.ParticipantId, IsVisit = p.IsVisit });
            }

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<SignupEventResultVm>> SignupEvent([FromBody] SignupEventDto signupEvent)
        {

            var userIdClaim = User.Claims.FirstOrDefault(i => i.Type == "Id");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var queryUser = new GetUserDetailsQuery() { Id = Guid.Parse(userIdClaim.Value) };
            var user = await Mediator.Send(queryUser);
            if (user == null)
            {
                return Unauthorized();
            }

            var command = new SignupEventCommand
            {
                EventId = signupEvent.EventId,
                UserId = user.Id,
                EventRoleId = signupEvent.EventRoleId
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
