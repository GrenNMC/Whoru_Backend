namespace WhoruBackend.ModelViews.FeedModelViews
{
    public class FeedStatusModelView
    {
        public int idPost { get; set; }
        public int status { get; set; }

        public FeedStatusModelView(int id, int status)
        {
            idPost = id;
            this.status = status;
        }

        public FeedStatusModelView()
        {
        }
    }
}
