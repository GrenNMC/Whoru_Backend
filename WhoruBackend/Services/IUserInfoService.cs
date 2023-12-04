﻿using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;

namespace WhoruBackend.Services
{
    public interface IUserInfoService
    {
        public Task<ResponseInfoView?> GetUserInfoByName(string userName);
        public Task<ResponseInfoView?> GetUserInfoById(int id);
        public Task<ResponseView> Create(RequestUserInfoView request);
        public Task<ResponseView> Update(RequestUserInfoView request);
        public Task<ResponseView> UpdateAvatar(IFormFile file);
        public Task<ResponseView> UpdateBackground(IFormFile file);
    }
}
