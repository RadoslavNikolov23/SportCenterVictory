namespace SCV.Services.Core.EmailServices.Contracts
{
    using System;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public interface ISmtpClient : IDisposable
    {
        Task SendMailAsync(MailMessage message);
    }
}
