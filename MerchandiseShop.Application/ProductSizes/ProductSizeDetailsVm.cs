using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductSizes
{
    public class ProductSizeDetailsVm : IMapWith<ProductSize>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductSize, ProductSizeDetailsVm>()
                .ForMember(productSizeVm => productSizeVm.Id, opt => opt.MapFrom(productSize => productSize.Id))
                .ForMember(productSizeVm => productSizeVm.Name, opt => opt.MapFrom(productSize => productSize.Name));
        }
    }
}
