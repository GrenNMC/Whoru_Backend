namespace WhoruBackend.ModelViews.FollowModelViews
{
    public class FollowerModelView
    {
        public int? id;
        public string? FullName;
        public string? Avatar;

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
