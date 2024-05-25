namespace WhoruBackend.ModelViews.StoryModelViews
{
    public class NewStoryModelView
    {
        public IFormFile? File { get; set; }

        public NewStoryModelView(IFormFile files)
        {
            File = files;
        }
        public NewStoryModelView()
        {
        }
    }
}
