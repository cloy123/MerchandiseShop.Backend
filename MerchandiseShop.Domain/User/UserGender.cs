﻿using MerchandiseShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.User
{
    public class UserGender : Enumeration
    {
        public static UserGender Male = new(0, "Мужской");
        public static UserGender Female = new(1, "Женский");
        public static UserGender None = new(2, "");
        public UserGender(int id, string name) : base(id, name)
        {
        }
    }
}