using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Holiday;
using AutoMapper;

namespace MerchandiseShop.Application.Holidays.Queries
{
    public class HolidayDetailsVm : IMapWith<Holiday>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsEveryYear { get; set; }
        public int Prize { get; set; }
        public int UserTypeId { get; set; }
        public int GenderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Holiday, HolidayDetailsVm>()
                .ForMember(holidayVm => holidayVm.Id, opt => opt.MapFrom(holiday => holiday.Id))
                .ForMember(holidayVm => holidayVm.Name, opt => opt.MapFrom(holiday => holiday.Name))
                .ForMember(holidayVm => holidayVm.Date, opt => opt.MapFrom(holiday => holiday.Date))
                .ForMember(holidayVm => holidayVm.IsEveryYear, opt => opt.MapFrom(holiday => holiday.IsEveryYear))
                .ForMember(holidayVm => holidayVm.Prize, opt => opt.MapFrom(holiday => holiday.Prize))
                .ForMember(holidayVm => holidayVm.UserTypeId, opt => opt.MapFrom(holiday => holiday.UserTypeId))
                .ForMember(holidayVm => holidayVm.GenderId, opt => opt.MapFrom(holiday => holiday.GenderId));
        }
    }
}
