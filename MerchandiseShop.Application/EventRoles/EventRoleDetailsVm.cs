using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles
{
    public class EventRoleDetailsVm : IMapWith<EventRole>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UserTypeId { get; set; }
        public Guid EventId { get; set; }
        public int Prize { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EventRole, EventRoleDetailsVm>()
                .ForMember(eventRoleVm => eventRoleVm.Id, opt => opt.MapFrom(eventRole => eventRole.Id))
                .ForMember(eventRoleVm => eventRoleVm.Name, opt => opt.MapFrom(eventRole => eventRole.Name))
                .ForMember(eventRoleVm => eventRoleVm.UserTypeId, opt => opt.MapFrom(eventRole => eventRole.UserTypeId))
                .ForMember(eventRoleVm => eventRoleVm.EventId, opt => opt.MapFrom(eventRole => eventRole.EventId))
                .ForMember(eventRoleVm => eventRoleVm.Prize, opt => opt.MapFrom(eventRole => eventRole.Prize));
        }
    }
}
