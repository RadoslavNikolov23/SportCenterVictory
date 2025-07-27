namespace SCV.Web.ViewModels.Administration.EventVM
{
    public class EventAdminDetailViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
