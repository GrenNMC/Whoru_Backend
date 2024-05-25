using PagedList;
using Serilog;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.StoryModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Services.Implement
{
    public class StoryService : IStoryService
    {
        private readonly IUserService _userService;
        private readonly IStoryRepository _storyRepository;
        private readonly IUserInfoRepository _infoRepo;
        UploadImageToStorage storage = new UploadImageToStorage();
        public StoryService(IUserService userService, IStoryRepository storyRepository, IUserInfoRepository _userInfoRepo)
        {
            _userService = userService;
            _storyRepository = storyRepository;
            _infoRepo = _userInfoRepo;
        }

        public async Task<ResponseView> Create(IFormFile file)
        {
            int idUser = await _userService.GetIdByToken();
            int id = await _infoRepo.GetInfoByUserId(idUser);
            string url = await storage.StoryImageUrl(file);
            Story story = new Story
            {
                Name = file.FileName,
                Date = DateTime.UtcNow,
                UserId = id,
                ImageUrl = url,
            };
             var response = await _storyRepository.Create(story);
            if(response.Message == MessageConstant.CREATE_SUCCESS)
                return new ResponseView(MessageConstant.CREATE_SUCCESS);
            return new ResponseView(MessageConstant.SYSTEM_ERROR);
        }

        public async Task<ResponseView> Delete(int id)
        {
            return await _storyRepository.Delete(id);
        }

        public async Task<List<StoryModelView>?> GetAllByUserId(int page)
        {
            int idUser = await _userService.GetIdByToken();
            int id = await _infoRepo.GetInfoByUserId(idUser);

            var getStories = await _storyRepository.GetStoryByUserId(id);

            if(getStories != null)
            {
                var result = getStories.ToPagedList(page, 10).ToList();
                return result;
            }
            return null;
        }
    }
}
