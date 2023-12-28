using Microsoft.AspNetCore.SignalR;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;
using static System.Net.Mime.MediaTypeNames;

namespace WhoruBackend.Hubs
{
    public class ChatHub: Hub
    {
        private readonly IChatService _chatService;
        private readonly IUserInfoService _infoService;
        private readonly static Dictionary<string, int> onlineUser = new Dictionary<string, int>();
        private readonly static Dictionary<string, int> isCalling = new Dictionary<string, int>();
        public ChatHub(IChatService chatService, IUserInfoService infoService)
        {
            _chatService = chatService;
            _infoService = infoService;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceviedNotification", $"{Context.ConnectionId} has connected");
        }

        public async Task Online(int idUser)
        {
            onlineUser.Add(Context.ConnectionId, idUser);
            await Clients.Caller.SendAsync("ReceviedNotification", $"{Context.ConnectionId} has online");
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            onlineUser.Remove(Context.ConnectionId);
            isCalling.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(int Sender, int Receiver, string Message)
        {
            var isOnline = onlineUser.ContainsValue(Receiver);
            if (isOnline)
            {
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveMessage",Message,Sender,Receiver);
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
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveImage", link, Sender, Receiver);
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
        public async Task SendSignal(int Sender, int Receiver, string Type)
        {
            //var isCall = isCalling.ContainsValue(Receiver);
            //if (isCall) 
            //{
            //    await Clients.Caller.SendAsync("ReceiveSignal", "Receiver is calling");
            //}
            //else
            //{
                var info = await _infoService.GetUserInfo(Sender);
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveSignal", Sender, info.FullName, info.Avatar, Receiver, Type);
            //}
        }
        public async Task SendOffer(int Sender, int Receiver, string ConnectionString) 
        {
            await _chatService.SendChat(Sender, Receiver, "Call video", MessageConstant.Room, true);
            isCalling.Add(Context.ConnectionId, Sender);
            await Clients.Client(GetConnectionId(Sender)).SendAsync("ReceiveOffer", Sender, Receiver, ConnectionString);
        }
        public async Task SendCandidate(int Sender, int Receiver, string Candidate)
        {
            await Clients.Client(GetConnectionId(Sender)).SendAsync("ReceiveCandidate", Sender, Receiver, Candidate);
        }
    }
}
