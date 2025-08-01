namespace SCV.Web.ViewModels.ContactVM
{
    using System.ComponentModel.DataAnnotations;

    public class ContactFormViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; } = null!;
    }
}
