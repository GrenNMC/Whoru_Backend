namespace WhoruBackend.ModelViews.NotificationModelView
{
    public class NotificationModelView
    {
        public int idUser { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Notification { get; set; }

        public NotificationModelView(int idUser, string avatar, string name, string time, string notification)
        {
            this.idUser = idUser;
            Avatar = avatar;
            Name = name;
            Time = time;
            Notification = notification;
        }
    }
}
