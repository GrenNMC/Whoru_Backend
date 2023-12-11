namespace WhoruBackend.ModelViews.InfoModelViews
{
    public class ResponseListUser
    {
        public int IdUser { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }

        public ResponseListUser(int idUser, string fullName, string avatar)
        {
            IdUser = idUser;
            FullName = fullName;
            Avatar = avatar;
        }
    }
}
