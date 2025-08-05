namespace SCV.Test.ServiceTests
{
    using Moq;
    using Microsoft.Extensions.Options;

    using System.Net.Mail;
    using SCV.Services.Core.EmailServices;
    using SCV.Services.Core.EmailServices.Contracts;
    using SCV.Web.ViewModels.ContactVM;
    using SCV.Services.Common.EmailSettings;

    [TestFixture]
    public class EmailServiceTests
    {
        private Mock<IOptions<EmailSettings>> mockOptions;
        private Mock<ISmtpClient> mockSmtpClient;
        private EmailSettings settings;

        [SetUp]
        public void Setup()
        {
            this.settings = new EmailSettings
            {
                SenderEmail = "testSender@example.com",
                ReceiverEmail = "testReceiver@example.com",
                Host = "smtp.example.com",
                Port = 587,
                Username = "rado01",
                Password = "password**"
            };

            this.mockOptions = new Mock<IOptions<EmailSettings>>();
            this.mockOptions.Setup(o => o.Value)
                       .Returns(settings);

            this.mockSmtpClient = new Mock<ISmtpClient>();
        }

        [Test]
        public async Task SendContactEmailAsync_WithValidModel_ReturnsTrue()
        {
            ContactFormViewModel model = new ContactFormViewModel
            {
                Name = "Rado",
                Email = "rado@example.com",
                PhoneNumber = "0888123456",
                Message = "Test message - something",
            };

            mockSmtpClient.Setup(c => c.SendMailAsync(It.IsAny<MailMessage>()))
                          .Returns(Task.CompletedTask);

            EmailService service = new EmailService(() => mockSmtpClient.Object, mockOptions.Object);

            bool isSend = await service
                            .SendContactEmailAsync(model);

            Assert.IsTrue(isSend);
            mockSmtpClient.Verify(c => c.SendMailAsync(It.IsAny<MailMessage>()), Times.Once);
        }

        [Test]
        public async Task SendContactEmailAsync_WhenExceptionThrown_ReturnsFalse()
        {
            ContactFormViewModel model = new ContactFormViewModel
            {
                Name = "Rado Georgiev",
                Email = "rado@example.com",
                PhoneNumber = "123456789",
                Message = "Test message - something"
            };

            mockSmtpClient.Setup(c => c.SendMailAsync(It.IsAny<MailMessage>()))
                          .ThrowsAsync(new SmtpException("SMTP error"));

            EmailService service = new EmailService(() => mockSmtpClient.Object, mockOptions.Object);

            bool isNotSend = await service.SendContactEmailAsync(model);

            Assert.IsFalse(isNotSend);
        }
    }
}
