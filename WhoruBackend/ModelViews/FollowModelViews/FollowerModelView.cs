namespace WhoruBackend.ModelViews.FollowModelViews
{
    public class FollowerModelView
    {
        public int? id { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }

        public FollowerModelView(int id, string fullName, string avatar)
        {
            this.id = id;
            FullName = fullName;
            Avatar = avatar;
        }

        public FollowerModelView()
        {
        }
    }
}
