using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchandiseShop.Domain.Models;

namespace MerchandiseShop.Domain.CurrencyTransactions
{
    public class CurrencyTransactionType : Enumeration
    {
        public static CurrencyTransactionType OrderCreatedTransaction = new(0, "Заказ");
        public static CurrencyTransactionType OrderCancelledTransaction = new(1, "Отмена заказа");
        public static CurrencyTransactionType EventTransaction = new(2, "Мероприятие");
        public static CurrencyTransactionType EventResponsiblesTransaction = new(3, "Ответственный за мероприятие");
        public static CurrencyTransactionType HolidayTransaction = new(4, "Событие");
        public CurrencyTransactionType(int id, string name) : base(id, name)
        {
        }
    }
}
