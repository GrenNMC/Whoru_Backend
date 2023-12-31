﻿namespace WhoruBackend.ModelViews.FeedModelViews
{
    public class ResponseAllFeedModelView
    {
        public int IdFeed { get; set; }
        public string Content { get; set; }
        public List<string> ListImages { get; set; }
        public int IdUser { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public bool isLike { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount {  get; set; }
        public int SharesCount { get; set; }

        public ResponseAllFeedModelView(int idFeed, string content, List<string> listImages, int idUser, string fullName, string avatar,bool isLike, int likesCount, int commentsCount, int sharesCount)
        {
            IdFeed = idFeed;
            Content = content;
            ListImages = listImages;
            IdUser = idUser;
            FullName = fullName;
            Avatar = avatar;
            this.isLike = isLike;
            LikesCount = likesCount;
            CommentsCount = commentsCount;
            SharesCount = sharesCount;
        }
    }
}
