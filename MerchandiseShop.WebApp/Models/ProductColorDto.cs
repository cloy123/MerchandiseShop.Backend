using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.ProductColors;
using MerchandiseShop.Application.ProductColors.Commands.CreateProductColor;
using MerchandiseShop.Application.ProductColors.Commands.UpdateProductColor;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class ProductColorDto : IMapWith<CreateProductColorCommand>, IMapWith<UpdateProductColorCommand>, IMapWith<ProductColorDetailsVm>
    {
        public Guid Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Значение")]
        public string Value { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<ProductColorDto, CreateProductColorCommand>()
                .ForMember(createProductColorCommand => createProductColorCommand.Name, opt => opt.MapFrom(productColorDto => productColorDto.Name))
                .ForMember(createProductColorCommand => createProductColorCommand.Value, opt => opt.MapFrom(productColorDto => productColorDto.Value));

            profile.CreateMap<ProductColorDto, UpdateProductColorCommand>()
                .ForMember(updateProductColorCommand => updateProductColorCommand.Id, opt => opt.MapFrom(productColorDto => productColorDto.Id))
                .ForMember(updateProductColorCommand => updateProductColorCommand.Name, opt => opt.MapFrom(productColorDto => productColorDto.Name))
                .ForMember(updateProductColorCommand => updateProductColorCommand.Value, opt => opt.MapFrom(productColorDto => productColorDto.Value));

            profile.CreateMap<ProductColorDetailsVm, ProductColorDto>()
                .ForMember(productColorDto => productColorDto.Id, opt => opt.MapFrom(productColorDetails => productColorDetails.Id))
                .ForMember(productColorDto => productColorDto.Name, opt => opt.MapFrom(productColorDetails => productColorDetails.Name))
                .ForMember(productColorDto => productColorDto.Value, opt => opt.MapFrom(productColorDetails => productColorDetails.Value));
        }
    }
}
