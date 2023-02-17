using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchandiseShop.Domain.Models;

namespace MerchandiseShop.Domain.Users
{
    public class UserType : Enumeration
    {
        public static UserType Administrator = new(0, "admin");
        public static UserType SupplyManager = new(1, "manager");
        public static UserType Teacher = new(2, "teacher");
        public static UserType Student = new(3, "student");
        public static UserType All = new(4, "Все");
        public UserType(int id, string name) : base(id, name)
        {
        }
    }
}
