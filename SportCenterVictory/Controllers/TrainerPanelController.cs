namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SCV.Services.Core.TrainerServices.Contracts;
    using SCV.Web.ViewModels.TrainerVM;

    using static SCV.GlCommon.RoleConstants;

    public class TrainerPanelController : BaseController
    {
        private readonly ITrainerUserService trainerUserService;

        public TrainerPanelController(ITrainerUserService trainerUserService)
        {
            this.trainerUserService = trainerUserService;
        }

        [HttpGet]
        [Authorize(Roles = Trainer)]
        public async Task<IActionResult> UserClientList()
        {
            try
            {
                string? userId = this.GetUserId();

                if (userId == null)
                {
                    return this.Forbid();
                }

                IEnumerable<TrainerClientListViewModel> clientsTrainerList = await this.trainerUserService
                    .AllClientsTrainerListAsync(userId);

                return View(clientsTrainerList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
