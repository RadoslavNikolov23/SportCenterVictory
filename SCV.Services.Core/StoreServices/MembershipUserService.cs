namespace SCV.Services.Core.StoreServices
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.CommonVM;

    using static SCV.GlCommon.ApplicationConstants;

    public class MembershipUserService : IMembershipUserService
    {

        private readonly IMembershipUserRepository membershipUserRepo;

        public MembershipUserService(IMembershipUserRepository membershipUserRepo)
        {
            this.membershipUserRepo = membershipUserRepo;
        }


        public async Task<IEnumerable<MembershipUserDetailViewModel>> GetMembershipUserListAsync(string userId)
        {
            IEnumerable<MembershipUserDetailViewModel> membershipUserList = await membershipUserRepo
                .GetAllAttached()
                .Include(mu => mu.Membership)
                .AsNoTracking()
                .Where(mu => mu.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .Select(mu => new MembershipUserDetailViewModel()
                {
                    MembershipId = mu.MembershipId.ToString(),
                    Name = mu.Membership.Name,
                    MembershipType = mu.Membership.MembershipType,
                    DurationText = mu.Membership.DurationText,
                    PurchasedOn = mu.PurchasedOn.ToString(DateOnlyFormat),
                })
                .ToArrayAsync();

            return membershipUserList;
        }

        public async Task<bool> AddUserToMembership(string? membershipId, string userId)
        {
            bool result = false;

            if (membershipId != null && userId != null)
            {
                bool isMembershipIdValid = Guid.TryParse(membershipId, out Guid membershipGuid);
                bool isUserIdValid = Guid.TryParse(userId, out Guid userGuid);

                if (isMembershipIdValid && isUserIdValid)
                {
                    MembershipUser? membershipUserEntity = await membershipUserRepo
                        .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(mu => mu.ApplicationUserId.ToString().ToLower() == userId.ToLower()
                       && mu.MembershipId.ToString().ToLower() == membershipGuid.ToString().ToLower());

                    if (membershipUserEntity != null && !CanBeRemoved(membershipUserEntity.PurchasedOn))
                    {
                        membershipUserEntity.IsDeleted = false;
                        membershipUserEntity.PurchasedOn = DateTime.UtcNow;
                        result = await membershipUserRepo
                                                    .UpdateAsync(membershipUserEntity);
                    }
                    else
                    {
                        membershipUserEntity = new MembershipUser()
                        {
                            ApplicationUserId = userGuid,
                            MembershipId = membershipGuid,
                            PurchasedOn = DateTime.UtcNow,
                        };

                        await membershipUserRepo.AddAsync(membershipUserEntity);
                        result = true;
                    }
                }
            }

            return result;
        }

        public async Task<bool> RemoveUserFromMembershipAsync(string? membershipId, string? userId)
        {
            bool result = false;

            if (membershipId != null && userId != null)
            {
                bool isMembershipIdValid = Guid.TryParse(membershipId, out Guid membershipGuid);

                if (isMembershipIdValid)
                {
                    MembershipUser? membershipUserEntry = await membershipUserRepo
                        .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(mu => mu.ApplicationUserId.ToString().ToLower() == userId.ToLower() 
                       && mu.MembershipId.ToString().ToLower() == membershipGuid.ToString().ToLower());

                    if (membershipUserEntry != null)
                    {
                        if (CanBeRemoved(membershipUserEntry.PurchasedOn))
                        {
                            membershipUserEntry.IsDeleted = true;
                            membershipUserEntry.PurchasedOn = new DateTime();

                            result = await membershipUserRepo.DeleteAsync(membershipUserEntry);
                        }
                    } 
                }
            }

            return result;
        }

        public async Task<bool> IsUserAddedToMembershipList(string? membershipId, string? userId)
        {
            bool result = false;

            if (membershipId != null && userId != null)
            {
                bool isMembershipIdValid = Guid.TryParse(membershipId, out Guid membershipGuid);

                if (isMembershipIdValid)
                {
                    MembershipUser? membershipUserEntry = await membershipUserRepo
                        .GetAllAttached()
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(mu =>mu.ApplicationUserId.ToString().ToLower() == userId.ToLower()
                       && mu.MembershipId.ToString().ToLower() == membershipGuid.ToString().ToLower()
                       && mu.IsDeleted == false);

                    if (membershipUserEntry != null)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public async Task<IEnumerable<UserMembershipForAdminListViewModel>> ForAdminMembershipClientsListAsync()
        {
            IEnumerable<UserMembershipForAdminListViewModel> clientsMembershipList = await membershipUserRepo
                .GetAllAttached()
                .Include(mu => mu.ApplicationUser)
                .Include(mu => mu.Membership)
                .AsNoTracking()
                .OrderBy(mu => mu.Membership.MembershipType)
                .ThenBy(mu => mu.ApplicationUser.FullName)
                .Select(mu => new UserMembershipForAdminListViewModel()
                {
                    ClientEmail = mu.ApplicationUser!.Email!,
                    ClientFullName = mu.ApplicationUser.FullName,
                    MembershipName = mu.Membership.Name,
                    MembershipType = mu.Membership.MembershipType,
                    PurchaseDate = mu.PurchasedOn.ToString(DateOnlyFormat)
                })
                .ToListAsync();

            return clientsMembershipList;
        }

        public async Task<bool> CanUserRemovedIt(string? membershipId, string? userId)
        {
            bool result = false;

            if (membershipId != null && userId != null)
            {
                bool isMembershipIdValid = Guid.TryParse(membershipId, out Guid membershipGuid);

                if (isMembershipIdValid)
                {
                    MembershipUser? membershipUserEntry = await membershipUserRepo
                        .GetAllAttached()
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(mu => mu.ApplicationUserId.ToString().ToLower() == userId.ToLower()
                       && mu.MembershipId.ToString().ToLower() == membershipGuid.ToString().ToLower()
                       && mu.IsDeleted == false);

                    if (membershipUserEntry != null && CanBeRemoved(membershipUserEntry.PurchasedOn))
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public async Task<bool> IsExpired(string? membershipId, string? userId)
        {
            bool result = false;

            if (membershipId != null && userId != null)
            {
                bool isMembershipIdValid = Guid.TryParse(membershipId, out Guid membershipGuid);

                if (isMembershipIdValid)
                {
                    MembershipUser? membershipUserEntry = await membershipUserRepo
                        .GetAllAttached()
                        .Include(mu=>mu.Membership)
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(mu => mu.ApplicationUserId.ToString().ToLower() == userId.ToLower()
                       && mu.MembershipId.ToString().ToLower() == membershipGuid.ToString().ToLower()
                       && mu.IsDeleted == false);

                    if (membershipUserEntry != null && IsExpired(membershipUserEntry.PurchasedOn, membershipUserEntry.Membership.Duration))
                    {
                        membershipUserEntry.IsDeleted = true;

                        await this.membershipUserRepo.UpdateAsync(membershipUserEntry);
                        result = true;
                    }
                }
            }

            return result;
        }

        private static bool CanBeRemoved(DateTime inputDateTime)
        {
            return (DateTime.UtcNow - inputDateTime).TotalDays <= 14;
        }

        private static bool IsExpired(DateTime purchasedOn, int durationInDays)
        {
            return DateTime.UtcNow > purchasedOn.AddDays(durationInDays);
        }

    }
}
