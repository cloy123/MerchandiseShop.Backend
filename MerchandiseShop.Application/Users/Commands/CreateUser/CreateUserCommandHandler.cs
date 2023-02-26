using MediatR;
using MerchandiseShop.Application.Common;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMerchShopDbContext _dbContext;

        public CreateUserCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var pass = "";
            var user = new User
            {
                UserTypeId = request.UserTypeId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthday = request.Birthday,
                Email = request.Email,
                PointBalance = request.PointBalance,
                ClassNumber = request.ClassNumber,
                ClassLetter = request.ClassLetter,
                IsAccess = request.IsAccess,
                GenderId = request.GenderId,
                Id = Guid.NewGuid()
            };
            if(request.Password != null && request.Password != String.Empty)
            {
                pass = request.Password;
                user.SetPassword(request.Password);
            }
            else
            {
                pass = User.CreatePassword();
                user.SetPassword(pass);
            }

            //var emailService = new EmailService();
            //await emailService.SendEmailAsync(user.Email, "Данные для входа", $"Логин: {user.Email} Пароль: {pass}");

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
