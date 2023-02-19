using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MerchandiseShop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.EventRoles.Queries.GetEventRoleList
{
    public class GetEventRoleListQueryHandler : IRequestHandler<GetEventRoleListQuery, EventRoleListVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventRoleListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventRoleListVm> Handle(GetEventRoleListQuery request, CancellationToken cancellationToken)
        {
            var eventRoles = await _dbContext.EventRoles
                .ProjectTo<EventRoleDetailsVm>(_mapper.ConfigurationProvider)
                .Where(e => e.EventId == request.EventId)
                .ToListAsync(cancellationToken);
            return new EventRoleListVm { EventRoles = eventRoles };
        }
    }
}
