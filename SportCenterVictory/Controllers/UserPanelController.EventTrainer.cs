namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.TrainerVM;

    using SCV.GlCommon;

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
                    return this.Forbid();
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> JoinEvent(string? eventId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (eventId == null)
                {
                    return this.RedirectToAction(nameof(JoinedEvents));
                }

                bool isEventJoinedByUser = await this.eventUserService
                                      .AddUserToEvent(eventId, userId);

                if (isEventJoinedByUser == false)
                {
                    return this.RedirectToAction(nameof(JoinedEvents), "UserPanel");
                }

                return this.RedirectToAction(nameof(JoinedEvents));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.User},{RoleConstants.Trainer}")]
        public async Task<IActionResult> RemoveEvent(string? eventId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (eventId == null)
                {
                    return this.RedirectToAction(nameof(JoinedEvents));
                }

                bool isRemovedUserFromEvent = await this.eventUserService
                                     .RemoveUserFromEventAsync(eventId, userId);

                if (isRemovedUserFromEvent == false)
                {
                    return this.RedirectToAction(nameof(JoinedEvents), "UserPanel");
                }

                return this.RedirectToAction(nameof(JoinedEvents));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
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
                    return this.Forbid();
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
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainer(string? trainerId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (trainerId == null)
                {
                    return this.RedirectToAction(nameof(FavoriteTrainers));
                }

                bool isTrainerAddedByUser = await this.trainerUserService
                                      .AddUserToTrainer(trainerId, userId);

                if (isTrainerAddedByUser == false)
                {
                    return this.RedirectToAction(nameof(FavoriteTrainers), "UserPanel");
                }

                return this.RedirectToAction(nameof(FavoriteTrainers));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTrainer(string? trainerId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (trainerId == null)
                {
                    return this.RedirectToAction(nameof(FavoriteTrainers));
                }

                bool isRemovedTrainerFromUser = await this.trainerUserService
                                     .RemoveTrainerFromUserAsync(trainerId, userId);

                if (isRemovedTrainerFromUser == false)
                {
                    return this.RedirectToAction(nameof(FavoriteTrainers), "UserPanel");
                }

                return this.RedirectToAction(nameof(FavoriteTrainers));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
