using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.User
{
    public class User
    {
        public Guid Id { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }//имя
        public string LastName { get; set; }//фамилия
        public DateOnly Birthday { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public int PointBalance { get; set; }
        public int ClassNumber { get; set; }
        public string ClassLetter { get; set; }
        public bool IsAccess { get; set; }
        public int GenderId { get; set; }

    }
}
