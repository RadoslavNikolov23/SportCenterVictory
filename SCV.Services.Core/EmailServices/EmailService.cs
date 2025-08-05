namespace SCV.Services.Core.EmailServices
{
    using Microsoft.Extensions.Options;
    using SCV.Services.Common;
    using SCV.Services.Core.EmailServices.Contracts;
    using SCV.Web.ViewModels.ContactVM;
    using System.Net.Mail;

    public class EmailService : IEmailService
    {
        private readonly Func<ISmtpClient> smtpClientFactory;
        private readonly EmailSettings settings;

        public EmailService(Func<ISmtpClient> smtpClientFactory, IOptions<EmailSettings> settings)
        {
            this.smtpClientFactory = smtpClientFactory;
            this.settings = settings.Value;
        }

        public async Task<bool> SendContactEmailAsync(ContactFormViewModel model)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(settings.SenderEmail, "Sport Center Victory - Email \n\n"),
                Subject = $"Contact Form: {model.Name} \n\n",
                Body = $"Name: {model.Name}\nEmail: {model.Email}\nPhone: {model.PhoneNumber}\nMessage:\n{model.Message} \n\n",
                IsBodyHtml = false
            };

            message.To.Add(settings.ReceiverEmail);

            try
            {
                using ISmtpClient smtp = smtpClientFactory();

                await smtp.SendMailAsync(message);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
