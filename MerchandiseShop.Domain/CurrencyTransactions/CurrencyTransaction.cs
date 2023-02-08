using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.CurrencyTransactions
{
    public class CurrencyTransaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyTransactionTypeId { get; set; }
    }
}
