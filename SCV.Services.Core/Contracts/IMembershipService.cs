namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.CommonVM;

    public interface IMembershipService
    {
        public Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipPerSportAsync(SportType MembershipType);

        public Task<ICollection<MembershipsTrainerViewModel>> GetAllMembershipForTrainerAsync(Guid trainerId);
    }
}
