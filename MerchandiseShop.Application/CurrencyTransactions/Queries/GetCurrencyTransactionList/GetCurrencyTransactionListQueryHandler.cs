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

namespace MerchandiseShop.Application.CurrencyTransactions.Queries.GetCurrencyTransactionList
{
    public class GetCurrencyTransactionListQueryHandler : IRequestHandler<GetCurrencyTransactionListQuery, CurrencyTransactionListVm>
    {

        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCurrencyTransactionListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CurrencyTransactionListVm> Handle(GetCurrencyTransactionListQuery request, CancellationToken cancellationToken)
        {
            var currencyTransactions = await _dbContext.CurrencyTransactions
                .Where(n => n.UserId == request.UserId)
                .ProjectTo<CurrencyTransactionDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new CurrencyTransactionListVm { CurrencyTransactions = currencyTransactions };
        }
    }
}
