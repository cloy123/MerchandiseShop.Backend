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

namespace MerchandiseShop.Application.EventResponsibles.Queries.GetEventResponsibleList
{
    public class GetEventResponsibleListQueryHandler : IRequestHandler<GetEventResponsibleListQuery, EventResponsibleListVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventResponsibleListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventResponsibleListVm> Handle(GetEventResponsibleListQuery request, CancellationToken cancellationToken)
        {
            var eventResponsibles = await _dbContext.EventResponsibles
                .Include(u => u.User)
                .ProjectTo<EventResponsibleDetailsVm>(_mapper.ConfigurationProvider)
                .Where(e => e.EventId == request.EventId)
                .ToListAsync(cancellationToken);
            return new EventResponsibleListVm { EventResponsibles = eventResponsibles };
        }
    }
}
