namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.CommonVM;

    public interface IEventService
    {
        Task<IEnumerable<EventViewModel>> GetAllEventByEventType(SportType eventType);
    }
}
