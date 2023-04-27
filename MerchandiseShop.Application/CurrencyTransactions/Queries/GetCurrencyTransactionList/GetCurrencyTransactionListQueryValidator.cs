using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.CurrencyTransactions.Queries.GetCurrencyTransactionList
{
    public class GetCurrencyTransactionListQueryValidator : AbstractValidator<GetCurrencyTransactionListQuery>
    {
        public GetCurrencyTransactionListQueryValidator()
        {
            RuleFor(h => h.UserId).NotEqual(Guid.Empty);
        }
    }
}
