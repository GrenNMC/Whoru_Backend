namespace WhoruBackend.ModelViews.UserModelViews
{
    public class FriendshipSuggestionsModelView
    {
        public List<int> listIdUser {  get; set; }

        public FriendshipSuggestionsModelView(List<int> listIdUser)
        {
            this.listIdUser = listIdUser;
        }

    }
}
