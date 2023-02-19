using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Event;
using MerchandiseShop.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles
{
    public class EventResponsibleDetailsVm : IMapWith<EventResponsible>
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EventResponsible, EventResponsibleDetailsVm>()
                .ForMember(eventResponsibleVm => eventResponsibleVm.Id, opt => opt.MapFrom(eventResponsible => eventResponsible.Id))
                .ForMember(eventResponsibleVm => eventResponsibleVm.UserId, opt => opt.MapFrom(eventResponsible => eventResponsible.UserId))
                .ForMember(eventResponsibleVm => eventResponsibleVm.User, opt => opt.MapFrom(eventResponsible => eventResponsible.User))
                .ForMember(eventResponsibleVm => eventResponsibleVm.EventId, opt => opt.MapFrom(eventResponsible => eventResponsible.EventId));
        }
    }
}
