namespace WhoruBackend.ModelViews.UserModelViews
{
    public class UserInfoImgModelView
    {
        public string avatar { get; set; }
        public string name { get; set; }

        public UserInfoImgModelView(string avatar, string name)
        {
            this.avatar = avatar;
            this.name = name;
        }
    }
}
