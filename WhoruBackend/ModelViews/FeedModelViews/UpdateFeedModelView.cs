namespace WhoruBackend.ModelViews.FeedModelViews
{
    public class UpdateFeedModelView
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public List<IFormFile>? Files { get; set; }
        public int State { get; set; }

        public UpdateFeedModelView(int id,string status, List<IFormFile> files, int state)
        {
            Id = id;
            Status = status;
            Files = files;
            State = state;
        }

        public UpdateFeedModelView()
        {
        }
    }
}
