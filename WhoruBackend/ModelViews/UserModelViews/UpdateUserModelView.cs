namespace WhoruBackend.ModelViews.UserModelViews
{
    public class UpdateUserModelView
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public UpdateUserModelView(string? email, string? phone)
        {
            Email = email;
            Phone = phone;
        }

        public UpdateUserModelView()
        {
        }
    }
}
