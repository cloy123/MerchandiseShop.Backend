﻿using AutoMapper;
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

namespace MerchandiseShop.Application.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventDetailsQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventDetailsVm> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Events.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            return _mapper.Map<EventDetailsVm>(entity);
        }
    }
}