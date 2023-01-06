using System;
using FluentValidation;

namespace MerchandiseShop.Application.Holidays.Commands.DeleteHoliday
{
    public class DeleteHolidayCommandValidator : AbstractValidator<DeleteHolidayCommand>
    {
        public DeleteHolidayCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
