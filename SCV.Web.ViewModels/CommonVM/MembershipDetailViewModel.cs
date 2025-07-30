namespace SCV.Web.ViewModels.CommonVM
{
    using SCV.GlCommon.Enums;

    public class MembershipDetailViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public SportType MembershipType { get; set; }

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string Duration { get; set; } = null!;

        public bool IsPurchasedMembership { get; set; }
    }
}
