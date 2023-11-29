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


        public async void DeleteImage(FeedImage image)
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
                ).Child("Images")
                .Child(image.ImageName)
                .DeleteAsync();

            await task;
        }
        public async Task<string> ImageURL(IFormFile file)
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
                ).Child("Images")
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
