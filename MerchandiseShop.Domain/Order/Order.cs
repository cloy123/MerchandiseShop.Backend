using MerchandiseShop.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.Order
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateCompletion { get; set; }
        public int StatusId { get; set; }
    }
}
