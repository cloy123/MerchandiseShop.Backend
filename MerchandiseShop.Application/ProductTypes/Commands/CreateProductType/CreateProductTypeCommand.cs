using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes.Commands.CreateProductType
{
    public class CreateProductTypeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
