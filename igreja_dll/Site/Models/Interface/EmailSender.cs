using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Site.Models.Interface
{
    public class EmailSender : IEmailSender
    {
       // private readonly EmailSettings EmailSettings;

        public EmailSender()
        {
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                Execute(email, subject, message).Wait();
                return Task.FromResult(0);
            }
            catch
            {
                throw;
            }
        }

        private async Task Execute(string email, string subject, string message)
        {
            var Email = new EmailSettings();
            try
            {
                var toEmail = string.IsNullOrEmpty(email) ? Email.ToEmail : email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(Email.UsernameEmail, "Advocacia")
                };

                mail.To.Add(toEmail);
                mail.CC.Add(Email.CcEmail);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mail.BodyEncoding = Encoding.GetEncoding("UTF-8");
                mail.Priority = MailPriority.High;

                using(var smtp = new SmtpClient(Email.PrimaryDomaim, Email.PrimaryPort))
                {
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential(Email.UsernameEmail, Email.UserNamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
