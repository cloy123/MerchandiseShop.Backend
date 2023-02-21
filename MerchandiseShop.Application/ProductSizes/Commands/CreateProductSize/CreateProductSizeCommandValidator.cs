using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes.Commands.CreateProductSize
{
    public class CreateProductSizeCommandValidator : AbstractValidator<CreateProductSizeCommand>
    {
        public CreateProductSizeCommandValidator()
        {
            RuleFor(h => h.Name).NotEmpty();
        }
    }
}
