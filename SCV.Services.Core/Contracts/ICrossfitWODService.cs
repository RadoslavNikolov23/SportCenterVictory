namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.CrossfitVM;

    public interface ICrossfitWODService
    {
        Task<CrossfitWODViewModel?> GetCrossfitWODByIdAsync(int id);
        Task<CrossfitWODViewModel?> GetLatestCrossfitWODAsync();

        Task<IEnumerable<CrossfitWODViewModel>> GetAllCrossfitWODAsync();

    }
}
