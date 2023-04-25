using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Orders;

namespace MerchandiseShop.WebApi.Models
{
    public class OrderDto : IMapWith<OrderDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateCompletion { get; set; }
        public int StatusId { get; set; }
        public IList<OrderItemDto> OrderItems { get; set; }
        public int OrderSum { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDetailsVm, OrderDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(dto => dto.UserId, opt => opt.MapFrom(vm => vm.UserId))
                .ForMember(dto => dto.DateCreation, opt => opt.MapFrom(vm => vm.DateCreation))
                .ForMember(dto => dto.DateCompletion, opt => opt.MapFrom(vm => vm.DateCompletion))
                .ForMember(dto => dto.StatusId, opt => opt.MapFrom(vm => vm.StatusId))
                .ForMember(dto => dto.OrderSum, opt => opt.MapFrom(vm => vm.OrderSum));
        }
    }
}
