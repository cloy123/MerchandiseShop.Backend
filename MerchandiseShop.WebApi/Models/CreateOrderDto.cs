using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Orders.Commands.CreateOrder;

namespace MerchandiseShop.WebApi.Models
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public IList<CreateOrderItemDto> OrderItems { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(command => command.OrderItems, opt => opt.MapFrom(dto => dto.OrderItems)); ;
        }
    }
}

