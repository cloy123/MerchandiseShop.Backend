using MediatR;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Users.Commands.FindUser
{
    public class FindUserCommandHandler : IRequestHandler<FindUserCommand, FindUserVm>
    {
        private readonly IMerchShopDbContext _dbContext;

        public FindUserCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FindUserVm> Handle(FindUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);
            var findUserVm = new FindUserVm();
            if(user == null)
            {
                findUserVm.IsUserFound = false;
                findUserVm.IsPasswordCorrect = false;
                findUserVm.IsAccess = false;
            }
            else
            {
                findUserVm.IsUserFound = true;
                if(user.PasswordHash == User.GetHashFromString(request.Password))
                {
                    findUserVm.IsPasswordCorrect = true;
                    findUserVm.UserDto = new UserDetailsVm
                    {
                        Id = user.Id,
                        UserTypeId = user.UserTypeId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Birthday = user.Birthday,
                        Email = user.Email,
                        PointBalance = user.PointBalance,
                        ClassNumber = user.ClassNumber,
                        ClassLetter = user.ClassLetter,
                        GenderId = user.GenderId
                    };
                    findUserVm.IsAccess = user.IsAccess;
                }
                else
                {
                    findUserVm.IsPasswordCorrect = false;
                    findUserVm.IsAccess = false;
                }
            }
            return findUserVm;
        }
    }
}
