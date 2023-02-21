using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes.Commands.DeleteProductType
{
    public class DeleteProductTypeCommandValidator : AbstractValidator<DeleteProductTypeCommand>
    {
        public DeleteProductTypeCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
