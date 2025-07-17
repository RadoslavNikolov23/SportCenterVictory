namespace SCV.Services.Core
{
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;

    public class TrainerService:ITrainerService
    {
        private readonly ITrainerRepository trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            this.trainerRepository = trainerRepository;
        }
    }
}
