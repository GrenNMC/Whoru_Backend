namespace WhoruBackend.ModelViews.InfoModelViews
{
    public class ResponseInfoView
    {
        public int? id {  get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? Background { get; set; }
        public string? Description { get; set; }
        public string? Work { get; set; }
        public string? Study { get; set; }
        public int FollowerCount {  get; set; }
        public int FollowingCount { get; set; }
        public bool IsFollow {  get; set; }
        public ResponseInfoView(int? id, string? fullName, string? avatar, string? background, string? description, string? work, string? study, int followerCount, int followingCount, bool isFollow)
        {
            this.id = id;
            FullName = fullName;
            Avatar = avatar;
            Background = background;
            Description = description;
            Work = work;
            Study = study;
            FollowerCount = followerCount;
            FollowingCount = followingCount;
            IsFollow = isFollow;
        }

        public ResponseInfoView(int? id, string? fullName, string? avatar, string? background, string? description, string? work, string? study, int followerCount, int followingCount)
        {
            this.id = id;
            FullName = fullName;
            Avatar = avatar;
            Background = background;
            Description = description;
            Work = work;
            Study = study;
            FollowerCount = followerCount;
            FollowingCount = followingCount;
        }

        public ResponseInfoView()
        {
        }
    }
}
