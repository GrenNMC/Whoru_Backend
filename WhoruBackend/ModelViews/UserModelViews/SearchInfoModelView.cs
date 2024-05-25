namespace WhoruBackend.ModelViews.UserModelViews
{
    public class SearchInfoModelView
    {
        public string keyword { get; set; }
        public int page { get; set; }

        public SearchInfoModelView(string keyword, int page)
        {
            this.keyword = keyword;
            this.page = page;
        }
    }
}
