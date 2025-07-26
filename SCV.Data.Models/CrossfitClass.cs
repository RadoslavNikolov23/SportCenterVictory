namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("CrossFit Class Model")]
    public class CrossfitClass
    {
        [Comment("CrossFit Class Id")]
        public Guid Id { get; set; }

        [Comment("CrossFit Class Name")]
        public string Name { get; set; } = null!;

        [Comment("CrossFit Class Description for details")]
        public string Description { get; set; } = null!;

        [Comment("CrossFit Class starting date and time - a string, because it will say in which day of the week will there be classes, ex. Monday 17:00")]
        public string StartTime { get; set; } = null!;

        [Comment("CrossFit Class day of the week, for ordering purpose.")]
        public DayOfWeek DayOfWeek { get; set; }

        [Comment("CrossFit Class Trainer name - can be a Trainer in the Sport Center or a guest Trainer")]
        public string TrainerName { get; set; } = null!;

        [Comment("Indicates if the class is active or not")]
        public bool IsActive { get; set; }
        
        [Comment("Collection of participants in the class")]
        public virtual ICollection<CrossfitClassUser> CrossfitClassUsers { get; set; } = new HashSet<CrossfitClassUser>();

    }
}
