namespace SCV.Services.Core
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.TrainerBioVM;
    using SCV.Web.ViewModels.TrainerVM;
    using static SCV.GlCommon.RoleConstants;

    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository trainerRepo;
        private readonly UserManager<ApplicationUser> userManager;

        public TrainerService(ITrainerRepository trainerRepo, UserManager<ApplicationUser> userManager)
        {
            this.trainerRepo = trainerRepo;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<TrainerDetailViewModel>> GetAllTrainerBySpecialtiesAsync(SportType trainerSpecialty)
        {
            IEnumerable<TrainerDetailViewModel> trainerVM = await this.trainerRepo
                                        .GetAllAttached()
                                        .Include(tp => tp.Memberships)
                                        .AsNoTracking()
                                        .Where(tp => tp.TrainerSpecialty == trainerSpecialty)
                                        .Select(tp => new TrainerDetailViewModel()
                                        {
                                            Id = tp.Id.ToString(),
                                            FirstName = tp.FirstName,
                                            LastName = tp.LastName,
                                            Email = tp.Email,
                                            PhoneNumber = tp.PhoneNumber ?? "n/a",
                                            Bio = tp.Bio,
                                            TrainerSpecialty = tp.TrainerSpecialty,
                                            ImageUrl = tp.ImageUrl ?? $"/noImage.jpg",

                                        })
                                        .ToListAsync();

            return trainerVM;

        }

        public async Task<IEnumerable<TrainerAdminDetailViewModel>> GetAllTrainersForAdminAsync()
        {
            IEnumerable<TrainerAdminDetailViewModel> trainersAdminDetailVM = await this.userManager
                                                                .Users
                                                                .AsNoTracking()
                                                                .Select(u => new TrainerAdminDetailViewModel
                                                                {
                                                                    Id = u.Id.ToString(),
                                                                    Email = u.Email!
                                                                })
                                                                .ToListAsync();
            return trainersAdminDetailVM;
        }

        public async Task<bool> AddTrainerBioAsync(TrainerBioAddViewModel trainerBioToAddVM)
        {
            bool isAdded = false;

            if (trainerBioToAddVM != null)
            {
                Trainer trainerToAdd = new Trainer()
                {
                    FirstName = trainerBioToAddVM.FirstName,
                    LastName = trainerBioToAddVM.LastName,
                    Email = trainerBioToAddVM.Email,
                    PhoneNumber = trainerBioToAddVM.PhoneNumber,
                    Bio = trainerBioToAddVM.Bio,
                    TrainerSpecialty = trainerBioToAddVM.TrainerSpecialty,
                    ImageUrl = trainerBioToAddVM.ImageUrl,
                    ApplicationUserId = Guid.TryParse(trainerBioToAddVM.ApplicationUserId, out Guid userId) ? userId : null,
                };

                await this.trainerRepo.AddAsync(trainerToAdd);

                isAdded = true;
            }

            return isAdded;
        }

        public async Task<TrainerBioEditViewModel?> GetTrainerBioByIdAsync(string? id)
        {
            TrainerBioEditViewModel? trainerBioForEditVM = null;

            if (!string.IsNullOrEmpty(id))
            {
                Trainer? trainerEntity = await this.trainerRepo
                    .GetAllAttached()
                    .Include(t => t.ApplicationUser)
                    .AsNoTracking()
                    .IgnoreQueryFilters()
                    .SingleOrDefaultAsync(t => t.ApplicationUserId.ToString()!.ToLower()==id.ToLower());

                if (trainerEntity != null)
                {
                    trainerBioForEditVM = new TrainerBioEditViewModel()
                    {
                        Id = trainerEntity.Id.ToString(),
                        FirstName = trainerEntity.FirstName,
                        LastName = trainerEntity.LastName,
                        Email = trainerEntity.Email,
                        PhoneNumber = trainerEntity.PhoneNumber,
                        Bio = trainerEntity.Bio,
                        TrainerSpecialty = trainerEntity.TrainerSpecialty,
                        ImageUrl = trainerEntity.ImageUrl,
                        ApplicationUserId = trainerEntity.ApplicationUserId?.ToString() ?? string.Empty
                    };
                }
            }

            return trainerBioForEditVM;
        }

        public async Task<bool> EditTrainerBioAsync(TrainerBioEditViewModel trainerBioEditVM, string userId)
        {
            bool isEdited = false;

            if (trainerBioEditVM == null || string.IsNullOrEmpty(userId))
            {
                return isEdited;
            }

            bool isAuthorizeToEdit = await CanEditTrainerBioAsync(trainerBioEditVM.Id, userId);
            if (!isAuthorizeToEdit)
            {
                return isEdited;
            }

            Trainer? trainerEntity = await this.trainerRepo
                                        .GetAllAttached()
                                        .AsNoTracking()
                                        .IgnoreQueryFilters()
                                        .SingleOrDefaultAsync(t => t.Id.ToString().ToLower() == trainerBioEditVM.Id.ToLower());

            if (trainerEntity != null)
            {
                trainerEntity.FirstName = trainerBioEditVM.FirstName;
                trainerEntity.LastName = trainerBioEditVM.LastName;
                trainerEntity.Email = trainerBioEditVM.Email;
                trainerEntity.PhoneNumber = trainerBioEditVM.PhoneNumber;
                trainerEntity.Bio = trainerBioEditVM.Bio;
                trainerEntity.TrainerSpecialty = trainerBioEditVM.TrainerSpecialty;
                trainerEntity.ImageUrl = trainerBioEditVM.ImageUrl;

                isEdited = await this.trainerRepo
                                        .UpdateAsync(trainerEntity);
            }

            return isEdited;
        }


        public async Task<IEnumerable<TrainerBioDeleteViewModel>> GetAllTrainerBiosForDeletingAsync()
        {
            IEnumerable<TrainerBioDeleteViewModel> listTrainerBiosToDelete = await this.trainerRepo
                                        .GetAllAttached()
                                        .AsNoTracking()
                                        .IgnoreQueryFilters()
                                        .Select(t => new TrainerBioDeleteViewModel()
                                        {
                                            Id = t.Id.ToString(),
                                            FirstName = t.FirstName,
                                            LastName = t.LastName,
                                            Email = t.Email,
                                            TrainerSpecialty = t.TrainerSpecialty,
                                            IsDeleted = t.IsDeleted
                                        })
                                        .ToListAsync();

            return listTrainerBiosToDelete;
        }

        public async Task<(bool, bool)> DeleteOrRestoreTrainerBioAsync(string? id)
        {
            bool result = false;
            bool isRestored = false;

            if (!String.IsNullOrWhiteSpace(id))
            {
                Trainer? trainerEntity = await this.trainerRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToLower());

                if (trainerEntity != null)
                {
                    if (!trainerEntity.IsDeleted)
                    {
                        isRestored = true;
                    }

                    trainerEntity.IsDeleted = !trainerEntity.IsDeleted;

                    result = await this.trainerRepo
                                    .UpdateAsync(trainerEntity);
                }
            }

            return (result, isRestored);
        }

        private async Task<bool> CanEditTrainerBioAsync(string trainerId, string userId)
        {
            if (string.IsNullOrEmpty(trainerId) && string.IsNullOrEmpty(userId))
            {
                return false;
            }

            ApplicationUser? user = await userManager
                                    .FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            IList<string> roles = await userManager.GetRolesAsync(user);

            if (roles.Contains(Admin) || roles.Contains(Manager))
            {
                return true;
            }

            Trainer? trainer = await trainerRepo
                                .GetAllAttached()
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .SingleOrDefaultAsync(t => t.Id.ToString().ToLower() == trainerId.ToLower());

            if (trainer == null)
            {
                return false;
            }

            return trainer.ApplicationUserId?.ToString().ToLower() == userId.ToLower();

        }

    }
}
