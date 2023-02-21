using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductTypes
{
    public class ProductTypeDetailsVm : IMapWith<ProductType>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductType, ProductTypeDetailsVm>()
                .ForMember(productTypeVm => productTypeVm.Id, opt => opt.MapFrom(productType => productType.Id))
                .ForMember(productTypeVm => productTypeVm.Name, opt => opt.MapFrom(productType => productType.Name));
        }
    }
}
