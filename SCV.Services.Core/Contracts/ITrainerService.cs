namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.Administration.TrainerBio;
    using SCV.Web.ViewModels.CommonVM;

    public interface ITrainerService
    {
        Task<IEnumerable<TrainerDetailViewModel>> GetAllTrainerBySpecialtiesAsync(SportType trainerSpecialty); 

        Task<bool> AddTrainerBioAsync(TrainerBioAddViewModel trainerBioToAddVM);

        Task<TrainerBioEditViewModel?> GetTrainerBioByIdAsync(string? id);

        Task<bool> EditTrainerBioAsync(TrainerBioEditViewModel trainerBioEditVM, string userId);

        Task<IEnumerable<TrainerBioDeleteViewModel>> GetAllTrainerBiosForDeletingAsync();

        Task<(bool, bool)> DeleteOrRestoreTrainerBioAsync(string? id);
    }
}
