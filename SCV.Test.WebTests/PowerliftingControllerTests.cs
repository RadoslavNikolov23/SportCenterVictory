namespace SCV.Test.WebTests
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.Extensions.Logging;
    using Moq;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.EventServices.Contracts;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Services.Core.TrainerServices.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.TrainerVM;
    using SportCenterVictory.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [TestFixture]

    public class PowerliftingControllerTests
    {
        private Mock<IMembershipService> mockMembershipService;
        private Mock<IMembershipUserService> mockMembershipUserService;
        private Mock<ITrainerService> mockTrainerService;
        private Mock<ITrainerUserService> mockTrainerUserService;
        private Mock<IEventService> mockEventService;
        private Mock<IEventUserService> mockEventUserService;
        private Mock<ILogger<PowerliftingController>> mockLogger;

        private PowerliftingController controller;

        [SetUp]
        public void SetUp()
        {
            mockMembershipService = new Mock<IMembershipService>();
            mockMembershipUserService = new Mock<IMembershipUserService>();
            mockTrainerService = new Mock<ITrainerService>();
            mockTrainerUserService = new Mock<ITrainerUserService>();
            mockEventService = new Mock<IEventService>();
            mockEventUserService = new Mock<IEventUserService>();
            mockLogger = new Mock<ILogger<PowerliftingController>>();

            controller = new PowerliftingController(
                mockMembershipService.Object,
                mockTrainerService.Object,
                mockEventService.Object,
                mockEventUserService.Object,
                mockMembershipUserService.Object,
                mockTrainerUserService.Object,
                mockLogger.Object
            );
        }


        [TearDown]
        public void TearDown()
        {
            controller.Dispose();
        }

        [Test]
        public void PowerliftingZone_ReturnsView()
        {
            IActionResult result = controller.PowerliftingZone();
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task PowerliftingMembership_ReturnsView_WhenMembershipsExist()
        {
            IList<MembershipDetailViewModel> memberships = new List<MembershipDetailViewModel>
            {
                new MembershipDetailViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Fitness Standard",
                    Description = "Basic access to gym equipment and cardio area.",
                    DurationText = "1 Month"
                }
            };

            mockMembershipService.Setup(m => m.GetAllMembershipPerSportAsync(SportType.Powerlifting))
                                 .ReturnsAsync(memberships);

            mockMembershipUserService.Setup(m => m.IsUserAddedToMembershipList(It.IsAny<string>(), It.IsAny<string>()))
                                     .ReturnsAsync(false);

            mockMembershipUserService.Setup(m => m.CanUserRemovedIt(It.IsAny<string>(), It.IsAny<string>()))
                                     .ReturnsAsync(true);

            mockMembershipUserService.Setup(m => m.IsExpired(It.IsAny<string>(), It.IsAny<string>()))
                                     .ReturnsAsync(false);

            SimulateAuthenticatedUser();

            IActionResult result = await controller.PowerliftingMembership();

            ViewResult? view = result as ViewResult;
            Assert.NotNull(view);
            Assert.IsInstanceOf<IEnumerable<MembershipDetailViewModel>>(view.Model);
        }

        [Test]
        public async Task PowerliftingMembership_ReturnsNotFound_WhenNoMemberships()
        {
            mockMembershipService.Setup(m => m.GetAllMembershipPerSportAsync(SportType.Powerlifting))
                                 .ReturnsAsync(new List<MembershipDetailViewModel>());



            var user = new ClaimsPrincipal(new ClaimsIdentity(
                    new Claim[]
                        {
                            new Claim(ClaimTypes.Name, "TestUser"),
                        }, 
                         "TestAuthentication"));

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            ITempDataDictionary tempData = new TempDataDictionary(
                        controller.ControllerContext.HttpContext,
                        Mock.Of<ITempDataProvider>());

            controller.TempData = tempData;
            controller.TempData["IsAuthenticated"] = false;

            IActionResult result = await controller.PowerliftingMembership();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task PowerliftingCoaches_ReturnsView_WhenTrainersExist()
        {
            IList<TrainerDetailViewModel> trainers = new List<TrainerDetailViewModel>
            {
                new TrainerDetailViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Viktor",
                    LastName = "Nachev",
                    Email = "viktornachev@sportcentervictory.com",
                    Bio = "Certified fitness instructor and personal coach.",

                }
            };

            mockTrainerService.Setup(t => t.GetAllTrainerBySpecialtiesAsync(SportType.Powerlifting))
                              .ReturnsAsync(trainers);

            mockTrainerUserService.Setup(t => t.IsTrainerAddedToUserList(It.IsAny<string>(), It.IsAny<string>()))
                                  .ReturnsAsync(true);

            SimulateAuthenticatedUser();

            IActionResult result = await controller.PowerliftingCoaches();

            ViewResult? view = result as ViewResult;
            Assert.NotNull(view);
            Assert.IsInstanceOf<IEnumerable<TrainerDetailViewModel>>(view.Model);
        }

        [Test]
        public async Task PowerliftingEvents_ReturnsView_WhenEventsExist()
        {
            IList<EventDetailViewModel> events = new List<EventDetailViewModel>
            {
                new EventDetailViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Fitness Transformation Bootcamp",
                    StartDate = "2025-08-15",
                    Location = "Sport Center Victory - Ruse"

                }
            };

            mockEventService.Setup(e => e.GetAllEventByEventTypeAsync(SportType.Powerlifting))
                            .ReturnsAsync(events);

            mockEventUserService.Setup(e => e.IsUserAddedToEventList(It.IsAny<string>(), It.IsAny<string>()))
                                .ReturnsAsync(false);

            SimulateAuthenticatedUser();

            IActionResult result = await controller.PowerliftingEvents();

            ViewResult? view = result as ViewResult;
            Assert.NotNull(view);
            Assert.IsInstanceOf<IEnumerable<EventDetailViewModel>>(view.Model);
        }

        private void SimulateAuthenticatedUser(string userId = "test-user-id")
        {
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }, "mock"));

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }
    }
}
