using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Server
{
    [Route("notifications")]
    [ApiController]
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly PizzaStoreContext _db;

        public NotificationsController(PizzaStoreContext db)
        {
            _db = db;
        }

        [HttpPut("endpoint")]
        public async Task<NotificationEndpoint> Endpoint(NotificationEndpoint endpoint)
        {
            // We're storing at most one endpoint per user, so delete old ones.
            // Alternatively, you could let the user register multiple endpoints from different browsers/devices.
            var userId = GetUserId();
            var oldEndpoints = _db.NotificationEndpoints.Where(e => e.UserId == userId);
            _db.NotificationEndpoints.RemoveRange(oldEndpoints);

            // Store new endpoint
            endpoint.UserId = userId;
            _db.NotificationEndpoints.Attach(endpoint);

            await _db.SaveChangesAsync();
            return endpoint;
        }

        private string GetUserId()
        {
            // This will be the user's twitter username
            return HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
        }
    }
}
