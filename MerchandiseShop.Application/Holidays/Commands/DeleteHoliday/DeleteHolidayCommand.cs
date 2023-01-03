﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MerchandiseShop.Application.Holidays.Commands.DeleteHoliday
{
    public class DeleteHolidayCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
