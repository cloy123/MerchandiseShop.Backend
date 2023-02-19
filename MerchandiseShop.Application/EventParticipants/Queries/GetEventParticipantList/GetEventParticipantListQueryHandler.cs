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

namespace MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantList
{
    public class GetEventParticipantListQueryHandler : IRequestHandler<GetEventParticipantListQuery, EventParticipantListVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventParticipantListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventParticipantListVm> Handle(GetEventParticipantListQuery request, CancellationToken cancellationToken)
        {
            var eventParcticants = await _dbContext.EventParticipants
                .Include(e => e.EventRole)
                .Include(e => e.User)
                .ProjectTo<EventParticipantDetailsVm>(_mapper.ConfigurationProvider)
                .Where(e => e.EventId == request.EventId)
                .ToListAsync(cancellationToken);
            return new EventParticipantListVm { EventParticipants = eventParcticants };
        }
    }
}
