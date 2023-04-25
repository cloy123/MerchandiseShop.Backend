using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Order;

namespace MerchandiseShop.WebApi.Models
{
    public class OrderItemDto : IMapWith<OrderItem>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(dto => dto.OrderId, opt => opt.MapFrom(vm => vm.OrderId))
                .ForMember(dto => dto.ProductId, opt => opt.MapFrom(vm => vm.ProductId))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(vm => vm.Quantity))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(vm => vm.Price));
        }
    }
}
