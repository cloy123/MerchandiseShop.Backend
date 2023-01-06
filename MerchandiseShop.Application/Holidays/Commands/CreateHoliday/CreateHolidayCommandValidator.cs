using System;
using FluentValidation;

namespace MerchandiseShop.Application.Holidays.Commands.CreateHoliday
{
    public class CreateHolidayCommandValidator : AbstractValidator<CreateHolidayCommand>
    {
        public CreateHolidayCommandValidator()
        {
            RuleFor(h => h.Name).NotEmpty();
            RuleFor(h => h.Date).NotEmpty();
            RuleFor(h => h.IsEveryYear).NotEmpty();
            RuleFor(h => h.Prize).NotEmpty();
            RuleFor(h => h.UserTypeId).NotEmpty();
            RuleFor(h => h.GenderId).NotEmpty();
        }
    }
}
