namespace SCV.Services.Core.Contracts
{
    using SCV.Web.ViewModels.ContactVM;

    public interface IEmailService
    {
        Task<bool> SendContactEmailAsync(ContactFormViewModel model);
    }
}
