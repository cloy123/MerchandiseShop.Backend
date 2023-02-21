using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes.Commands.DeleteProductType
{
    public class DeleteProductTypeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
