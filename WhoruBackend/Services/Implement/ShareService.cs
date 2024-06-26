﻿using Microsoft.AspNetCore.Mvc;
using PagedList;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Services.Implement
{
    public class ShareService : IShareService
    {
        private readonly IShareRepository _shareRepo;
        private readonly IUserService _userService;
        private readonly IFeedRepository _feedRepo;
        private readonly IUserInfoRepository _userInfoRepo;
        public ShareService(IShareRepository shareRepo, IUserService userService, IFeedRepository feedRepo,IUserInfoRepository infoRepository)
        {
            _shareRepo = shareRepo;
            _userService = userService;
            _feedRepo = feedRepo;
            _userInfoRepo = infoRepository;
        }

        public async Task<List<ResponseListUser>?> GetAllUser(int idFeed, int page)
        {
            var list = await _shareRepo.GetAllUser(idFeed);
            var result = list.ToPagedList(page, 10).ToList();
            return result;
        }

        public async Task<ResponseView> SharePost(int idPost)
        {
            var idUser = await _userService.GetIdByToken();
            var feed = await _feedRepo.FindFeedById(idPost);
            if(feed != null)
            {
                var idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
                var response = await _shareRepo.ShareFeed(idInfo, idPost);
                return new(response.Message);
            }
            return new(MessageConstant.NOT_FOUND);
        }

        public async Task<ResponseView> UnSharePost(int idPost)
        {
            var idUser = await _userService.GetIdByToken();
            var feed = await _feedRepo.FindFeedById(idPost);
            if (feed != null)
            {
                var idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
                var response = await _shareRepo.UnShareFeed(idInfo, idPost);
                return new(response.Message);
            }
            return new(MessageConstant.NOT_FOUND);
        }
    }
}
