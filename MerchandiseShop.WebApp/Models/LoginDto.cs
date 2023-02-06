using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Users.Commands.FindUser;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class LoginDto : IMapWith<FindUserCommand>
    {
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<LoginDto, FindUserCommand>()
                .ForMember(findUserCommand => findUserCommand.Email, opt => opt.MapFrom(loginDto => loginDto.Email))
                .ForMember(findUserCommand => findUserCommand.Password, opt => opt.MapFrom(loginDto => loginDto.Password));
        }
    }
}
