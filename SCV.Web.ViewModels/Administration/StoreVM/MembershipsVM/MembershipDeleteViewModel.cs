namespace SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM
{
    using SCV.GlCommon.Enums;

    public class MembershipDeleteViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public SportType MembershipType { get; set; }

        public bool IsDeleted { get; set; }
    }
}
