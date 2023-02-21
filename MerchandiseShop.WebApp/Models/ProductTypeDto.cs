using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.ProductTypes;
using MerchandiseShop.Application.ProductTypes.Commands.CreateProductType;
using MerchandiseShop.Application.ProductTypes.Commands.UpdateProductType;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class ProductTypeDto : IMapWith<CreateProductTypeCommand>, IMapWith<UpdateProductTypeCommand>, IMapWith<ProductTypeDetailsVm>
    {
        public Guid Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<ProductTypeDto, CreateProductTypeCommand>()
                .ForMember(createProductTypeCommand => createProductTypeCommand.Name, opt => opt.MapFrom(productTypeDto => productTypeDto.Name));

            profile.CreateMap<ProductTypeDto, UpdateProductTypeCommand>()
                .ForMember(updateProductTypeCommand => updateProductTypeCommand.Id, opt => opt.MapFrom(productTypeDto => productTypeDto.Id))
                .ForMember(updateProductTypeCommand => updateProductTypeCommand.Name, opt => opt.MapFrom(productTypeDto => productTypeDto.Name));

            profile.CreateMap<ProductTypeDetailsVm, ProductTypeDto>()
                .ForMember(productTypeDto => productTypeDto.Id, opt => opt.MapFrom(productTypeDetails => productTypeDetails.Id))
                .ForMember(productTypeDto => productTypeDto.Name, opt => opt.MapFrom(productTypeDetails => productTypeDetails.Name));
        }
    }
}
