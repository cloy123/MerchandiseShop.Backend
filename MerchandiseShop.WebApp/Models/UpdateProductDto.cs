using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Products;
using MerchandiseShop.Application.Products.Commands.UpdateProduct;
using MerchandiseShop.Domain.Products;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>, IMapWith<ProductDetailsVm>
    {
        public Guid Id { get; set; }
        [DisplayName("Тип товара")]
        public Guid ProductTypeId { get; set; }
        [ValidateNever]
        public ProductType ProductType { get; set; }

        [DisplayName("Размер")]
        public Guid ProductSizeId { get; set; }
        [ValidateNever]
        public ProductSize ProductSize { get; set; }
        [DisplayName("Цвет")]
        public Guid ProductColorId { get; set; }
        [ValidateNever]
        public ProductColor ProductColor { get; set; }
        [DisplayName("Показывать в каталоге")]
        public bool ShowInCatalog { get; set; }
        [DisplayName("Количество")]
        public int Quantity { get; set; }

        [ValidateNever]
        [DisplayName("Свободное Количество")]
        public int FreeQuantity { get; set; }

        [DisplayName("Минимальное количество")]
        public int MinQuantity { get; set; }
        [DisplayName("Цена")]
        public int Price { get; set; }
        [DisplayName("Скидка")]
        public int Discount { get; set; }

        [ValidateNever]
        [DisplayName("Картинка")]
        public string ImageFileName { get; set; }

        [DisplayName("Картинка")]
        [ValidateNever]
        public IFormFile NewImageFile { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForMember(updateProductCommand => updateProductCommand.Id, opt => opt.MapFrom(productDto => productDto.Id))
                .ForMember(updateProductCommand => updateProductCommand.ProductTypeId, opt => opt.MapFrom(productDto => productDto.ProductTypeId))
                .ForMember(updateProductCommand => updateProductCommand.ProductSizeId, opt => opt.MapFrom(productDto => productDto.ProductSizeId))
                .ForMember(updateProductCommand => updateProductCommand.ProductColorId, opt => opt.MapFrom(productDto => productDto.ProductColorId))
                .ForMember(updateProductCommand => updateProductCommand.ShowInCatalog, opt => opt.MapFrom(productDto => productDto.ShowInCatalog))
                .ForMember(updateProductCommand => updateProductCommand.Quantity, opt => opt.MapFrom(productDto => productDto.Quantity))
                .ForMember(updateProductCommand => updateProductCommand.MinQuantity, opt => opt.MapFrom(productDto => productDto.MinQuantity))
                .ForMember(updateProductCommand => updateProductCommand.Price, opt => opt.MapFrom(productDto => productDto.Price))
                .ForMember(updateProductCommand => updateProductCommand.Discount, opt => opt.MapFrom(productDto => productDto.Discount))
                .ForMember(updateProductCommand => updateProductCommand.ImageFileName, opt => opt.MapFrom(productDto => productDto.ImageFileName));

            profile.CreateMap<ProductDetailsVm, UpdateProductDto>()
                .ForMember(productDto => productDto.Id, opt => opt.MapFrom(productDetails => productDetails.Id))
                .ForMember(productDto => productDto.ProductTypeId, opt => opt.MapFrom(productDetails => productDetails.ProductTypeId))
                .ForMember(productDto => productDto.ProductType, opt => opt.MapFrom(productDetails => productDetails.ProductType))
                .ForMember(productDto => productDto.ProductSizeId, opt => opt.MapFrom(productDetails => productDetails.ProductSizeId))
                .ForMember(productDto => productDto.ProductSize, opt => opt.MapFrom(productDetails => productDetails.ProductSize))
                .ForMember(productDto => productDto.ProductColorId, opt => opt.MapFrom(productDetails => productDetails.ProductColorId))
                .ForMember(productDto => productDto.ProductColor, opt => opt.MapFrom(productDetails => productDetails.ProductColor))
                .ForMember(productDto => productDto.ShowInCatalog, opt => opt.MapFrom(productDetails => productDetails.ShowInCatalog))
                .ForMember(productDto => productDto.Quantity, opt => opt.MapFrom(productDetails => productDetails.Quantity))
                .ForMember(productDto => productDto.FreeQuantity, opt => opt.MapFrom(productDetails => productDetails.FreeQuantity))
                .ForMember(productDto => productDto.MinQuantity, opt => opt.MapFrom(productDetails => productDetails.MinQuantity))
                .ForMember(productDto => productDto.Price, opt => opt.MapFrom(productDetails => productDetails.Price))
                .ForMember(productDto => productDto.Discount, opt => opt.MapFrom(productDetails => productDetails.Discount))
                .ForMember(productDto => productDto.ImageFileName, opt => opt.MapFrom(productDetails => productDetails.ImageFileName));
        }
    }
}
