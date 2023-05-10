using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.OrderItems.Commands.DeleteOrderItemFromOrder
{
    public class CancelOrderCommandValidator : AbstractValidator<CancelOrderCommand>
    {
        public CancelOrderCommandValidator()
        {
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
            RuleFor(h => h.OrderId).NotEqual(Guid.Empty);
        }
    }
}
