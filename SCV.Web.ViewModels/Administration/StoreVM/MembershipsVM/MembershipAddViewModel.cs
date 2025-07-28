namespace SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM
{
    using SCV.GlCommon.Enums;
    using System.ComponentModel.DataAnnotations;

    using static SCV.GlCommon.ModelConstants.EntityConstantsMembership;
    using static SCV.GlCommon.ValidationMessages.Membership;

    public class MembershipAddViewModel
    {
        [Required(ErrorMessage = NameRequired)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = NameRequired)]

        public SportType MembershipType { get; set; }

        [Required(ErrorMessage = DescriptionRequired)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = PriceRequired)]
        [Range((double)PriceMinValue, (double)PriceMaxValue, ErrorMessage = PriceRange)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = DurationRequired)]
        [StringLength(DurationMaxLength, MinimumLength = DurationMinLength, ErrorMessage = DurationLength)]
        public string Duration { get; set; } = null!;
    }
}
