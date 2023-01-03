using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchandiseShop.Domain.Models;

namespace MerchandiseShop.Domain.Supply
{
    public class SupplyStatus : Enumeration
    {

        public static SupplyStatus Created = new(0, "Создано");
        public static SupplyStatus InWork = new(1, "В работе");
        public static SupplyStatus Ready = new(2, "Готово");
        public SupplyStatus(int id, string name) : base(id, name)
        {
        }
    }
}
