namespace WhoruBackend.ModelViews.FeedModelViews
{
    public class SearchFeedModelView
    {
        public string keyword { get; set; }
        public int page {  get; set; }

        public SearchFeedModelView(string keyword, int page)
        {
            this.keyword = keyword;
            this.page = page;
        }
    }
}
