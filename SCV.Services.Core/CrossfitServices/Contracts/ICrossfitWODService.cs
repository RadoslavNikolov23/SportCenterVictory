namespace SCV.Services.Core.CrossfitServices.Contracts
{
    using SCV.Web.ViewModels.CrossfitVM;

    public interface ICrossfitWODService
    {
        Task<CrossfitWODViewModel?> GetCrossfitWODByIdAsync(string id);

        Task<CrossfitWODViewModel?> GetLatestCrossfitWODAsync();

        Task<IEnumerable<CrossfitWODViewModel>> GetAllCrossfitWODAsync();

    }
}
