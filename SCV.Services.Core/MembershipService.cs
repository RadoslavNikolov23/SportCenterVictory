namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.EventVM;
    using SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM;
    using SCV.Web.ViewModels.CommonVM;

    public class MembershipService : IMembershipService
    {

        private readonly IMembershipRepository membershipRepo;

        public MembershipService(IMembershipRepository membershipRepo)
        {
            this.membershipRepo = membershipRepo;
        }

        public async Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipAsync()
        {
            IEnumerable<MembershipDetailViewModel> allMembershipsViewModels = await this.membershipRepo
                                    .GetAllAttached()
                                    .AsNoTracking()
                                    .OrderBy(m => m.MembershipType)
                                    .ThenBy(m => m.Price)
                                    .Select(m => new MembershipDetailViewModel()
                                    {
                                        Name = m.Name,
                                        MembershipType = m.MembershipType,
                                        Description = m.Description,
                                        Price = m.Price,
                                        Duration = m.Duration,
                                    })
                                    .ToListAsync();

            return allMembershipsViewModels;

        }

        public async Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipPerSportAsync(SportType membershipType)
        {
            IEnumerable<MembershipDetailViewModel> membershipsCollection = new List<MembershipDetailViewModel>();

            membershipsCollection = await this.membershipRepo
                        .GetAllAttached()
                        .AsNoTracking()
                        .Where(m => m.MembershipType == membershipType)
                        .OrderBy(m => m.Price)
                        .Select(m => new MembershipDetailViewModel()
                        {
                            Name = m.Name,
                            MembershipType = m.MembershipType,
                            Description = m.Description,
                            Price = m.Price,
                            Duration = m.Duration,
                        })
                        .ToListAsync();

            return membershipsCollection;

        }

        public async Task<IEnumerable<MembershipAdminDetailViewModel>> GetAllMembershipsForAdminAsync()
        {
            IEnumerable<MembershipAdminDetailViewModel> membershipAdminDetailVM = await 
                                                    this.membershipRepo
                                                    .GetAllAttached()
                                                    .AsNoTracking()
                                                    .IgnoreQueryFilters()
                                                    .Select(e => new MembershipAdminDetailViewModel()
                                                    {
                                                        Id = e.Id.ToString(),
                                                        Name = e.Name,
                                                    })
                                                    .ToListAsync();

            return membershipAdminDetailVM;

        }

        public async Task<bool> AddMembershipAsync(MembershipAddViewModel membershipAddVM)
        {
            bool isAdded = false;

            if (membershipAddVM != null)
            {
                Membership membershipToAdd = new Membership
                {
                    Name = membershipAddVM.Name,
                    MembershipType = membershipAddVM.MembershipType,
                    Description = membershipAddVM.Description,
                    Price = membershipAddVM.Price,
                    Duration = membershipAddVM.Duration,

                };

                await this.membershipRepo.AddAsync(membershipToAdd);
                isAdded = true;
            }

            return isAdded;
        }

        public async Task<MembershipEditViewModel?> GetMembershipByIdAsync(string? id)
        {
            MembershipEditViewModel? membershipEditVM = null;

            if (!string.IsNullOrEmpty(id))
            {
                Membership? membershipEntity = await this.membershipRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(cc => cc.Id.ToString().ToLower() == id.ToLower());

                if (membershipEntity != null)
                {
                    membershipEditVM = new MembershipEditViewModel()
                    {
                        Id = membershipEntity.Id.ToString(),
                        Name = membershipEntity.Name,
                        MembershipType = membershipEntity.MembershipType,
                        Description = membershipEntity.Description,
                        Price = membershipEntity.Price,
                        Duration = membershipEntity.Duration,
                    };
                }
            }

            return membershipEditVM;
        }

        public async Task<bool> EditMembershipAsync(MembershipEditViewModel membershipEditVM)
        {
            bool isEdited = false;

            if (membershipEditVM == null)
            {
                return isEdited;
            }

            Membership? membershipEntity = await this.membershipRepo
                                        .GetAllAttached()
                                        .IgnoreQueryFilters()
                                        .SingleOrDefaultAsync(cc => cc.Id.ToString().ToLower() == membershipEditVM.Id.ToLower());

            if (membershipEntity != null)
            {
                membershipEntity.Name = membershipEditVM.Name;
                membershipEntity.MembershipType = membershipEditVM.MembershipType;
                membershipEntity.Description = membershipEditVM.Description;
                membershipEntity.Price = membershipEditVM.Price;
                membershipEntity.Duration = membershipEditVM.Duration;

                isEdited = await this.membershipRepo
                                        .UpdateAsync(membershipEntity);
            }

            return isEdited;
        }

        public async Task<IEnumerable<MembershipDeleteViewModel>> GetAllMembershipForDeletingAsync()
        {
            IEnumerable<MembershipDeleteViewModel> listMembershipsDeleteVM = await this.membershipRepo
                                                    .GetAllAttached()
                                                    .AsNoTracking()
                                                    .IgnoreQueryFilters()
                                                    .Select(e => new MembershipDeleteViewModel()
                                                    {
                                                       Id = e.Id.ToString(),
                                                        Name = e.Name,
                                                        MembershipType = e.MembershipType,
                                                        IsDeleted = e.IsDeleted
                                                    })
                                                    .ToListAsync();

            return listMembershipsDeleteVM;
        }

        public async Task<(bool, bool)> DeleteOrRestoreMembershipAsync(string? id)
        {
            bool result = false;
            bool isRestored = false;

            if (!String.IsNullOrWhiteSpace(id))
            {
                Membership? membershipEntity = await this.membershipRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToLower());

                if (membershipEntity != null)
                {
                    if (!membershipEntity.IsDeleted)
                    {
                        isRestored = true;
                    }

                    membershipEntity.IsDeleted = !membershipEntity.IsDeleted;

                    result = await this.membershipRepo
                                    .UpdateAsync(membershipEntity);
                }
            }

            return (result, isRestored);
        }
    }
}
