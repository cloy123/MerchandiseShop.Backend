using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace MerchandiseShop.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IMerchShopDbContext _dbContext;

        public UpdateUserCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            user.Birthday = request.Birthday;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.IsAccess = request.IsAccess;
            user.UserTypeId = request.UserTypeId;
            user.PointBalance = request.PointBalance;
            user.ClassNumber = request.ClassNumber;
            user.ClassLetter = request.ClassLetter;
            user.GenderId = request.GenderId;
            if (request.NewPassword != null && request.NewPassword != String.Empty)
            {
                user.SetPassword(request.NewPassword);
            }
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
