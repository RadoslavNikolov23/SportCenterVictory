namespace SCV.Test.ServiceTests
{
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.UserFeedbackServices;
    using SCV.Services.Core.UserFeedbackServices.Contracts;
    using SCV.Web.ViewModels.Administration.UserFeedbackVM;
    using SCV.Web.ViewModels.UserFeedbackVM;
    using System.Linq;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    [TestFixture]
    public class UserFeedbackServiceTests
    {
        private Mock<IUserFeedbackRepository> mockRepo;
        private IUserFeedbackService userFeedbackService;

        [SetUp]
        public void SetUp()
        {
            mockRepo = new Mock<IUserFeedbackRepository>();
            userFeedbackService = new UserFeedbackService(mockRepo.Object);
        }

        [Test]
        public async Task GetAllUserFeedbacksAsync_ReturnsThreeRandomPublished()
        {
            IQueryable<UserFeedback> data = new List<UserFeedback>
            {
                new UserFeedback
                {
                    UserName = "victoriadimitrova@sportcentervictory.com",
                    FullName = "Victoria Dimitrova",
                    Feedback = "The trainers are amazing and the CrossFit classes!",
                    Status = FeedbackStatus.Published,
                    ImageUrl = "victoria.jpg"
                },
                new UserFeedback
                {
                    UserName = "ivanpetrov@sportcentervictory.com",
                    FullName = "Ivan Petrov",
                    Feedback = "I really enjoy the new powerlifting area!",
                    Status = FeedbackStatus.Published,
                    ImageUrl = "ivan.jpg"
                },
                new UserFeedback
                {
                    UserName = "mariastefanova@sportcentervictory.com",
                    FullName = "Maria Stefanova",
                    Feedback = "Excellent gym with a motivating atmosphere!",
                    Status = FeedbackStatus.Published,
                    ImageUrl = "maria.jpg"
                },
                new UserFeedback
                {
                    UserName = "stefanivanov@sportcentervictory.com",
                    FullName = "Stefan Ivanov",
                    Feedback = "Excellent Crossfit Area with a motivating  and participants!",
                    Status = FeedbackStatus.Published,
                    ImageUrl = "stefan.jpg"
                }
            }.AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<UserFeedbackDetailViewModel> result = await userFeedbackService
                                .GetAllUserFeedbacksAsync();

            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task AddUserFeedbackAsync_AddsValidFeedback_ReturnsTrue()
        {
            Guid userId = Guid.NewGuid();

            UserFeedbackAddViewModel viewModel = new UserFeedbackAddViewModel
            {
                UserId = userId.ToString(),
                UserName = "ivanpetrov@sportcentervictory.com",
                FullName = "Ivan Petrov",
                Feedback = "I really enjoy the new powerlifting area!",
                Status = FeedbackStatus.Pending,
                ImageUrl = "ivan.jpg"
            };

            mockRepo.Setup(r => r.AddAsync(It.IsAny<UserFeedback>()))
                    .Returns(Task.CompletedTask);

            bool isAdded = await userFeedbackService.AddUserFeedbackAsync(viewModel);

            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task AllUserFeedbacksForApproveAsync_ReturnsAllFeedbacks()
        {
            IQueryable<UserFeedback> data = new List<UserFeedback>
            {
                new UserFeedback
                {
                    UserName = "victoriadimitrova@sportcentervictory.com",
                    FullName = "Victoria Dimitrova",
                    Feedback = "The trainers are amazing and the CrossFit classes!",
                    Status = FeedbackStatus.Pending,
                    ImageUrl = "victoria.jpg"
                },
                new UserFeedback
                {
                    UserName = "ivanpetrov@sportcentervictory.com",
                    FullName = "Ivan Petrov",
                    Feedback = "I really enjoy the new powerlifting area!",
                    Status = FeedbackStatus.Pending,
                    ImageUrl = "ivan.jpg"
                },
                new UserFeedback
                {
                    UserName = "mariastefanova@sportcentervictory.com",
                    FullName = "Maria Stefanova",
                    Feedback = "Excellent gym with a motivating atmosphere!",
                    Status = FeedbackStatus.Pending,
                    ImageUrl = "maria.jpg"
                },
                new UserFeedback
                {
                    UserName = "stefanivanov@sportcentervictory.com",
                    FullName = "Stefan Ivanov",
                    Feedback = "Excellent Crossfit Area with a motivating  and participants!",
                    Status = FeedbackStatus.Pending,
                    ImageUrl = "stefan.jpg"
                }
            }.AsQueryable();

            var mockSet = data.BuildMockDbSet();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<UserFeedbackApproveViewModel> result = await userFeedbackService
                    .AllUserFeedbacksForApproveAsync();

            Assert.That(result.Count(), Is.EqualTo(4));
        }

        [Test]
        public async Task ApproveOrNotUserFeedbackAsync_UpdatesFeedback_ReturnsTrue()
        {
            Guid userId = Guid.NewGuid();
            UserFeedback feedback = new UserFeedback
            {
                Id = userId,
                UserName = "mariastefanova@sportcentervictory.com",
                FullName = "Maria Stefanova",
                Feedback = "Excellent gym with a motivating atmosphere!",
                Status = FeedbackStatus.Pending,
                ImageUrl = "maria.jpg"
            };

            IQueryable<UserFeedback> data = new List<UserFeedback>
                                                {
                                                    feedback
                                                }
                                               .AsQueryable();
            var mockSet = data.BuildMockDbSet();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<UserFeedback>()))
                    .ReturnsAsync(true);

            UserFeedbackApproveViewModel userFeedbackViewModel = new UserFeedbackApproveViewModel
            {
                Id = userId.ToString(),
                UserName = "mariastefanova@sportcentervictory.com",
                FullName = "Maria Stefanova",
                Feedback = "Excellent gym with a motivating atmosphere!",
                Status = FeedbackStatus.Published,
                ImageUrl = "/img.jpg"
            };

            bool isApproved = await userFeedbackService
                            .ApproveOrNotUserFeedbackAsync(userFeedbackViewModel);

            Assert.IsTrue(isApproved);
        }
    }
}
