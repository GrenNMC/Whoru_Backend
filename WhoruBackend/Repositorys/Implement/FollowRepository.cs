﻿using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FollowModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class FollowRepository : IFollowRepository
    {
        private readonly IUserInfoRepository _userInfoRepo;
        private readonly ApplicationDbContext _DbContext;
        private readonly INotificationService _notiService;
        public FollowRepository(IUserInfoRepository userRepo, ApplicationDbContext dbContext, INotificationService service)
        {
            _userInfoRepo = userRepo;
            _DbContext = dbContext;
            _notiService = service;
        }

        public async Task<ResponseView> FollowUser(int idFollower, int idUser)
        {
            try
            {
                var follow = await _DbContext.Follows.Where(s => s.IdFollower == idFollower && s.IdFollowing == idUser).FirstOrDefaultAsync();
                if (follow == null)
                {
                    Follow response = new Follow
                    {
                        IdFollower = idFollower,
                        IdFollowing = idUser,
                    };
                    _DbContext.Follows.Add(response);
                    await _DbContext.SaveChangesAsync();
                    var info = await _DbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == idFollower);
                    // URL của SignalR hub
                    var hubUrl = "wss://whorubackend20240510001558.azurewebsites.net/appHub";
                    //var hubUrl = "wss://localhost:7175/notificationHub";
                    // Tạo một kết nối tới hub
                    var connection = new HubConnectionBuilder().WithUrl(hubUrl).Build();
                    // Kết nối tới hub
                    await connection.StartAsync();
                    await connection.InvokeAsync("SendNotification", idFollower, idUser, info.FullName, info.Avatar, "Follow");
                    await connection.StopAsync();
                    await _notiService.SendNotification(idFollower, idUser, "Follow");
                    return new(MessageConstant.CREATE_SUCCESS);
                }
                return new(MessageConstant.EXISTED);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<List<FollowerModelView>?> GetAllFollower(int id)
        {
            try
            {
                List<Follow> listFollower = await _DbContext.Follows.Where(s => s.IdFollowing == id).ToListAsync();
                List<FollowerModelView> allFollower = new List<FollowerModelView>();
                if(listFollower == null)
                {
                    return null;
                }

                foreach (var item in listFollower)
                {
                    var user = await _userInfoRepo.GetUserInfoById(item.IdFollower);
                    if(user != null )
                    {
                        FollowerModelView follower = new FollowerModelView(user.Id, user.FullName, user.Avatar);
                        allFollower.Add(follower);
                    }
                }
                return allFollower;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<FollowerModelView>?> GetAllFollowing(int idUser)
        {
            try
            {
                List<Follow> listFollower = await _DbContext.Follows.Where(s => s.IdFollower == idUser).ToListAsync();
                List<FollowerModelView> allFollower = new List<FollowerModelView>();
                if (listFollower == null)
                {
                    return null;
                }

                foreach (var item in listFollower)
                {
                    var user = await _userInfoRepo.GetUserInfoById(item.IdFollowing);
                    if (user != null)
                    {
                        allFollower.Add(new FollowerModelView(user.Id, user.FullName, user.Avatar));
                    }
                }
                return allFollower;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<ResponseView> UnFollowUser(int idFollower, int idUser)
        {
            try
            {
                var follow = await _DbContext.Follows.Where(s => s.IdFollower == idFollower && s.IdFollowing == idUser).FirstOrDefaultAsync();
                if (follow != null)
                {
                    _DbContext.Follows.Remove(follow);
                    await _DbContext.SaveChangesAsync();
                    return new(MessageConstant.DELETE_SUCCESS);
                }
                return new(MessageConstant.NOT_FOUND);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }
    }
}
