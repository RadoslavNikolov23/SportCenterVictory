namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.UserFeedbackVM;
    using System.Collections.Generic;

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
                                               .Where(uf => uf.Status == FeedbackStatus.Published)
                                               .Select(uf => new UserFeedbackDetailViewModel()
                                               {
                                                   UserName = uf.UserName,
                                                   FullName = uf.FullName,
                                                   Feedback = uf.Feedback,
                                                   ImageUrl = uf.ImageUrl ?? $"/noImage.jpg",
                                               })
                                               .ToListAsync();

            //Chech if it is a HasSet their is a bool in add method
            HashSet<UserFeedbackDetailViewModel> randomUserFeedback = new HashSet<UserFeedbackDetailViewModel>();

            if(userFeedbackDetailsVM.Count() < 3)
            {
                return userFeedbackDetailsVM;
            }

            for (int i = 0; i < 3; i++)
            {
                int randomIndex = Random.Shared.Next(0, userFeedbackDetailsVM.Count());

                
                if (!randomUserFeedback.Add(userFeedbackDetailsVM.ElementAt(randomIndex)))
                {
                    i--;
                }
            }

            return randomUserFeedback;
        }

        public async Task<bool> AddUserFeedbackAsync(UserFeedbackAddViewModel userFeedbackToAddVM)
        {
            bool isAdded = false;

            bool isUserFeedbackIdGuid = Guid.TryParse(userFeedbackToAddVM.UserId, out Guid userIdGuid);

            if (userFeedbackToAddVM != null)
            {
                UserFeedback userFeedbackToAdd = new UserFeedback()
                {
                    UserName = userFeedbackToAddVM.UserName,
                    FullName = userFeedbackToAddVM.FullName,
                    Feedback = userFeedbackToAddVM.Feedback,
                    Status = FeedbackStatus.Pending,
                    ImageUrl = userFeedbackToAddVM.ImageUrl,
                    UserId = isUserFeedbackIdGuid ? userIdGuid : Guid.Empty

                };

                await this.userFeedbackRepo.AddAsync(userFeedbackToAdd);

                isAdded = true;
            }

            return isAdded;
        }
    }
}
