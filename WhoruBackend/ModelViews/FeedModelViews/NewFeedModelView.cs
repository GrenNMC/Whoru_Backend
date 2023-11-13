namespace WhoruBackend.ModelViews.FeedModelViews
{
    public class NewFeedModelView
    {
        public string? Status { get; set; }
        public List<IFormFile>? Files { get; set; }

        public NewFeedModelView(string status, List<IFormFile> files)
        {
            Status = status;
            Files = files;
        }

        public NewFeedModelView(string status)
        {
            Status = status;
        }
        public NewFeedModelView()
        {
        }
    }
}
