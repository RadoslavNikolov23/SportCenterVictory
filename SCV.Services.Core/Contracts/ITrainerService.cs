namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.CommonVM;

    public interface ITrainerService
    {
        Task<IEnumerable<TrainerDetailViewModel>> GetAllTrainerBySpecialtiesAsync(SportType trainerSpecialty); 
    }
}
