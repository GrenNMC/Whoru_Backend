using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class FeedRepository : IFeedRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly string apiKey = "AIzaSyBEJTPrsVR8wgoiD4FLtx0XZNhxdqz6kjs";
        private readonly string bucketUrl = "whoru-2f115.appspot.com";
        private readonly string authEmail = "nmc0401@gmail.com";
        private readonly string authPassword = "123456@A";

        public FeedRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseView> Create(Feed feed, List<IFormFile> files)
        {
            try
            {
                if (feed == null)
                {
                    return new ResponseView(MessageConstant.NO_DATA_REQUEST);
                }
                _dbContext.Feeds.Add(feed);
                await _dbContext.SaveChangesAsync();

                if(files != null)
                {
                    files.ForEach(async file => {
                        Stream fileStream;
                        fileStream = file.OpenReadStream();
                        var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                        var firebaseAuth = await auth.SignInWithEmailAndPasswordAsync(authEmail, authPassword);

                        var cancellation = new CancellationTokenSource();
                        var task = new FirebaseStorage(
                            bucketUrl,
                            new FirebaseStorageOptions
                            {
                                AuthTokenAsyncFactory = () => Task.FromResult(firebaseAuth.FirebaseToken),
                                ThrowOnCancel = true
                            }
                            ).Child("Images")
                             .Child(file.FileName)
                             .PutAsync(fileStream, cancellation.Token);

                        string url = await task;
                        FeedImage image = new FeedImage
                        {
                            FeedId = feed.Id,
                            Url = url,
                        };

                        _dbContext.FeedImages.Add(image);
                        await _dbContext.SaveChangesAsync();
                    });
                }
                return new ResponseView(MessageConstant.CREATE_POST_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<ResponseView> Delete(Feed feed)
        {
            try
            {
                if(feed == null)
                {
                    return new(MessageConstant.NO_DATA_REQUEST);
                }
                List<FeedImage> listImg = _dbContext.FeedImages.Where(s => s.FeedId == feed.Id).ToList();
                foreach (FeedImage img in listImg)
                {
                    _dbContext.FeedImages.Remove(img);
                }
                _dbContext.Feeds.Remove(feed);
                await _dbContext.SaveChangesAsync();
                return new(MessageConstant.DELETE_SUCCESS);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<Feed?> FindFeedById(int id)
        {
            try
            {
                Feed? feed = await _dbContext.Feeds.Where(s => s.Id == id).FirstOrDefaultAsync();
                if (feed == null)
                    return null;
                return feed;
            }
            catch(Exception e) 
            {
                Log.Error(e.Message);
                return null;
            }
        }
    }
}
