using Microsoft.AspNetCore.SignalR;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Hubs
{
    public class LocationHub : Hub
    {
        private readonly ILocationService _locationService;

        public LocationHub(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Notification", $"{Context.ConnectionId} has connected");
        }

        public async Task SendLocation(int IdUser, double Long,double Lang)
        {
            await _locationService.UpdateLocation(IdUser, Long, Lang);
        }
    }
}
