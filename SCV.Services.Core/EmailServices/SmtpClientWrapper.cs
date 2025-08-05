namespace SCV.Services.Core.EmailServices
{
    using System.Net;
    using System.Net.Mail;
    using SCV.Services.Core.EmailServices.Contracts;

    public class SmtpClientWrapper : ISmtpClient
    {
        private readonly SmtpClient smtpClient;

        public SmtpClientWrapper(string host, int port, string username, string password)
        {
            this.smtpClient = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
        }

        public Task SendMailAsync(MailMessage message)
        {
            return smtpClient.SendMailAsync(message);
        }

        public void Dispose()
        {
            smtpClient.Dispose();
        }
    }
}
