namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.StoreVM;

    public partial class UserPanelController
    {
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
            try
            {
                string? userId = this.GetUserId();

                if (userId == null)
                {
                    return this.Forbid();
                }

                IEnumerable<OrderDetailViewModel> orders = await this.orderService
                                    .GetUserPastOrdersAsync(userId);
                return View(orders);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
