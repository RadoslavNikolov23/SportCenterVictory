namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.EventVM;
    using SCV.Web.ViewModels.CommonVM;

    using static SCV.GlCommon.ApplicationConstants;

    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepo;

        public EventService(IEventRepository eventRepo)
        {
            this.eventRepo = eventRepo;
        }

        public async Task<IEnumerable<EventDetailViewModel>> GetAllEventByEventTypeAsync(SportType eventType)
        {
            IEnumerable<EventDetailViewModel> eventVM = await this.eventRepo
                            .GetAllAttached()
                            .AsNoTracking()
                            .Where(e => e.EventType == eventType)
                            .Select(e => new EventDetailViewModel()
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

        public async Task<IEnumerable<EventAdminDetailViewModel>> GetAllEventForAdminAsync()
        {
            IEnumerable<EventAdminDetailViewModel> eventsAdminDetailVM = await this.eventRepo
                                                    .GetAllAttached()
                                                    .AsNoTracking()
                                                    .IgnoreQueryFilters()
                                                    .Select(e => new EventAdminDetailViewModel()
                                                    {
                                                        Id = e.Id.ToString(),
                                                        Title = e.Title,
                                                    })
                                                    .ToListAsync();

            return eventsAdminDetailVM;

        }

        public async Task<bool> AddEventAsync(EventAddViewModel crossfitClassAddVM)
        {
            bool isAdded = false;

            if (crossfitClassAddVM != null)
            {
                Event eventToAdd = new Event
                {
                    Title = crossfitClassAddVM.Title,
                    EventType = crossfitClassAddVM.EventType,
                    Description = crossfitClassAddVM.Description,
                    StartDate = crossfitClassAddVM.StartDate,
                    Location = crossfitClassAddVM.Location,
                    ImageUrl = crossfitClassAddVM.ImageUrl
                };

                await this.eventRepo.AddAsync(eventToAdd);
                isAdded = true;
            }

            return isAdded;
        }

        public async Task<EventEditViewModel?> GetEventByIdAsync(string? id)
        {
            EventEditViewModel? eventEditVM = null;

            if (!string.IsNullOrEmpty(id))
            {
                Event? eventEntity = await this.eventRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(cc => cc.Id.ToString().ToLower() == id.ToLower());

                if (eventEntity != null)
                {
                    eventEditVM = new EventEditViewModel()
                    {
                        Title = eventEntity.Title,
                        EventType = eventEntity.EventType,
                        Description = eventEntity.Description,
                        StartDate = eventEntity.StartDate,
                        Location = eventEntity.Location,
                        ImageUrl = eventEntity.ImageUrl
                    };
                }
            }

            return eventEditVM;
        }

        public async Task<bool> EditEventAsync(EventEditViewModel eventEditVM)
        {
            bool isEdited = false;

            if (eventEditVM == null)
            {
                return isEdited;
            }

            Event? eventEntity = await this.eventRepo
                                        .GetAllAttached()
                                        .IgnoreQueryFilters()
                                        .SingleOrDefaultAsync(cc => cc.Id.ToString().ToLower() == eventEditVM.Id.ToLower());

            if (eventEntity != null)
            {
                eventEntity.Title = eventEditVM.Title;
                eventEntity.EventType = eventEditVM.EventType;
                eventEntity.Description = eventEditVM.Description;
                eventEntity.StartDate = eventEditVM.StartDate;
                eventEntity.Location = eventEditVM.Location;
                eventEntity.ImageUrl = eventEditVM.ImageUrl;

                isEdited = await this.eventRepo
                                        .UpdateAsync(eventEntity);
            }

            return isEdited;
        }
        public async Task<IEnumerable<EventDeleteViewModel>> GetAllEventForDeletingAsync()
        {
            IEnumerable<EventDeleteViewModel> listEventsDeleteVM = await this.eventRepo
                                                    .GetAllAttached()
                                                    .AsNoTracking()
                                                    .IgnoreQueryFilters()
                                                    .Select(e => new EventDeleteViewModel()
                                                    {
                                                        Id = e.Id.ToString(),
                                                        Title = e.Title,
                                                        EventType = e.EventType,
                                                        IsDeleted = e.IsDeleted
                                                    })
                                                    .ToListAsync();

            return listEventsDeleteVM;

        }
        public async Task<(bool, bool)> DeleteOrRestoreEventAsync(string? id)
        {
            bool result = false;
            bool isRestored = false;

            if (!String.IsNullOrWhiteSpace(id))
            {
                Event? eventEntity = await this.eventRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToLower());

                if (eventEntity != null)
                {
                    if (!eventEntity.IsDeleted)
                    {
                        isRestored = true;
                    }

                    eventEntity.IsDeleted = !eventEntity.IsDeleted;

                    result = await this.eventRepo
                                    .UpdateAsync(eventEntity);
                }
            }

            return (result, isRestored);

        }
    }
}
