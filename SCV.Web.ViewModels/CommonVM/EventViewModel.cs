namespace SCV.Web.ViewModels.CommonVM
{
    using SCV.GlCommon.Enums;

    public class EventViewModel
    {
        public string Title { get; set; } = null!;

        public SportType EventType { get; set; }

        public string? Description { get; set; }

        public string StartDate { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
