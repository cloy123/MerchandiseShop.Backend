using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors.Commands.DeleteProductColor
{
    public class DeleteProductColorCommandValidator : AbstractValidator<DeleteProductColorCommand>
    {
        public DeleteProductColorCommandValidator()
        {
            RuleFor(h => h.Id).NotEqual(Guid.Empty);
        }
    }
}
