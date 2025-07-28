namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.Administration.EventVM;
    using SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM;
    using SCV.Web.ViewModels.CommonVM;

    public interface IMembershipService
    {
        Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipAsync();

        Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipPerSportAsync(SportType membershipType);

        Task<ICollection<MembershipsTrainerViewModel>> GetAllMembershipForTrainerAsync(string trainerId);

        Task<bool> AddMembershipAsync(MembershipAddViewModel membershipAddVM);

        Task<MembershipEditViewModel?> GetMembershipByIdAsync(string? id);

        Task<bool> EditMembershipAsync(MembershipEditViewModel membershipEditVM);

        Task<IEnumerable<MembershipDeleteViewModel>> GetAllMembershipForDeletingAsync();

        Task<(bool, bool)> DeleteOrRestoreMembershipAsync(string? id);
    }
}
