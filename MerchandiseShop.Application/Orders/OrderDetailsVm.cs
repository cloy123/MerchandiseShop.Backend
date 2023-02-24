using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Order;
using MerchandiseShop.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Orders
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateCompletion { get; set; }
        public int StatusId { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public int OrderSum { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>()
                .ForMember(orderVm => orderVm.Id, opt => opt.MapFrom(order => order.Id))
                .ForMember(orderVm => orderVm.UserId, opt => opt.MapFrom(order => order.UserId))
                .ForMember(orderVm => orderVm.User, opt => opt.MapFrom(order => order.User))
                .ForMember(orderVm => orderVm.DateCreation, opt => opt.MapFrom(order => order.DateCreation))
                .ForMember(orderVm => orderVm.DateCompletion, opt => opt.MapFrom(order => order.DateCompletion))
                .ForMember(orderVm => orderVm.StatusId, opt => opt.MapFrom(order => order.StatusId));
        }
    }
}
