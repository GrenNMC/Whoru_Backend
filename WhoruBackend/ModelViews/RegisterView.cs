namespace WhoruBackend.ModelViews
{
    public class RegisterView
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public RegisterView(string userName, string password, string email, string phone)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Phone = phone;
        }
    }
}
