namespace SCV.Web.ViewModels.Administration.ReferenceVM
{
    using SCV.GlCommon.Enums;
    public class UserCrossfitClassesForAdminListViewModel
    {
        public string CrossfitClassName { get; set; } = null!;

        public string CrossfitClassTrainerName { get; set; } = null!;

        public string ClientEmail { get; set; } = null!;

        public string ClientFullName { get; set; } = null!;

        public DayOfWeek DayOfWeek { get; set; }

    }
}
