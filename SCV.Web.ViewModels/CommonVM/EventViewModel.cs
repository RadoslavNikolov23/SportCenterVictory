namespace SCV.Web.ViewModels.CommonVM
{
    using SCV.GlCommon.Enums;

    public class EventViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public SportType EventType { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public string Location { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
