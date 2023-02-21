using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.ProductColors
{
    public class ProductColorDetailsVm : IMapWith<ProductColor>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductColor, ProductColorDetailsVm>()
                .ForMember(productColorVm => productColorVm.Id, opt => opt.MapFrom(productColor => productColor.Id))
                .ForMember(productColorVm => productColorVm.Name, opt => opt.MapFrom(productColor => productColor.Name))
                .ForMember(productColorVm => productColorVm.Value, opt => opt.MapFrom(productColor => productColor.Value));
        }
    }
}
