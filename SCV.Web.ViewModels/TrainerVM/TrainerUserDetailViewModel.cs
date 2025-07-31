namespace SCV.Web.ViewModels.TrainerVM
{
    using SCV.GlCommon.Enums;

    public class TrainerUserDetailViewModel
    {
        public string TrainerId { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public SportType TrainerSpecialty { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsAddedToFavorite { get; set; }
    }
}
