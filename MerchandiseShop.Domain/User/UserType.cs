using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchandiseShop.Domain.Models;

namespace MerchandiseShop.Domain.User
{
    public class UserType : Enumeration
    {
        public static UserType Administrator = new(0, "Администратор");
        public static UserType SupplyManager = new(1, "Завхоз");
        public static UserType Teacher = new(2, "Учитель");
        public static UserType Student = new(3, "Ученик");
        public UserType(int id, string name) : base(id, name)
        {
        }
    }
}
