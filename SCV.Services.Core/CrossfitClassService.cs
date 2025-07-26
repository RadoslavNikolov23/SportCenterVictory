namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.CrossfitClassesVM;
    using SCV.Web.ViewModels.CrossfitVM;

    public class CrossfitClassService : ICrossfitClassService
    {
        private readonly ICrossfitClassRepository crossfitClassRepo;

        public CrossfitClassService(ICrossfitClassRepository crossfitClassRepo)
        {
            this.crossfitClassRepo = crossfitClassRepo;
        }

        public async Task<IEnumerable<CrossfitClassDetailViewModel>> GetAllCrossfitClassesAsync()
        {
            IEnumerable<CrossfitClassDetailViewModel> crossfitClassDetailVM = await this.crossfitClassRepo
                                            .GetAllAttached()
                                            .AsNoTracking()
                                            .OrderBy(cc=>(int)cc.DayOfWeek)
                                            .Select(cc => new CrossfitClassDetailViewModel()
                                            {
                                                Name = cc.Name,
                                                Description = cc.Description,
                                                StartTime = cc.StartTime,
                                                TrainerName = cc.TrainerName,
                                            })
                                            .ToListAsync();

            return crossfitClassDetailVM;
        }

        public async Task<bool> AddCrossfitClassAsync(CrossfitClassAddViewModel crossfitClassAddVM)
        {
            bool isAdded = false;

            if (crossfitClassAddVM != null)
            {
                CrossfitClass crossfitClass = new CrossfitClass()
                {
                    Name = crossfitClassAddVM.Name,
                    Description = crossfitClassAddVM.Description,
                    StartTime = crossfitClassAddVM.StartTime,
                    DayOfWeek = crossfitClassAddVM.DayOfWeek,
                    TrainerName = crossfitClassAddVM.TrainerName,
                    IsActive = true
                };

                await this.crossfitClassRepo.AddAsync(crossfitClass);
                isAdded = true;
            }

            return isAdded;

        }
    }
}
