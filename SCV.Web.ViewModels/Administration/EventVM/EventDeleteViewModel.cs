namespace SCV.Web.ViewModels.Administration.EventVM
{
    using SCV.GlCommon.Enums;

    public class EventDeleteViewModel : BaseEventViewModel
    {
        public SportType EventType { get; set; }

        public bool IsDeleted { get; set; }
    }
}
