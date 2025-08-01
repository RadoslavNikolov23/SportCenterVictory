namespace SCV.Web.ViewModels.Administration.UserManagementVM
{
    using System.ComponentModel.DataAnnotations;

    public class RoleSelectionInputViewModel
    {
        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!;
    }
}
