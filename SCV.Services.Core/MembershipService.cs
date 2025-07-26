namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.GlCommon.Enums;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
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
                                    .Include(m => m.Trainer)
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
                                        TrainerName = m.Trainer == null ? $"{m.Trainer!.FirstName} {m.Trainer.LastName}" : null,
                                    })
                                    .ToListAsync();

            return allMembershipsViewModels;

        }

        public async Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipPerSportAsync(SportType membershipType)
        {
            IEnumerable<MembershipDetailViewModel> membershipsCollection = new List<MembershipDetailViewModel>();

            membershipsCollection = await this.membershipRepo
                        .GetAllAttached()
                        .Include(m => m.Trainer)
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
                            TrainerName = m.Trainer == null ? $"{m.Trainer!.FirstName} {m.Trainer.LastName}" : null,
                        })
                        .ToListAsync();

            return membershipsCollection;

        }

        public async Task<ICollection<MembershipsTrainerViewModel>> GetAllMembershipForTrainerAsync(string trainerId)
        {
            ICollection<MembershipsTrainerViewModel> membershipsTrainerVM = await this.membershipRepo
                                      .GetAllAttached()
                                      .Include(mt => mt.Trainer)
                                      .AsNoTracking()
                                      .Where(mt => mt.Trainer!.Id.ToString().ToLower() == trainerId.ToString().ToLower())
                                      .Select(mt => new MembershipsTrainerViewModel()
                                      {
                                          Name = mt.Name,
                                          MembershipType = mt.MembershipType,
                                      })
                                      .ToListAsync();

            return membershipsTrainerVM;

        }
    }
}
