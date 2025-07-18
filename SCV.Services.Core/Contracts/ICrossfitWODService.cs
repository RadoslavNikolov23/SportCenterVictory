namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.CrossfitVM;

    public interface ICrossfitWODService
    {
        Task<CrossfitWODViewModel?> GetLatestCrossfitWODAsync();

    }
}
