namespace WhoruBackend.ModelViews.InfoModelViews
{
    public class RequestUserInfoView
    {
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? Backround { get; set; }

        public RequestUserInfoView(string? fullName, string? avatar, string? backround)
        {
            FullName = fullName;
            Avatar = avatar;
            Backround = backround;
        }

        public RequestUserInfoView()
        {
        }
    }
}
