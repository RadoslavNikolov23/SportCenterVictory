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

        public async Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipPerSport(SportType MembershipType)
        {
            IEnumerable<MembershipDetailViewModel> membershipsCollection = new List<MembershipDetailViewModel>();

            membershipsCollection = await this.membershipRepo
                        .GetAllAttached()
                        .Include(m=>m.Trainer)
                        .AsNoTracking()
                        .Where(m => (int)m.MembershipType == (int)MembershipType)
                        .OrderBy(m=>m.Price)
                        .Select(m => new MembershipDetailViewModel()
                        {
                            Name = m.Name,
                            MembershipType = m.MembershipType,
                            MembershipTier = m.MembershipTier,
                            Description = m.Description,
                            Price = m.Price,
                            Duration = m.Duration,
                            TrainerName = m.Trainer==null ? $"{m.Trainer!.FirstName} {m.Trainer.LastName}" : null ,
                        })
                        .ToListAsync();

            return membershipsCollection;

        }

        public async Task<ICollection<MembershipsTrainerViewModel>> GetAllMembershipForTrainer(Guid trainerId)
        {
            ICollection<MembershipsTrainerViewModel> membershipsTrainerVM = await this.membershipRepo
                                      .GetAllAttached()
                                      .Include(mt => mt.Trainer)
                                      .AsNoTracking()
                                      .Where(mt=>mt.Trainer!.Id==trainerId)
                                      .Select(mt=> new MembershipsTrainerViewModel()
                                      {
                                          Name = mt.Name,
                                          MembershipType = mt.MembershipType,
                                          MembershipTier = mt.MembershipTier,
                                      })
                                      .ToListAsync();

            return membershipsTrainerVM;

        }
    }
}
