using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public bool IsAccess { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public int PointBalance { get; set; }
        public int? ClassNumber { get; set; }
        public string? ClassLetter { get; set; }
        public int GenderId { get; set; }
        public string? NewPassword { get; set; } = String.Empty;
    }
}
