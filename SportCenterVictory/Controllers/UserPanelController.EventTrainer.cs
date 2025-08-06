namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.TrainerVM;

    using SCV.GlCommon;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

    public partial class UserPanelController
    {
        //--------------------Events-------------------------------

        [HttpGet]
        [Authorize(Roles = $"{RoleConstants.User},{RoleConstants.Trainer}")]
        public async Task<IActionResult> JoinedEvents()
        {
            try
            {
                string? userId = this.GetUserId();

                if (userId == null)
                {
                    return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
                }

                IEnumerable<EventUserDetailViewModel> eventUserList = await this.eventUserService
                                .GetEventUserListAsync(userId);

                foreach (EventUserDetailViewModel eventUserVM in eventUserList)
                {
                    eventUserVM.IsUserJoined = await this.eventUserService
                        .IsUserAddedToEventList(eventUserVM.EventId, this.GetUserId());
                }

                return View(eventUserList);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while loading events for User with ID: {this.GetUserId()}. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> JoinEvent(string? eventId, string? returnUrl)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (eventId == null)
                {
                    this.logger.LogWarning($"Error occurred while joining event with Id: {eventId} by user with ID: {userId}.");

                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(JoinedEvents));
                }

                bool isEventJoinedByUser = await this.eventUserService
                                      .AddUserToEvent(eventId, userId);

                if (isEventJoinedByUser == false)
                {
                    this.logger.LogWarning($"Error occurred in the service method while joining event with ID: {eventId} by user with Id: {userId}.");

                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(JoinedEvents));
                }

                TempData[SuccessMessageKey] = SuccessMessageJoinedEvent;

                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return this.RedirectToAction(nameof(JoinedEvents));
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while joining event with Id: {eventId} by user with ID: {this.GetUserId()}. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.User},{RoleConstants.Trainer}")]
        public async Task<IActionResult> RemoveEvent(string? eventId, string? returnUrl)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (eventId == null)
                {
                    this.logger.LogWarning($"Error occurred while removing event with Id: {eventId} by user with ID: {userId}.");

                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(JoinedEvents));
                }

                bool isRemovedUserFromEvent = await this.eventUserService
                                     .RemoveUserFromEventAsync(eventId, userId);

                if (isRemovedUserFromEvent == false)
                {
                    this.logger.LogWarning($"Error occurred in the service method while removing event with ID: {eventId} by user with Id: {userId}.");

                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(JoinedEvents));
                }

                TempData[SuccessMessageKey] = SuccessRemovedJoinedEvent;

                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return this.RedirectToAction(nameof(JoinedEvents));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while removing event with Id: {eventId} by user with ID: {this.GetUserId()}. Error: {e.Message}.");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        //----------------------Trainers-----------------------------------

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> FavoriteTrainers()
        {
            try
            {
                string? userId = this.GetUserId();

                if (userId == null)
                {
                    return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
                }

                IEnumerable<TrainerUserDetailViewModel> trainerUserList = await this.trainerUserService
                    .GetTrainerUserListAsync(userId);

                foreach (TrainerUserDetailViewModel trainerUserVM in trainerUserList)
                {
                    trainerUserVM.IsAddedToFavorite = await this.trainerUserService
                        .IsTrainerAddedToUserList(trainerUserVM.TrainerId, userId);
                }

                return View(trainerUserList);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while loading Favorite Trainers from user with ID: {this.GetUserId()}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainer(string? trainerId, string? returnUrl)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (trainerId == null)
                {
                    this.logger.LogWarning($"Error occurred while adding trainer with Id: {trainerId} by user with ID: {userId}.");

                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(FavoriteTrainers));
                }

                bool isTrainerAddedByUser = await this.trainerUserService
                                      .AddUserToTrainer(trainerId, userId);

                if (isTrainerAddedByUser == false)
                {
                    this.logger.LogWarning($"Error occurred in the service methods while adding trainer with Id: {trainerId} by user with ID: {userId}.");

                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(FavoriteTrainers));
                }

                TempData[SuccessMessageKey] = SuccessMessageJoinedTrainer;

                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return this.RedirectToAction(nameof(FavoriteTrainers));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while adding trainer with Id: {trainerId} by user with ID: {this.GetUserId()}. Exception: {e.Message}.");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTrainer(string? trainerId, string? returnUrl)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (trainerId == null)
                {
                    this.logger.LogWarning($"Error occurred while removing trainer with Id: {trainerId} by user with ID: {userId}.");

                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(FavoriteTrainers));
                }

                bool isRemovedTrainerFromUser = await this.trainerUserService
                                     .RemoveTrainerFromUserAsync(trainerId, userId);

                if (isRemovedTrainerFromUser == false)
                {
                    this.logger.LogWarning($"Error occurred in the service method while c removing trainer with Id: {trainerId} by user with ID: {userId}.");

                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(FavoriteTrainers));
                }
                TempData[SuccessMessageKey] = SuccessMessageRemovedTrainer;

                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return this.RedirectToAction(nameof(FavoriteTrainers));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while removing trainer with Id: {trainerId} by user with ID: {this.GetUserId()}. Error: {e.Message}.");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }
    }
}
