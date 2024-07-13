namespace WhoruBackend.ModelViews.LocationModelView
{
    public class UserLocationModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public double Long { get; set; }

        public double Lang { get; set; }
        public string? Note { get; set; }

        public UserLocationModelView(int id,string name, string avatar, double @long, double lang, string? note)
        {
            Id = id;
            Name = name;
            Avatar = avatar;
            Long = @long;
            Lang = lang;
            Note = note;
        }
    }
}
