namespace WhoruBackend.ModelViews.StoryModelViews
{
    public class StoryModelView
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string imageUrl { get; set; }
        public string date { get; set; }

        public StoryModelView(int id, string name, string avatar, string imageUrl, string date)
        {
            this.id = id;
            this.name = name;
            this.avatar = avatar;
            this.imageUrl = imageUrl;
            this.date = date;
        }
    }
}
