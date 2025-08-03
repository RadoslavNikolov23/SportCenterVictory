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

                    membershipUserVM.CanBeRemoved = await this.membershipUserService
         .CanUserRemovedIt(membershipUserVM.MembershipId, this.GetUserId());


                    membershipUserVM.IsExpired = await this.membershipUserService
                        .IsExpired(membershipUserVM.MembershipId, this.GetUserId());
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
                    return this.RedirectToAction(nameof(Index));
                }

                bool isMembershipJoinedByUser = await this.membershipUserService
                                      .AddUserToMembership(membershipId, userId);

                if (isMembershipJoinedByUser == false)
                {
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

        [HttpPost]
        public async Task<IActionResult> RemoveMembership(string? membershipId)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (membershipId == null)
                {
                    return this.RedirectToAction(nameof(PurchasedMemberships));
                }

                bool isRemovedUserFromMembership = await this.membershipUserService
                                        .RemoveUserFromMembershipAsync(membershipId, userId);

                if (isRemovedUserFromMembership == false)
                {
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
