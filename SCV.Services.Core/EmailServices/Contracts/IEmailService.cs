namespace SCV.Services.Core.EmailServices.Contracts
{
    using SCV.Web.ViewModels.ContactVM;

    public interface IEmailService
    {
        Task<bool> SendContactEmailAsync(ContactFormViewModel model);
    }
}
