namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.FitnessVM;

    public interface IMembershipService
    {
        public Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipPerSport(SportType MembershipType);
    }
}
