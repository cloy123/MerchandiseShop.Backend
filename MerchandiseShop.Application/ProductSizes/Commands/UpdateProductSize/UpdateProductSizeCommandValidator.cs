using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes.Commands.UpdateProductSize
{
    public class UpdateProductSizeCommandValidator : AbstractValidator<UpdateProductSizeCommand>
    {
        public UpdateProductSizeCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
            RuleFor(h => h.Name).NotEmpty();
        }
    }
}
