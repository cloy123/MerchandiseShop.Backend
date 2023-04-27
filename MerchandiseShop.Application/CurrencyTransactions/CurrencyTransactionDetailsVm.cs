using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.CurrencyTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.CurrencyTransactions
{
    public class CurrencyTransactionDetailsVm : IMapWith<CurrencyTransaction>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyTransactionTypeId { get; set; }
        public int Points { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CurrencyTransaction, CurrencyTransactionDetailsVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(notification => notification.Id))
                .ForMember(vm => vm.UserId, opt => opt.MapFrom(notification => notification.UserId))
                .ForMember(vm => vm.Date, opt => opt.MapFrom(notification => notification.Date))
                .ForMember(vm => vm.CurrencyTransactionTypeId, opt => opt.MapFrom(notification => notification.CurrencyTransactionTypeId))
                .ForMember(vm => vm.Points, opt => opt.MapFrom(notification => notification.Points));
        }
    }
}
