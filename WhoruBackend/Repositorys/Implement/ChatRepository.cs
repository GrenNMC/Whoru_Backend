using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
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
    }
}
