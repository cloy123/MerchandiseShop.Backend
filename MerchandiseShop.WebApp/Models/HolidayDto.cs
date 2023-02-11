using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Holidays.Commands.CreateHoliday;
using MerchandiseShop.Application.Holidays.Commands.UpdateHoliday;
using MerchandiseShop.Application.Holidays.Queries;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class HolidayDto : IMapWith<CreateHolidayCommand>, IMapWith<UpdateHolidayCommand>, IMapWith<HolidayDetailsVm>
    {
        public Guid Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        [DisplayName("Каждый год")]
        public bool IsEveryYear { get; set; }

        [DisplayName("Награда")]
        public int Prize { get; set; }

        [DisplayName("Тип пользователей")]
        public int UserTypeId { get; set; }

        [DisplayName("Пол")]
        public int GenderId { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<HolidayDto, CreateHolidayCommand>()
                .ForMember(createHolidayCommand => createHolidayCommand.Name, opt => opt.MapFrom(holidayDto => holidayDto.Name))
                .ForMember(createHolidayCommand => createHolidayCommand.Date, opt => opt.MapFrom(holidayDto => holidayDto.Date))
                .ForMember(createHolidayCommand => createHolidayCommand.IsEveryYear, opt => opt.MapFrom(holidayDto => holidayDto.IsEveryYear))
                .ForMember(createHolidayCommand => createHolidayCommand.Prize, opt => opt.MapFrom(holidayDto => holidayDto.Prize))
                .ForMember(createHolidayCommand => createHolidayCommand.UserTypeId, opt => opt.MapFrom(holidayDto => holidayDto.UserTypeId))
                .ForMember(createHolidayCommand => createHolidayCommand.GenderId, opt => opt.MapFrom(holidayDto => holidayDto.GenderId));

            profile.CreateMap<HolidayDto, UpdateHolidayCommand>()
                .ForMember(updateHolidayCommand => updateHolidayCommand.Id, opt => opt.MapFrom(holidayDto => holidayDto.Id))
                .ForMember(updateHolidayCommand => updateHolidayCommand.Name, opt => opt.MapFrom(holidayDto => holidayDto.Name))
                .ForMember(updateHolidayCommand => updateHolidayCommand.Date, opt => opt.MapFrom(holidayDto => holidayDto.Date))
                .ForMember(updateHolidayCommand => updateHolidayCommand.IsEveryYear, opt => opt.MapFrom(holidayDto => holidayDto.IsEveryYear))
                .ForMember(updateHolidayCommand => updateHolidayCommand.Prize, opt => opt.MapFrom(holidayDto => holidayDto.Prize))
                .ForMember(updateHolidayCommand => updateHolidayCommand.UserTypeId, opt => opt.MapFrom(holidayDto => holidayDto.UserTypeId))
                .ForMember(updateHolidayCommand => updateHolidayCommand.GenderId, opt => opt.MapFrom(holidayDto => holidayDto.GenderId));

            profile.CreateMap<HolidayDetailsVm, HolidayDto>()
                .ForMember(holidayDto => holidayDto.Id, opt => opt.MapFrom(holidayDetails => holidayDetails.Id))
                .ForMember(holidayDto => holidayDto.Name, opt => opt.MapFrom(holidayDetails => holidayDetails.Name))
                .ForMember(holidayDto => holidayDto.Date, opt => opt.MapFrom(holidayDetails => holidayDetails.Date))
                .ForMember(holidayDto => holidayDto.IsEveryYear, opt => opt.MapFrom(holidayDetails => holidayDetails.IsEveryYear))
                .ForMember(holidayDto => holidayDto.Prize, opt => opt.MapFrom(holidayDetails => holidayDetails.Prize))
                .ForMember(holidayDto => holidayDto.UserTypeId, opt => opt.MapFrom(holidayDetails => holidayDetails.UserTypeId))
                .ForMember(holidayDto => holidayDto.GenderId, opt => opt.MapFrom(holidayDetails => holidayDetails.GenderId));
        }
    }
}
