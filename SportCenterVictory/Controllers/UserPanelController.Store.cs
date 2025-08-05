namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.StoreVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

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
                    return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
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
                this.logger.LogError($"Error occurred while loading purchased Memberships from user with ID: {this.GetUserId()}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                    this.logger.LogWarning($"Error occurred while purchasing Memberships with ID: {membershipId}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(PurchasedMemberships));
                }

                bool isMembershipJoinedByUser = await this.membershipUserService
                                      .AddUserToMembership(membershipId, userId);

                if (isMembershipJoinedByUser == false)
                {
                    this.logger.LogWarning($"Error occurred in the service methods while purchasing Memberships with ID: {membershipId} by user with ID: {this.GetUserId()}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(PurchasedMemberships));
                }

                return this.RedirectToAction(nameof(PurchasedMemberships));
            }
            catch (Exception e)
            {

                this.logger.LogError($"Error occurred while purchasing Memberships with ID: {membershipId} by user with ID: {this.GetUserId()}. Error: {e.Message}.");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                    this.logger.LogWarning($"Error occurred while removing Memberships with ID: {membershipId}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(PurchasedMemberships));
                }

                bool isRemovedUserFromMembership = await this.membershipUserService
                                        .RemoveUserFromMembershipAsync(membershipId, userId);

                if (isRemovedUserFromMembership == false)
                {
                    this.logger.LogWarning($"Error occurred in the service methods while removing Membersips with ID: {membershipId} by user with ID: {this.GetUserId()}.");
                    TempData[ErrorMessageKey] = ErrorMessageBaseSomethingWentWrong;
                    return this.RedirectToAction(nameof(PurchasedMemberships));
                }

                return this.RedirectToAction(nameof(PurchasedMemberships));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while removing Memberships with ID: {membershipId} by user with ID: {this.GetUserId()}. Error: {e.Message}.");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                    return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
                }

                IEnumerable<OrderDetailViewModel> orders = await this.orderService
                                    .GetUserPastOrdersAsync(userId);
                return View(orders);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while loading order by user with ID: {this.GetUserId()}. Error: {e.Message}.");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }
    }
}
