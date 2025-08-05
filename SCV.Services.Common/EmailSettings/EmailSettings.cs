namespace SCV.Services.Common.EmailSettings
{
    public class EmailSettings
    {
        public string Host { get; set; } = null!;

        public int Port { get; set; } // Standard is 587

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string SenderEmail { get; set; } = null!;

        public string ReceiverEmail { get; set; } = null!;
    }
}
