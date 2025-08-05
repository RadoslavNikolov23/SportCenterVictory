namespace SCV.Test.WebTests
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.Extensions.Logging;

    using Moq;

    using SCV.Services.Core.EmailServices.Contracts;
    using SCV.Web.ViewModels.ContactVM;
    using SportCenterVictory.Controllers;

    [TestFixture]
    public class ContactControllerTests
    {
        private Mock<IEmailService> mockEmailService;
        private Mock<ILogger<ContactController>> mockLogger;
        private ContactController controller;

        [SetUp]
        public void Setup()
        {
            mockEmailService = new Mock<IEmailService>();
            mockLogger = new Mock<ILogger<ContactController>>();
            controller = new ContactController(mockEmailService.Object, mockLogger.Object);

            ITempDataDictionary tempData = new TempDataDictionary(
                                new DefaultHttpContext(),
                                Mock.Of<ITempDataProvider>());

            controller.TempData = tempData;
        }

        [TearDown]
        public void TearDown()
        {
            controller.Dispose();
        }

        [Test]
        public async Task Index_Post_ReturnsRedirectWithSuccess_WhenEmailSent()
        {
            ContactFormViewModel model = new ContactFormViewModel
            {
                Name = "Rado",
                Email = "test@example.com",
                Message = "Hello! This is a Test!"
            };

            mockEmailService.Setup(s => s.SendContactEmailAsync(model))
                            .ReturnsAsync(true);

            var result = await controller.Index(model);

            var redirect = result as RedirectToActionResult;

            Assert.NotNull(redirect);
            Assert.That(redirect.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task Index_Post_ReturnsRedirectWithError_WhenEmailFails()
        {
            ContactFormViewModel model = new ContactFormViewModel
            {
                Name = "Test",
                Email = "failTest@example.com",
                Message = "Test message - Hello!"
            };

            mockEmailService.Setup(s => s.SendContactEmailAsync(It.IsAny<ContactFormViewModel>()))
                            .ReturnsAsync(false);

            var result = await controller.Index(model);

            var redirect = result as RedirectToActionResult;
            Assert.NotNull(redirect);
            Assert.That(redirect.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task Index_Post_ReturnsView_WhenModelStateIsInvalid()
        {
            controller.ModelState.AddModelError("Email", "Required");

            ContactFormViewModel model = new ContactFormViewModel
            {
                Name = "Invalid",
                Message = "Missing email"
            };

            var result = await controller.Index(model);

            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            Assert.That(viewResult.Model, Is.EqualTo(model));
        }

        [Test]
        public async Task Index_Post_ReturnsServerError_WhenExceptionThrown()
        {
            ContactFormViewModel model = new ContactFormViewModel
            {
                Name = "Test- Error",
                Email = "crash@example.com",
                Message = "Something that will crash!"
            };

            mockEmailService.Setup(s => s.SendContactEmailAsync(It.IsAny<ContactFormViewModel>()))
                           .ReturnsAsync(false);

            var result = await controller.Index(model);

            var statusResult = result as ViewResult;
            Assert.IsNull(statusResult);
        }
    }
}
