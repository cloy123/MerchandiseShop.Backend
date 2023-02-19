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

namespace MerchandiseShop.Application.EventResponsibles.Queries.GetEventResponsibleDetails
{
    public class GetEventResponsibleDetailsQueryHandler : IRequestHandler<GetEventResponsibleDetailsQuery, EventResponsibleDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventResponsibleDetailsQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventResponsibleDetailsVm> Handle(GetEventResponsibleDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.EventResponsibles
                .Include(u => u.User)
                .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventResponsible), request.Id);
            }

            return _mapper.Map<EventResponsibleDetailsVm>(entity);
        }
    }
}
