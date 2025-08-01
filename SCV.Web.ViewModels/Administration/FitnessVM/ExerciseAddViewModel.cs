namespace SCV.Web.ViewModels.Administration.FitnessVM
{
    using System.ComponentModel.DataAnnotations;
    using static SCV.GlCommon.ModelConstants.EntityConstantsExercise;
    using static SCV.GlCommon.ValidationMessages.Exercise;

    public class ExerciseAddViewModel
    {

        // [Required(ErrorMessage = IdRequired)]
        // [StringLength(IdLength, MinimumLength = IdMinLength, ErrorMessage = IdLength)]
        // public string Id { get; set; } = null!;

        [Required(ErrorMessage = NameRequired)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLength)]
        public string Name { get; set; } = null!;

        [StringLength(ForceMaxLength, MinimumLength = ForceMinLength, ErrorMessage = ForceLength)]
        public string? Force { get; set; }

        [StringLength(MechanicMaxLength, MinimumLength = MechanicMinLength, ErrorMessage = MechanicLength)]
        public string? Mechanic { get; set; }

        [StringLength(EquipmentMaxLength, MinimumLength = EquipmentMinLength, ErrorMessage = EquipmentLength)]
        public string? Equipment { get; set; }

        [Required(ErrorMessage = PrimaryMuscleRequired)]
        [StringLength(PrimaryMusclesMaxLength, MinimumLength = PrimaryMusclesMinLength, ErrorMessage = PrimaryMuscleLength)]
        public string PrimaryMuscles { get; set; } = null!;

        [StringLength(SecondaryMusclesMaxLength, MinimumLength = SecondaryMusclesMinLength, ErrorMessage = SecondaryMuscleLength)]
        public string? SecondaryMuscles { get; set; }

        [StringLength(InstructionsMaxLength, MinimumLength = InstructionsMinLength, ErrorMessage = InstructionLength)]
        public string? Instructions { get; set; }

        [Required(ErrorMessage = CategoryRequired)]
        [StringLength(CategoryMaxLength, MinimumLength = CategoryMinLength, ErrorMessage = CategoryRequired)]
        public string Category { get; set; } = null!;


        [StringLength(ImageUrlOneMaxLength, MinimumLength = ImageUrlOneMinLength, ErrorMessage = ImageUrlOneInvalid)]
        [Url(ErrorMessage = ImageUrlOneInvalid)]
        public string? ImageUrlOne { get; set; }


        [StringLength(ImageUrlTwoMaxLength, MinimumLength = ImageUrlTwoMinLength, ErrorMessage = ImageUrlTwoInvalid)]
        [Url(ErrorMessage = ImageUrlTwoInvalid)]
        public string? ImageUrlTwo { get; set; }
    }
}
