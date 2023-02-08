using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Models;
using MerchandiseShop.Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Users
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid Id { get; set; }
        public int UserTypeId { get; set; } = -1;
        public string UserTypeName
        {
            get
            {
                if (UserTypeId == -1)
                {
                    return "";
                }
                return Enumeration.GetAll<UserType>().FirstOrDefault(it => it.Id.Equals(UserTypeId)).Name;
            }
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public int PointBalance { get; set; } = 0;
        public int? ClassNumber { get; set; }
        public string? ClassLetter { get; set; }
        public int GenderId { get; set; } = -1;
        public string GenderName
        {
            get
            {
                if (GenderId == -1)
                {
                    return "";
                }
                return Enumeration.GetAll<UserGender>().FirstOrDefault(it => it.Id.Equals(GenderId)).Name;
            }
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userDto => userDto.Id, opt => opt.MapFrom(user => user.Id))
                .ForMember(userDto => userDto.UserTypeId, opt => opt.MapFrom(user => user.UserTypeId))
                .ForMember(userDto => userDto.FirstName, opt => opt.MapFrom(user => user.FirstName))
                .ForMember(userDto => userDto.LastName, opt => opt.MapFrom(user => user.LastName))
                .ForMember(userDto => userDto.Birthday, opt => opt.MapFrom(user => user.Birthday))
                .ForMember(userDto => userDto.Email, opt => opt.MapFrom(user => user.Email))
                .ForMember(userDto => userDto.PointBalance, opt => opt.MapFrom(user => user.PointBalance))
                .ForMember(userDto => userDto.ClassNumber, opt => opt.MapFrom(user => user.ClassNumber))
                .ForMember(userDto => userDto.ClassLetter, opt => opt.MapFrom(user => user.ClassLetter))
                .ForMember(userDto => userDto.GenderId, opt => opt.MapFrom(user => user.GenderId));
        }
    }
}
