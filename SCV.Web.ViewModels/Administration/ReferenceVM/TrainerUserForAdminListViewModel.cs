namespace SCV.Web.ViewModels.Administration.ReferenceVM
{
    using System.ComponentModel.DataAnnotations;

    using SCV.GlCommon.Enums;

    public class TrainerUserForAdminListViewModel
    {
        public string ClientEmail { get; set; } = null!;

        public string ClientFullName { get; set; } = null!;

        public string TrainerFullName { get; set; } = null!;

        [EmailAddress]
        public string TrainerEmail { get; set; } = null!;

        public SportType TrainerSpecialty { get; set; }

    }
}
