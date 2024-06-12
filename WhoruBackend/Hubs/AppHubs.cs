using Microsoft.AspNetCore.SignalR;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Hubs
{
    public class AppHubs: Hub
    {
        private readonly static Dictionary<string, int> onlineUser = new Dictionary<string, int>();
        private readonly static Dictionary<string, int> isCalling = new Dictionary<string, int>();

        private readonly INotificationService _notiService;
        private readonly IChatService _chatService;
        private readonly IUserInfoService _infoService;
        private readonly ILocationService _locationService;

        private static Timer _timer;
        private static readonly object _timerLock = new object();
        private static bool _isTimerInitialized = false;

        public AppHubs(INotificationService notiService, IChatService chatService, IUserInfoService infoService, ILocationService locationService)
        {
            _notiService = notiService;
            _chatService = chatService;
            _infoService = infoService;
            _locationService = locationService;

            //InitializeTimer();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            onlineUser.Remove(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
        public async Task OnDisconnectCalling(int idUser)
        {
            isCalling.Remove(GetConnectionId(idUser));
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
        private string GetConnectionId(int idUser)
        {
            foreach (KeyValuePair<string, int> item in onlineUser)
            {
                if (item.Value == idUser)
                    return item.Key;
            }
            return string.Empty;
        }
        public async Task SendNotification(int Sender, int Receiver, string NameSender, string AvatarSender, string Type)
        {

            var isOnline = onlineUser.ContainsValue(Receiver);
            if (isOnline)
            {
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveNotification", Sender, Receiver, NameSender, AvatarSender, Type);
            }
        }
        public async Task SendMessage(int Sender, int Receiver, string Message)
        {
            var isOnline = onlineUser.ContainsValue(Receiver);
            if (isOnline)
            {
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveMessage", Message, Sender, Receiver);
            }
            await _chatService.SendChat(Sender, Receiver, Message, MessageConstant.MESSAGE, false);
        }

        public async Task SendImage(int Sender, int Receiver, string ImageUrl)
        {
            var isOnline = onlineUser.ContainsValue(Receiver);
            if (isOnline)
            {
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveImage", ImageUrl, Sender, Receiver);
            }
        }

        public async Task SendSignal(int Sender, int Receiver, string Type)
        {
            var isCall = isCalling.ContainsValue(Receiver);
            if (isCall)
            {
                await Clients.Caller.SendAsync("ReceiveSignal", "The recipient cannot answer the phone because he is on another call");
            }
            else
            {
                await _chatService.SendChat(Sender, Receiver, "Call video", MessageConstant.Room, true);
                isCalling.Add(Context.ConnectionId, Sender);
                var info = await _infoService.GetUserInfo(Sender);
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveSignal", Sender, info.FullName, info.Avatar, Receiver, Type);
            }
        }

        public async Task SendOffer(int Sender, int Receiver, string ConnectionString)
        {
            await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveOffer", Sender, Receiver, ConnectionString);
        }
        public async Task SendCandidate(int Sender, int Receiver, string Candidate)
        {
            await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveCandidate", Sender, Receiver, Candidate);
        }
        //private void InitializeTimer()
        //{
        //    if (!_isTimerInitialized)
        //    {
        //        lock (_timerLock)
        //        {
        //            if (!_isTimerInitialized)
        //            {
        //                _timer = new Timer(SendNearestUsersList, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        //                _isTimerInitialized = true;
        //            }
        //        }
        //    }
        //}

        public async Task getNearestUsers(int id)
        {
            List<int> userOnline = new List<int>();
            foreach (var user in onlineUser.Values) 
            {
                userOnline.Add(user);
            }
            //foreach (var user in onlineUser.Values)
            //{
                var nearestUsers = await _locationService.GetNearestUser(id, 5, userOnline); //5km
                await Clients.Caller.SendAsync("Return_List_User", nearestUsers);
            //}
        }
        public async Task SendLocation(int IdUser, double Long, double Lang)
        {
            await _locationService.UpdateLocation(IdUser, Long, Lang);
        }

    }
}
