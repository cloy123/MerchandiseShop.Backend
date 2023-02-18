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

namespace MerchandiseShop.Application.EventParticipants.Queries.GetEventParticipantDetails
{
    public class GetEventParticipantDetailsQueryHandler : IRequestHandler<GetEventParticipantDetailsQuery, EventParticipantDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventParticipantDetailsQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventParticipantDetailsVm> Handle(GetEventParticipantDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.EventParticipants
                .Include(e => e.EventRole)
                .Include(e => e.User)
                .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventParticipant), request.Id);
            }

            return _mapper.Map<EventParticipantDetailsVm>(entity);
        }
    }
}
