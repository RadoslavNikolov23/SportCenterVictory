namespace SCV.Services.Core
{
    using Microsoft.Extensions.Options;

    using System.Net;
    using System.Net.Mail;

    using SCV.Services.Common;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.ContactVM;

    public class EmailService : IEmailService
    {
        private readonly EmailSettings settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            this.settings = settings.Value;
        }

        public async Task<bool> SendContactEmailAsync(ContactFormViewModel model)
        {
            bool isSendSuccessful = false;

            var message = new MailMessage
            {
                From = new MailAddress(settings.SenderEmail, "Sport Center Victory - Email"),
                Subject = $"Contact Form: {model.Name}",
                Body = $"Name: {model.Name}\nEmail: {model.Email}\nPhone: {model.PhoneNumber}\nMessage:\n{model.Message}",
                IsBodyHtml = false
            };

            message.To.Add(settings.ReceiverEmail);

            using var smtp = new SmtpClient(settings.Host, settings.Port)
            {
                Credentials = new NetworkCredential(settings.Username, settings.Password),
                EnableSsl = true
            };

            try
            {
                await smtp.SendMailAsync(message);
                isSendSuccessful = true; 
            }
            catch (SmtpException ex)
            {
                isSendSuccessful = false;
            }
            catch (Exception ex)
            {
                isSendSuccessful = false;
            }

            return isSendSuccessful;
        }
    }
}
