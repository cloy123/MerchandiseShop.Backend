using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Holidays.Commands.CheckHolidays
{
    public class CheckHolidaysCommandValidator : AbstractValidator<CheckHolidaysCommand>
    {
        public CheckHolidaysCommandValidator()
        {
        }
    }
}
