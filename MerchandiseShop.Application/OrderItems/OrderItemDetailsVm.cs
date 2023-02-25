using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Order;
using MerchandiseShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.OrderItems
{
    public class OrderItemDetailsVm : IMapWith<OrderItem>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemDetailsVm>()
                .ForMember(orderItemVm => orderItemVm.Id, opt => opt.MapFrom(orderItem => orderItem.Id))
                .ForMember(orderItemVm => orderItemVm.OrderId, opt => opt.MapFrom(orderItem => orderItem.OrderId))
                .ForMember(orderItemVm => orderItemVm.Order, opt => opt.MapFrom(orderItem => orderItem.Order))
                .ForMember(orderItemVm => orderItemVm.ProductId, opt => opt.MapFrom(orderItem => orderItem.ProductId))
                .ForMember(orderItemVm => orderItemVm.Product, opt => opt.MapFrom(orderItem => orderItem.Product))
                .ForMember(orderItemVm => orderItemVm.Quantity, opt => opt.MapFrom(orderItem => orderItem.Quantity))
                .ForMember(orderItemVm => orderItemVm.Price, opt => opt.MapFrom(orderItem => orderItem.Price));
        }
    }
}
