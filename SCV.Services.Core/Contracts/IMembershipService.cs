namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.CommonVM;

    public interface IMembershipService
    {
        public Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipPerSport(SportType MembershipType);

        public Task<IEnumerable<MembershipsTrainerViewModel>> GetAllMembershipForTrainer(Guid trainerId);
    }
}
