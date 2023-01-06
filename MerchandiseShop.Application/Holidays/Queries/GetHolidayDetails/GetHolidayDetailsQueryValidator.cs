using System;
using FluentValidation;

namespace MerchandiseShop.Application.Holidays.Queries.GetHolidayDetails
{
    public class GetHolidayDetailsQueryValidator : AbstractValidator<GetHolidayDetailsQuery>
    {
        public GetHolidayDetailsQueryValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}

