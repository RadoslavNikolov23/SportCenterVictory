namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.EventVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;

    public class EventController : BaseAdminController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
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
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");

                    return this.View(eventAddVM);
                }

                bool isAddedSuccessfully = await this.eventService
                                                        .AddEventAsync(eventAddVM);

                if (!isAddedSuccessfully)
                {
                    TempData[ErrorMessageKey] = "Event could not be created. Please try again.";

                    return View(eventAddVM);
                }


                TempData[SuccessMessageKey] = "Event added successfully!";

                switch(eventAddVM.EventType)
                {
                    case SportType.Fitness:
                        return RedirectToAction("FitnessEvents", "Fitness", new { area = "" });
                    case SportType.CrossFit:
                        return RedirectToAction("CrossfitEvents", "Crossfit", new { area = "" });
                    case SportType.Powerlifting:
                        return RedirectToAction("PowerliftingEvents", "Powerlifting", new { area = "" });
                    default:
                        return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while adding the Event! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditEvent()
        {
            try
            {
                IEnumerable<EventAdminDetailViewModel> evenrAdminDetailVM = await this.eventService
                                                        .GetAllEventForAdminAsync();

                return this.View(evenrAdminDetailVM);
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the Event! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
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
                        message = "Event could not be found. Please try again."
                    });
                }

                return Json(new
                {
                    success = true,
                    data = new {
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
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the Event! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(EventEditViewModel eventEditVM)
        {
            if (!ModelState.IsValid)
            {
                return View(eventEditVM);
            }

            await eventService.EditEventAsync(eventEditVM);

            TempData["Success"] = $"Event {eventEditVM.Title} updated successfully!";

            switch (eventEditVM.EventType)
            {
                case SportType.Fitness:
                    return RedirectToAction("FitnessEvents", "Fitness", new { area = "" });
                case SportType.CrossFit:
                    return RedirectToAction("CrossfitEvents", "Crossfit", new { area = "" });
                case SportType.Powerlifting:
                    return RedirectToAction("PowerliftingEvents", "Powerlifting", new { area = "" });
                default:
                    return RedirectToAction("Memberships", "Store", new { area = "" });
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
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Event! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
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
                    TempData[ErrorMessageKey] = "Event could not be found and deleted!";
                }
                else
                {
                    string operation = opResult.isRestored ? "Deleted" : "Restored";

                    TempData[SuccessMessageKey] = $"Event is {operation} successfully!";
                }

                return this.RedirectToAction(nameof(DeleteEvent));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Event! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
            }
        }

    }
}
