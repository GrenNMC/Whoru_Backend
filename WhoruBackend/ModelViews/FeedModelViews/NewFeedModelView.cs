namespace WhoruBackend.ModelViews.FeedModelViews
{
    public class NewFeedModelView
    {
        public string? Status { get; set; }
        public List<IFormFile>? Files { get; set; }
        public int State { get; set; }

        public NewFeedModelView(string status, List<IFormFile> files, int state)
        {
            Status = status;
            Files = files;
            State = state;
        }

        public NewFeedModelView(string status, int state)
        {
            Status = status;
            State = state;
        }
        public NewFeedModelView()
        {
        }
    }
}
