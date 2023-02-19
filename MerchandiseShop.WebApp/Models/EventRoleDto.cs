using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.EventRoles;
using MerchandiseShop.Application.EventRoles.Commands.CreateEventRole;
using MerchandiseShop.Application.EventRoles.Commands.UpdateEventRole;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class EventRoleDto : IMapWith<CreateEventRoleCommand>, IMapWith<UpdateEventRoleCommand>, IMapWith<EventRoleDetailsVm>
    {
        public Guid Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Тип пользователя")]
        public int UserTypeId { get; set; }
        public Guid EventId { get; set; }
        [DisplayName("Приз")]
        public int Prize { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<EventRoleDto, CreateEventRoleCommand>()
                .ForMember(createEventRoleCommand => createEventRoleCommand.Name, opt => opt.MapFrom(eventRoleDto => eventRoleDto.Name))
                .ForMember(createEventRoleCommand => createEventRoleCommand.UserTypeId, opt => opt.MapFrom(eventRoleDto => eventRoleDto.UserTypeId))
                .ForMember(createEventRoleCommand => createEventRoleCommand.EventId, opt => opt.MapFrom(eventRoleDto => eventRoleDto.EventId))
                .ForMember(createEventRoleCommand => createEventRoleCommand.Prize, opt => opt.MapFrom(eventRoleDto => eventRoleDto.Prize));

            profile.CreateMap<EventRoleDto, UpdateEventRoleCommand>()
                .ForMember(updateEventRoleCommand => updateEventRoleCommand.Id, opt => opt.MapFrom(eventRoleDto => eventRoleDto.Id))
                .ForMember(updateEventRoleCommand => updateEventRoleCommand.Name, opt => opt.MapFrom(eventRoleDto => eventRoleDto.Name))
                .ForMember(updateEventRoleCommand => updateEventRoleCommand.UserTypeId, opt => opt.MapFrom(eventRoleDto => eventRoleDto.UserTypeId))
                .ForMember(updateEventRoleCommand => updateEventRoleCommand.EventId, opt => opt.MapFrom(eventRoleDto => eventRoleDto.EventId))
                .ForMember(updateEventRoleCommand => updateEventRoleCommand.Prize, opt => opt.MapFrom(eventRoleDto => eventRoleDto.Prize));


            profile.CreateMap<EventRoleDetailsVm, EventRoleDto>()
                .ForMember(eventRoleDto => eventRoleDto.Id, opt => opt.MapFrom(eventRoleDetails => eventRoleDetails.Id))
                .ForMember(eventRoleDto => eventRoleDto.Name, opt => opt.MapFrom(eventRoleDetails => eventRoleDetails.Name))
                .ForMember(eventRoleDto => eventRoleDto.UserTypeId, opt => opt.MapFrom(eventRoleDetails => eventRoleDetails.UserTypeId))
                .ForMember(eventRoleDto => eventRoleDto.EventId, opt => opt.MapFrom(eventRoleDetails => eventRoleDetails.EventId))
                .ForMember(eventRoleDto => eventRoleDto.Prize, opt => opt.MapFrom(eventRoleDetails => eventRoleDetails.Prize));
        }
    }
}