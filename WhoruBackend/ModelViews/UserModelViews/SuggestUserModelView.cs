namespace WhoruBackend.ModelViews.UserModelViews
{
    public class SuggestUserModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }

        public SuggestUserModelView(int id, string name, string avatar)
        {
            Id = id;
            Name = name;
            Avatar = avatar;
        }
    }
}
