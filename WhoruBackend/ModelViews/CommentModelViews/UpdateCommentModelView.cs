namespace WhoruBackend.ModelViews.CommentModelViews
{
    public class UpdateCommentModelView
    {
        public int IdComment { get; set; }
        public string Content { get; set; }

        public UpdateCommentModelView(int idComment, string content)
        {
            IdComment = idComment;
            Content = content;
        }
    }
}
