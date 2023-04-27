using AutoMapper;
using MerchandiseShop.Application.CurrencyTransactions.Queries.GetCurrencyTransactionList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApi.Controllers
{
    public class CurrencyTransactionsController : BaseController
    {
        private readonly IMapper _mapper;

        public CurrencyTransactionsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<CurrencyTransactionListVm>> GetCurrencyTransactionsInfo()
        {
            var userIdClaim = User.Claims.FirstOrDefault(i => i.Type == "Id");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            var guid = Guid.Parse(userIdClaim.Value);
            var query = new GetCurrencyTransactionListQuery { UserId = guid };
            var currencyTransactions = await Mediator.Send(query);
            return Ok(new { currencyTransactions.CurrencyTransactions });
        }
    }
}
