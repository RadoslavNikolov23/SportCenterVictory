namespace SCV.Test.ServiceTests
{
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM;
    using SCV.Web.ViewModels.CommonVM;

    [TestFixture]
    public class MembershipServiceTests
    {
        private Mock<IMembershipRepository> mockRepo;
        private IMembershipService membershipService;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IMembershipRepository>();
            membershipService = new MembershipService(mockRepo.Object);
        }

        [Test]
        public async Task GetAllMembershipAsync_ReturnsOrderedMemberships()
        {
            IQueryable<Membership> data = new List<Membership>
            {
                new Membership
                {
                        Id = Guid.NewGuid(),
                        Name = "Fitness Standard",
                        MembershipType  = SportType.Fitness,
                        Description = "Basic access to gym equipment and cardio area. Includes 1 trainer session/month.",
                        Price  = 39.99m,
                        DurationText = "1 Month",
                        Duration  = 31,

                },
                new Membership
                {
                        Id = Guid.NewGuid(),
                        Name  = "CrossFit Limited",
                        MembershipType  = SportType.CrossFit,
                        Description  = "Up to 8 classes a month, perfect for beginners or busy athletes.",
                        Price  = 59.99m,
                        DurationText  = "1 Month",
                        Duration  = 31,
                    }
            }.AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);

            IEnumerable<MembershipDetailViewModel> result = await membershipService
                                        .GetAllMembershipAsync();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Name, Is.EqualTo("Fitness Standard"));
            Assert.That(result.First().MembershipType, Is.EqualTo(SportType.Fitness));
            Assert.That(result.First().Description, Is.EqualTo("Basic access to gym equipment and cardio area. Includes 1 trainer session/month."));
            Assert.That(result.First().Price, Is.EqualTo(39.99));
            Assert.That(result.First().DurationText, Is.EqualTo("1 Month"));
        }

        [Test]
        public async Task GetAllMembershipPerSportAsync_ReturnsCorrectType()
        {
            IQueryable<Membership> data = new List<Membership>
            {
                new Membership
                {
                        Id = Guid.NewGuid(),
                        Name = "Fitness Standard",
                        MembershipType  = SportType.Fitness,
                        Description = "Basic access to gym equipment and cardio area. Includes 1 trainer session/month.",
                        Price  = 39.99m,
                        DurationText = "1 Month",
                        Duration  = 31,

                },
                new Membership
                {
                        Id = Guid.NewGuid(),
                        Name  = "CrossFit Limited",
                        MembershipType  = SportType.CrossFit,
                        Description  = "Up to 8 classes a month, perfect for beginners or busy athletes.",
                        Price  = 59.99m,
                        DurationText  = "1 Month",
                        Duration  = 31,
                    }
            }.AsQueryable();


            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);

            IEnumerable<MembershipDetailViewModel> result = await membershipService
                            .GetAllMembershipPerSportAsync(SportType.Fitness);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Name, Is.EqualTo("Fitness Standard"));
            Assert.That(result.First().MembershipType, Is.EqualTo(SportType.Fitness));
        }

        [Test]
        public async Task GetAllMembershipsForAdminAsync_ReturnsAllMemberships()
        {
            IQueryable<Membership> data = new List<Membership>
            {
                new Membership
                {
                        Id = Guid.NewGuid(),
                        Name = "Fitness Standard",
                        MembershipType  = SportType.Fitness,
                        Description = "Basic access to gym equipment and cardio area. Includes 1 trainer session/month.",
                        Price  = 39.99m,
                        DurationText = "1 Month",
                        Duration  = 31,

                },
                new Membership
                {
                        Id = Guid.NewGuid(),
                        Name  = "CrossFit Limited",
                        MembershipType  = SportType.CrossFit,
                        Description  = "Up to 8 classes a month, perfect for beginners or busy athletes.",
                        Price  = 59.99m,
                        DurationText  = "1 Month",
                        Duration  = 31,
                    }
            }.AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);

            IEnumerable<MembershipAdminDetailViewModel> result = await membershipService
                                .GetAllMembershipsForAdminAsync();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Name, Is.EqualTo("Fitness Standard"));
        }

        [Test]
        public async Task AddMembershipAsync_WithValidInput_ReturnsTrue()
        {
            MembershipAddViewModel membershipViewModel = new MembershipAddViewModel
            {
                Name = "Fitness Gold",
                MembershipType = SportType.Fitness,
                Description = "Full access to gym equipment and cardio area.",
                Price = 139.99m,
                DurationText = "1 Month",
                Duration = 31,
            };

            bool isAdded = false;
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Membership>())).Callback(() => isAdded = true);

            bool result = await membershipService
                                .AddMembershipAsync(membershipViewModel);

            Assert.IsTrue(result);
            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task GetMembershipByIdAsync_WithExistingId_ReturnsMembership()
        {
            Guid membershipId = Guid.NewGuid();
            IQueryable<Membership> data = new List<Membership>
            {
                new Membership
                {
                        Id = membershipId,
                        Name  = "CrossFit Limited",
                        MembershipType  = SportType.CrossFit,
                        Description  = "Up to 8 classes a month, perfect for beginners or busy athletes.",
                        Price  = 59.99m,
                        DurationText  = "1 Month",
                        Duration  = 31,
                    }
           }.AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);

            MembershipEditViewModel? result = await membershipService
                            .GetMembershipByIdAsync(membershipId.ToString());

            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("CrossFit Limited"));
            Assert.That(result.MembershipType, Is.EqualTo(SportType.CrossFit));
        }

        [Test]
        public async Task EditMembershipAsync_WithValidEdit_UpdatesSuccessfully()
        {
            Guid membershipId = Guid.NewGuid();
            Membership membership = new Membership
            {
                Id = membershipId,
                Name = "CrossFit Limited",
                MembershipType = SportType.CrossFit,
                Description = "Up to 8 classes a month, perfect for beginners or busy athletes.",
                Price = 59.9m,
                DurationText = "1 Month",
                Duration = 31,
            };

            IQueryable<Membership> data = new List<Membership> 
                                        { 
                                            membership 
                                        }
                                        .AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Membership>()))
                    .ReturnsAsync(true);

            MembershipEditViewModel viewModel = new MembershipEditViewModel
            {
                Id = membershipId.ToString(),
                Name = "Test",
                MembershipType = SportType.Fitness,
                Description = "Test",
                Price = 100m,
                Duration = 60
            };

            bool isEdit = await membershipService.EditMembershipAsync(viewModel);

            Assert.IsTrue(isEdit);
            Assert.That(membership.Name, Is.EqualTo("Test"));
            Assert.That(membership.MembershipType, Is.EqualTo(SportType.Fitness));
            Assert.That(membership.Description, Is.EqualTo("Test"));
            Assert.That(membership.Price, Is.EqualTo(100));
            Assert.That(membership.Duration, Is.EqualTo(60));

        }

        [Test]
        public async Task GetAllMembershipForDeletingAsync_ReturnsAllMemberships()
        {
            IQueryable<Membership> data = new List<Membership>
            {
                new Membership
                {
                        Id = Guid.NewGuid(),
                        Name = "Fitness Standard",
                        MembershipType  = SportType.Fitness,
                        Description = "Basic access to gym equipment and cardio area. Includes 1 trainer session/month.",
                        Price  = 39.99m,
                        DurationText = "1 Month",
                        Duration  = 31,
                        IsDeleted = false

                },
                new Membership
                {
                        Id = Guid.NewGuid(),
                        Name  = "CrossFit Limited",
                        MembershipType  = SportType.CrossFit,
                        Description  = "Up to 8 classes a month, perfect for beginners or busy athletes.",
                        Price  = 59.99m,
                        DurationText  = "1 Month",
                        Duration  = 31,
                        IsDeleted = true
                }
            }.AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);

            IEnumerable<MembershipDeleteViewModel> result = await membershipService
                            .GetAllMembershipForDeletingAsync();

            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task DeleteOrRestoreMembershipAsync_TogglesIsDeleted()
        {
            Guid membershipId = Guid.NewGuid();
            Membership membership = new Membership
            {
                Id = membershipId,
                Name = "Fitness Standard",
                MembershipType = SportType.Fitness,
                Description = "Basic access to gym equipment and cardio area. Includes 1 trainer session/month.",
                Price = 39.99m,
                DurationText = "1 Month",
                Duration = 31,
                IsDeleted = false

            };
            IQueryable<Membership> data = new List<Membership> 
                                                { 
                                                    membership 
                                                }
                                                .AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Membership>()))
                    .ReturnsAsync(true);

            var (result, isRestored) = await membershipService
                        .DeleteOrRestoreMembershipAsync(membershipId.ToString());

            Assert.IsTrue(result);
            Assert.IsTrue(isRestored);
            Assert.IsTrue(membership.IsDeleted);
        }
    }
}
