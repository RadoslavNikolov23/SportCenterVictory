namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.TrainerVM;

    public class TrainerUserService : ITrainerUserService
    {

        private readonly ITrainerUserRepository trainerUserRepo;

        public TrainerUserService(ITrainerUserRepository trainerUserRepo)
        {
            this.trainerUserRepo = trainerUserRepo;
        }


        public async Task<IEnumerable<TrainerUserDetailViewModel>> GetTrainerUserListAsync(string userId)
        {
            IEnumerable<TrainerUserDetailViewModel> trainerUserList = await this.trainerUserRepo
                .GetAllAttached()
                .Include(tu => tu.Trainer)
                .AsNoTracking()
                .Where(tu => tu.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .Select(tu => new TrainerUserDetailViewModel()
                {
                    TrainerId = tu.TrainerId.ToString(),
                    FirstName = tu.Trainer.FirstName,
                    LastName = tu.Trainer.LastName,
                    Email = tu.Trainer.Email,
                    TrainerSpecialty = tu.Trainer.TrainerSpecialty,
                    ImageUrl = tu.Trainer.ImageUrl
                })
                .ToArrayAsync();

            return trainerUserList;
        }

        public async Task<IEnumerable<TrainerClientListViewModel>> AllClientsTrainerListAsync(string userId)
        {
            IEnumerable<TrainerClientListViewModel> clientsTrainerList = await this.trainerUserRepo
                .GetAllAttached()
                .Include(tu => tu.ApplicationUser)
                .Include(tu => tu.Trainer)
                .AsNoTracking()
                .Where(tu => tu.Trainer!.ApplicationUserId!.ToString()!.ToLower() == userId.ToLower())
                .Select(tu => new TrainerClientListViewModel()
                {
                    UserName = tu.ApplicationUser!.UserName!,
                    FullName = tu.ApplicationUser.FullName,
                })
                .ToListAsync();

            return clientsTrainerList;
        }

        public async Task<bool> AddUserToTrainer(string? trainerId, string userId)
        {
            bool result = false;

            if (trainerId != null && userId != null)
            {
                bool isTrainerIdValid = Guid.TryParse(trainerId, out Guid trainerGuid);
                bool isUserIdValid = Guid.TryParse(userId, out Guid userGuid);


                if (isTrainerIdValid && isUserIdValid)
                {
                    TrainerUser? trainerUserEntity = await this.trainerUserRepo
                        .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(tu =>
                                               tu.ApplicationUserId.ToString().ToLower() == userId
                                            && tu.TrainerId.ToString() == trainerGuid.ToString());

                    if (trainerUserEntity != null)
                    {
                        trainerUserEntity.IsDeleted = false;
                        result = await this.trainerUserRepo
                                                    .UpdateAsync(trainerUserEntity);
                    }
                    else
                    {
                        trainerUserEntity = new TrainerUser()
                        {
                            ApplicationUserId = userGuid,
                            TrainerId = trainerGuid,
                        };

                        await this.trainerUserRepo.AddAsync(trainerUserEntity);
                        result = true;
                    }
                }
            }

            return result;
        }

        public async Task<bool> RemoveTrainerFromUserAsync(string? trainerId, string? userId)
        {
            bool result = false;

            if (trainerId != null && userId != null)
            {
                bool isTrainerIdValid = Guid.TryParse(trainerId, out Guid trainerGuid);

                if (isTrainerIdValid)
                {
                    TrainerUser? trainerUserEntry = await this.trainerUserRepo
                        .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(tu => tu.ApplicationUserId.ToString().ToLower() == userId.ToLower() 
                        && tu.TrainerId.ToString().ToLower() == trainerGuid.ToString().ToLower());
                    
                    if (trainerUserEntry != null)
                    {
                        trainerUserEntry.IsDeleted = true;

                        result = await this.trainerUserRepo.DeleteAsync(trainerUserEntry);
                    }
                }
            }

            return result;
        }

        public async Task<bool> IsTrainerAddedToUserList(string? trainerId, string? userId)
        {
            bool result = false;

            if (trainerId != null && userId != null)
            {
                bool isTrainerIdValid = Guid.TryParse(trainerId, out Guid trainerGuid);
                if (isTrainerIdValid)
                {
                    TrainerUser? trainerUserEntry = await this.trainerUserRepo
                        .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(tu => (tu.ApplicationUserId.ToString().ToLower() == userId.ToLower()
                        && tu.TrainerId.ToString().ToLower() == trainerGuid.ToString().ToLower())
                        && tu.IsDeleted == false);

                    if (trainerUserEntry != null)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public async Task<IEnumerable<TrainerUserForAdminListViewModel>> ForAdminTrainerClientsListAsync()
        {
            IEnumerable<TrainerUserForAdminListViewModel> clientsTrainerList = await this.trainerUserRepo
                .GetAllAttached()
                .Include(tu => tu.ApplicationUser)
                .Include(tu => tu.Trainer)
                .AsNoTracking()
                .OrderBy(tu => tu.Trainer.TrainerSpecialty)
                .ThenBy(tu => tu.Trainer.FirstName)
                .Select(tu => new TrainerUserForAdminListViewModel()
                {
                    ClientEmail = tu.ApplicationUser!.Email!,
                    ClientFullName = tu.ApplicationUser.FullName,
                    TrainerFullName = $"{tu.Trainer.FirstName} {tu.Trainer.LastName}",
                    TrainerEmail = tu.Trainer.Email,
                    TrainerSpecialty = tu.Trainer.TrainerSpecialty
                })
                .ToListAsync();

            return clientsTrainerList;
        }

    }
}
