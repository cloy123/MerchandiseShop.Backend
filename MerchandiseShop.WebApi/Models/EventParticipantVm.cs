using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Event;

namespace MerchandiseShop.WebApi.Models
{
    public class EventParticipantVm : IMapWith<EventParticipant>
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid EventRoleId { get; set; }
        public Guid UserId { get; set; }
        public bool IsVisit { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }//имя
        public string LastName { get; set; }//фамилия
        public string Email { get; set; }
        public int? ClassNumber { get; set; }
        public string? ClassLetter { get; set; }
        public int GenderId { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<EventParticipant, EventParticipantVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(ep => ep.Id))
                .ForMember(vm => vm.EventId, opt => opt.MapFrom(ep => ep.EventId))
                .ForMember(vm => vm.EventRoleId, opt => opt.MapFrom(ep => ep.EventRoleId))
                .ForMember(vm => vm.UserId, opt => opt.MapFrom(ep => ep.UserId))
                .ForMember(vm => vm.IsVisit, opt => opt.MapFrom(ep => ep.IsVisit))
                .ForMember(vm => vm.UserTypeId, opt => opt.MapFrom(ep => ep.User.UserTypeId))
                .ForMember(vm => vm.FirstName, opt => opt.MapFrom(ep => ep.User.FirstName))
                .ForMember(vm => vm.LastName, opt => opt.MapFrom(ep => ep.User.LastName))
                .ForMember(vm => vm.Email, opt => opt.MapFrom(ep => ep.User.Email))
                .ForMember(vm => vm.ClassNumber, opt => opt.MapFrom(ep => ep.User.ClassNumber))
                .ForMember(vm => vm.ClassLetter, opt => opt.MapFrom(ep => ep.User.ClassLetter))
                .ForMember(vm => vm.GenderId, opt => opt.MapFrom(ep => ep.User.GenderId));
        }
    }
}
