using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WhoruBackend.ModelViews.FeedModelViews
{
    public class ResponseAllFeedModelView
    {
        public int IdFeed { get; set; }
        public string Content { get; set; }
        public string? Date { get; set; }
        public List<string> ListImages { get; set; }
        public int IdUser { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public bool isFollow {  get; set; }
        public bool isLike { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount {  get; set; }
        public bool isShare { get; set; }
        public int SharesCount { get; set; }
        public bool isSave { get; set; }
        public int Status { get; set; }

        public ResponseAllFeedModelView(int idFeed, string content,string? date, List<string> listImages, int idUser, string fullName, string avatar,bool isFollow,bool isLike, int likesCount, int commentsCount,bool isShare, int sharesCount, bool isSave, int status)
        {
            IdFeed = idFeed;
            Content = content;
            Date = date;
            ListImages = listImages;
            IdUser = idUser;
            FullName = fullName;
            Avatar = avatar;
            this.isFollow = isFollow;
            this.isLike = isLike;
            LikesCount = likesCount;
            CommentsCount = commentsCount;
            this.isShare = isShare;
            SharesCount = sharesCount;
            this.isSave = isSave;
            Status = status;
        }

        public ResponseAllFeedModelView()
        {
        }
    }
}
