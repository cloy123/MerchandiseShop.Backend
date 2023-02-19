using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.EventResponsibles;
using MerchandiseShop.Application.EventResponsibles.Commands.CreateEventResponsible;
using MerchandiseShop.Application.EventResponsibles.Commands.UpdateEventResponsible;
using MerchandiseShop.Domain.Users;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class EventResponsibleDto : IMapWith<CreateEventResponsibleCommand>, IMapWith<UpdateEventResponsibleCommand>, IMapWith<EventResponsibleDetailsVm>
    {
        
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        [DisplayName("Пользователь")]
        public Guid UserId { get; set; }
        [ValidateNever]
        public User User { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<EventResponsibleDto, CreateEventResponsibleCommand>()
                .ForMember(createEventResponsibleCommand => createEventResponsibleCommand.EventId, opt => opt.MapFrom(eventResponsibleDto => eventResponsibleDto.EventId))
                .ForMember(createEventResponsibleCommand => createEventResponsibleCommand.UserId, opt => opt.MapFrom(eventResponsibleDto => eventResponsibleDto.UserId));

            profile.CreateMap<EventResponsibleDto, UpdateEventResponsibleCommand>()
                .ForMember(updateEventResponsibleCommand => updateEventResponsibleCommand.Id, opt => opt.MapFrom(eventResponsibleDto => eventResponsibleDto.Id))
                .ForMember(updateEventResponsibleCommand => updateEventResponsibleCommand.EventId, opt => opt.MapFrom(eventResponsibleDto => eventResponsibleDto.EventId))
                .ForMember(updateEventResponsibleCommand => updateEventResponsibleCommand.UserId, opt => opt.MapFrom(eventResponsibleDto => eventResponsibleDto.UserId));


            profile.CreateMap<EventResponsibleDetailsVm, EventResponsibleDto>()
                .ForMember(eventResponsibleDto => eventResponsibleDto.Id, opt => opt.MapFrom(eventResponsibleDetails => eventResponsibleDetails.Id))
                .ForMember(eventResponsibleDto => eventResponsibleDto.EventId, opt => opt.MapFrom(eventResponsibleDetails => eventResponsibleDetails.EventId))
                .ForMember(eventResponsibleDto => eventResponsibleDto.UserId, opt => opt.MapFrom(eventResponsibleDetails => eventResponsibleDetails.UserId))
                .ForMember(eventResponsibleDto => eventResponsibleDto.User, opt => opt.MapFrom(eventResponsibleDetails => eventResponsibleDetails.User));
        }
    }
}
