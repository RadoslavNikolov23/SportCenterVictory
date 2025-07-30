namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;

    public class MembershipUserService : IMembershipUserService
    {

        private readonly IMembershipUserRepository membershipUserRepo;

        public MembershipUserService(IMembershipUserRepository membershipUserRepo)
        {
            this.membershipUserRepo = membershipUserRepo;
        }


        public async Task<IEnumerable<MembershipUserDetailViewModel>> GetMembershipUserListAsync(string userId)
        {
            IEnumerable<MembershipUserDetailViewModel> membershipUserList = await this.membershipUserRepo
                .GetAllAttached()
                .Include(mu => mu.Membership)
                .AsNoTracking()
                .Where(mu => mu.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .Select(mu => new MembershipUserDetailViewModel()
                {
                    MembershipId = mu.MembershipId.ToString(),
                    Name = mu.Membership.Name,
                    MembershipType = mu.Membership.MembershipType,
                    Duration = mu.Membership.Duration
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
                    MembershipUser? membershipUserEntity = await this.membershipUserRepo
                        .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(mu =>
                                               mu.ApplicationUserId.ToString().ToLower() == userId
                                            && mu.MembershipId.ToString() == membershipGuid.ToString());

                    if (membershipUserEntity != null)
                    {
                        membershipUserEntity.IsDeleted = false;
                        result = await this.membershipUserRepo
                                                    .UpdateAsync(membershipUserEntity);
                    }
                    else
                    {
                        membershipUserEntity = new MembershipUser()
                        {
                            ApplicationUserId = userGuid,
                            MembershipId = membershipGuid,
                        };

                        await this.membershipUserRepo.AddAsync(membershipUserEntity);
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
                    MembershipUser? membershipUserEntry = await this.membershipUserRepo
                         .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(mu => mu.ApplicationUserId.ToString().ToLower() == userId &&
                                                     mu.MembershipId.ToString() == membershipGuid.ToString());

                    if (membershipUserEntry != null)
                    {
                        membershipUserEntry.IsDeleted = true;

                        //Maybe make DeleteAsync to -> SoftDeleteAsync
                        result = await this.membershipUserRepo.DeleteAsync(membershipUserEntry);
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
                    MembershipUser? membershipUserEntry = await this.membershipUserRepo
                         .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(mu => (mu.ApplicationUserId.ToString().ToLower() == userId &&
                                                    mu.MembershipId.ToString() == membershipGuid.ToString())
                                                    && mu.IsDeleted == false);
                    if (membershipUserEntry != null)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

    }
}
