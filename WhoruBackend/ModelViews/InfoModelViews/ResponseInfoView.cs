namespace WhoruBackend.ModelViews.InfoModelViews
{
    public class ResponseInfoView
    {
        public int? id {  get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? Background { get; set; }
        public string? Description { get; set; }
        public string? Work { get; set; }
        public string? Study { get; set; }

        public ResponseInfoView(int? id, string? fullName, string? avatar, string? background, string? description, string? work, string? study)
        {
            this.id = id;
            FullName = fullName;
            Avatar = avatar;
            Background = background;
            Description = description;
            Work = work;
            Study = study;
        }

        public ResponseInfoView()
        {
        }
    }
}
