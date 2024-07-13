namespace WhoruBackend.ModelViews.StoryModelViews
{
    public class StoryModelView
    {
        public int idUser {  get; set; }
        public int idStory { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string imageUrl { get; set; }
        public string date { get; set; }

        public StoryModelView(int id,int idStory, string name, string avatar, string imageUrl, string date)
        {
            this.idUser = id;
            this.idStory = idStory;
            this.name = name;
            this.avatar = avatar;
            this.imageUrl = imageUrl;
            this.date = date;
        }
    }
}
