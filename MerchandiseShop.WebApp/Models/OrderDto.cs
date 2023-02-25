using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Orders;
using MerchandiseShop.Domain.Order;
using MerchandiseShop.Domain.Users;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class OrderDto : IMapWith<OrderDetailsVm>
    {
        public Guid Id { get; set; }

        [DisplayName("Пользователь")]
        public Guid UserId { get; set; }

        [ValidateNever]
        public User User { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreation { get; set; }

        [DisplayName("Дата выполнения")]
        public DateTime? DateCompletion { get; set; }

        [DisplayName("Статус")]
        public int StatusId { get; set; }
        [ValidateNever]
        public IList<OrderItem> OrderItems { get; set; }
        [DisplayName("Сумма")]
        public int OrderSum { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<OrderDetailsVm, OrderDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(details => details.Id))
                .ForMember(dto => dto.UserId, opt => opt.MapFrom(details => details.UserId))
                .ForMember(dto => dto.User, opt => opt.MapFrom(details => details.User))
                .ForMember(dto => dto.DateCreation, opt => opt.MapFrom(details => details.DateCreation))
                .ForMember(dto => dto.DateCompletion, opt => opt.MapFrom(details => details.DateCompletion))
                .ForMember(dto => dto.StatusId, opt => opt.MapFrom(details => details.StatusId))
                .ForMember(dto => dto.OrderItems, opt => opt.MapFrom(details => details.OrderItems))
                .ForMember(dto => dto.OrderSum, opt => opt.MapFrom(details => details.OrderSum));
        }
    }
}
