using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Notifications.Queries.GetNotificationList
{
    public class GetNotificationListQueryValidator : AbstractValidator<GetNotificationListQuery>
    {
        public GetNotificationListQueryValidator()
        {
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
        }
    }
}
