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

namespace MerchandiseShop.Application.Notifications.Queries.GetNotificationList
{
    public class GetNotificationListQueryHandler : IRequestHandler<GetNotificationListQuery, NotificationListVm>
    {

        private readonly IMerchShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNotificationListQueryHandler(IMerchShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NotificationListVm> Handle(GetNotificationListQuery request, CancellationToken cancellationToken)
        {
            var notificationsQuery = await _dbContext.Notifications
                //.Where(n => n.UserId == request.UserId)
                .ProjectTo<NotificationDetailsVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            await _dbContext.Notifications.Where(n => n.UserId == request.UserId).ForEachAsync(n => n.IsSend = true);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new NotificationListVm { Notifications = notificationsQuery };
        }
    }
}
