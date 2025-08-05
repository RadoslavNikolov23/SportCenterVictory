namespace SCV.Services.Core.TrainerServices.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.Administration.TrainerBioVM;
    using SCV.Web.ViewModels.TrainerVM;

    public interface ITrainerService
    {
        Task<IEnumerable<TrainerDetailViewModel>> GetAllTrainerBySpecialtiesAsync(SportType trainerSpecialty);

        Task<IEnumerable<TrainerAdminDetailViewModel>> GetAllTrainersForAdminAsync();

        Task<bool> AddTrainerBioAsync(TrainerBioAddViewModel trainerBioToAddVM);

        Task<TrainerBioEditViewModel?> GetTrainerBioByIdAsync(string? id);

        Task<bool> EditTrainerBioAsync(TrainerBioEditViewModel trainerBioEditVM, string userId);

        Task<IEnumerable<TrainerBioDeleteViewModel>> GetAllTrainerBiosForDeletingAsync();

        Task<(bool, bool)> DeleteOrRestoreTrainerBioAsync(string? id);
    }
}
