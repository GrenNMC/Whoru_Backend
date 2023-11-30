namespace WhoruBackend.ModelViews.InfoModelViews
{
    public class RequestUserInfoView
    {
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public string? Work { get; set; }
        public string? Study { get; set; }

        public RequestUserInfoView(string? fullName, string? description, string? work, string? study)
        {
            FullName = fullName;
            Description = description;
            Work = work;
            Study = study;
        }

        public RequestUserInfoView()
        {
        }
    }
}
