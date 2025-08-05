namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.GlCommon.Enums;
    using SCV.Services.Core.EventServices.Contracts;
    using SCV.Web.ViewModels.Administration.EventVM;
    using SCV.Web.ViewModels.Administration.ReferenceVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.RoleConstants;
    using static SCV.GlCommon.ToastMessages;

    public class EventController : BaseAdminController<EventController>
    {
        private readonly IEventService eventService;
        private readonly IEventUserService eventUserService;

        public EventController(IEventService eventService, IEventUserService eventUserService, ILogger<EventController> logger) : base(logger)
        {
            this.eventService = eventService;
            this.eventUserService = eventUserService;
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public IActionResult AddEvent()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> AddEvent(EventAddViewModel eventAddVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, SomethingWentWrong);

                    return this.View(eventAddVM);
                }

                bool isAddedSuccessfully = await this.eventService
                                                        .AddEventAsync(eventAddVM);

                if (!isAddedSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred in the service methods while adding an Event.");
                    TempData[ErrorMessageKey] = ErrorMessageCannotCreateEvent;

                    return View(eventAddVM);
                }


                TempData[SuccessMessageKey] = SuccessMessageAddEvent;

                switch (eventAddVM.EventType)
                {
                    case SportType.Fitness:
                        return RedirectToAction("FitnessEvents", "Fitness");
                    case SportType.CrossFit:
                        return RedirectToAction("CrossfitEvents", "Crossfit");
                    case SportType.Powerlifting:
                        return RedirectToAction("PowerliftingEvents", "Powerlifting");
                    default:
                        return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while adding Event. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditEvent()
        {
            try
            {
                IEnumerable<EventAdminDetailViewModel> eventAdminDetailVM = await this.eventService
                                                        .GetAllEventForAdminAsync();

                return this.View(eventAdminDetailVM);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while edditing Event. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEvent(string? id)
        {
            try
            {
                EventEditViewModel? eventEditVM = await this.eventService
                                                        .GetEventByIdAsync(id);

                if (eventEditVM == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = ErrorMessageCannotFindEvent
                    });
                }

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        id = eventEditVM.Id,
                        title = eventEditVM.Title,
                        eventType = (int)eventEditVM.EventType,
                        description = eventEditVM.Description,
                        startDate = eventEditVM.StartDate,
                        location = eventEditVM.Location,
                        imageUrl = eventEditVM.ImageUrl
                    }
                });
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while editing Event with ID:{id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(EventEditViewModel eventEditVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(eventEditVM);
                }

                await eventService.EditEventAsync(eventEditVM);

                TempData[SuccessMessageKey] = string.Format(SuccessMessageUpdateEvent, eventEditVM.Title);

                switch (eventEditVM.EventType)
                {
                    case SportType.Fitness:
                        return RedirectToAction("FitnessEvents", "Fitness");
                    case SportType.CrossFit:
                        return RedirectToAction("CrossfitEvents", "Crossfit");
                    case SportType.Powerlifting:
                        return RedirectToAction("PowerliftingEvents", "Powerlifting");
                    default:
                        return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while edditing Event with ID:{eventEditVM.Id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteEvent()
        {
            try
            {
                IEnumerable<EventDeleteViewModel> eventDeleteDetailVM = await this.eventService
                                                        .GetAllEventForDeletingAsync();

                return this.View(eventDeleteDetailVM);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while deleting Event. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }


        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> ToggleDelete(string? id)
        {
            try
            {
                (bool isSuccess, bool isRestored) opResult = await this.eventService
                                        .DeleteOrRestoreEventAsync(id);

                if (!opResult.isSuccess)
                {
                    this.logger.LogWarning($"Error occurred in the service while deleting Event with ID:{id}.");
                    TempData[ErrorMessageKey] = ErrorMessageCannotFindEvent;
                }
                else
                {
                    string operation = opResult.isRestored ? Deleted : Restored;
                    TempData[SuccessMessageKey] = string.Format(SuccessMessageDeleteEvent, operation);
                }

                return this.RedirectToAction(nameof(DeleteEvent));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while editing Event with ID:{id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> EventsAndClients()
        {
            try
            {
                IEnumerable<EventsUserForAdminListViewModel> eventUserList = await this.eventUserService
                    .ForAdminEventUsersListAsync();

                return View(eventUserList);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while trying to load all the Events with their Clients. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

    }
}
