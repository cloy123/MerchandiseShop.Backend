using AutoMapper;
using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Event;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Queries.GetEventRoleDetails
{
    public class GetEventRoleDetailsQueryHandler : IRequestHandler<GetEventRoleDetailsQuery, EventRoleDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventRoleDetailsQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventRoleDetailsVm> Handle(GetEventRoleDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.EventRoles
                .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventRole), request.Id);
            }

            return _mapper.Map<EventRoleDetailsVm>(entity);
        }
    }
}
