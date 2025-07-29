namespace SCV.Web.ViewModels.CommonVM
{
    using SCV.GlCommon.Enums;
    public class CrossfitClassUserDetailViewModel
    {
        public string CrossfitClassId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string StartTime { get; set; } = null!;

        public DayOfWeek DayOfWeek { get; set; }

        public string TrainerName { get; set; } = null!;
    }
}
