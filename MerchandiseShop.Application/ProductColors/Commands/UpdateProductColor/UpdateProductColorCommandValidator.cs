using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors.Commands.UpdateProductColor
{
    public class UpdateProductColorCommandValidator : AbstractValidator<UpdateProductColorCommand>
    {
        public UpdateProductColorCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
            RuleFor(h => h.Name).NotEmpty();
            RuleFor(h => h.Value).NotEmpty();
        }
    }
}
