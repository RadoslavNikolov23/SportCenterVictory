namespace SCV.Web.ViewModels.Administration.CrossfitClassesVM
{
    using System.ComponentModel.DataAnnotations;

    using SCV.GlCommon.Enums;

    using static SCV.GlCommon.ModelConstants.EntityConstantsCrossfit.CrossfitClassConstraints;
    using static SCV.GlCommon.ValidationMessages.CrossfitClass;

    public class CrossfitClassAddViewModel
    {
        [Required(ErrorMessage = NameRequired)]
        [StringLength(ClassNameMaxLength, MinimumLength = ClassNameMinLength, ErrorMessage = NameLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = DescriptionRequired)]
        [StringLength(ClassDescriptionMaxLength, MinimumLength = ClassDescriptionMinLength, ErrorMessage = DescriptionLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = StartTimeRequired)]
        [StringLength(ClassStartTimeMaxLength, MinimumLength = ClassStartTimeMinLength, ErrorMessage = StartTimeLength)]
        public string StartTime { get; set; } = null!;

        [Required(ErrorMessage = DayOfWeekRequired)]
        public DayOfWeek DayOfWeek { get; set; }

        [Required(ErrorMessage = TrainerNameRequired)]
        [StringLength(TrainerNameMaxLength, MinimumLength = TrainerNameMinLength, ErrorMessage = TrainerNameLength)]
        public string TrainerName { get; set; } = null!;

    }
}
