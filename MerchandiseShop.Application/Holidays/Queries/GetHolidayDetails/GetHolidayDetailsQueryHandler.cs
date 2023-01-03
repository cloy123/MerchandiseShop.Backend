using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MediatR;
using MerchandiseShop.Application.Common.Exceptions;
using MerchandiseShop.Application.Interfaces;
using MerchandiseShop.Domain.Holiday;
using Microsoft.EntityFrameworkCore;

namespace MerchandiseShop.Application.Holidays.Queries.GetHolidayDetails
{
    public class GetHolidayDetailsQueryHandler : IRequestHandler<GetHolidayDetailsQuery, HolidayDetailsVm>
    {
        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetHolidayDetailsQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<HolidayDetailsVm> Handle(GetHolidayDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Holidays.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Holiday), request.Id);
            }

            return _mapper.Map<HolidayDetailsVm>(entity);
        }
    }
}
