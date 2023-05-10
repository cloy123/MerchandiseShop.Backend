using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events
{
    public class EventDetailsVm : IMapWith<Event>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> AvalibleFor { get; set; }


        public bool IsCompleted { get; set; }

        public List<EventResponsible> EventResponsibles { get; set; }
        public List<EventRole> EventRoles { get; set; }
        public List<EventParticipant> EventParticipants { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventDetailsVm>()
                .ForMember(eventVm => eventVm.Id, opt => opt.MapFrom(event_ => event_.Id))
                .ForMember(eventVm => eventVm.Date, opt => opt.MapFrom(event_ => event_.Date))
                .ForMember(eventVm => eventVm.Name, opt => opt.MapFrom(event_ => event_.Name))
                .ForMember(eventVm => eventVm.Description, opt => opt.MapFrom(event_ => event_.Description))
                .ForMember(eventVm => eventVm.AvalibleFor, opt => opt.MapFrom(event_ => event_.GetAvalibleFor()))
                .ForMember(eventVm => eventVm.IsCompleted, opt => opt.MapFrom(event_ => event_.IsCompleted));
        }
    }
}
