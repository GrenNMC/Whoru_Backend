namespace WhoruBackend.ModelViews.ChatModelViews
{
    public class ListChatModelView
    {
        public int? Id { get; set; }
        public string? Date { get; set; }
        public string? Message { get; set; }
        public string? Type { get; set; }
        public int? UserSend { get; set; }
        public int? UserReceive { get; set; }

        public ListChatModelView(int? id, string? date, string? message, int? userSend, int? userReceive, string? type)
        {
            Id = id;
            Date = date;
            Message = message;
            UserSend = userSend;
            UserReceive = userReceive;
            Type = type;
        }
    }
}
