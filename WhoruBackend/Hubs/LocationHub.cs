//using Microsoft.AspNetCore.SignalR;
//using WhoruBackend.Services;
//using WhoruBackend.Utilities.Constants;

//namespace WhoruBackend.Hubs
//{
//    public class LocationHub : Hub
//    {
//        private readonly ILocationService _locationService;
//        private readonly static Dictionary<string, int> onlineUser = new Dictionary<string, int>();
//        public LocationHub(ILocationService locationService)
//        {
//            _locationService = locationService;
//        }

//        public async Task Online(int idUser)
//        {
//            onlineUser.Add(Context.ConnectionId, idUser);
//            await Clients.Caller.SendAsync("Notification", $"{Context.ConnectionId} has online");
//        }

//        public override Task OnDisconnectedAsync(Exception? exception)
//        {
//            onlineUser.Remove(Context.ConnectionId);
//            return base.OnDisconnectedAsync(exception);
//        }

//        public override async Task OnConnectedAsync()
//        {
//            await Clients.Caller.SendAsync("Notification", $"{Context.ConnectionId} has connected");
//        }

//        public async Task SendLocation(int IdUser, double Long,double Lang)
//        {
//            await _locationService.UpdateLocation(IdUser, Long, Lang);
//        }

//        private string GetConnectionId(int idUser)
//        {
//            foreach (KeyValuePair<string, int> item in onlineUser)
//            {
//                if (item.Value == idUser)
//                    return item.Key;
//            }
//            return string.Empty;
//        }

//        public async Task GetNearestUser(int IdUser, double Size) 
//        {
//            var list = await _locationService.GetNearestUser(IdUser, Size);
//            await Clients.Caller.SendAsync("Return_List_User", list);
//        }
//    }
//}

using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Hubs
{
    public class LocationHub : Hub
    {
        private readonly ILocationService _locationService;
        private readonly static Dictionary<string, int> onlineUser = new Dictionary<string, int>();
        private static Timer _timer;
        private static readonly object _timerLock = new object();
        private static bool _isTimerInitialized = false;

        public LocationHub(ILocationService locationService)
        {
            _locationService = locationService;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            if (!_isTimerInitialized)
            {
                lock (_timerLock)
                {
                    if (!_isTimerInitialized)
                    {
                        _timer = new Timer(SendNearestUsersList, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
                        _isTimerInitialized = true;
                    }
                }
            }
        }

        private async void SendNearestUsersList(object state)
        {
        //    foreach (var user in onlineUser.Values)
        //    {
        //        var nearestUsers = await _locationService.GetNearestUser(user, 5); 
        //        await Clients.All.SendAsync("Return_List_User", nearestUsers);
        //    }
        //
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

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Notification", $"{Context.ConnectionId} has connected");
        }

        public async Task SendLocation(int IdUser, double Long, double Lang)
        {
            await _locationService.UpdateLocation(IdUser, Long, Lang);
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

        //public async Task GetNearestUser(int IdUser, double Size)
        //{
        //    var list = await _locationService.GetNearestUser(IdUser, Size);
        //    await Clients.Caller.SendAsync("Return_List_User", list);
        //}
    }
}

