namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.Administration.CrossfitClassesVM;
    using SCV.Web.ViewModels.CrossfitVM;

    public interface ICrossfitClassService
    {
        Task<IEnumerable<CrossfitClassDetailViewModel>> GetAllCrossfitClassesAsync();

        Task<bool> AddCrossfitClassAsync(CrossfitClassAddViewModel crossfitClassAddVM);

    }
}
