namespace WhoruBackend.ModelViews.FeedModelViews
{
    public class GetAllReactModelView
    {
        public int IdPost { get; set; }
        public int Page { get; set; }

        public GetAllReactModelView(int idPost, int page)
        {
            IdPost = idPost;
            Page = page;
        }
    }
}
