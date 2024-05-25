namespace WhoruBackend.ModelViews.FeedModelViews
{
    public class FindFeedModelView
    {
        public int id { get; set; }
        public int page { get; set; }

        public FindFeedModelView(int id, int page)
        {
            this.id = id;
            this.page = page;
        }
    }
}
