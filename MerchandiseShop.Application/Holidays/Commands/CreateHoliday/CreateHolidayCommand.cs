﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Holidays.Commands.CreateHoliday
{
    public class CreateHolidayCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public bool IsEveryYear { get; set; }
        public int Prize { get; set; }
        public int UserTypeId { get; set; }
        public int GenderId { get; set; }
    }
}