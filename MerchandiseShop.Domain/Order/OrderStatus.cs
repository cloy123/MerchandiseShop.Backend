using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchandiseShop.Domain.Models;

namespace MerchandiseShop.Domain.Order
{
    public class OrderStatus : Enumeration
    {
        public static OrderStatus InWork = new(0, "В работе");
        public static OrderStatus WaitingNewSupply = new(1, "Ожидание новой поставки");
        public static OrderStatus Canceled = new(2, "Отменено");
        public static OrderStatus Ready = new(3, "Готово к выдаче");
        public static OrderStatus Complete = new(4, "Получено");
        public OrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}
