using Microsoft.AspNetCore.SignalR;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Hubs
{
    public class NotificationHub: Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceviedNotification", $"{Context.ConnectionId} has connected");
        }
        //public async Task SendNotification(int Sender, int Receiver, string Message)
        //{
            
        //        await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveMessage", Message, Sender, Receiver);
        //        //Lưu DB
          
        //}
    }
}
