namespace SportCenterVictory.Areas.Identity.Pages.Account.Manage
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    using System.ComponentModel.DataAnnotations;

    using SCV.Data.Models;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }


        [TempData]
        public string StatusMessage { get; set; } = string.Empty;

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Phone]
            [Display(Name = "Full Name")]
            public string FullName { get; set; } = string.Empty;
        }

        //private async Task LoadAsync(ApplicationUser user)
        //{
        //    var userName = await _userManager.GetUserNameAsync(user);
        //    var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

        //    Username = userName;

        //    Input = new InputModel
        //    {
        //        PhoneNumber = phoneNumber
        //    };
        //}

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            Input = new InputModel
            {
                FullName = user.FullName
            };
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            user.FullName = Input.FullName;

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated.";

            return RedirectToPage();
        }
    }
}
