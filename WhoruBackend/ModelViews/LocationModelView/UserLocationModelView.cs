namespace WhoruBackend.ModelViews.LocationModelView
{
    public class UserLocationModelView
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public double Long { get; set; }

        public double Lang { get; set; }

        public UserLocationModelView(int id, string avatar, double @long, double lang)
        {
            Id = id;
            Avatar = avatar;
            Long = @long;
            Lang = lang;
        }
    }
}
