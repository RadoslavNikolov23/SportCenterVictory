namespace SCV.Services.Core.CrossfitServices
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.CrossfitServices.Contracts;
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
            IEnumerable<CrossfitClassDetailViewModel> crossfitClassDetailVM = await crossfitClassRepo
                                            .GetAllAttached()
                                            .AsNoTracking()
                                            .OrderBy(cc => cc.DayOfWeek)
                                            .Select(cc => new CrossfitClassDetailViewModel()
                                            {
                                                CrossfitClassId = cc.Id.ToString(),
                                                Name = cc.Name,
                                                Description = cc.Description,
                                                StartTime = cc.StartTime,
                                                TrainerName = cc.TrainerName,
                                            })
                                            .ToListAsync();

            return crossfitClassDetailVM;
        }

        public async Task<IEnumerable<CrossfitClassAdminDetailViewModel>> GetAllCrossfitClassesForAdminAsync()
        {
            IEnumerable<CrossfitClassAdminDetailViewModel> crossfitClassAdminDetailVM = 
                                await crossfitClassRepo
                                                .GetAllAttached()
                                                .AsNoTracking()
                                                .Select(cc => new CrossfitClassAdminDetailViewModel()
                                                {
                                                    Id = cc.Id.ToString(),
                                                    Name = cc.Name,
                                                })
                                                .ToListAsync();

            return crossfitClassAdminDetailVM;
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

                await crossfitClassRepo.AddAsync(crossfitClass);
                isAdded = true;
            }

            return isAdded;

        }

        public async Task<CrossfitClassEditViewModel?> GetCrossfitClassByIdAsync(string? id)
        {
            CrossfitClassEditViewModel? crossfitClassEditVM = null;

            if (!string.IsNullOrEmpty(id))
            {
                CrossfitClass? crossfitClassEntity = await crossfitClassRepo
                                    .GetAllAttached()
                                    .SingleOrDefaultAsync(cc => cc.Id.ToString().ToLower() == id.ToLower());
                
                if (crossfitClassEntity != null)
                {
                    crossfitClassEditVM = new CrossfitClassEditViewModel()
                    {
                        Id = crossfitClassEntity.Id.ToString(),
                        Name = crossfitClassEntity.Name,
                        Description = crossfitClassEntity.Description,
                        StartTime = crossfitClassEntity.StartTime,
                        DayOfWeek = crossfitClassEntity.DayOfWeek,
                        TrainerName = crossfitClassEntity.TrainerName
                    };
                }
            }

            return crossfitClassEditVM;
        }

        public async Task<bool> EditCrossfitClassAsync(CrossfitClassEditViewModel crossfitClassEditVM)
        {
            bool isEdited = false;

            if (crossfitClassEditVM == null)
            {
                return isEdited;
            }

            CrossfitClass? crossfitClass = await crossfitClassRepo
                                        .GetAllAttached()
                                        .FirstOrDefaultAsync(cc => cc.Id.ToString().ToLower() == crossfitClassEditVM.Id.ToLower());

            if (crossfitClass != null)
            {
                crossfitClass.Name = crossfitClassEditVM.Name;
                crossfitClass.Description = crossfitClassEditVM.Description;
                crossfitClass.StartTime = crossfitClassEditVM.StartTime;
                crossfitClass.DayOfWeek = crossfitClassEditVM.DayOfWeek;
                crossfitClass.TrainerName = crossfitClassEditVM.TrainerName;

                isEdited = await crossfitClassRepo
                                        .UpdateAsync(crossfitClass);
            }

            return isEdited;
        }

        public async Task<IEnumerable<CrossfitClassDeleteVIewModel>> GetAllCrossfitClassesForDeletingAsync()
        {
            IEnumerable<CrossfitClassDeleteVIewModel> crossfitClassAdminDetailVM =
                                await crossfitClassRepo
                                                .GetAllAttached()
                                                .AsNoTracking()
                                                .IgnoreQueryFilters()
                                                .Select(cc => new CrossfitClassDeleteVIewModel()
                                                {
                                                    Id = cc.Id.ToString(),
                                                    Name = cc.Name,
                                                    IsActive = cc.IsActive
                                                })
                                                .ToListAsync();

            return crossfitClassAdminDetailVM;
        }

        public async Task<(bool, bool)> DeleteOrRestoreCrossfitClassAsync(string? id)
        {
            bool result = false;
            bool isRestored = false;

            if (!string.IsNullOrWhiteSpace(id))
            {
                CrossfitClass? crossfitClass = await crossfitClassRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToLower());
                
                if (crossfitClass != null)
                {
                    if (!crossfitClass.IsActive)
                    {
                        isRestored = true;
                    }

                    crossfitClass.IsActive = !crossfitClass.IsActive;

                    result = await crossfitClassRepo
                                    .UpdateAsync(crossfitClass);
                }
            }

            return (result, isRestored);

        }
    }
}
