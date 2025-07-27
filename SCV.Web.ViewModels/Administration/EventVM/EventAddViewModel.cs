namespace SCV.Web.ViewModels.Administration.EventVM
{
    using SCV.GlCommon.Enums;
    using System.ComponentModel.DataAnnotations;

    using static SCV.GlCommon.ModelConstants.EntityConstantsEvent;
    using static SCV.GlCommon.ValidationMessages.Event;

    public class EventAddViewModel
    {
        [Required(ErrorMessage =TitleRequired)]
        [StringLength(TitleMaxLength,MinimumLength = TitleMinLength,ErrorMessage = TitleLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = TypeRequired)]
        public SportType EventType { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLength)]
        public string? Description { get; set; }

        [Required(ErrorMessage = StartDateRequired)]

        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = LocationRequired)]
        [StringLength(LocationMaxLength, MinimumLength = LocationMinLength, ErrorMessage = LocationLength)]
        public string Location { get; set; } = null!;

        [Url(ErrorMessage = ImageUrlInvalid)]
        [StringLength(ImageUrlMaxLength, ErrorMessage = ImageUrlInvalid)]
        public string? ImageUrl { get; set; }


    }
}
