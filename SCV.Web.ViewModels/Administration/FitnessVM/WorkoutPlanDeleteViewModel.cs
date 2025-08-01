namespace SCV.Web.ViewModels.Administration.FitnessVM
{
    using SCV.GlCommon.Enums;

    public class WorkoutPlanDeleteViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public SportType Type { get; set; }

        public bool IsDeleted { get; set; }
    }
}
