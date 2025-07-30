namespace SCV.Web.ViewModels.CommonVM
{
    using SCV.GlCommon.Enums;

    public class EventUserDetailViewModel
    {
        public string EventId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public SportType EventType { get; set; }

        public string StartDate { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsUserJoined { get; set; }
    }
}
