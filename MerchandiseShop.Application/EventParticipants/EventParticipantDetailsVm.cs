using AutoMapper;
using MerchandiseShop.Application.Common;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Event;
using MerchandiseShop.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventParticipants
{
    public class EventParticipantDetailsVm : IMapWith<EventParticipant>
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid EventRoleId { get; set; }
        public EventRole EventRole { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsVisit { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EventParticipant, EventParticipantDetailsVm>()
                .ForMember(eventParticipantVm => eventParticipantVm.Id, opt => opt.MapFrom(eventParticipant => eventParticipant.Id))
                .ForMember(eventParticipantVm => eventParticipantVm.EventId, opt => opt.MapFrom(eventParticipant => eventParticipant.EventId))
                .ForMember(eventParticipantVm => eventParticipantVm.EventRoleId, opt => opt.MapFrom(eventParticipant => eventParticipant.EventRoleId))
                .ForMember(eventParticipantVm => eventParticipantVm.EventRole, opt => opt.MapFrom(eventParticipant => eventParticipant.EventRole))
                .ForMember(eventParticipantVm => eventParticipantVm.UserId, opt => opt.MapFrom(eventParticipant => eventParticipant.UserId))
                .ForMember(eventParticipantVm => eventParticipantVm.User, opt => opt.MapFrom(eventParticipant => eventParticipant.User))
                .ForMember(eventParticipantVm => eventParticipantVm.IsVisit, opt => opt.MapFrom(eventParticipant => eventParticipant.IsVisit));
        }
    }
}
