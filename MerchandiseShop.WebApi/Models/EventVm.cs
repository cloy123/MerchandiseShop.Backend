using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Events;
using MerchandiseShop.Domain.Event;

namespace MerchandiseShop.WebApi.Models
{
    public class EventVm : IMapWith<EventDetailsVm>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> AvailableFor { get; set; }

        public List<EventResponsibleVm> EventResponsibles { get; set; }
        public List<EventRole> EventRoles { get; set; }
        public List<EventParticipantVm> EventParticipants { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EventDetailsVm, EventVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(edVm => edVm.Id))
                .ForMember(vm => vm.Date, opt => opt.MapFrom(edVm => edVm.Date))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(edVm => edVm.Name))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(edVm => edVm.Description))
                .ForMember(vm => vm.AvailableFor, opt => opt.MapFrom(edVm => edVm.AvalibleFor))
                .ForMember(vm => vm.EventRoles, opt => opt.MapFrom(edVm => edVm.EventRoles));
        }
    }
}
