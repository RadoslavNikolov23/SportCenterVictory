namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.Administration.CrossfitClassesVM;
    using SCV.Web.ViewModels.CrossfitVM;

    public interface ICrossfitClassService
    {
        Task<IEnumerable<CrossfitClassDetailViewModel>> GetAllCrossfitClassesAsync();

        Task<IEnumerable<CrossfitClassAdminDetailViewModel>> GetAllCrossfitClassesForAdminAsync();

        Task<bool> AddCrossfitClassAsync(CrossfitClassAddViewModel crossfitClassAddVM);

        Task<CrossfitClassEditViewModel?> GetCrossfitClassByIdAsync(string? id);

        Task<bool> EditCrossfitClassAsync(CrossfitClassEditViewModel crossfitClassEditVM);

        Task<(bool, bool)> DeleteOrRestoreCrossfitClassAsync(string? id);

    }
}
