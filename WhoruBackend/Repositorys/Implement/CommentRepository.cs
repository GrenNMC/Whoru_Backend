﻿using Firebase.Auth;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.CommentModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IFeedRepository _FeedRepository;
        private readonly INotificationService _notiService;
        public CommentRepository(ApplicationDbContext dbContext, IFeedRepository feedRepository, INotificationService service)
        {
            _DbContext = dbContext;
            _FeedRepository = feedRepository;
            _notiService = service;
        }

        public async Task<ResponseView> Create(Comment comment)
        {
            try
            {
                _DbContext.Comments.Add(comment);
                await _DbContext.SaveChangesAsync();
                var info = await _DbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == comment.UserId);
                var receiver = await _FeedRepository.FindFeedById(comment.FeedId);

                if(comment.UserId != receiver.UserInfoId)
                {

                    // URL của SignalR hub
                    var hubUrl = "wss://whorubackend20240510001558.azurewebsites.net/appHub";
                    //var hubUrl = "wss://localhost:7175/notificationHub";
                    // Tạo một kết nối tới hub
                    var connection = new HubConnectionBuilder().WithUrl(hubUrl).Build();
                    // Kết nối tới hub
                    await connection.StartAsync();
                    await connection.InvokeAsync("SendNotification", comment.UserId, receiver.UserInfoId, info.FullName, info.Avatar, "Comment");
                    await connection.StopAsync();
                    await _notiService.SendNotification(comment.UserId, receiver.UserInfoId.Value, "Comment");
                }
                return new ResponseView(MessageConstant.CREATE_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<ResponseView> Delete(Comment comment)
        {
            try
            {
                _DbContext.Comments.Remove(comment);
                await _DbContext.SaveChangesAsync();
                return new ResponseView(MessageConstant.DELETE_SUCCESS);
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<Comment?> FindCommentById(int id)
        {
            try
            {
                var comment = await _DbContext.Comments.Where(s => s.Id == id).FirstOrDefaultAsync();
                return comment;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<ResponseAllCommentFromFeed>?> GetAllCommentFromFeed(int feedId)
        {
            try
            {
                List<ResponseAllCommentFromFeed> listResult = new List<ResponseAllCommentFromFeed>();
                var list = await _DbContext.Comments.Where(s => s.FeedId == feedId).ToListAsync();

                if (list != null)
                {
                    foreach (var item in list)
                    {
                        var info = await _DbContext.UserInfos.Where(s => s.Id == item.UserId).FirstOrDefaultAsync();
                        ResponseAllCommentFromFeed response = new ResponseAllCommentFromFeed(item.Id,item.Message,info.Id,info.FullName,info.Avatar);
                        listResult.Add(response);
                    }

                    return listResult;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<ResponseView> Update(Comment comment)
        {
            try
            {
                _DbContext.Comments.Update(comment);
                await _DbContext.SaveChangesAsync();
                return new ResponseView(MessageConstant.UPDATE_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }
    }
}
