using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Users.Commands.FindUser;

namespace MerchandiseShop.IdentityService.Models
{
    public class LoginDto : IMapWith<FindUserCommand>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<LoginDto, FindUserCommand>()
                .ForMember(findUserCommand => findUserCommand.Email, opt => opt.MapFrom(loginDto => loginDto.Email))
                .ForMember(findUserCommand => findUserCommand.Password, opt => opt.MapFrom(loginDto => loginDto.Password));
        }
    }
}
