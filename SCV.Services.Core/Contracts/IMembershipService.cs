namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.CommonVM;

    public interface IMembershipService
    {
        Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipAsync();

        Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipPerSportAsync(SportType membershipType);

        Task<ICollection<MembershipsTrainerViewModel>> GetAllMembershipForTrainerAsync(Guid trainerId);
    }
}
