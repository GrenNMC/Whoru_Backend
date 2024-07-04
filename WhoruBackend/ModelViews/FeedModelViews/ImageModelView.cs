namespace WhoruBackend.ModelViews.FeedModelViews
{
    public class ImageModelView
    {
        public IFormFile File { get; set; }

        public ImageModelView(IFormFile file)
        {
            File = file;
        }

        public ImageModelView()
        {
        }
    }
}
