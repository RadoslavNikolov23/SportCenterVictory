namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;

    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository trainerRepo;

        public TrainerService(ITrainerRepository trainerRepo)
        {
            this.trainerRepo = trainerRepo;
        }

        public async Task<IEnumerable<TrainerDetailViewModel>> GetAllTrainerBySpecialties(SportType trainerSpecialty)
        {
            IEnumerable<TrainerDetailViewModel> trainerVM = await this.trainerRepo
                                        .GetAllAttached()
                                        .Include(tp => tp.Memberships)
                                        .AsNoTracking()
                                        .Where(tp=>tp.TrainerSpecialty == trainerSpecialty)
                                        .Select(tp => new TrainerDetailViewModel()
                                        {
                                            Id = tp.Id,
                                            FirstName = tp.FirstName,
                                            LastName = tp.LastName,
                                            Email = tp.Email,
                                            PhoneNumber = tp.PhoneNumber ?? "n/a",
                                            Bio = tp.Bio,
                                            TrainerSpecialty = tp.TrainerSpecialty,
                      //----------- ! Remove the "/" when reseed the DB ---- !!!
                                            ImageUrl = $"/{tp.ImageUrl}" ?? $"/noImage.jpg",

                                        })
                                        .ToListAsync();

            return trainerVM;

        }
    }
}
