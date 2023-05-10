using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.SignupEvent
{
    public class SignupEventResultVm
    {
        public bool IsSigned { get; set; }
        public string ErrorMessage { get; set; }
    }
}
