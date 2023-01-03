using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Holiday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MerchandiseShop.Application.Holidays.Queries.GetHolidaysList
{
    public class HolidayDto : IMapWith<Holiday>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Holiday, HolidayDto>()
                .ForMember(holidayDto => holidayDto.Id, opt => opt.MapFrom(holiday => holiday.Id))
                .ForMember(holidayDto => holidayDto.Name, opt => opt.MapFrom(holiday => holiday.Name));
        }
    }
}
