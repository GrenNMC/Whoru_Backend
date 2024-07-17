using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections;
using System.Collections.Generic;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.ModelViews.UserModelViews;
using WhoruBackend.Utilities.Constants;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace WhoruBackend.Repositorys.Implement
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserInfoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(UserInfo user)
        {
            try
            {
                if(user == null) 
                {
                    return -2;
                }
                await _dbContext.UserInfos.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                //return new ResponseView(MessageConstant.CREATE_SUCCESS);
                return user.Id;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                //return new ResponseView(MessageConstant.SYSTEM_ERROR);
                return -3;
            }
        }

        public async Task CreateEmbedding(int idUser, double embeddingNumber)
        {
            try
            {
                FaceRecogNumber number = new FaceRecogNumber
                {
                    UserId = idUser,
                    Embedding = embeddingNumber
                };
                _dbContext.FaceRecogNumbers.Add(number);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        public async Task<List<NumberRecogModelView>?> GetEmbeddedNumber()
        {
            try
            {
                var list = await _dbContext.FaceRecogNumbers.ToListAsync();
                var increaseList = list.OrderBy(s => s.Id);
                List<NumberRecogModelView> result = new List<NumberRecogModelView>();
                // Nhóm theo UserId và tạo NumberRecogModelView
                result = increaseList.GroupBy(x => x.UserId)
                                      .Select(g => new NumberRecogModelView
                                      {
                                          UserId = g.Key,
                                          Embedding = g.Select(x => x.Embedding).ToList()
                                      })
                                      .ToList();
                return result;
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<int> GetInfoByUserId(int userId)
        {
            try
            {
                var info = await _dbContext.UserInfos.FirstOrDefaultAsync(s => s.UserId == userId);
                if(info == null)
                {
                    return -1;
                }
                return info.Id;
            }
            catch(Exception ex) 
            {
                Log.Error(ex.Message);
                return -1;
            }
        }

        public async Task<ResponseView> PostSuggestionFriendList(int idAuth,int type, List<int> idList)
        {
            try
            {
                if(type == 2)
                {
                    var listLocation =       from suggestUser in _dbContext.SuggestionUsers
                                             where suggestUser.UserId == idAuth && suggestUser.Type == 2
                                             select suggestUser;
                    foreach(var item in listLocation)
                    {
                        _dbContext.SuggestionUsers.Remove(item);
                    }
                    await _dbContext.SaveChangesAsync();
                }
                //List<SuggestUserModelView> listResult = new List<SuggestUserModelView> ();
                foreach (var item in idList)
                {
                    var checkNull = await _dbContext.SuggestionUsers.FirstOrDefaultAsync(s => s.SuggestUser == item && s.UserId == idAuth);
                    if (checkNull == null)
                    {
                        var checkFollow = await _dbContext.Follows.FirstOrDefaultAsync(s => s.IdFollower == idAuth && s.IdFollowing == item);
                        if (checkFollow == null)
                        {
                            //var info = await _dbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == item);
                            //listResult.Add(new SuggestUserModelView(item, info.FullName,info.Avatar));
                            SuggestionUser suggestion = new SuggestionUser
                            {
                                UserId = idAuth,
                                SuggestUser = item,
                                Type = type,
                            };
                            _dbContext.SuggestionUsers.Add(suggestion);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                }
                return new ResponseView(MessageConstant.CREATE_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR); ;
            }
        }

        public async Task<ResponseInfoView?> GetUserInfo(int userId, int idAuthor)
        {
            try
            {
                var info = await _dbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == userId);
                if (info == null)
                {
                    return null;
                }
                var followerCount = await _dbContext.Follows.Where(s => s.IdFollowing == userId).CountAsync();
                var followingCount = await _dbContext.Follows.Where(s => s.IdFollower == userId).CountAsync();
                if (userId == idAuthor)
                {
                    return new ResponseInfoView(info.Id, info.FullName, info.Avatar, info.Backround, info.Description, info.WorkingAt, info.StudyAt, followerCount, followingCount);
                }
                var follow = await _dbContext.Follows.Where(s => s.IdFollower == idAuthor && s.IdFollowing == userId).FirstOrDefaultAsync();
                if (follow == null)
                {
                    return new ResponseInfoView(info.Id, info.FullName, info.Avatar, info.Backround, info.Description, info.WorkingAt, info.StudyAt, followerCount,followingCount,false);
                }
                return new ResponseInfoView(info.Id, info.FullName, info.Avatar, info.Backround, info.Description, info.WorkingAt, info.StudyAt, followerCount, followingCount, true); ;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<UserInfo?> GetUserInfoById(int userId)
        {
            try
            {
                var info = await _dbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == userId);
                if (info == null)
                {
                    return null;
                }
                return info;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<UserInfo?> GetUserInfoByName(string userName)
        {
            try
            {
                var User = await _dbContext.Users.FirstOrDefaultAsync(s => s.UserName == userName);
                if (User == null)
                {
                    return null;
                }
                var info = await _dbContext.UserInfos.FirstOrDefaultAsync(s => s.UserId == User.Id);
                if (info == null)
                {
                    return null;
                }
                return info;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<ResponseListUser>?> SearchUser(string keyWord)
        {
            try
            {
                List<ResponseListUser> list = new List<ResponseListUser>();
                if (keyWord == string.Empty)
                    return list;
                var listUser = await _dbContext.UserInfos.ToListAsync();
                if(listUser.Count() != 0) {
                    foreach (var item in listUser)
                    {
                        if (item.FullName.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0)
                            list.Add(new ResponseListUser(item.Id, item.FullName, item.Avatar));
                    }
                }
                return list;
            }
            catch(Exception ex) {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<ResponseView> Update(UserInfo user)
        {
            try
            {
                if (user == null)
                    return new(MessageConstant.NO_DATA_REQUEST);
                _dbContext.UserInfos.Update(user);
                await _dbContext.SaveChangesAsync();
                return new(MessageConstant.UPDATE_SUCCESS);
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<List<SuggestUserModelView>?> GetSuggestionFriendList(int idAuth)
        {
            try
            {
                var list = await _dbContext.SuggestionUsers.Where(s => s.UserId == idAuth).ToListAsync();
                List<SuggestUserModelView> listResult = new List<SuggestUserModelView> ();
                foreach (var item in list)
                {
                        var info = await _dbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == item.SuggestUser);
                        listResult.Add(new SuggestUserModelView(item.SuggestUser, info.FullName, info.Avatar));
                }
                return listResult;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null; ;
            }
        }
    }
}
