using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Users.Commands.FindUser
{
    public class UserDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }//имя
        public string LastName { get; set; }//фамилия
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public int PointBalance { get; set; } = 0;
        public int? ClassNumber { get; set; }
        public string? ClassLetter { get; set; }
        public int GenderId { get; set; }
    }
}
