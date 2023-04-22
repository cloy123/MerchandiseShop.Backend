using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.UserRefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.UserRefreshTokens.Queries
{
    public class UserRefreshTokenDetailsVm : IMapWith<UserRefreshToken>
    {
        public Guid Id { get; set; }
        public string RefreshToken { get; set; }   
        public Guid UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserRefreshToken, UserRefreshTokenDetailsVm>()
                .ForMember(userRefreshTokenVm => userRefreshTokenVm.Id, opt => opt.MapFrom(userRefreshToken => userRefreshToken.Id))
                .ForMember(userRefreshTokenVm => userRefreshTokenVm.RefreshToken, opt => opt.MapFrom(userRefreshToken => userRefreshToken.RefreshToken))
                .ForMember(userRefreshTokenVm => userRefreshTokenVm.UserId, opt => opt.MapFrom(userRefreshToken => userRefreshToken.UserId));
        }
    }
}
