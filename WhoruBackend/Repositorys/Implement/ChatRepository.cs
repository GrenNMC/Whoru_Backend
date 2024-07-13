using Azure.Messaging;
using Firebase.Auth;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Serilog;
using System;
using System.Linq;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.ChatModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IUserInfoRepository _UserInfoRepo;

        public ChatRepository(ApplicationDbContext dbContext, IUserInfoRepository userInfoRepo)
        {
            _DbContext = dbContext;
            _UserInfoRepo = userInfoRepo;
        }
        public async Task<ListChatModelView> CreateChat(Chat chat)
        {
            try
            {

                //var checkChat = await _DbContext.Chats.Where(s => (s.UserSend == chat.UserSend && s.UserReceive == chat.UserReceive) || (s.UserSend == chat.UserReceive && s.UserReceive == chat.UserSend)).ToListAsync();

                //var checkNull = await _DbContext.UserChats.Where(s => (s.IdUser1 == chat.UserSend && s.IdUser2 == chat.UserReceive && s.isWait == false) || (s.IdUser1 == chat.UserReceive && s.IdUser2 == chat.UserSend && s.isWait == false)).ToListAsync();
                //await SendChat(chat);

                //if (checkNull.Count == 2 && checkChat.Count >= 1)
                //{
                //    await SendChat(chat);
                //}
                //else
                //{
                //    var checkFollow = await _DbContext.Follows.Where(s => (s.IdFollower == chat.UserSend && s.IdFollowing == chat.UserReceive) || (s.IdFollower == chat.UserReceive && s.IdFollowing == chat.UserSend)).ToListAsync();
                //    var checkIsWaitList = await _DbContext.UserChats.Where(s => s.IdUser1 == chat.UserReceive && s.IdUser2 == chat.UserSend && s.isWait == true).FirstOrDefaultAsync();
                //    if (checkIsWaitList != null)
                //    {
                //        checkIsWaitList.isWait = false;
                //        _DbContext.UserChats.Update(checkIsWaitList);
                //        UserChat user = new UserChat
                //        {
                //            IdUser1 = checkIsWaitList.IdUser2,
                //            IdUser2 = checkIsWaitList.IdUser1,
                //            isWait = false,
                //        };
                //        _DbContext.UserChats.Add(user);
                //        await _DbContext.SaveChangesAsync();
                //        await SendChat(chat);
                //    }
                //    else
                //    {
                //        if (checkFollow.Count < 2 && checkNull.Count < 2 && checkChat.Count < 1)
                //        {

                //            UserChat user = new UserChat
                //            {
                //                IdUser1 = chat.UserSend.GetValueOrDefault(),
                //                IdUser2 = chat.UserReceive.GetValueOrDefault(),
                //                isWait = true,
                //            };
                //            _DbContext.UserChats.Add(user);
                //            await _DbContext.SaveChangesAsync();
                //        }
                //        else
                //        {
                //            if (checkFollow.Count == 2 && checkChat.Count < 1)
                //            {
                //                UserChat user1 = new UserChat
                //                {
                //                    IdUser1 = chat.UserSend.GetValueOrDefault(),
                //                    IdUser2 = chat.UserReceive.GetValueOrDefault(),
                //                    isWait = false,
                //                };
                //                UserChat user2 = new UserChat
                //                {
                //                    IdUser1 = chat.UserReceive.GetValueOrDefault(),
                //                    IdUser2 = chat.UserSend.GetValueOrDefault(),
                //                    isWait = false,
                //                };
                //                _DbContext.UserChats.AddRange(user1, user2);
                //                await _DbContext.SaveChangesAsync();
                //                await SendChat(chat);
                //            }
                //            //else
                //            //{
                //            //    var check = await _DbContext.UserChats.Where(s => s.IdUser1 == chat.UserSend && s.IdUser2 == chat.UserReceive && s.isWait == true).FirstOrDefaultAsync();
                //            //    if (check == null)
                //            //    {
                //            //        await SendChat(chat);
                //            //    }
                //            //}

                //        }
                //    }
                //}
                bool areFollowing = _DbContext.Follows.Any(f => f.IdFollower == chat.UserReceive && f.IdFollowing == chat.UserSend);
                bool hasPreviousMessages = _DbContext.Chats.Any(m => m.UserSend == chat.UserReceive && m.UserReceive == chat.UserSend);
                
                if (hasPreviousMessages == false)
                {
                    if (areFollowing == false)
                    {
                        chat.Status = 2;
                        _DbContext.Chats.Add(chat);
                        await _DbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    chat.Status = 1;
                    _DbContext.Chats.Add(chat);
                    await _DbContext.SaveChangesAsync();
                    // URL của SignalR hub
                    var hubUrl = "wss://whorubackend20240510001558.azurewebsites.net/appHub";
                    //var hubUrl = "wss://localhost:7175/appHub";
                    // Tạo một kết nối tới hub
                    var connection = new HubConnectionBuilder().WithUrl(hubUrl).Build();
                    // Kết nối tới hub
                    await connection.StartAsync();
                    await connection.InvokeAsync("SendMessToUser", chat.Id, chat.Message, chat.UserSend, chat.UserReceive);
                    await connection.StopAsync();
                }
                string date = chat.Date.Value.ToString("H:mm dd/MM/yyyy");
                ListChatModelView objChat = new ListChatModelView(chat.Id, date, chat.Message, chat.UserSend, chat.UserReceive, chat.Type);
                return objChat;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<ResponseView> DeleteChat(int id)
        {
            try
            {
                Chat? chat = await _DbContext.Chats.Where(s => s.Id == id).FirstOrDefaultAsync();
                if (chat == null)
                {
                    return new(MessageConstant.NOT_FOUND);
                }
                if(chat.Type != MessageConstant.MESSAGE && chat.Type != MessageConstant.Room)
                {
                    UploadImageToStorage storage = new UploadImageToStorage();
                    await storage.DeleteChatImageUrl(chat.Type);
                }
                _DbContext.Chats.Remove(chat);
                await _DbContext.SaveChangesAsync();

                // URL của SignalR hub
                var hubUrl = "wss://whorubackend20240510001558.azurewebsites.net/appHub";
                //var hubUrl = "wss://localhost:7175/chatHub";
                // Tạo một kết nối tới hub
                var connection = new HubConnectionBuilder().WithUrl(hubUrl).Build();
                // Kết nối tới hub
                await connection.StartAsync();
                await connection.InvokeAsync("DeleteMessage",chat.UserReceive, chat.Id);
                await connection.StopAsync();

                return new(MessageConstant.DELETE_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<List<ListChatModelView>?> GetAllChat(int idSender, int idReceiver)
        {
            try 
            {
                var list = await _DbContext.Chats.Where(s => 
                (s.UserSend == idSender && s.UserReceive == idReceiver) || 
                (s.UserReceive == idSender && s.UserSend == idReceiver)).ToListAsync();
                if(list.Count > 0)
                {
                    List<ListChatModelView> result = new List<ListChatModelView>();
                    var chatModel = list.OrderByDescending(e => e.Date).ToList();
                    foreach (var chat in chatModel)
                    {
                        string date = chat.Date.Value.ToString("H:mm dd/MM/yyyy");
                        ListChatModelView objChat = new ListChatModelView(chat.Id, date, chat.Message, chat.UserSend, chat.UserReceive, chat.Type);
                        result.Add(objChat);
                    }
                    //result.Reverse();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<UserChatModelView>?> GetAllUser(int idUser)
        {
            try
            {
                //var users = new List<UserChatModelView>();
                //var listUser = await _DbContext.UserChats.Where(s => s.IdUser1 == idUser && s.isWait == false).ToListAsync();
                //var currentChatList = await _DbContext.Chats.Where(s => s.UserSend == idUser || s.UserReceive == idUser).ToListAsync();
                //currentChatList.Reverse();
                //if (listUser.Count != 0)
                //{
                //        foreach (var user in listUser)
                //        {
                //            var chatModel = currentChatList.Where(s=> (s.UserSend == user.IdUser1 && s.UserReceive == user.IdUser2) || (s.UserSend == user.IdUser2 && s.UserReceive == user.IdUser1)).FirstOrDefault();
                //            var infoUser = await _UserInfoRepo.GetUserInfoById(user.IdUser2);
                //            UserChatModelView modelView = new UserChatModelView(infoUser.Id, infoUser.FullName,infoUser.Avatar, chatModel.Message, chatModel.Type,chatModel.IsSeen.GetValueOrDefault());
                //            users.Add(modelView);
                //        }
                //}
                //return users;
                var list = await _DbContext.Chats.Where(s => (s.UserSend == idUser || s.UserReceive == idUser) ).ToListAsync();
                list.Reverse();
                var users = new List<UserChatModelView>();
                if (list.Count() != 0)
                {
                    List<int> idUsers = new List<int>();
                    foreach (Chat chat in list)
                    {
                        if (chat.UserSend == idUser)
                        {
                            idUsers.Add(chat.UserReceive.GetValueOrDefault());
                        }
                        if (chat.UserReceive == idUser)
                        {
                            idUsers.Add(chat.UserSend.GetValueOrDefault());
                        }
                    }
                    if (idUsers.Count() != 0)
                    {
                        var listUnique = idUsers.Distinct();
                        foreach (var user in listUnique)
                        {
                            var listUser = list.Where(s => (s.UserSend == user || s.UserReceive == user)).ToList();
                            bool checkWaitMess = listUser.Any(s => (s.UserSend == user || s.UserReceive == user) && s.Status == 1);
                            if (checkWaitMess)
                            {
                                var chatModel = listUser.OrderByDescending(e => e.Date).FirstOrDefault();
                                var infoUser = await _UserInfoRepo.GetUserInfoById(user);
                                UserChatModelView modelView = new UserChatModelView(infoUser.Id, infoUser.FullName, infoUser.Avatar, chatModel.Message, chatModel.Type, chatModel.IsSeen.GetValueOrDefault());
                                users.Add(modelView);
                            }
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<UserChatModelView>?> GetAllWaitingUser(int idUser)
        {
            try
            {
                //var users = new List<UserChatModelView>();
                //var listUser = await _DbContext.UserChats.Where(s => s.IdUser2 == idUser && s.isWait == true).ToListAsync();
                //var currentChatList = await _DbContext.Chats.Where(s => s.UserReceive == idUser).ToListAsync();
                //currentChatList.Reverse();
                //if (listUser.Count != 0)
                //{
                //    foreach (var user in listUser)
                //    {
                //        var chatModel = currentChatList.Where(s => (s.UserSend == user.IdUser1 )).FirstOrDefault();
                //        var infoUser = await _UserInfoRepo.GetUserInfoById(user.IdUser1);
                //        UserChatModelView modelView = new UserChatModelView(infoUser.Id, infoUser.FullName, infoUser.Avatar, chatModel.Message, chatModel.Type, chatModel.IsSeen.GetValueOrDefault());
                //        users.Add(modelView);
                //    }
                //}
                //return users;
                var list = await _DbContext.Chats.Where(s => (s.UserSend == idUser || s.UserReceive == idUser) ).ToListAsync();
                list.Reverse();
                var users = new List<UserChatModelView>();
                if (list.Count() != 0)
                {
                    List<int> idUsers = new List<int>();
                    foreach (Chat chat in list)
                    {
                        if (chat.UserSend == idUser)
                        {
                            idUsers.Add(chat.UserReceive.GetValueOrDefault());
                        }
                        if (chat.UserReceive == idUser)
                        {
                            idUsers.Add(chat.UserSend.GetValueOrDefault());
                        }
                    }
                    if (idUsers.Count() != 0)
                    {
                        var listUnique = idUsers.Distinct();
                        foreach (var user in listUnique)
                        {
                            var listUser = list.Where(s => (s.UserSend == user || s.UserReceive == user)).ToList();
                            bool checkWaitMess = listUser.All(s => s.Status == 2);
                            if (checkWaitMess)
                            {
                                var chatModel = list.Where(s => s.UserSend == user || s.UserReceive == user).FirstOrDefault();
                                var infoUser = await _UserInfoRepo.GetUserInfoById(user);
                                UserChatModelView modelView = new UserChatModelView(infoUser.Id, infoUser.FullName, infoUser.Avatar, chatModel.Message, chatModel.Type, chatModel.IsSeen.GetValueOrDefault());
                                users.Add(modelView);
                            }
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }
    }
}
