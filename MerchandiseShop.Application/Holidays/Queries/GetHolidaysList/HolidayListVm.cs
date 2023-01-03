using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Holidays.Queries.GetHolidaysList
{
    public class HolidayListVm
    {
        public IList<HolidayDto> Holidays { get; set; }
    }
}
