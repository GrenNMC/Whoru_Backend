using Microsoft.AspNetCore.SignalR;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Hubs
{
    public class ChatHub: Hub
    {
        private readonly IChatService _chatService;
        private readonly static Dictionary<string, int> onlineUser = new Dictionary<string, int>();

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceviedMessage", $"{Context.ConnectionId} has connected");
        }

        public async Task Online(int idUser)
        {
            onlineUser.Add(Context.ConnectionId, idUser);
            await Clients.Caller.SendAsync("ReceviedMessage", $"{Context.ConnectionId} has online");
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            onlineUser.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(int Sender, int Receiver, string Message)
        {
            var isOnline = onlineUser.ContainsValue(Receiver);
            if (isOnline)
            {
                await Clients.Client(GetConnectionId(Receiver)).SendAsync(Message);
                //Lưu DB
                await _chatService.SendChat(Sender, Receiver, Message,MessageConstant.MESSAGE,true);
            }
            //Lưu DB
            else 
                await _chatService.SendChat(Sender, Receiver, Message, MessageConstant.MESSAGE, false);
        }

        public async Task SendImage(int Sender, int Receiver, IFormFile Image)
        {
            var isOnline = onlineUser.ContainsValue(Receiver);
            UploadImageToStorage storage = new UploadImageToStorage();
            var link = await storage.ChatImageUrl(Image);
            if (isOnline)
            {
                await Clients.Client(GetConnectionId(Receiver)).SendAsync(link);
                //Lưu DB
                await _chatService.SendChat(Sender, Receiver, link, Image.FileName, true);
            }
            //Lưu DB
            else
                await _chatService.SendChat(Sender, Receiver, link, Image.FileName, false);
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
    }
}
