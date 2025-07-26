namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;

    public class UserFeedbackService : IUserFeedbackService
    { 
        private readonly IUserFeedbackRepository userFeedbackRepo;

        public UserFeedbackService(IUserFeedbackRepository userFeedbackRepo)
        {
            this.userFeedbackRepo = userFeedbackRepo;
        }

        public async Task<IEnumerable<UserFeedbackDetailViewModel>> GetAllUserFeedbacksAsync()
        {
            IEnumerable<UserFeedbackDetailViewModel> userFeedbackDetailsVM = await this.userFeedbackRepo
                                                .GetAllAttached()
                                                .AsNoTracking()
                                                .Select (uf => new UserFeedbackDetailViewModel()
                                                {
                                                    UserName = uf.UserName,
                                                    FullName = uf.FullName,
                                                    Feedback = uf.Feedback,
                                                    ImageUrl = uf.ImageUrl ?? $"/noImage.jpg",
                                                })
                                                .ToListAsync();

            return userFeedbackDetailsVM;
        }
    }
}
