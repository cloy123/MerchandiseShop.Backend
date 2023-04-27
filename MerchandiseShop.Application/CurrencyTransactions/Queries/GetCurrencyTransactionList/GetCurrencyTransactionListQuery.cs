using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.CurrencyTransactions.Queries.GetCurrencyTransactionList
{
    public class GetCurrencyTransactionListQuery : IRequest<CurrencyTransactionListVm>
    {
        public Guid UserId { get; set; }
    }
}
