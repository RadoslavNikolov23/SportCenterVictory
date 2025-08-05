namespace SCV.Services.Core.UserFeedbackServices
{
    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.Administration.UserFeedbackVM;
    using SCV.Web.ViewModels.UserFeedbackVM;

    using static SCV.GlCommon.ApplicationConstants;
    using SCV.Services.Core.UserFeedbackServices.Contracts;

    public class UserFeedbackService : IUserFeedbackService
    { 
        private readonly IUserFeedbackRepository userFeedbackRepo;

        public UserFeedbackService(IUserFeedbackRepository userFeedbackRepo)
        {
            this.userFeedbackRepo = userFeedbackRepo;
        }

        public async Task<IEnumerable<UserFeedbackDetailViewModel>> GetAllUserFeedbacksAsync()
        {
            IEnumerable<UserFeedbackDetailViewModel> userFeedbackDetailsVM = await userFeedbackRepo
                                               .GetAllAttached()
                                               .AsNoTracking()
                                               .Where(uf => uf.Status == FeedbackStatus.Published)
                                               .Select(uf => new UserFeedbackDetailViewModel()
                                               {
                                                   UserName = uf.UserName,
                                                   FullName = uf.FullName,
                                                   Feedback = uf.Feedback,
                                                   ImageUrl = uf.ImageUrl ?? NoImage,
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

                await userFeedbackRepo.AddAsync(userFeedbackToAdd);

                isAdded = true;
            }

            return isAdded;
        }

        public async Task<IEnumerable<UserFeedbackApproveViewModel>> AllUserFeedbacksForApproveAsync()
        {
            IEnumerable<UserFeedbackApproveViewModel> userFeedbackApproveVM = await userFeedbackRepo
                                            .GetAllAttached()
                                            .Select(uf => new UserFeedbackApproveViewModel
                                            {
                                                Id = uf.Id.ToString(),
                                                UserName = uf.UserName,
                                                FullName = uf.FullName,
                                                Feedback = uf.Feedback,
                                                Status = uf.Status,
                                                ImageUrl = uf.ImageUrl,
                                            })
                                            .ToListAsync();
            return userFeedbackApproveVM;
        }


        public async Task<bool> ApproveOrNotUserFeedbackAsync(UserFeedbackApproveViewModel userFeedbackApproveVM)
        {
            bool isApproved = false;

            if (userFeedbackApproveVM != null)
            {
                UserFeedback? userFeedbackToApprove = await userFeedbackRepo
                                        .GetAllAttached()
                                        .SingleOrDefaultAsync(uf => uf.Id.ToString().ToLower() == userFeedbackApproveVM.Id.ToLower());

                if (userFeedbackToApprove != null)
                {

                    userFeedbackToApprove.UserName = userFeedbackApproveVM.UserName;
                    userFeedbackToApprove.FullName = userFeedbackApproveVM.FullName;
                    userFeedbackToApprove.Feedback = userFeedbackApproveVM.Feedback;
                    userFeedbackToApprove.Status = userFeedbackApproveVM.Status;
                    userFeedbackToApprove.ImageUrl = userFeedbackApproveVM.ImageUrl;

                    isApproved = await userFeedbackRepo.UpdateAsync(userFeedbackToApprove);
                }
            }

            return isApproved;
        }
    }
}
