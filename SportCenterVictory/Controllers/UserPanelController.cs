namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.CrossfitVM;

    public class UserPanelController : BaseController
    {
        private readonly IEventUserService eventUserService;
        private readonly ICrossfitClassUserService crossfitClassUserService;
        private readonly IMembershipUserService membershipUserService;

        public UserPanelController(IEventUserService eventUserService, ICrossfitClassUserService crossfitClassUserService, IMembershipUserService membershipUserService)
        {
            this.eventUserService = eventUserService;
            this.crossfitClassUserService = crossfitClassUserService;
            this.membershipUserService = membershipUserService;
        }

        //-------------------UserFeedback--------------------------------------

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> LeaveFeedback()
        {
           return View();
        }


        //-------------------CrossfitClasses--------------------------------------

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> JoinedCrossfitClasses()
        {
            try
            {
                string? userId = this.GetUserId();

                if (userId == null)
                {
                    return this.Forbid();
                }

                IEnumerable<CrossfitClassUserDetailViewModel> crossfitClassUserList = await this.crossfitClassUserService.GetCrossfitClassUserListAsync(userId);

                foreach (CrossfitClassUserDetailViewModel crossfitClassUserVM in crossfitClassUserList)
                {
                    crossfitClassUserVM.IsUserJoined = await this.crossfitClassUserService
                        .IsUserAddedToCrossfitClassList(crossfitClassUserVM.CrossfitClassId, this.GetUserId());
                }

                return View(crossfitClassUserList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> JoinCrossfitClass(string? crossfitClassId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (crossfitClassId == null)
                {
                    //TODO: Redirect to the same action detail
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses));
                    //Or ad this   return this.Forbid();
                }

                bool isCrossfitClassJoinedByUser = await this.crossfitClassUserService
                                      .AddUserToCrossfitClass(crossfitClassId, userId);

                if (isCrossfitClassJoinedByUser == false)
                {
                    // TODO: Add JS notifications and fix this!
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses), "UserPanel");
                }

                // Also TODO this:
                return this.RedirectToAction(nameof(JoinedCrossfitClasses));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCrossfitClass(string? crossfitClassId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (crossfitClassId == null)
                {
                    //TODO: Redirect to the same action detail
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses));
                    //Or ad this   return this.Forbid();
                }

                bool isRemovedUserFromCrossfitClass = await this.crossfitClassUserService
                                     .RemoveUserFromCrossfitClassAsync(crossfitClassId, userId);

                if (isRemovedUserFromCrossfitClass == false)
                {
                    // If the recipe was not removed from favorites, we still redirect to the same page by default by the requirements.
                    return this.RedirectToAction(nameof(JoinedCrossfitClasses), "UserPanel");
                }

                return this.RedirectToAction(nameof(JoinedCrossfitClasses));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        //--------------------Events-------------------------------

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
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
                    //TODO: Redirect to the same action detail
                    return this.RedirectToAction(nameof(JoinedEvents));
                    //Or ad this   return this.Forbid();
                }

                bool isEventJoinedByUser = await this.eventUserService
                                      .AddUserToEvent(eventId, userId);

                if (isEventJoinedByUser == false)
                {
                    // TODO: Add JS notifications and fix this!
                    return this.RedirectToAction(nameof(JoinedEvents), "UserPanel");
                }

                // Also TODO this:
                return this.RedirectToAction(nameof(JoinedEvents));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveEvent(string? eventId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (eventId == null)
                {
                    //TODO: Redirect to the same action detail
                    return this.RedirectToAction(nameof(JoinedEvents));
                    //Or ad this   return this.Forbid();
                }

                bool isRemovedUserFromEvent = await this.eventUserService
                                     .RemoveUserFromEventAsync(eventId, userId);

                if (isRemovedUserFromEvent == false)
                {
                    // If the recipe was not removed from favorites, we still redirect to the same page by default by the requirements.
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
            return View();
        }

        //------------------------Memberships---------------------------------

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> PurchasedMemberships()
        {
            try
            {
                string? userId = this.GetUserId();

                if (userId == null)
                {
                    return this.Forbid();
                }

                IEnumerable<MembershipUserDetailViewModel> membershipUserList = await this.membershipUserService
                                                .GetMembershipUserListAsync(userId);

                foreach (MembershipUserDetailViewModel membershipUserVM in membershipUserList)
                {
                    membershipUserVM.IsPurchasedMembership = await this.membershipUserService
                        .IsUserAddedToMembershipList(membershipUserVM.MembershipId, this.GetUserId());
                }

                return View(membershipUserList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> JoinMembership(string? membershipId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (membershipId == null)
                {
                    //TODO: Redirect to the same action detail
                    return this.RedirectToAction(nameof(Index));
                    //Or ad this   return this.Forbid();
                }

                bool isMembershipJoinedByUser = await this.membershipUserService
                                      .AddUserToMembership(membershipId, userId);

                if (isMembershipJoinedByUser == false)
                {
                    // TODO: Add JS notifications and fix this!
                    return this.RedirectToAction(nameof(PurchasedMemberships), "UserPanel");
                }

                // Also TODO this:
                return this.RedirectToAction(nameof(PurchasedMemberships));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveMembership(string? membershipId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (membershipId == null)
                {
                    //TODO: Redirect to the same action detail
                    return this.RedirectToAction(nameof(PurchasedMemberships));
                    //Or ad this   return this.Forbid();
                }

                bool isRemovedUserFromMembership = await this.membershipUserService
                                        .RemoveUserFromMembershipAsync(membershipId, userId);

                if (isRemovedUserFromMembership == false)
                {
                    // If the recipe was not removed from favorites, we still redirect to the same page by default by the requirements.
                    return this.RedirectToAction(nameof(PurchasedMemberships), "UserPanel");
                }

                return this.RedirectToAction(nameof(PurchasedMemberships));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        //----------------------Orders-----------------------------------

        [HttpGet]
        [Authorize(Roles = SCV.GlCommon.RoleConstants.User)]
        public async Task<IActionResult> MadeOrders()
        {
            return View();
        }
    }
}
