namespace WhoruBackend.Utilities.SecurePassword
{
    public class ValidateCodeProvider
    {
        private readonly String str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public ValidateCodeProvider()
        {
        }

        public string ValidateCode(int size)
        {
            Random res = new Random();
            String code = string.Empty;
            for (int i = 0; i < size; i++)
            {
                int x = res.Next(str.Length);
                code = code + str[x];
            }
            return code;
        }

    }
}
