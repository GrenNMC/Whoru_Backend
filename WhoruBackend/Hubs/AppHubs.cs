using Firebase.Auth;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using System;
using System.Reflection;
using System.Threading.Channels;
using Tensorflow;
using WhoruBackend.Models;
using WhoruBackend.ModelViews.LocationModelView;
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
        public async Task OnDisconnectCalling(int idSender, int idReceiver)
        {
            var isCall = isCalling.ContainsValue(idSender);
            var isRep = isCalling.ContainsValue(idReceiver);
            if(isCall)
            {
                isCalling.Remove(GetConnectionId(idSender));
            }
            if(isRep)
            {
                isCalling.Remove(GetConnectionId(idReceiver));
            }
            if(Context.ConnectionId == GetConnectionId(idSender))
            {
                await Clients.Client(GetConnectionId(idReceiver)).SendAsync("DisconnectCalling", "");
            }
            else 
                await Clients.Client(GetConnectionId(idSender)).SendAsync("DisconnectCalling", "");
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
            //var isOnline = onlineUser.ContainsValue(Receiver);
            var chat =  await _chatService.SendChat(Sender, Receiver, Message, MessageConstant.MESSAGE, false);
            await Clients.Caller.SendAsync("SendMessage", chat.Id, chat.Message,chat.UserSend,chat.UserReceive);
            //if (isOnline)
            //{
            //    await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveMessage", chat.Id, Message, Sender, Receiver);
            //}

        }

        //public async Task SendWaitMessage(int Sender, int Receiver, string Message)
        //{
        //    //var isOnline = onlineUser.ContainsValue(Receiver);
        //    var chat = await _chatService.SendChat(Sender, Receiver, Message, MessageConstant.MESSAGE, false);
        //    await Clients.Caller.SendAsync("ReceiveMessage", chat.Id, chat.Date, chat.Message, chat.Type, chat.UserSend, chat.UserReceive);
        //    //if (isOnline)
        //    //{
        //    //    await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveMessage", chat.Id, Message, Sender, Receiver);
        //    //}

        //}
        public async Task SendMessToUser(int Id,string Message,int Sender,int Receiver)
        {
            var isOnline = onlineUser.ContainsValue(Receiver);
            if (isOnline)
            {
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveMessage", Id, Message, Sender, Receiver);
            }

        }

        public async Task DeleteMessage(int Receiver, int idPost)
        {
            var isOnline = onlineUser.ContainsValue(Receiver);
            if (isOnline)
            {
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("DeleteMessage", idPost);
            }

        }

        public async Task SendImage(int Sender, int Receiver, string ImageUrl)
        {
            var isOnline = onlineUser.ContainsValue(Receiver);
            if (isOnline)
            {
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveImage", ImageUrl, Sender, Receiver);
            }
        }
        public async Task GetCallingList()
        {
            await Clients.Caller.SendAsync("ReceiveListCalling", isCalling);
        }

        public async Task GetOnlineList()
        {
            await Clients.Caller.SendAsync("ReceiveListOnline", onlineUser);
        }

        public async Task SendSignal(int Sender, int Receiver, string Type)
        {
            var isCall = isCalling.ContainsValue(Receiver);
            if (isCall)
            {
                await Clients.Caller.SendAsync("isCalling", "The recipient cannot answer the phone because he is on another call");
            }
            else
            {

                await _chatService.SendChat(Sender, Receiver, "Call video", MessageConstant.Room, true);
                isCalling.Add(Context.ConnectionId, Sender);
                isCalling.Add(GetConnectionId(Receiver), Receiver);
                var info = await _infoService.GetUserInfo(Sender);
                await Clients.Client(GetConnectionId(Receiver)).SendAsync("ReceiveSignal", Sender, info.name, info.avatar, Receiver, Type);
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
                //if(nearestUsers.Count == 0)
                //{
                //await Clients.Caller.SendAsync("Return_List_User", "[]");
                //}
                await Clients.Caller.SendAsync("Return_List_User", nearestUsers);
            //}
        }
        public async Task SendLocation(int IdUser, double Long, double Lang)
        {
            await _locationService.UpdateLocation(IdUser, Long, Lang);
        }
        public async Task SendNote(int IdUser, string Note) {
            await _locationService.CreateNote(IdUser, Note);
        }
        public async Task DeleteNote(int IdUser)
        {
            await _locationService.DeleteNote(IdUser);
        }
        public ChannelReader<List<UserLocationModelView>> StreamNearestUser(int idUser, CancellationToken cancellationToken)
        {
            var channel = Channel.CreateUnbounded<List<UserLocationModelView>>();

            // Start a background task to write to the channel
            _ = WriteToChannel(channel.Writer,idUser, cancellationToken);

            return channel.Reader;
        }

        private async Task WriteToChannel(ChannelWriter<List<UserLocationModelView>> writer,int id, CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    List<int> userOnline = new List<int>();
                    foreach (var user in onlineUser.Values)
                    {
                        userOnline.Add(user);
                    }
                    var nearestUsers = await _locationService.GetNearestUser(id, 5, userOnline);
                    await writer.WriteAsync(nearestUsers, cancellationToken);
                    await Task.Delay(5000, cancellationToken); 
                }
            }
            catch (OperationCanceledException ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                writer.TryComplete();
            }
        }
    }

}

