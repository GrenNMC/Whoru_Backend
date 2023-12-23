namespace WhoruBackend.ModelViews.LogModelViews
{
    public class LoginView
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginView(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public class ResponseLoginView
    {
        public int UserId { get; set; }
        public int InfoId {  get; set; }
        public string? UserName { get; set; }
        public string? Message { get; set; }
        public bool? IsDisabled { get; set; }
        public string? Token { get; set; }

        public ResponseLoginView(int UserId,int InfoId, string? Message, string? UserName, string? token, bool? isDisabled)
        {
            this.UserId = UserId;
            this.InfoId = InfoId;
            this.Message = Message;
            this.UserName = UserName;
            Token = token;
            IsDisabled = isDisabled;
        }

        public ResponseLoginView(string? Message)
        {
            this.Message = Message;
        }
    }
}
