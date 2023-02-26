using MediatR;
using MerchandiseShop.Application.Holidays.Commands.CheckHolidays;

namespace MerchandiseShop.WebApp.Middleware
{
    public class CheckHolidaysBackgroundService : BackgroundService
    {
        private readonly PeriodicTimer _timer = new(TimeSpan.FromDays(1));//new(TimeSpan.FromMinutes(1))
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IMediator _mediator;

        public CheckHolidaysBackgroundService(IServiceProvider serviceProvider, IServiceScopeFactory serviceScopeFactory)
        {
            _serviceProvider = serviceProvider;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            while (await _timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                await mediator.Send(new CheckHolidaysCommand());
            }
        }
    }
}
