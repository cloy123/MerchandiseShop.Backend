using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes.Commands.DeleteProductSize
{
    public class DeleteProductSizeCommandValidator : AbstractValidator<DeleteProductSizeCommand>
    {
        public DeleteProductSizeCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
