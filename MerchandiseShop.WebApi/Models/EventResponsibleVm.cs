using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Event;

namespace MerchandiseShop.WebApi.Models
{
    public class EventResponsibleVm : IMapWith<EventResponsible>
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }//имя
        public string LastName { get; set; }//фамилия
        public string Email { get; set; }
        public int? ClassNumber { get; set; }
        public string? ClassLetter { get; set; }
        public int GenderId { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<EventResponsible, EventResponsibleVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(er => er.Id))
                .ForMember(vm => vm.EventId, opt => opt.MapFrom(er => er.EventId))
                .ForMember(vm => vm.UserId, opt => opt.MapFrom(er => er.UserId))
                .ForMember(vm => vm.UserTypeId, opt => opt.MapFrom(er => er.User.UserTypeId))
                .ForMember(vm => vm.FirstName, opt => opt.MapFrom(er => er.User.FirstName))
                .ForMember(vm => vm.LastName, opt => opt.MapFrom(er => er.User.LastName))
                .ForMember(vm => vm.Email, opt => opt.MapFrom(er => er.User.Email))
                .ForMember(vm => vm.ClassNumber, opt => opt.MapFrom(er => er.User.ClassNumber))
                .ForMember(vm => vm.ClassLetter, opt => opt.MapFrom(er => er.User.ClassLetter))
                .ForMember(vm => vm.GenderId, opt => opt.MapFrom(er => er.User.GenderId));
        }
    }
}
