namespace SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM
{
    using SCV.GlCommon.Enums;

    public class MembershipDeleteViewModel : BaseMembershipViewModel
    {
        public SportType MembershipType { get; set; }

        public bool IsDeleted { get; set; }
    }
}
