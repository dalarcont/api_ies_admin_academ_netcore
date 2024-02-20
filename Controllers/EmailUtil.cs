 using Abp.Extensions;
using IES_ADMIN_ACADEM_API.Entities;
using IES_ADMIN_ACADEM_API.Services;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;

namespace IES_ADMIN_ACADEM_API.Controllers
{
    public class EmailUtil
    {
        //Logger 
        private readonly ILogger<UserService> EventLogger;
        private readonly IConfiguration _configuration;

        public EmailUtil(ILogger<UserService> logger) {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
            EventLogger = logger;
        }

        public void sendEmail_SMTP(IES_EmailModel emailModel) {
            try
            {
                using (SmtpClient client = new SmtpClient(_configuration.GetConnectionString("IES_SMTP").ToString()))
                {
                    MailMessage mailMessage  = new MailMessage();
                    mailMessage.From         = new MailAddress(emailModel.SenderMail, emailModel.SenderName);
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.To           .Add(emailModel.Destination);
                    mailMessage.Body         = emailModel.Body;
                    mailMessage.Subject      = emailModel.Subject;
                    mailMessage.IsBodyHtml   = emailModel.IsHtml;
                    client.Send(mailMessage);
                    EventLogger.Log(LogLevel.Information,$"Email to {emailModel.Destination} sended successfully");
                }
            }
            catch(Exception ex)
            {
                EventLogger.Log(LogLevel.Error, $"ERROR sending Email to {emailModel.Destination} -> {ex.Message}");
            }

        }
    }
}
