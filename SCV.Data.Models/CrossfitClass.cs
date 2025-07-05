namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("CrossFit Class Model")]
    public class CrossfitClass
    {
        [Comment("CrossFit Class Id")]
        public int Id { get; set; }

        [Comment("CrossFit Class Name")]
        public string Name { get; set; } = null!;

        [Comment("CrossFit Class Description for details")]
        public string Description { get; set; } = null!;

        [Comment("CrossFit Class starting date and time")]
        public DateTime StartTime { get; set; }

        [Comment("CrossFit Class Trainer name - can be a Trainer in the Sport Center or a guest Trainer")]
        public string TrainerName { get; set; } = null!;

        [Comment("Indicates if the class is active or not")]
        public bool IsActive { get; set; } = true;
        
        [Comment("Collection of participants in the class")]
        public virtual ICollection<CrossfitClassUser> CrossfitClassUsers { get; set; } = new HashSet<CrossfitClassUser>();

    }
}
