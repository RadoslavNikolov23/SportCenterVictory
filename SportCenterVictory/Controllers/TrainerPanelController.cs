namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Services.Core.TrainerServices.Contracts;
    using SCV.Web.ViewModels.TrainerVM;

    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.RoleConstants;

    public class TrainerPanelController : BaseController<TrainerPanelController>
    {
        private readonly ITrainerUserService trainerUserService;

        public TrainerPanelController(ITrainerUserService trainerUserService, ILogger<TrainerPanelController> logger) : base(logger)
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
                    return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
                }

                IEnumerable<TrainerClientListViewModel> clientsTrainerList = await this.trainerUserService
                    .AllClientsTrainerListAsync(userId);

                return View(clientsTrainerList);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while trying to load all the Clients for a Trainer with user Id: {this.GetUserId()}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }
    }
}
