using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventResponsibles.Commands.DeleteEventResponsible
{
    public class DeleteEventResponsibleCommandHandler : IRequestHandler<DeleteEventResponsibleCommand>
    {

        private readonly IMerchShopDbContext _dbContext;

        public DeleteEventResponsibleCommandHandler(IMerchShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteEventResponsibleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.EventResponsibles.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventResponsible), request.Id);
            }

            _dbContext.EventResponsibles.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
