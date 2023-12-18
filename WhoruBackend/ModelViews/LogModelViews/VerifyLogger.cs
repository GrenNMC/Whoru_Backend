namespace WhoruBackend.ModelViews.LogModelViews
{
    public class VerifyLogger
    {
        public int? IdUser {  get; set; }
        public string? Code {  get; set; }

        public VerifyLogger(int? idUser, string? code)
        {
            IdUser = idUser;
            Code = code;
        }

        public VerifyLogger()
        {
        }
    }
}
