namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.CommonVM;

    using static SCV.GlCommon.ApplicationConstants;

    public class EventUserService : IEventUserService
    {

        private readonly IEventUserRepository eventUserRepo;

        public EventUserService(IEventUserRepository eventUserRepo)
        {
            this.eventUserRepo = eventUserRepo;
        }


        public async Task<IEnumerable<EventUserDetailViewModel>> GetEventUserListAsync(string userId)
        {
            IEnumerable<EventUserDetailViewModel> eventUserList = await this.eventUserRepo
                .GetAllAttached()
                .Include(eu=>eu.Event)
                .AsNoTracking()
                .Where(eu => eu.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .Select(eu => new EventUserDetailViewModel()
                {
                    EventId = eu.EventId.ToString(),
                    Title = eu.Event.Title,
                    EventType = eu.Event.EventType,
                    StartDate = eu.Event.StartDate.ToString(DateOnlyFormat),
                    Location = eu.Event.Location,
                    ImageUrl = eu.Event.ImageUrl
                })
                .ToArrayAsync();

            return eventUserList;
        }

        public async Task<bool> AddUserToEvent(string? eventId, string userId)
        {
            bool result = false;

            if (eventId != null && userId != null)
            {
                bool isEventIdValid = Guid.TryParse(eventId, out Guid eventGuid);
                bool isUserIdValid = Guid.TryParse(userId, out Guid userGuid);


                if (isEventIdValid && isUserIdValid)
                {
                    EventUser? eventUserEntity = await this.eventUserRepo
                        .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(eu =>
                                               eu.ApplicationUserId.ToString().ToLower() == userId
                                            && eu.EventId.ToString() == eventGuid.ToString());

                    if (eventUserEntity != null)
                    {
                        eventUserEntity.IsDeleted = false;
                        result = await this.eventUserRepo
                                                    .UpdateAsync(eventUserEntity);
                    }
                    else
                    {
                        eventUserEntity = new EventUser()
                        {
                            ApplicationUserId = userGuid,
                            EventId = eventGuid,
                        };

                        await this.eventUserRepo.AddAsync(eventUserEntity);
                        result = true;
                    }
                }
            }

            return result;
        }

        public async Task<bool> RemoveUserFromEventAsync(string? eventId, string? userId)
        {
            bool result = false;

            if (eventId != null && userId != null)
            {
                bool isEventIdValid = Guid.TryParse(eventId, out Guid eventGuid);

                if (isEventIdValid)
                {
                    EventUser? eventUserEntry = await this.eventUserRepo
                        .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(eu => eu.ApplicationUserId.ToString().ToLower() == userId.ToLower() 
                        && eu.EventId.ToString().ToLower() == eventGuid.ToString().ToLower());

                    if (eventUserEntry != null)
                    {
                        eventUserEntry.IsDeleted = true;

                        result = await this.eventUserRepo.DeleteAsync(eventUserEntry);
                    }
                }
            }

            return result;
        }

        public async Task<bool> IsUserAddedToEventList(string? eventId, string? userId)
        {
            bool result = false;

            if (eventId != null && userId != null)
            {
                bool isEventIdValid = Guid.TryParse(eventId, out Guid eventGuid);
                if (isEventIdValid)
                {
                    EventUser? eventUserEntry = await this.eventUserRepo
                        .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(eu => (eu.ApplicationUserId.ToString().ToLower() == userId.ToLower() 
                        && eu.EventId.ToString().ToLower() == eventGuid.ToString().ToLower())
                        && eu.IsDeleted == false);

                    if (eventUserEntry != null)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public async Task<IEnumerable<EventsUserForAdminListViewModel>> ForAdminEventUsersListAsync()
        {
            IEnumerable<EventsUserForAdminListViewModel> eventUserList = await this.eventUserRepo
                .GetAllAttached()
                .Include(eu => eu.ApplicationUser)
                .Include(eu => eu.Event)
                .AsNoTracking()
                .OrderBy(eu => eu.Event.EventType)
                .ThenBy(eu => eu.Event.StartDate)
                .Select(eu => new EventsUserForAdminListViewModel()
                {
                    ClientEmail = eu.ApplicationUser!.Email!,
                    ClientFullName = eu.ApplicationUser.FullName,
                    EventTitle = eu.Event.Title,
                    EventStartDate = eu.Event.StartDate.ToString(DateOnlyFormat),
                    EventLocation = eu.Event.Location,
                    EventType = eu.Event.EventType
                })
                .ToListAsync();

            return eventUserList;
        }

    }
}
