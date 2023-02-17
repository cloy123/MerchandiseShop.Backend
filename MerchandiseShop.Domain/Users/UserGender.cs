using MerchandiseShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.Users
{
    public class UserGender : Enumeration
    {
        public static UserGender Male = new(0, "Мужской");
        public static UserGender Female = new(1, "Женский");
        public static UserGender All = new(2, "Все");
        public UserGender(int id, string name) : base(id, name)
        {
        }
    }
}
