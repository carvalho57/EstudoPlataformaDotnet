using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace SendEmail
{
    public class EmailService
    {
        private readonly SmtpClient _smtpClient;
        public EmailService(Smtp config)
        {
            _smtpClient = new SmtpClient(config.Host)
            {
                Port = config.Port,
                Credentials = new NetworkCredential(config.Username, config.Password),
                EnableSsl = true,                
            };
        }
        public MailMessage CreateMailMessage(string from, string to, string subject, string body)
        {
            var mailMessage = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(to);
            return mailMessage;
        }
        public void Send(string from, string to, string subject, string body)
        {            
            var mailMessage = CreateMailMessage(from, to, subject, body);
            Send(mailMessage);
        }
        public void Send(MailMessage mailMessage, Attachment attachment)
        {            
            mailMessage.Attachments.Add(attachment);
            Send(mailMessage);
        }
        public void Send(MailMessage mailMessage) => _smtpClient.Send(mailMessage);
    }

}
