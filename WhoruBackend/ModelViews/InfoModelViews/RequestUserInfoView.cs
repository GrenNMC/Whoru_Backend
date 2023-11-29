namespace WhoruBackend.ModelViews.InfoModelViews
{
    public class RequestUserInfoView
    {
        public string? FullName { get; set; }
        public IFormFile? Avatar { get; set; }
        public IFormFile? Backround { get; set; }

        public RequestUserInfoView(string? fullName, IFormFile? avatar, IFormFile? backround)
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
