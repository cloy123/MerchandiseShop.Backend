using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors.Commands.CreateProductColor
{
    public class CreateProductColorCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
