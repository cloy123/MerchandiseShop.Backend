using AutoMapper;
using MerchandiseShop.Application.Notifications.Queries.GetNotificationList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseShop.WebApi.Controllers
{
    public class NotificationsController : BaseController
    {
        private readonly IMapper _mapper;

        public NotificationsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<NotificationListVm>> GetNotifications()
        {

            var userIdClaim = User.Claims.FirstOrDefault(i => i.Type == "Id");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            var guid = Guid.Parse(userIdClaim.Value).ToString();
            var query = new GetNotificationListQuery { UserId = Guid.Parse(userIdClaim.Value)};
            var notifications = await Mediator.Send(query);
            return Ok(new { notifications, guid });
        }
    }
}
