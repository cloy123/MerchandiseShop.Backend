using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Events;
using MerchandiseShop.Application.Events.Commands.CreateEvent;
using MerchandiseShop.Application.Events.Commands.UpdateEvent;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class EventDto : IMapWith<CreateEventCommand>, IMapWith<UpdateEventCommand>, IMapWith<EventDetailsVm>
    {
        public Guid Id { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Доступно для")]
        public List<string> AvalibleFor { get; set; } = new List<string>();

        [ValidateNever]
        [DisplayName("Статус")]
        public string Status { get
            {
                if (IsCompleted)
                {
                    return "Завершенное";
                }
                else
                {
                    return "Активное";
                }
            } }


        public bool IsCompleted { get; set; }

        [ValidateNever]
        public string NewAvalibleFor { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<EventDto, CreateEventCommand>()
                .ForMember(createEventCommand => createEventCommand.Name, opt => opt.MapFrom(eventDto => eventDto.Name))
                .ForMember(createEventCommand => createEventCommand.Date, opt => opt.MapFrom(eventDto => eventDto.Date))
                .ForMember(createEventCommand => createEventCommand.Description, opt => opt.MapFrom(eventDto => eventDto.Description))
                .ForMember(createEventCommand => createEventCommand.AvalibleFor, opt => opt.MapFrom(eventDto => eventDto.AvalibleFor));

            profile.CreateMap<EventDto, UpdateEventCommand>()
                .ForMember(updateEventCommand => updateEventCommand.Id, opt => opt.MapFrom(eventDto => eventDto.Id))
                .ForMember(updateEventCommand => updateEventCommand.Name, opt => opt.MapFrom(eventDto => eventDto.Name))
                .ForMember(updateEventCommand => updateEventCommand.Date, opt => opt.MapFrom(eventDto => eventDto.Date))
                .ForMember(updateEventCommand => updateEventCommand.Description, opt => opt.MapFrom(eventDto => eventDto.Description))
                .ForMember(updateEventCommand => updateEventCommand.AvalibleFor, opt => opt.MapFrom(eventDto => eventDto.AvalibleFor));


            profile.CreateMap<EventDetailsVm, EventDto>()
                .ForMember(eventDto => eventDto.Id, opt => opt.MapFrom(eventDetails => eventDetails.Id))
                .ForMember(eventDto => eventDto.Name, opt => opt.MapFrom(eventDetails => eventDetails.Name))
                .ForMember(eventDto => eventDto.Date, opt => opt.MapFrom(eventDetails => eventDetails.Date))
                .ForMember(eventDto => eventDto.Description, opt => opt.MapFrom(eventDetails => eventDetails.Description))
                .ForMember(eventDto => eventDto.IsCompleted, opt => opt.MapFrom(eventDetails => eventDetails.IsCompleted))
                .ForMember(eventDto => eventDto.AvalibleFor, opt => opt.MapFrom(eventDetails => eventDetails.AvalibleFor));
        }
    }
}
