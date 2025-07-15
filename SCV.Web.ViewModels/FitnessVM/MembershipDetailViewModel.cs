namespace SCV.Web.ViewModels.FitnessVM
{
    using SCV.GlCommon.Enums;

    public class MembershipDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public SportType MembershipType { get; set; }

        public MembershipTier MembershipTier { get; set; }

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string Duration { get; set; } = null!;

        public string? TrainerName { get; set; }
    }
}
