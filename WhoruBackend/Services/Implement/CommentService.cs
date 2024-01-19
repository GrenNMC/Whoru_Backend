using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.CommentModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Services.Implement
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IUserService _userService;
        private readonly IFeedRepository _feedRepo;
        private readonly IUserInfoRepository _userInfoRepo;
        public CommentService(ICommentRepository commentRepo, IUserService userService, IFeedRepository feedRepo, IUserInfoRepository userInfoRepo)
        {
            _commentRepo = commentRepo;
            _userService = userService;
            _feedRepo = feedRepo;
            _userInfoRepo = userInfoRepo;
        }

        public async Task<ResponseView> Create(CommentModelView comment)
        {
            if (comment == null || comment.Content == string.Empty) 
            {
                return new(MessageConstant.NO_DATA_REQUEST);        
            }

            Feed? feed = await _feedRepo.FindFeedById(comment.IdFeed);
            if (feed == null) 
            {
                return new(MessageConstant.NOT_FOUND);
            }
            var userId = await _userService.GetIdByToken();
            var infoId = await _userInfoRepo.GetInfoByUserId(userId);
            Comment newComment = new Comment
            {
                FeedId = comment.IdFeed,
                Date = DateTime.UtcNow,
                Message = comment.Content,
                UserId = infoId,
            };
            var response = await _commentRepo.Create(newComment);
            return response;
        }

        public async Task<ResponseView> Delete(int id)
        {
            if (id < 1)
            {
                return new(MessageConstant.NO_DATA_REQUEST);
            }
            var comment = await _commentRepo.FindCommentById(id);
            if (comment == null)
                return new(MessageConstant.NOT_FOUND);

            var response = await _commentRepo.Delete(comment);
            return response;
        }

        public async Task<Comment?> FindCommentById(int id)
        {
            return await _commentRepo.FindCommentById(id);
        }

        public async Task<List<ResponseAllCommentFromFeed>?> GetAllCommentByFeedId(int id)
        {
            var feed = await _feedRepo.FindFeedById(id);
            if(feed == null)
                return null;
            return await _commentRepo.GetAllCommentFromFeed(id);
        }

        public async Task<ResponseView> Update(UpdateCommentModelView comment)
        {
            if (comment == null || comment.Content == string.Empty)
            {
                return new(MessageConstant.NO_DATA_REQUEST);
            }
            var updatedComment = await _commentRepo.FindCommentById(comment.IdComment);
            if(updatedComment == null)
                return new(MessageConstant.NOT_FOUND);

            updatedComment.Date = DateTime.UtcNow;
            updatedComment.Message = comment.Content;
            var response = await _commentRepo.Update(updatedComment);
            return response;
        }
    }
}
