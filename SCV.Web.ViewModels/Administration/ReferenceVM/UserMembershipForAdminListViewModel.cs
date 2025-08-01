namespace SCV.Web.ViewModels.Administration.ReferenceVM
{
    using SCV.GlCommon.Enums;

    public class UserMembershipForAdminListViewModel
    {
        public string MembershipName { get; set; } = null!;

        public SportType MembershipType { get; set; }

        public string ClientUserName { get; set; } = null!;

        public string ClientFullName { get; set; } = null!;


    }
}
