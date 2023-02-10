using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Application.Users;
using MerchandiseShop.Application.Users.Commands.CreateUser;
using MerchandiseShop.Application.Users.Commands.UpdateUser;
using System.ComponentModel;

namespace MerchandiseShop.WebApp.Models
{
    public class UserDto : IMapWith<CreateUserCommand>, IMapWith<UpdateUserCommand>, IMapWith<UserDetailsVm>
    {
        public Guid Id { get; set; }

        [DisplayName("Тип пользователя")]
        public int UserTypeId { get; set; }

        [DisplayName("Доступ")]
        public bool IsAccess { get; set; }
        
        [DisplayName("Имя")]
        public string FirstName { get; set; }
       
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        
        [DisplayName("Дата рождения")]
        public DateTime Birthday { get; set; }
       
        [DisplayName("Email")]
        public string Email { get; set; }
        
        [DisplayName("Баланс баллов")]
        public int PointBalance { get; set; }

        [DisplayName("Номер класса")]
        public int? ClassNumber { get; set; }
        
        [DisplayName("Буква класса")]
        public string? ClassLetter { get; set; }
       
        [DisplayName("Пол")]
        public int GenderId { get; set; }
        
        [DisplayName("Пароль")]
        public string? NewPassword { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<UserDto, CreateUserCommand>()
                .ForMember(createUserCommand => createUserCommand.UserTypeId, opt => opt.MapFrom(userDto => userDto.UserTypeId))
                .ForMember(createUserCommand => createUserCommand.UserTypeId, opt => opt.MapFrom(userDto => userDto.UserTypeId))
                .ForMember(createUserCommand => createUserCommand.IsAccess, opt => opt.MapFrom(userDto => userDto.IsAccess))
                .ForMember(createUserCommand => createUserCommand.FirstName, opt => opt.MapFrom(userDto => userDto.FirstName))
                .ForMember(createUserCommand => createUserCommand.Email, opt => opt.MapFrom(userDto => userDto.Email))
                .ForMember(createUserCommand => createUserCommand.LastName, opt => opt.MapFrom(userDto => userDto.LastName))
                .ForMember(createUserCommand => createUserCommand.Birthday, opt => opt.MapFrom(userDto => userDto.Birthday))
                .ForMember(createUserCommand => createUserCommand.PointBalance, opt => opt.MapFrom(userDto => userDto.PointBalance))
                .ForMember(createUserCommand => createUserCommand.ClassNumber, opt => opt.MapFrom(userDto => userDto.ClassNumber))
                .ForMember(createUserCommand => createUserCommand.ClassLetter, opt => opt.MapFrom(userDto => userDto.ClassLetter))
                .ForMember(createUserCommand => createUserCommand.GenderId, opt => opt.MapFrom(userDto => userDto.GenderId))
                .ForMember(createUserCommand => createUserCommand.Password, opt => opt.MapFrom(userDto => userDto.NewPassword));
            
            profile.CreateMap<UserDto, UpdateUserCommand>()
                .ForMember(updateUserCommand => updateUserCommand.Id, opt => opt.MapFrom(userDto => userDto.Id))
                .ForMember(updateUserCommand => updateUserCommand.UserTypeId, opt => opt.MapFrom(userDto => userDto.UserTypeId))
                .ForMember(updateUserCommand => updateUserCommand.IsAccess, opt => opt.MapFrom(userDto => userDto.IsAccess))
                .ForMember(updateUserCommand => updateUserCommand.FirstName, opt => opt.MapFrom(userDto => userDto.FirstName))
                .ForMember(updateUserCommand => updateUserCommand.Email, opt => opt.MapFrom(userDto => userDto.Email))
                .ForMember(updateUserCommand => updateUserCommand.LastName, opt => opt.MapFrom(userDto => userDto.LastName))
                .ForMember(updateUserCommand => updateUserCommand.Birthday, opt => opt.MapFrom(userDto => userDto.Birthday))
                .ForMember(updateUserCommand => updateUserCommand.PointBalance, opt => opt.MapFrom(userDto => userDto.PointBalance))
                .ForMember(updateUserCommand => updateUserCommand.ClassNumber, opt => opt.MapFrom(userDto => userDto.ClassNumber))
                .ForMember(updateUserCommand => updateUserCommand.ClassLetter, opt => opt.MapFrom(userDto => userDto.ClassLetter))
                .ForMember(updateUserCommand => updateUserCommand.GenderId, opt => opt.MapFrom(userDto => userDto.GenderId))
                .ForMember(updateUserCommand => updateUserCommand.NewPassword, opt => opt.MapFrom(userDto => userDto.NewPassword));

            profile.CreateMap<UserDetailsVm, UserDto>()
                .ForMember(userDto => userDto.Id, opt => opt.MapFrom(userDetails => userDetails.Id))
                .ForMember(userDto => userDto.UserTypeId, opt => opt.MapFrom(userDetails => userDetails.UserTypeId))
                .ForMember(userDto => userDto.IsAccess, opt => opt.MapFrom(userDetails => userDetails.IsAccess))
                .ForMember(userDto => userDto.FirstName, opt => opt.MapFrom(userDetails => userDetails.FirstName))
                .ForMember(userDto => userDto.Email, opt => opt.MapFrom(userDetails => userDetails.Email))
                .ForMember(userDto => userDto.LastName, opt => opt.MapFrom(userDetails => userDetails.LastName))
                .ForMember(userDto => userDto.Birthday, opt => opt.MapFrom(userDetails => userDetails.Birthday))
                .ForMember(userDto => userDto.PointBalance, opt => opt.MapFrom(userDetails => userDetails.PointBalance))
                .ForMember(userDto => userDto.ClassNumber, opt => opt.MapFrom(userDetails => userDetails.ClassNumber))
                .ForMember(userDto => userDto.ClassLetter, opt => opt.MapFrom(userDetails => userDetails.ClassLetter))
                .ForMember(userDto => userDto.GenderId, opt => opt.MapFrom(userDetails => userDetails.GenderId));
        }
    }
}
