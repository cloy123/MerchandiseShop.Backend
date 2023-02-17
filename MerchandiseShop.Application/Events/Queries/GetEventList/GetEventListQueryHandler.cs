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

namespace MerchandiseShop.Application.Events.Queries.GetEventList
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, EventListVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventListVm> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var eventsQuery = await _dbContext.Events.ProjectTo<EventDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new EventListVm { Events = eventsQuery };
        }
    }
}
