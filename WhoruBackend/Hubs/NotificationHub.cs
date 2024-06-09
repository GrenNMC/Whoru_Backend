using Microsoft.AspNetCore.SignalR;
using WhoruBackend.Services;
using WhoruBackend.Services.Implement;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Hubs
{
    public class NotificationHub: Hub
    {
        private readonly INotificationService _notiService;
        private readonly static Dictionary<string, int> onlineUser = new Dictionary<string, int>();

        public NotificationHub(INotificationService notiService)
        {
            _notiService = notiService;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Notification", $"{Context.ConnectionId} has connected");
        }
        public async Task Online(int idUser)
        {
            onlineUser.Add(Context.ConnectionId, idUser);
            await Clients.Caller.SendAsync("Notification", $"{Context.ConnectionId} has online");
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            onlineUser.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
        private string GetConnectionId(int idUser)
        {
            foreach (KeyValuePair<string, int> item in onlineUser)
            {
                if (item.Value == idUser)
                    return item.Key;
            }
            return string.Empty;
        }
        public async Task SendNotification(int Sender, int Receiver,string NameSender, string AvatarSender, string Type)
        {

            var isOnline = onlineUser.ContainsValue(Receiver);
            if (isOnline)
            {
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveNotification", Sender, Receiver, NameSender, AvatarSender, Type);
            }
        }
    }
}
