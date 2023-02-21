using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors.Commands.CreateProductColor
{
    public class CreateProductColorCommandValidator : AbstractValidator<CreateProductColorCommand>
    {
        public CreateProductColorCommandValidator()
        {
            RuleFor(h => h.Name).NotEmpty();
            RuleFor(h => h.Value).NotEmpty();
        }
    }
}
