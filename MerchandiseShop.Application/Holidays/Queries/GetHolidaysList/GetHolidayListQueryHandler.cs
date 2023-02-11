using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MerchandiseShop.Application.Interfaces;

namespace MerchandiseShop.Application.Holidays.Queries.GetHolidaysList
{
    public class GetHolidayListQueryHandler : IRequestHandler<GetHolidayListQuery, HolidayListVm>
    {

        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetHolidayListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<HolidayListVm> Handle(GetHolidayListQuery request, CancellationToken cancellationToken)
        {
            var holidaysQuery = await _dbContext.Holidays.ProjectTo<HolidayDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new HolidayListVm { Holidays = holidaysQuery };
        }
    }
}
