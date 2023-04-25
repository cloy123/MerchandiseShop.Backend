using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Notifications
{
    public class NotificationDetailsVm : IMapWith<Notification>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public bool IsSend { get; set; }
        public DateTime DateTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Notification, NotificationDetailsVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(notification => notification.Id))
                .ForMember(vm => vm.UserId, opt => opt.MapFrom(notification => notification.UserId))
                .ForMember(vm => vm.Message, opt => opt.MapFrom(notification => notification.Message))
                .ForMember(vm => vm.IsSend, opt => opt.MapFrom(notification => notification.IsSend))
                .ForMember(vm => vm.DateTime, opt => opt.MapFrom(notification => notification.DateTime));
        }
    }
}
