namespace SVC.Data.Models
{
    public class CrossfitClass
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime StartTime { get; set; }

        //Can be a Trainer in the Sport Center or a guest Trainer
        public string TrainerName { get; set; } = null!;

        public bool IsActive { get; set; } = true;
        
        // Collection of participants in the class
        public ICollection<CrossfitClassUser> Participants { get; set; } = new HashSet<CrossfitClassUser>();

    }
}
