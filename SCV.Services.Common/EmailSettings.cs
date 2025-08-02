namespace SCV.Services.Common
{
    public class EmailSettings
    {
        public string Host { get; set; } = null!;// e.g., smtp-relay.sendinblue.com
        public int Port { get; set; } = 587;
        public string Username { get; set; } = null!;// Brevo/SMTP2GO username
        public string Password { get; set; } = null!;
        public string SenderEmail { get; set; } = null!;
        public string ReceiverEmail { get; set; } = null!;// your abv email
    }
}
