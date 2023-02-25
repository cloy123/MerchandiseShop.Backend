using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.OrderItems.Queries.GetOrderItemList
{
    public class GetOrderItemListQueryValidator : AbstractValidator<GetOrderItemListQuery>
    {
        public GetOrderItemListQueryValidator()
        {
            RuleFor(h => h.OrderId).NotEqual(Guid.Empty);
        }
    }
}
