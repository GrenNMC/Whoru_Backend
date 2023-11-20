using System.Net.Mail;
using System.Net;

namespace WhoruBackend.Utilities.Emails
{
    public class VerifyEmail
    {

        public async void ResetPassword(string address,string password)
        {
            var configuration = new ConfigurationManager();
            configuration.AddJsonFile("appsettings.json");

            var mail = new MailMessage();
            mail.From = new MailAddress(configuration.GetValue<string>("SMTPEmailConfiguration:RootAddress") ?? "", configuration.GetValue<string>("SMTPEmailConfiguration:Sender"));
            mail.To.Add(new MailAddress(address));
            mail.Body = "<div style=\"font-size: 20px;\">Mật khẩu mới của bạn là: </div>\r" +
                "\n <div style=\"color: red; font-size: 30px;\">" + password + "</div>\r"+
                "<div style =\"font-size: 18px;\">Vui lòng đăng nhập bằng mật khẩu trên và vào trang cá nhân để đổi mật khẩu!</div>\r";
            mail.IsBodyHtml = true;
            mail.Subject = "Reset mật khẩu người dùng";

            var smtp = new SmtpClient();
            smtp.Host = configuration.GetValue<string>("SMTPEmailConfiguration:Host") ?? "";
            smtp.Port = configuration.GetValue<int>("SMTPEmailConfiguration:Port");
            smtp.EnableSsl = configuration.GetValue<bool>("SMTPEmailConfiguration:EnableSSL");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(configuration.GetValue<string>("SMTPEmailConfiguration:RootAddress"), configuration.GetValue<string>("SMTPEmailConfiguration:Password"));
            smtp.SendCompleted += Smtp_SendCompleted;
            await smtp.SendMailAsync(mail);
        }

        public async void SendMail(string address, string code)
        {
            var configuration = new ConfigurationManager();
            configuration.AddJsonFile("appsettings.json");

            var mail = new MailMessage();
            mail.From = new MailAddress(configuration.GetValue<string>("SMTPEmailConfiguration:RootAddress") ?? "", configuration.GetValue<string>("SMTPEmailConfiguration:Sender"));
            mail.To.Add(new MailAddress(address));
            mail.Body = "<div style=\"font-size: 20px;\">Mã xác nhận của bạn là: </div>\r" +
                "\n <div style=\"color: red; font-size: 30px;\">" + code + "</div>\r";
            mail.IsBodyHtml = true;
            mail.Subject = "Mã xác nhận tài khoản";

            var smtp = new SmtpClient();
            smtp.Host = configuration.GetValue<string>("SMTPEmailConfiguration:Host") ?? "";
            smtp.Port = configuration.GetValue<int>("SMTPEmailConfiguration:Port");
            smtp.EnableSsl = configuration.GetValue<bool>("SMTPEmailConfiguration:EnableSSL");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(configuration.GetValue<string>("SMTPEmailConfiguration:RootAddress"), configuration.GetValue<string>("SMTPEmailConfiguration:Password"));
            smtp.SendCompleted += Smtp_SendCompleted;
            await smtp.SendMailAsync(mail);
        }

        private void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var obj = (SmtpClient)sender;
            if (obj != null)
            {
                obj.Dispose();
            }
        }

        public VerifyEmail()
        {

        }
    }
}
