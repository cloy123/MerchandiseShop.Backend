using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.ProductSizes;
using MerchandiseShop.Application.ProductSizes.Commands.CreateProductSize;
using MerchandiseShop.Application.ProductSizes.Commands.UpdateProductSize;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class ProductSizeDto : IMapWith<CreateProductSizeCommand>, IMapWith<UpdateProductSizeCommand>, IMapWith<Application.ProductSizes.ProductSizeDetailsVm>
    {
        public Guid Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<ProductSizeDto, CreateProductSizeCommand>()
                .ForMember(createProductSizeCommand => createProductSizeCommand.Name, opt => opt.MapFrom(productSizeDto => productSizeDto.Name));

            profile.CreateMap<ProductSizeDto, UpdateProductSizeCommand>()
                .ForMember(updateProductSizeCommand => updateProductSizeCommand.Id, opt => opt.MapFrom(productSizeDto => productSizeDto.Id))
                .ForMember(updateProductSizeCommand => updateProductSizeCommand.Name, opt => opt.MapFrom(productSizeDto => productSizeDto.Name));

            profile.CreateMap<ProductSizeDetailsVm, ProductSizeDto>()
                .ForMember(productSizeDto => productSizeDto.Id, opt => opt.MapFrom(productSizeDetails => productSizeDetails.Id))
                .ForMember(productSizeDto => productSizeDto.Name, opt => opt.MapFrom(productSizeDetails => productSizeDetails.Name));
        }
    }
}
