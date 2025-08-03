namespace SCV.Web.ViewModels.Administration.FitnessVM
{
    using System.ComponentModel.DataAnnotations;

    using SCV.GlCommon.Enums;

    using static SCV.GlCommon.ModelConstants.EntityConstantsWorkoutPlan;
    using static SCV.GlCommon.ValidationMessages.WorkoutPlan;

    public class WorkoutPlanAddViewModel
    {
        [Required(ErrorMessage = TitleLengthRequired)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TitleLength)]
        public string Title { get; set; } = null!;


        [Required(ErrorMessage = DescriptionRequired)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = TypeRequired)]
        public SportType Type { get; set; }


        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = ImageUrlInvalid)]
        [Url(ErrorMessage = ImageUrlInvalid)]
        public string? ImageUrl { get; set; }
    }
}
