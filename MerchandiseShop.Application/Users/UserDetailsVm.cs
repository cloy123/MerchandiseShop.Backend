using AutoMapper;
using MerchandiseShop.Application.Common.Mappings;
using MerchandiseShop.Domain.Models;
using MerchandiseShop.Domain.Users;
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
        public bool IsAccess { get; set; }
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

        public string UserFullInfo
        {
            get
            {
                var info = FullName;
                if (ClassNumber != null)
                {
                    info += " " + ClassNumber.ToString();
                    if (ClassLetter != null)
                    {
                        info += ClassLetter;
                    }
                }
                info += " " + UserTypeName;
                return info;
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
                .ForMember(userVm => userVm.Id, opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.UserTypeId, opt => opt.MapFrom(user => user.UserTypeId))
                .ForMember(userVm => userVm.IsAccess, opt => opt.MapFrom(user => user.IsAccess))
                .ForMember(userVm => userVm.FirstName, opt => opt.MapFrom(user => user.FirstName))
                .ForMember(userVm => userVm.LastName, opt => opt.MapFrom(user => user.LastName))
                .ForMember(userVm => userVm.Birthday, opt => opt.MapFrom(user => user.Birthday))
                .ForMember(userVm => userVm.Email, opt => opt.MapFrom(user => user.Email))
                .ForMember(userVm => userVm.PointBalance, opt => opt.MapFrom(user => user.PointBalance))
                .ForMember(userVm => userVm.ClassNumber, opt => opt.MapFrom(user => user.ClassNumber))
                .ForMember(userVm => userVm.ClassLetter, opt => opt.MapFrom(user => user.ClassLetter))
                .ForMember(userVm => userVm.GenderId, opt => opt.MapFrom(user => user.GenderId));
        }
    }
}
