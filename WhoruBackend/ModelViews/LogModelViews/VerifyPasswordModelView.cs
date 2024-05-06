namespace WhoruBackend.ModelViews.LogModelViews
{
    public class VerifyPasswordModelView
    {
        public string email { get; set; }
        public string code { get; set; }

        public VerifyPasswordModelView(string email, string code)
        {
            this.email = email;
            this.code = code;
        }
    }
}
