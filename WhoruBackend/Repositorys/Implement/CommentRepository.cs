using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.CommentModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<ResponseView> Create(Comment comment)
        {
            try
            {
                _DbContext.Comments.Add(comment);
                await _DbContext.SaveChangesAsync();
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
