using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Holidays.Commands.CreateHoliday;

namespace MerchandiseShop.WebApi.Models
{
    public class CreateHolidayDto : IMapWith<CreateHolidayCommand>
    {
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public bool IsEveryYear { get; set; }
        public int Prize { get; set; }
        public int UserTypeId { get; set; }
        public int GenderId { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<CreateHolidayDto, CreateHolidayCommand>()
                .ForMember(holidayCommand => holidayCommand.Name, opt => opt.MapFrom(holidayDto => holidayDto.Name))
                .ForMember(holidayCommand => holidayCommand.Date, opt => opt.MapFrom(holidayDto => holidayDto.Date))
                .ForMember(holidayCommand => holidayCommand.IsEveryYear, opt => opt.MapFrom(holidayDto => holidayDto.IsEveryYear))
                .ForMember(holidayCommand => holidayCommand.Prize, opt => opt.MapFrom(holidayDto => holidayDto.Prize))
                .ForMember(holidayCommand => holidayCommand.UserTypeId, opt => opt.MapFrom(holidayDto => holidayDto.UserTypeId))
                .ForMember(holidayCommand => holidayCommand.GenderId, opt => opt.MapFrom(holidayDto => holidayDto.GenderId));
        }
    }
}
