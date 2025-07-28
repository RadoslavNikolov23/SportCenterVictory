namespace SCV.Web.ViewModels.Administration.TrainerBioVM
{
    using SCV.GlCommon.Enums;

    public class TrainerBioDeleteViewModel
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public SportType TrainerSpecialty { get; set; }

        public bool IsDeleted { get; set; }
    }
}
