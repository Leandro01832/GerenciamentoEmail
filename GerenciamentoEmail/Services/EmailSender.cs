using GerenciamentoEmail.Services.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEmail.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings EmailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            EmailSettings = emailSettings.Value;
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
            try
            {
                var toEmail = string.IsNullOrEmpty(email) ? EmailSettings.ToEmail : email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(EmailSettings.UsernameEmail, "Advocacia")
                };

                mail.To.Add(toEmail);
                mail.CC.Add(EmailSettings.CcEmail);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mail.BodyEncoding = Encoding.GetEncoding("UTF-8");
                mail.Priority = MailPriority.High;

                using(var smtp = new SmtpClient(EmailSettings.PrimaryDomaim, EmailSettings.PrimaryPort))
                {
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential(EmailSettings.UsernameEmail,
                        EmailSettings.UserNamePassword);
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
