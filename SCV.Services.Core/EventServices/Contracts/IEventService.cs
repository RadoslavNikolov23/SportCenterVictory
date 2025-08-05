namespace SCV.Services.Core.EventServices.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.Administration.EventVM;
    using SCV.Web.ViewModels.CommonVM;

    public interface IEventService
    {
        Task<IEnumerable<EventDetailViewModel>> GetAllEventByEventTypeAsync(SportType eventType);

        Task<IEnumerable<EventAdminDetailViewModel>> GetAllEventForAdminAsync();

        Task<bool> AddEventAsync(EventAddViewModel crossfitClassAddVM);

        Task<EventEditViewModel?> GetEventByIdAsync(string? id);

        Task<bool> EditEventAsync(EventEditViewModel eventEditVM);

        Task<IEnumerable<EventDeleteViewModel>> GetAllEventForDeletingAsync();

        Task<(bool, bool)> DeleteOrRestoreEventAsync(string? id);

    }
}
