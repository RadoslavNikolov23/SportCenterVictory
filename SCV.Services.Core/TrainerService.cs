namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;

    public class TrainerService:ITrainerService
    {
        private readonly ITrainerRepository trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            this.trainerRepository = trainerRepository;
        }

        public async Task<IEnumerable<TrainerViewModel>> GetAllTrainerBySpecialties(SportType TrainerSpecialty)
        {
            IEnumerable<TrainerViewModel> trainerVM = await this.trainerRepository
                                        .GetAllAttached()
                                        .Include(tp => tp.Memberships)
                                        .AsNoTracking()
                                        .Select(tp => new TrainerViewModel()
                                        {
                                            Id = tp.Id,
                                            FirstName = tp.FirstName,
                                            LastName = tp.LastName,
                                            Email = tp.Email,
                                            PhoneNumber = tp.PhoneNumber ?? "n/a",
                                            Bio = tp.Bio,
                                            ImageUrl = tp.ImageUrl ?? $"/noImage.jpg",

                                        })
                                        .ToListAsync();

            return trainerVM;

        }
    }
}
