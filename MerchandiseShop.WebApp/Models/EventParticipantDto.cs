using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.EventParticipants;
using MerchandiseShop.Application.EventParticipants.Commands.CreateEventParticipant;
using MerchandiseShop.Application.EventParticipants.Commands.UpdateEventParticipant;
using MerchandiseShop.Domain.Event;
using MerchandiseShop.Domain.Users;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class EventParticipantDto : IMapWith<CreateEventParticipantCommand>, IMapWith<UpdateEventParticipantCommand>, IMapWith<EventParticipantDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        [DisplayName("Роль")]
        public Guid EventRoleId { get; set; }
        [ValidateNever]
        public EventRole EventRole { get; set; }
        [DisplayName("Пользователь")]
        public Guid UserId { get; set; }
        [ValidateNever]
        public User User { get; set; }
        [DisplayName("Посещение")]
        public bool IsVisit { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<EventParticipantDto, CreateEventParticipantCommand>()
                .ForMember(createEventParticipantCommand => createEventParticipantCommand.EventId, opt => opt.MapFrom(eventParticipantDto => eventParticipantDto.EventId))
                .ForMember(createEventParticipantCommand => createEventParticipantCommand.EventRoleId, opt => opt.MapFrom(eventParticipantDto => eventParticipantDto.EventRoleId))
                .ForMember(createEventParticipantCommand => createEventParticipantCommand.UserId, opt => opt.MapFrom(eventParticipantDto => eventParticipantDto.UserId));

            profile.CreateMap<EventParticipantDto, UpdateEventParticipantCommand>()
                .ForMember(updateEventParticipantCommand => updateEventParticipantCommand.Id, opt => opt.MapFrom(eventParticipantDto => eventParticipantDto.Id))
                .ForMember(updateEventParticipantCommand => updateEventParticipantCommand.EventId, opt => opt.MapFrom(eventParticipantDto => eventParticipantDto.EventId))
                .ForMember(updateEventParticipantCommand => updateEventParticipantCommand.EventRoleId, opt => opt.MapFrom(eventParticipantDto => eventParticipantDto.EventRoleId))
                .ForMember(updateEventParticipantCommand => updateEventParticipantCommand.UserId, opt => opt.MapFrom(eventParticipantDto => eventParticipantDto.UserId))
                .ForMember(updateEventParticipantCommand => updateEventParticipantCommand.IsVisit, opt => opt.MapFrom(eventParticipantDto => eventParticipantDto.IsVisit));


            profile.CreateMap<EventParticipantDetailsVm, EventParticipantDto>()
                .ForMember(eventParticipantDto => eventParticipantDto.Id, opt => opt.MapFrom(eventParticipantDetails => eventParticipantDetails.Id))
                .ForMember(eventParticipantDto => eventParticipantDto.EventId, opt => opt.MapFrom(eventParticipantDetails => eventParticipantDetails.EventId))
                .ForMember(eventParticipantDto => eventParticipantDto.EventRoleId, opt => opt.MapFrom(eventParticipantDetails => eventParticipantDetails.EventRoleId))
                .ForMember(eventParticipantDto => eventParticipantDto.EventRole, opt => opt.MapFrom(eventParticipantDetails => eventParticipantDetails.EventRole))
                .ForMember(eventParticipantDto => eventParticipantDto.UserId, opt => opt.MapFrom(eventParticipantDetails => eventParticipantDetails.UserId))
                .ForMember(eventParticipantDto => eventParticipantDto.User, opt => opt.MapFrom(eventParticipantDetails => eventParticipantDetails.User))
                .ForMember(eventParticipantDto => eventParticipantDto.IsVisit, opt => opt.MapFrom(eventParticipantDetails => eventParticipantDetails.IsVisit));
        }
    }
}
