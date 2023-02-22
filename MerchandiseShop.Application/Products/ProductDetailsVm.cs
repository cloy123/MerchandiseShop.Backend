using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Products
{
    public class ProductDetailsVm : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public Guid ProductSizeId { get; set; }
        public ProductSize ProductSize { get; set; }
        public Guid ProductColorId { get; set; }
        public ProductColor ProductColor { get; set; }
        public bool ShowInCatalog { get; set; }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string ImageFileName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVm>()
                .ForMember(productVm => productVm.Id, opt => opt.MapFrom(product => product.Id))
                .ForMember(productVm => productVm.ProductTypeId, opt => opt.MapFrom(product => product.ProductTypeId))
                .ForMember(productVm => productVm.ProductType, opt => opt.MapFrom(product => product.ProductType))
                .ForMember(productVm => productVm.ProductSizeId, opt => opt.MapFrom(product => product.ProductSizeId))
                .ForMember(productVm => productVm.ProductSize, opt => opt.MapFrom(product => product.ProductSize))
                .ForMember(productVm => productVm.ProductColorId, opt => opt.MapFrom(product => product.ProductColorId))
                .ForMember(productVm => productVm.ProductColor, opt => opt.MapFrom(product => product.ProductColor))
                .ForMember(productVm => productVm.ShowInCatalog, opt => opt.MapFrom(product => product.ShowInCatalog))
                .ForMember(productVm => productVm.Quantity, opt => opt.MapFrom(product => product.Quantity))
                .ForMember(productVm => productVm.MinQuantity, opt => opt.MapFrom(product => product.MinQuantity))
                .ForMember(productVm => productVm.Price, opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.Discount, opt => opt.MapFrom(product => product.Discount))
                .ForMember(productVm => productVm.ImageFileName, opt => opt.MapFrom(product => product.ImageFileName));
        }
    }
}
