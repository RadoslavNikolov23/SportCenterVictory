namespace SCV.Web.ViewModels.CrossfitVM
{
    public class CrossfitClassDetailViewModel
    {
        public string CrossfitClassId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string StartTime { get; set; } = null!;

        public DayOfWeek DayOfWeek { get; set; }

        public string TrainerName { get; set; } = null!;

        public bool IsUserJoined { get; set; }
    }
}
