namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
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
                        .Select(m => new MembershipDetailViewModel()
                        {
                            Name = m.Name,
                            MembershipTier = m.MembershipTier, //Check if this works if not TryParse it
                            Description = m.Description,
                            Price = m.Price,
                            Duration = m.Duration,
                            TrainerName = m.Trainer==null ? $"{m.Trainer!.FirstName} {m.Trainer.LastName}" : null ,
                        })
                        .ToListAsync();

            return membershipsCollection;

        }

        public async Task<IEnumerable<MembershipsTrainerViewModel>> GetAllMembershipForTrainer(Guid trainerId)
        {
            IEnumerable<MembershipsTrainerViewModel> membershipsTrainerVM = await this.membershipRepo
                                      .GetAllAttached()
                                      .Include(mt => mt.Trainer)
                                      .AsNoTracking()
                                      .Where(mt=>mt.Trainer!.Id==trainerId)
                                      .Select(mt=> new MembershipsTrainerViewModel()
                                      {
                                          Name = mt.Name,
                                          MembershipType = mt.MembershipType, //Check if this works if not TryParse it
                                          MembershipTier = mt.MembershipTier, //Check if this works if not TryParse it
                                      })
                                      .ToListAsync();

            return membershipsTrainerVM;

        }
    }
}
