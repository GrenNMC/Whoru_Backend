using Firebase.Auth;
using Firebase.Storage;
using Serilog;

namespace WhoruBackend.Utilities.Constants
{
    public class UploadImageToStorage
    {

        private readonly string apiKey = "AIzaSyBEJTPrsVR8wgoiD4FLtx0XZNhxdqz6kjs";
        private readonly string bucketUrl = "whoru-2f115.appspot.com";
        private readonly string authEmail = "nmc0401@gmail.com";
        private readonly string authPassword = "123456@A";
        private readonly IWebHostEnvironment _environment;

        public UploadImageToStorage(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> ImageURL(IFormFile file)
        {

            Stream fileStream;
            //string path = Path.Combine(_environment.WebRootPath, "Data/Images");
            //fileStream = new FileStream(Path.Combine(path, file.Name), FileMode.Open);
            //await file.CopyToAsync(fileStream);
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
