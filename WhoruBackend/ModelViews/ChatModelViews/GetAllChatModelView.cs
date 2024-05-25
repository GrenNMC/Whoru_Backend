namespace WhoruBackend.ModelViews.ChatModelViews
{
    public class GetAllChatModelView
    {
        public int IdUser { get; set; }
        public int Page { get; set; }

        public GetAllChatModelView(int idUser, int page)
        {
            IdUser = idUser;
            Page = page;
        }
    }
}
