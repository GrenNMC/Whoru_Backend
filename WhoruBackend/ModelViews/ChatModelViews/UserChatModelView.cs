namespace WhoruBackend.ModelViews.ChatModelViews
{
    public class UserChatModelView
    {
        public int IdUser { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string CurrentMessage {  get; set; }
        public string Type {  get; set; }
        public bool IsSeen {  get; set; }

        public UserChatModelView(int idUser, string fullName, string avatar, string currentMessage, string type, bool isSeen)
        {
            IdUser = idUser;
            FullName = fullName;
            Avatar = avatar;
            CurrentMessage = currentMessage;
            Type = type;
            IsSeen = isSeen;
        }
    }
}
