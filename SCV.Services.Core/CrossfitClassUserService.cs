namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CrossfitVM;
    using SCV.GlCommon.Enums;

    public class CrossfitClassUserService : ICrossfitClassUserService
    {
        private readonly ICrossfitClassUserRepository crossfitClassUserRepo;

        public CrossfitClassUserService(ICrossfitClassUserRepository crossfitUserRepo)
        {
            this.crossfitClassUserRepo = crossfitUserRepo;
        }


        public async Task<IEnumerable<CrossfitClassUserDetailViewModel>> GetCrossfitClassUserListAsync(string userId)
        {
            IEnumerable<CrossfitClassUserDetailViewModel> crossfitClassUserList = await this.crossfitClassUserRepo
                .GetAllAttached()
                .Include(ccu => ccu.CrossfitClass)
                .AsNoTracking()
                .Where(ccu => ccu.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .Select(ccu => new CrossfitClassUserDetailViewModel()
                {
                    CrossfitClassId = ccu.CrossfitClassId.ToString(),
                    Name = ccu.CrossfitClass.Name,
                    //!!!!- Think this is string
                    StartTime = ccu.CrossfitClass.StartTime,
                    //See to use the one from the Gl.Common enum not the system one!!!
                    DayOfWeek = ccu.CrossfitClass.DayOfWeek,
                    TrainerName = ccu.CrossfitClass.TrainerName
                })
                .ToArrayAsync();

            return crossfitClassUserList;
        }

        public async Task<bool> AddUserToCrossfitClass(string? crossfitClassId, string userId)
        {
            bool result = false;

            if (crossfitClassId != null && userId != null)
            {
                bool isCrossfitClassIdValid = Guid.TryParse(crossfitClassId, out Guid crossfitClassGuid);

                bool isUserIdValid = Guid.TryParse(userId, out Guid userGuid);

                if (isCrossfitClassIdValid && isUserIdValid)
                {
                    CrossfitClassUser? crossfitClassUserEntity = await this.crossfitClassUserRepo
                        .GetAllAttached()
                        .IgnoreQueryFilters()
                        .SingleOrDefaultAsync(ccu =>
                                               ccu.ApplicationUserId.ToString().ToLower() == userId
                                            && ccu.CrossfitClassId.ToString() == crossfitClassGuid.ToString());

                    if (crossfitClassUserEntity != null)
                    {
                        crossfitClassUserEntity.IsActive = true;
                        crossfitClassUserEntity.JoinedAt = DateTime.UtcNow;
                        result = await this.crossfitClassUserRepo
                                                    .UpdateAsync(crossfitClassUserEntity);
                    }
                    else
                    {
                        crossfitClassUserEntity = new CrossfitClassUser()
                        {
                            ApplicationUserId = userGuid,
                            CrossfitClassId = crossfitClassGuid,
                            JoinedAt = DateTime.UtcNow,
                        };

                        await this.crossfitClassUserRepo.AddAsync(crossfitClassUserEntity);
                        result = true;
                    }
                }
            }

            return result;
        }

        public async Task<bool> RemoveUserFromCrossfitClassAsync(string? crossfitClassId, string? userId)
        {
            bool result = false;

            if (crossfitClassId != null && userId != null)
            {
                bool isCrossfitClassIdValid = Guid.TryParse(crossfitClassId, out Guid crossfitClassGuid);

                if (isCrossfitClassIdValid)
                {
                    CrossfitClassUser? crossfitClassUserEntry = await this.crossfitClassUserRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(ccu => ccu.ApplicationUserId.ToString().ToLower() == userId && ccu.CrossfitClassId.ToString() == crossfitClassGuid.ToString());

                    if (crossfitClassUserEntry != null)
                    {
                        crossfitClassUserEntry.IsActive = false;
                        crossfitClassUserEntry.JoinedAt = new DateTime();

                        //Maybe make DeleteAsync to -> SoftDeleteAsync
                        result = await this.crossfitClassUserRepo.DeleteAsync(crossfitClassUserEntry);
                    }
                }
            }

            return result;
        }

        public async Task<bool> IsUserAddedToCrossfitClassList(string? crossfitClassId, string? userId)
        {
            bool result = false;

            if (crossfitClassId != null && userId != null)
            {
                bool isCrossfitClassIdValid = Guid.TryParse(crossfitClassId, out Guid crossfitClassGuid);

                if (isCrossfitClassIdValid)
                {
                    CrossfitClassUser? crossfitClassUserEntry = await this.crossfitClassUserRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(ccu => (ccu.ApplicationUserId.ToString().ToLower() == userId && ccu.CrossfitClassId.ToString() == crossfitClassGuid.ToString())
                                     && ccu.IsActive == true);

                    if (crossfitClassUserEntry != null)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
