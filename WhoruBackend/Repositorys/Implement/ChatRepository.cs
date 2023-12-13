using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
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

        public async Task CreateChat(Chat chat)
        {
            try
            {
                _DbContext.Chats.Add(chat);
                await _DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
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
                if(chat.Type != MessageConstant.MESSAGE)
                {
                    UploadImageToStorage storage = new UploadImageToStorage();
                    await storage.DeleteChatImageUrl(chat.Type);
                }
                _DbContext.Chats.Remove(chat);
                await _DbContext.SaveChangesAsync();
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
                if(list.Count() != 0)
                {
                    List<ListChatModelView> result = new List<ListChatModelView>();
                    foreach (var chat in list)
                    {
                        ListChatModelView objChat = new ListChatModelView(chat.Id, chat.Date, chat.Message, chat.UserSend, chat.UserReceive, chat.Type);
                        result.Add(objChat);
                    }
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
                var list = await _DbContext.Chats.Where(s=> s.UserSend == idUser || s.UserReceive == idUser).ToListAsync();
                list.Reverse();
                if(list.Count() != 0)
                {
                    List<int> idUsers = new List<int>();
                    foreach (Chat chat in list)
                    {
                        if(chat.UserSend == idUser)
                        {
                            idUsers.Add(chat.UserReceive.GetValueOrDefault());
                        }
                        if (chat.UserReceive == idUser)
                        {
                            idUsers.Add(chat.UserSend.GetValueOrDefault());
                        }
                    }
                    if(idUsers.Count() != 0)
                    {
                        var listUnique = idUsers.Distinct();
                        var users = new List<UserChatModelView>();
                        foreach (var user in listUnique)
                        {
                            var chatModel = list.Where(s => s.UserSend == user || s.UserReceive == user).FirstOrDefault();
                            var infoUser = await _UserInfoRepo.GetUserInfoById(user);
                            UserChatModelView modelView = new UserChatModelView(infoUser.Id, infoUser.FullName,infoUser.Avatar, chatModel.Message, chatModel.Type,chatModel.IsSeen.GetValueOrDefault());
                            users.Add(modelView);
                        }
                        return users;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }
    }
}
