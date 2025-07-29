namespace SCV.Web.ViewModels.CommonVM
{
    using SCV.GlCommon.Enums;

    public class MembershipUserDetailViewModel
    {
        public string MembershipId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public SportType MembershipType { get; set; }

        public string Duration { get; set; } = null!;

    }
}
