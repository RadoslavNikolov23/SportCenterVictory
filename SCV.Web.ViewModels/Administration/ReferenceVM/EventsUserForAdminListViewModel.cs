namespace SCV.Web.ViewModels.Administration.ReferenceVM
{
    using SCV.GlCommon.Enums;

    public class EventsUserForAdminListViewModel
    {
        public string ClientEmail { get; set; } = null!;

        public string ClientFullName { get; set; } = null!;

        public string EventTitle { get; set; } = null!;

        public string EventStartDate { get; set; } = null!;

        public string EventLocation { get; set; } = null!;

        public SportType EventType { get; set; }



    }
}
