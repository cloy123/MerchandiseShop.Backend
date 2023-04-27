using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.CurrencyTransactions.Queries.GetCurrencyTransactionList
{
    public class CurrencyTransactionListVm
    {
        public IList<CurrencyTransactionDetailsVm> CurrencyTransactions { get; set; }
    }
}
