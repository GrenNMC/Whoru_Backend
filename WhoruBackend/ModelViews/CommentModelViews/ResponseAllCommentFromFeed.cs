namespace WhoruBackend.ModelViews.CommentModelViews
{
    public class ResponseAllCommentFromFeed
    {
        public int IdComment { get; set; }
        public string Content { get; set; }

        public int IdUser {  get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }

        public ResponseAllCommentFromFeed(int idComment, string content, int idUser, string fullName, string avatar)
        {
            IdComment = idComment;
            Content = content;
            IdUser = idUser;
            FullName = fullName;
            Avatar = avatar;
        }


    }
}
