namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Represents an exercise in the database for the web app.")]
    public class Exercise
    {
        [Comment("Unique identifier for the exercise - the name in snake case will be the Id.")]
        public string Id { get; set; } = null!;

        [Comment("Name of the exercise")]
        public string Name { get; set; } = null!;

        [Comment("Type of force applied in the exercise - push, pull, etc.")]
        public string? Force { get; set; }

        [Comment("Mechanic of the exercise - compound, isolation, etc.")]
        public string? Mechanic { get; set; }

        [Comment("Equipment used for the exercise - barbell, dumbbell, bodyweight, etc.")]
        public string? Equipment { get; set; }

        [Comment("Primary muscles targeted by the exercise.")]
        public string PrimaryMuscles { get; set; } = null!;

        [Comment("Secondary muscles targeted by the exercise, if any.")]
        public string? SecondaryMuscles { get; set; }

        [Comment("Instructions on how to perform the exercise.")]
        public string? Instructions { get; set; }

        [Comment("Category of the exercise - strength, cardio, flexibility, etc.")]
        public string Category { get; set; } = null!;

        [Comment("URL of the first image representing the exercise, if available..")]
        public string? ImageUrlOne { get; set; }

        [Comment("URL of the second image representing the exercise, if available.")]
        public string? ImageUrlTwo { get; set; }

        [Comment("Indicates whether the exercise is deleted or not - soft deletion.")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<WorkoutPlanExercise> WorkoutPlanExercises { get; set; } = new HashSet<WorkoutPlanExercise>();
    }
}
