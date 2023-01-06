using System;
using FluentValidation;

namespace MerchandiseShop.Application.Holidays.Commands.UpdateHoliday
{
    public class UpdateHolidayCommandVallidator : AbstractValidator<UpdateHolidayCommand>
    {
        public UpdateHolidayCommandVallidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
            RuleFor(h => h.Name).NotEmpty();
            RuleFor(h => h.Date).NotEmpty();
            RuleFor(h => h.IsEveryYear).NotEmpty();
            RuleFor(h => h.Prize).NotEmpty();
            RuleFor(h => h.UserTypeId).NotEmpty();
            RuleFor(h => h.GenderId).NotEmpty();
        }
    }
}
