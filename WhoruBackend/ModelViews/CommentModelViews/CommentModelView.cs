namespace WhoruBackend.ModelViews.CommentModelViews
{
    public class CommentModelView
    {
        public int IdFeed {  get; set; }
        public string Content { get; set; }

        public CommentModelView(int idFeed, string content)
        {
            IdFeed = idFeed;
            Content = content;
        }
    }
}
