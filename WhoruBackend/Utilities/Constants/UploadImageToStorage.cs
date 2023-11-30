using Firebase.Auth;
using Firebase.Storage;
using Serilog;
using System.IO;
using WhoruBackend.Models;

namespace WhoruBackend.Utilities.Constants
{
    public class UploadImageToStorage
    {

        private readonly string apiKey = "AIzaSyBEJTPrsVR8wgoiD4FLtx0XZNhxdqz6kjs";
        private readonly string bucketUrl = "whoru-2f115.appspot.com";
        private readonly string authEmail = "luci1luv187@gmail.com";
        private readonly string authPassword = "nhut12345678";

        public async Task<string> FeedImageUrl(IFormFile file)
        {
            string repo = "Images";
            return await ImageURL(repo, file);
        }

        public async Task<string> AvatarImageUrl(IFormFile file)
        {
            string repo = "Avatars";
            return await ImageURL(repo, file);
        }

        public async Task<string> BackgroundImageUrl(IFormFile file)
        {
            string repo = "Backgrounds";
            return await ImageURL(repo, file);
        }

        public async Task DeleteFeedImageUrl(FeedImage image)
        {
            string repo = "Images";
            await DeleteImage(repo, image.ImageName);
        }

        public async Task DeleteAvatarImageUrl(string name)
        {
            string repo = "Avatars";
            await DeleteImage(repo, name);
        }

        public async Task DeleteBackgroundImageUrl(string name)
        {
            string repo = "Backgrounds";
            await DeleteImage(repo, name);
        }

        private async Task DeleteImage(string repo ,string name)
        {
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
                ).Child(repo)
                .Child(name)
                .DeleteAsync();

            await task;
        }
        private async Task<string> ImageURL(string repo,IFormFile file)
        {

            Stream fileStream;
            fileStream = file.OpenReadStream();
            var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
            var firebaseAuth = await auth.SignInWithEmailAndPasswordAsync(authEmail,authPassword);

            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                bucketUrl,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(firebaseAuth.FirebaseToken),
                    ThrowOnCancel = true
                }
                ).Child(repo)
                .Child(file.FileName)
                .PutAsync(fileStream, cancellation.Token);

            try
            {
                string url = await task;
                return url;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return string.Empty;
            }
        }


    }
}
