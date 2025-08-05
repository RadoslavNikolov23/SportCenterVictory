namespace SCV.Services.Core.StoreServices.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM;
    using SCV.Web.ViewModels.CommonVM;

    public interface IMembershipService
    {
        Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipAsync();

        Task<IEnumerable<MembershipDetailViewModel>> GetAllMembershipPerSportAsync(SportType membershipType);

        Task<IEnumerable<MembershipAdminDetailViewModel>> GetAllMembershipsForAdminAsync();

        Task<bool> AddMembershipAsync(MembershipAddViewModel membershipAddVM);

        Task<MembershipEditViewModel?> GetMembershipByIdAsync(string? id);

        Task<bool> EditMembershipAsync(MembershipEditViewModel membershipEditVM);

        Task<IEnumerable<MembershipDeleteViewModel>> GetAllMembershipForDeletingAsync();

        Task<(bool, bool)> DeleteOrRestoreMembershipAsync(string? id);
    }
}
