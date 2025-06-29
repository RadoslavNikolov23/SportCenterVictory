namespace SVC.Data.Models
{
    public class Exercise
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Force { get; set; }

        public string? Mechanic { get; set; }

        public string? Equipment { get; set; }

        public string PrimaryMuscles { get; set; } = null!;

        public string? SecondaryMuscles { get; set; }

        public string? Instructions { get; set; }

        public string Category { get; set; } = null!;

        public string? ImageUrlOne { get; set; }

        public string? ImageUrlTwo { get; set; }

        public bool IsDeleted { get; set; }
    }
}
