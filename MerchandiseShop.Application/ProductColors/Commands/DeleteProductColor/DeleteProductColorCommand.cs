using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors.Commands.DeleteProductColor
{
    public class DeleteProductColorCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
