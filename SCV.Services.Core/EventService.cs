namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using static SCV.GlCommon.ApplicationConstants;

    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepo;

        public EventService(IEventRepository eventRepo)
        {
            this.eventRepo = eventRepo;
        }

        public async Task<IEnumerable<EventViewModel>> GetAllEventByEventType(SportType eventType)
        {
            IEnumerable<EventViewModel> eventVM = await this.eventRepo
                            .GetAllAttached()
                            .AsNoTracking()
                            .Where(e => e.EventType == eventType)
                            .Select(e => new EventViewModel()
                            {
                                Title = e.Title,
                                EventType = e.EventType,
                                Description = e.Description,
                                StartDate = e.StartDate.ToString(DateOnlyFormat) ?? "To be announced",
                                Location = e.Location,
                                ImageUrl = e.ImageUrl ?? $"/noImage.jpg",
                            })
                            .ToListAsync();

            return eventVM;
        }
    }
}
