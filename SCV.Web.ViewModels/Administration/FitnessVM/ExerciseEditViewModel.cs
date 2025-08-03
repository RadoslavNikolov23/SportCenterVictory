namespace SCV.Web.ViewModels.Administration.FitnessVM
{
    using System.ComponentModel.DataAnnotations;

    using static SCV.GlCommon.ModelConstants.EntityConstantsExercise;
    using static SCV.GlCommon.ValidationMessages.Exercise;

    public class ExerciseEditViewModel : ExerciseAddViewModel
    {

        [Required(ErrorMessage = IdRequired)]
        [StringLength(IdMaxLength, MinimumLength = IdMinLength, ErrorMessage = IdLength)]
        public string Id { get; set; } = null!;

    }
}
