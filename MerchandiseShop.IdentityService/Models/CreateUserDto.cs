using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Users.Commands.CreateUser;

namespace MerchandiseShop.IdentityService.Models
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }//имя
        public string LastName { get; set; }//фамилия
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public int? ClassNumber { get; set; }
        public string? ClassLetter { get; set; }
        public int GenderId { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(createUserCommand => createUserCommand.UserTypeId, opt => opt.MapFrom(userDto => userDto.UserTypeId))
                .ForMember(createUserCommand => createUserCommand.FirstName, opt => opt.MapFrom(userDto => userDto.FirstName))
                .ForMember(createUserCommand => createUserCommand.LastName, opt => opt.MapFrom(userDto => userDto.LastName))
                .ForMember(createUserCommand => createUserCommand.Birthday, opt => opt.MapFrom(userDto => userDto.Birthday))
                .ForMember(createUserCommand => createUserCommand.ClassNumber, opt => opt.MapFrom(userDto => userDto.ClassNumber))
                .ForMember(createUserCommand => createUserCommand.ClassLetter, opt => opt.MapFrom(userDto => userDto.ClassLetter))
                .ForMember(createUserCommand => createUserCommand.GenderId, opt => opt.MapFrom(userDto => userDto.GenderId));
        }
    }
}
